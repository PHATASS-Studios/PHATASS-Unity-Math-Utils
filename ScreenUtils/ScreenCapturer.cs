using Debug = UnityEngine.Debug;
using Screen = UnityEngine.Screen;

using IEnumerator = System.Collections.IEnumerator;

using WaitForEndOfFrame = UnityEngine.WaitForEndOfFrame;

using Vector2 = UnityEngine.Vector2;
using Rect = UnityEngine.Rect;
using RenderTexture = UnityEngine.RenderTexture;
using Texture2D = UnityEngine.Texture2D;
using Color = UnityEngine.Color;

using AsyncGPUReadback = UnityEngine.Rendering.AsyncGPUReadback;
using AsyncGPUReadbackRequest = UnityEngine.Rendering.AsyncGPUReadbackRequest;

namespace PHATASS.Utils.ScreenUtils
{
	public static class ScreenCapturer
	{
		// Asynchronously fetches a rendered frame off of the GPU
		//	Must be invoked through MonoBehaviour.StartCoroutine(), as it needs to yield until WaitForEndOfFrame
		//	takes a callback method that will be invoked passing the frame data
		public delegate void DCaptureScreenCallback (RenderTexture renderTexture);
		public static IEnumerator CaptureScreenAsync (DCaptureScreenCallback callback)
		{
			//we need to wait until the end of the frame to request frame data
			yield return new WaitForEndOfFrame();

			//render texture that will hold the data fetched from the GPI
			RenderTexture renderTexture = new RenderTexture(
				width: Screen.width,
				height: Screen.height,
				depth: 0,
				format: UnityEngine.RenderTextureFormat.ARGB32
			);

			UnityEngine.ScreenCapture.CaptureScreenshotIntoRenderTexture(renderTexture);
			AsyncGPUReadback.Request(
				src: renderTexture,
				mipIndex: 0,
				callback: CaptureScreenAsyncDoneCallback
			);

			//Debug.Log("Started screen capture asynchronous process");

			void CaptureScreenAsyncDoneCallback (AsyncGPUReadbackRequest request)
			{
				if (request.hasError) { Debug.LogError("CaptureScreenAsync: request.hasError is true - Error on fetching screen contents"); }
				else { callback(renderTexture); }
			}
		}

		// Asynchronously find the color of a given screen pixel
		//	Must be invoked through MonoBehaviour.StartCoroutine(), as it needs to yield until WaitForEndOfFrame
		//	takes a callback method that will be invoked passing the color data
		public delegate void DScreenPixelColorCallback (Color color);
		public static IEnumerator GetScreenPixelColorAsync (Vector2 pixelPosition, DScreenPixelColorCallback callback)
		{ return GetScreenPixelColorAsync((int) pixelPosition.x, (int) pixelPosition.y, callback); }
		public static IEnumerator GetScreenPixelColorAsync (int x, int y, DScreenPixelColorCallback callback)
		{
			yield return CaptureScreenAsync(GetScreenPixelColorAsyncDoneCallback);

			void GetScreenPixelColorAsyncDoneCallback (RenderTexture renderTexture)
			{
				RenderTexture activeRT = RenderTexture.active;
				RenderTexture.active = renderTexture;

				// create an empty Texture2d and import captured screen data into it
				Texture2D texture2d = new Texture2D(
					width: renderTexture.width,
					height: renderTexture.height//,
					//textureFormat: UnityEngine.TextureFormat.RGBA32
				);
				texture2d.ReadPixels(
					source: new Rect(0, 0, renderTexture.width, renderTexture.height),
					destX: 0,
					destY: 0,
					recalculateMipMaps: false
				);

				RenderTexture.active = activeRT; // restore previous RenderTexture.active

				//free allocated render texture memory
				renderTexture.Release();
				UnityEngine.Object.Destroy(renderTexture);

				//vertical position depends on platform
				#if UNITY_WEBGL
					int yPosition = y;
				#else
					int yPosition = texture2d.height - y;
				#endif

				//now we can fetch the color at desired position, and pass it to the callback
				callback(texture2d.GetPixel(x, yPosition));
				UnityEngine.Object.Destroy(texture2d);
			}
		}
	}
}
using UnityEngine;

namespace PHATASS.Utils.Extensions
{
// Extension methods for UnityEngine.RenderTexture
	// this file includes methods for RenderTexture type conversion
	public static partial class RenderTextureExtensions
	{
		public static Texture2D EToTexture2D (this RenderTexture renderTexture)
		{
			Texture2D texture2d	= new Texture2D(
				width: renderTexture.width,
				height: renderTexture.height,
				textureFormat: TextureFormat.RGBA32,
				mipCount: -1, //??
				linear: false, //????
				createUninitialized: true
			);

			// ReadPixels looks at the active RenderTexture.
			RenderTexture activeRenderTexture = RenderTexture.active;
			RenderTexture.active = renderTexture;

			texture2d.ReadPixels(new Rect(0,0, renderTexture.width, renderTexture.height), 0, 0);
			texture2d.Apply();

			RenderTexture.active = activeRenderTexture;

			return texture2d;
		}
	}
}
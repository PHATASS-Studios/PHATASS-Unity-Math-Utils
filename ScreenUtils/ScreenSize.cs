using Screen = UnityEngine.Screen;
using Vector2 = UnityEngine.Vector2;

namespace PHATASS.Utils.ScreenUtils
{
	public static class ScreenSize
	{
		//offers an easy to consume Vector2 with the pixel resolution of the screen
		public static Vector2 pixelResolution
		{ get { return new Vector2(x: Screen.width, y: Screen.height); }}

		//converts from an onscreen pixel position into a normalized (0f - 1f) position
		//considers Screen.width & Screen.height
		public static Vector2 PixelToNormalizedScreenPosition (Vector2 pixelPosition)
		{
			return pixelPosition / pixelResolution;
		}
	}
}
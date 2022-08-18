using Debug = UnityEngine.Debug;

using Sprite = UnityEngine.Sprite;
using Vector2 = UnityEngine.Vector2;
using Rect = UnityEngine.Rect;

namespace PHATASS.Utils.Extensions
{
	public static class SpriteExtensions
	{
	//sprite property getters
		//returns the size in pixels of the original sprite
		public static Vector2 EPixelSize (this Sprite sprite)
		{
			Rect rect = sprite.rect;
			return new Vector2 (x: rect.width, y: rect.height);
		}

		//returns the pivot of the sprite in normalized space (x1,y1 top right; x0,y0 bottom left)
		public static Vector2 ENormalizedPivot (this Sprite sprite)
		{
			Rect rect = sprite.rect;
			if (rect.height == 0 || rect.width == 0)
			{
				Debug.Log("ENormalizedPivot() Zero-size sprite");
				return Vector2.zero;
			}
			Vector2 pivot = sprite.pivot;
			return new Vector2 (x: pivot.x/rect.width, y: pivot.y/rect.height);
		}
	//ENDOF sprite property getters
	}
}
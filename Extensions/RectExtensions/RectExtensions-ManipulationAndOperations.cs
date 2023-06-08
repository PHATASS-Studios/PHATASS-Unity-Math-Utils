using UnityEngine;

using static PHATASS.Utils.Extensions.IComparableExtensions;

namespace PHATASS.Utils.Extensions
{
	//methods for Rect manipulation
	public static partial class RectExtensions
	{
	//Rect interpolation and movement
		//moves a rect
		public static Rect EMoveRect (this Rect rect, Vector3 movement)
		{ return RectExtensions.EMoveRect(rect: rect, movement: (Vector2) movement); }
		public static Rect EMoveRect (this Rect rect, Vector2 movement)
		{
			rect.position = rect.position + movement;
			return rect;
		}
		
		//interpolates position and size
		public static Rect ELerpRect (this Rect from, Rect to, float positionLerpRate, float sizeLerpRate)
		{
			return RectExtensions.ERectFromCenterAndSize(
				position: Vector2.Lerp(from.center, to.center, positionLerpRate),
				width: Mathf.Lerp(from.width, to.width, sizeLerpRate),
				height: Mathf.Lerp(from.height, to.height, sizeLerpRate)
			);
		}
	//ENDOF Rect interpolation

	}
}
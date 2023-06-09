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


	//Rect scaling
		//Scales a rect. Pivot is the point of the rectangle that will remain stationary, in local space, while the rest grows/shrinks.
		public static Rect EScale (this Rect rect, float scale, Vector2 pivot = default (Vector2))
		{
			Vector2 offset = (rect.size * (scale - 1f)) * pivot;
			return new Rect(
				x: rect.x - offset.x,
				y: rect.y - offset.y,
				width: rect.width * scale,
				height:	rect.height * scale
			);

		}		

		//Scales a rect to make it snugly fit outside given rect
		//Scaling respects rect aspect ratio and position. At least one dimension will be equal to innerBound's, with the other dimension scaled to fit outside innerBound 
		public static Rect EScaleToFitOutside (this Rect self, Rect innerBound)
		{
			Vector2 boundsToSelfScale = innerBound.size / self.size;	//calculate the bounds-by-size ratio to get necessary scale
			return self.EScale(boundsToSelfScale.EMaximumDimension());	//scale initial rect by the largest dimension of the bounds-by-size ratio to fit outside desired rect
		}
	//ENDOF Rect scaling
	}
}
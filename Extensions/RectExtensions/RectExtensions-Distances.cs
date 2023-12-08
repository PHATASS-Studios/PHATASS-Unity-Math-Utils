using UnityEngine;

using static PHATASS.Utils.Extensions.IComparableExtensions;

namespace PHATASS.Utils.Extensions
{
//Extension methods for UnityEngine.Rect
	public static partial class RectExtensions
	{
	// Distance-calculating extensions for the Rect class
		// Calculates the shortest distance to any point in this Rect. Points within bounds return Vector3.zero
		public static Vector2 EOuterDistance (this Rect rect, Vector2 point)
		{
			float xDistance;
			float yDistance;

			if (point.x > rect.xMax)
			{ xDistance = point.x - rect.xMax; }
			else if (point.x < rect.xMin)
			{ xDistance = point.x - rect.xMin; }
			else
			{ xDistance = 0f; }

			if (point.y > rect.yMax)
			{ yDistance = point.y - rect.yMax; }
			else if (point.y < rect.yMin)
			{ yDistance = point.y - rect.yMin; }
			else
			{ yDistance = 0f; }

			return new Vector2(x: xDistance, y: yDistance);
		}
	//ENDOF Rect clamping and trimming methods
	}
}
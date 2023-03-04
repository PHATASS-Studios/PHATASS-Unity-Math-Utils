using System.Collections.Generic;

using Vector2 = UnityEngine.Vector2;

using IAngle2D = PHATASS.Utils.Types.Angles.IAngle2D;

namespace PHATASS.Utils.Types.Boundaries
{
	public interface IBoundary2D
	{
		//position of the center of the boundaries
		Vector2 center { get; }

		//returns true if point is in or on the boundaries defined
		bool Contains (Vector2 point);

		//returns the closest point to target that is in or on bounds
		Vector2 Clamp (Vector2 point);

		//returns a point between the center (distance 0) and boundaries (distance 1)
		//point is projected in angle direction from bounds center
		Vector2 PointAtAngleFromCenter (float normalizedDistance, IAngle2D angle);

		//transforms a point into a value representing its distance from the center
		//returns 0 for the center point, 1 for any value exactly on the bounds, and >1 for items outside bounds, in proportion to its distance to the center
		float PointToNormalizedDistanceFromCenter (Vector2 point);

		//returns the distance from center to the boundaries in target direction
		float RadiusAtAngleFromCenter (IAngle2D angle);

		//Iterates over points of the boundary. gives exactly totalPoints points, which are meant to be equidistant around the shape
		IEnumerable<Vector2> EnumerateBoundaryPoints (ushort totalPoints);
	}
}
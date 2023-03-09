using System.Collections.Generic;

using UnityEngine;

using Vector2 = UnityEngine.Vector2;

using static PHATASS.Utils.Types.Boundaries.Boundary2DEnumerators;

using IAngle2D = PHATASS.Utils.Types.Angles.IAngle2D;
using static PHATASS.Utils.Types.Angles.IAngle2DExtensions;
using static PHATASS.Utils.Types.Angles.IAngle2DFactory;

using static PHATASS.Utils.Extensions.Vector2Extensions;
using static PHATASS.Utils.Extensions.FloatExtensions;

namespace PHATASS.Utils.Types.Boundaries
{
	//This class calculates an asymetrical ellipsoid boundary
	//each quarter has it's curvature defined by its two neigboring limits
	//Receives and returns values in local space
	[System.Serializable]
	public class OvoidBoundary2D :
		IBoundary2D
	{
	//Serialized fields
		[Tooltip("X Axis upper apex")]
		[SerializeField]
		private float xUpperRadius;

		[Tooltip("X Axis lower apex")]
		[SerializeField]
		private float xLowerRadius;

		[Tooltip("Y Axis upper apex")]
		[SerializeField]
		private float yUpperRadius;

		[Tooltip("Y Axis lower apex")]
		[SerializeField]
		private float yLowerRadius;
	//ENDOF Serialized

	//IBoundary2D
		//position of the center of the boundaries
		Vector2 IBoundary2D.center { get { return this.publicCenter; }}
		protected virtual Vector2 publicCenter { get { return this.center; }}

		//rotation of the  boundaries
		IAngle2D IBoundary2D.rotation { get { return this.publicRotation; }}
		protected virtual IAngle2D publicRotation { get { return 0f.EDegreesToAngle2D(); }}

		//returns true if point is in or on the boundaries defined
		bool IBoundary2D.Contains (Vector2 point) { return this.PublicContains(point); }
		protected virtual bool PublicContains (Vector2 point) { return this.Contains(point); }

		//returns the closest point to target that is in or on bounds
		Vector2 IBoundary2D.Clamp (Vector2 point) { return this.PublicClamp(point); }
		protected virtual Vector2 PublicClamp (Vector2 point) { return this.Clamp(point); }

		//returns a point between the center (distance 0) and boundaries (distance 1)
		//point is projected in angle direction from bounds center
		Vector2 IBoundary2D.PointAtAngleFromCenter (float normalizedDistance, IAngle2D angle) { return this.PublicPointAtAngleFromCenter(normalizedDistance, angle); }
		protected virtual Vector2 PublicPointAtAngleFromCenter (float normalizedDistance, IAngle2D angle)
		{ return this.PointAtAngleFromCenter(normalizedDistance, angle); }

		//transforms a point into a value representing its distance from the center
		//returns 0 for the center point, 1 for any value exactly on the bounds, and >1 for items outside bounds, in proportion to its distance to the center
		float IBoundary2D.PointToNormalizedDistanceFromCenter (Vector2 point) { return this.PublicPointToNormalizedDistanceFromCenter(point); }
		protected virtual float PublicPointToNormalizedDistanceFromCenter (Vector2 point)
		{ return this.PointToNormalizedDistanceFromCenter(point); }

		//returns the distance from center to the boundaries in target direction
		float IBoundary2D.RadiusAtAngleFromCenter (IAngle2D angle) { return this.PublicRadiusAtAngleFromCenter(angle); }
		protected virtual float PublicRadiusAtAngleFromCenter (IAngle2D angle)
		{ return this.RadiusAtAngleFromCenter(angle); }

		//Iterates over points of the boundary. gives exactly totalPoints points, which are meant to be equidistant around the shape
		IEnumerable<Vector2> IBoundary2D.EnumerateBoundaryPoints (ushort totalPoints)
		{ return new Boundary2DPerimeterEnumerable(this, totalPoints); }
	//ENDOF IBoundary2D

	//protected class members
		private Vector2 center { get { return Vector2.zero; }}
	//ENDOF protected

	//private members
		//transforms a point into a value representing its distance from the center
		//returns 0 for the center point, 1 for any value exactly on the bounds, and >1 for items outside bounds, in proportion to its distance to the center
		private float PointToNormalizedDistanceFromCenter (Vector2 point)
		{
			return this.DistanceToCenter(point) / this.RadiusAtAngleFromCenter(this.AngleFromCenterToPoint(point));
		}

		//calculates the position of the boundary at given angle from the center
		private Vector2 BoundsPositionAtAngleFromCenter (IAngle2D angle)
		{
			return angle.EAngle2DToVector2() * this.RadiusAtAngleFromCenter(angle);
		}

		//returns the distance from center to the boundaries in target direction
		private float RadiusAtAngleFromCenter(IAngle2D angle)
		{
			float cosine = angle.ECosine();
			float sine = angle.ESine();

			float horizontal = (cosine >= 0)
				?	this.xUpperRadius
				:	this.xLowerRadius;

			float vertical = (sine >= 0)
				?	this.yUpperRadius
				:	this.yLowerRadius;

			return (horizontal * vertical)
				/ System.MathF.Sqrt(
					((horizontal * horizontal) * (sine * sine))
					+ ((vertical * vertical) * (cosine * cosine))
				);
		}

		//returns a point between the center (distance 0) and boundaries (distance 1)
		//point is projected in angle direction from bounds center
		private Vector2 PointAtAngleFromCenter (float normalizedDistance, IAngle2D angle)
		{ return this.BoundsPositionAtAngleFromCenter(angle) * normalizedDistance; }

		//returns true if point is in or on the boundaries defined
		private bool Contains (Vector2 point)
		{ return this.PointToNormalizedDistanceFromCenter(point) <= 1f; }

		//returns the closest point to target that is in or on bounds
		private Vector2 Clamp (Vector2 point)
		{
			//return this.BoundsPositionAtAngleFromCenter(this.AngleFromCenterToPoint(point)); 
			if (this.Contains(point)) //if the point is contained return it as is
			{ return point; }
			else //otherwise clamp the position to a point over the boundary
			{ return this.PointAtAngleFromCenter(1f, this.AngleFromCenterToPoint(point)); } //this.BoundsPositionAtAngleFromCenter(this.AngleFromCenterToPoint(point)); }
		}

		//returns at what angle from the center given point is
		private IAngle2D AngleFromCenterToPoint (Vector2 point)
		{ return this.center.EFromToAngle2D(point); }
		
		//returns distance to center
		private float DistanceToCenter (Vector2 point)
		{ return (point - this.center).magnitude; }
	//ENDOF private methods
	}
}

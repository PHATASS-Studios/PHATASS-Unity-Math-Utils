using System.Collections.Generic;

using UnityEngine;

using static PHATASS.Utils.Types.Boundaries.Boundary2DEnumerators;

using IAngle2D = PHATASS.Utils.Types.Angles.IAngle2D;
using static PHATASS.Utils.Types.Angles.IAngle2DExtensions;
//using static PHATASS.Utils.Types.Angles.IAngle2DFactory;

using static PHATASS.Utils.Extensions.Vector2Extensions;

namespace PHATASS.Utils.Types.Boundaries
{
	//This class calculates an asymetrical ellipsoid boundary
	//each quarter has it's curvature defined by its two neigboring limits
	//Receives and returns values in world space if useCenterTransformLocalSpace is true
	public class OvoidBoundary2DBehaviour :
		UnityEngine.MonoBehaviour,
		IBoundary2D
	{
	//Serialized fields
	/*	[Tooltip("Center reference point. This transform will be considered the center of the boundary")]
		[SerializeField]
		private Transform centerTransform;
		*/

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
		Vector2 IBoundary2D.center { get { return this.center; }}

		//returns true if point is in or on the boundaries defined
		bool IBoundary2D.Contains (Vector2 point) { return this.Contains(point); }

		//returns the closest point to target that is in or on bounds
		Vector2 IBoundary2D.Clamp (Vector2 point) { return this.Clamp(point);  }

		//returns a point between the center (distance 0) and boundaries (distance 1)
		//point is projected in angle direction from bounds center
		Vector2 IBoundary2D.PointAtAngleFromCenter (float normalizedDistance, IAngle2D degrees)
		{ return this.PointAtAngleFromCenterWorldSpace(normalizedDistance, degrees); }

		//transforms a point into a value representing its distance from the center
		//returns 0 for the center point, 1 for any value exactly on the bounds, and >1 for items outside bounds, in proportion to its distance to the center
		float IBoundary2D.PointToNormalizedDistanceFromCenter (Vector2 point)
		{ return this.PointToNormalizedDistanceFromCenter(point); }

		//returns the distance from center to the boundaries in target direction
		float IBoundary2D.RadiusAtAngleFromCenter (IAngle2D angle)
		{ return this.RadiusAtAngleFromCenter(angle); }

		//Iterates over points of the boundary. gives exactly totalPoints points, which are meant to be equidistant around the shape
		IEnumerable<Vector2> IBoundary2D.EnumerateBoundaryPoints (ushort totalPoints)
		{ return new Boundary2DPerimeterEnumerable(this, totalPoints); }
	//ENDOF IBoundary2D

	//MonoBehaviour
		/*
		private void Awake ()
		{
			//this.ValidateLimits();
		}
		//*/

	//ENDOF MonoBehaviour

	//private properties
		private Transform centerTransform { get { return this.transform; }}
		private Vector2 center { get { return this.centerTransform.position; }}
		/*
		private float xUpperRadius { get { return this.xUpperRadiusReference.position.x - this.center.x; }}
		private float xLowerRadius { get { return this.xLowerRadiusReference.position.x - this.center.x * -1; }}
		private float yUpperRadius { get { return this.yUpperRadiusReference.position.y - this.center.y; }}
		private float yLowerRadius { get { return this.yLowerRadiusReference.position.y - this.center.y * -1; }}
		*/
	//ENDOF private properties

	//private methods
		//transforms a point into a value representing its distance from the center
		//returns 0 for the center point, 1 for any value exactly on the bounds, and >1 for items outside bounds, in proportion to its distance to the center
		private float PointToNormalizedDistanceFromCenter (Vector2 point)
		{
			return this.DistanceToCenter(point) / this.RadiusAtAngleFromCenter(this.AngleFromCenterToPoint(point));
		}

		//calculates the position of the boundary at given angle from the center
		private Vector2 BoundsPositionAtAngleFromCenter (IAngle2D angle)
		{
			float cosine = angle.ECosine();
			float sine = angle.ESine();

			float horizontalApex = (cosine >= 0)
				?	this.xUpperRadius
				:	this.xLowerRadius;

			float verticalApex = (sine >= 0)
				?	this.yUpperRadius
				:	this.yLowerRadius;

			return new Vector2(x: horizontalApex * cosine, y: verticalApex * sine);
		}

		//returns the distance from center to the boundaries in target direction
		private float RadiusAtAngleFromCenter (IAngle2D angle)
		{
			return this.BoundsPositionAtAngleFromCenter(angle).magnitude;
		}

		//returns a point between the center (distance 0) and boundaries (distance 1). point is projected in angle direction from bounds center
		//world space version - converts to local space and calls local space version
		private Vector2 PointAtAngleFromCenterWorldSpace (float normalizedDistance, IAngle2D angle)
		{ return this.centerTransform.TransformPoint(this.PointAtAngleFromCenterLocalSpace(normalizedDistance, angle)); }

		//returns a point between the center (distance 0) and boundaries (distance 1)
		//point is projected in angle direction from bounds center
		private Vector2 PointAtAngleFromCenterLocalSpace (float normalizedDistance, IAngle2D angle)
		{ return this.BoundsPositionAtAngleFromCenter(angle) * normalizedDistance; }

		//returns true if point is in or on the boundaries defined
		private bool Contains (Vector2 point)
		{ return this.PointToNormalizedDistanceFromCenter(point) <= 1f; }

		//returns the closest point to target that is in or on bounds
		private Vector2 Clamp (Vector2 point)
		{
			return this.BoundsPositionAtAngleFromCenter(this.AngleFromCenterToPoint(point)); 
			//
			if (this.Contains(point)) //if the point is contained return it as is
			{ return point; }
			else //otherwise clamp the position to a point over the boundary
			{ return this.BoundsPositionAtAngleFromCenter(this.AngleFromCenterToPoint(point)); }
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

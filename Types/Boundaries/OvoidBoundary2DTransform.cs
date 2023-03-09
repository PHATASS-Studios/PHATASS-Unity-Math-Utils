using System.Collections.Generic;

using UnityEngine;

using Vector2 = UnityEngine.Vector2;

using IAngle2D = PHATASS.Utils.Types.Angles.IAngle2D;
//using static PHATASS.Utils.Types.Angles.IAngle2DExtensions;
using static PHATASS.Utils.Types.Angles.IAngle2DFactory;

using static PHATASS.Utils.Extensions.Vector2Extensions;
using static PHATASS.Utils.Extensions.FloatExtensions;

namespace PHATASS.Utils.Types.Boundaries
{
	//This class calculates an asymetrical ellipsoid boundary
	//each quarter has it's curvature defined by its two neigboring limits
	//Receives and returns values in local space
	[System.Serializable]
	public class OvoidBoundary2DTransform :
		OvoidBoundary2D
	{
	//Serialized fields
		[Tooltip("Transform used as a pivot for the boundary.")]
		[SerializeField]
		private Transform pivotTransform;
	//ENDOF Serialized

	//Overrides
		protected override Vector2 publicCenter { get { return base.publicCenter + (Vector2) this.transform.position; }}
		protected override IAngle2D publicRotation { get { return this.boundaryRotation; }}

		protected override bool PublicContains (Vector2 point)
		{ return base.PublicContains(this.WorldToLocal(point)); }

		protected override Vector2 PublicClamp (Vector2 point)
		{ return this.LocalToWorld(base.PublicClamp(this.WorldToLocal(point))); }

		protected override float PublicPointToNormalizedDistanceFromCenter (Vector2 point)
		{ return base.PublicPointToNormalizedDistanceFromCenter(this.WorldToLocal(point)); }

		protected override Vector2 PublicPointAtAngleFromCenter (float normalizedDistance, IAngle2D angle)
		{ return this.LocalToWorld(base.PublicPointAtAngleFromCenter(normalizedDistance, this.WorldToLocal(angle))); }

		protected override float PublicRadiusAtAngleFromCenter (IAngle2D angle)
		{ return base.PublicRadiusAtAngleFromCenter(this.WorldToLocal(angle)); }
	//ENDOF Overrides

	//private properties
		private Transform transform { get { return this.pivotTransform; }}

		private IAngle2D boundaryRotation { get { return this.transform.rotation.eulerAngles.z.EDegreesToAngle2D(); }}
	//ENDOF private properties

	//private methods
		private Vector2 WorldToLocal (Vector2 worldVector)
		{ return this.transform.InverseTransformPoint(worldVector); }

		private Vector2 LocalToWorld (Vector2 localVector)
		{ return this.transform.TransformPoint(localVector); }

		private IAngle2D WorldToLocal (IAngle2D worldAngle)
		{ return worldAngle - this.boundaryRotation; }
	//ENDOF private methods
	}
}

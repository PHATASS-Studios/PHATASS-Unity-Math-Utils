using UnityEngine;

using static PHATASS.Utils.Extensions.TimeExtensions;

using Physics = PHATASS.Utils.Physics;

using IDoubleRange = PHATASS.Utils.Types.Ranges.IDoubleRange;

using SerializedTypeRestrictionAttribute = PHATASS.Utils.Attributes.SerializedTypeRestrictionAttribute;

namespace PHATASS.Utils.Physics.Physics1D
{
//Represents a 1D Physics spring that pulls primary subject body towards given value
	[System.Serializable]
	public struct FixedSpringJoint1D :
		IFixedJoint1D
	{
	//serialized fields
		[Tooltip("Spring force. Spring will pull back towards the center as long as the parameter's value is outside from the dead zone. Formula: springForce = distanceFromDeadZone * springForce")]
		[SerializeField]
		private double springForce = 1d;

		[Tooltip("Offset of the dead zone from the central position, which is usually 0 unless centerValue is set through code.")]
		[SerializeField]
		private double centerOffset = 0d;

		[Tooltip("Spring dead zone. Parameter values between the upper and lower dead zone will not activate the restitution spring. Default: 0d-0d.")]
		[SerializeField]
		private PHATASS.Utils.Types.Ranges.DoubleRange _springDeadZone = 0d;
		private IDoubleRange springDeadZone { get { return this._springDeadZone; }}
	//ENDOF serialized

	//IFixedJoint1D
		//this value will determine the centerpoint. if null, this centerpoint is 0
		IDoubleValue IFixedJoint1D.centerValue
		{ get { return this.centerValue; } set { this.centerValue = value; } }
	//ENDOF IFixedJoint1D

	//IPhysics1DComponent
		IPhysicsBody1D IPhysics1DComponent.primarySubject
		{ get { return this.primarySubject; } set { this.primarySubject = value; } }
	//ENDOF IPhysics1DComponent

	//IPhysicsUpdatable
		void Physics.IPhysicsUpdatable.Update (float? timeStep)
		{ this.Update(timeStep); }
	//ENDOF IPhysicsUpdatable

	//constructor
		public FixedSpringJoint1D (IPhysicsBody1D targetBody, double force, double offset, DoubleRange deadZone = 0d, IDoubleValue referenceCenterValue = null)
		{
			primarySubject = targetBody;
			springForce = force;
			centerOffset = offset;
			springDeadZone = deadZone;
			centerValue = referenceCenterValue;
		}
	//ENDOF constructor

	//private fields
		//Physics body moved by this joint"
		private IPhysicsBody1D primarySubject;
		//private IPhysicsBody1D primarySubject { get { return this._primarySubject; } set { this._primarySubject = value; } }

		//Value relay used as joint's centerpoint. It can fluctuate. If this is null, center will be considered 0
		private IDoubleValue centerValue;
	//ENDOF private fields

	//private properties
		// Force of the restitution spring
		protected double force
		{ get { return this.distanceFromDeadZone * this.springForce * -1d; }}

		private double distanceFromDeadZone
		{ get { return this.springDeadZone.DistanceFromRange(this.absoluteValue - this.offset, true); }}


		//calculated total offset of the center point
		private double offset
		{ get {
			return (((this.centerValue == null) ? this.centerValue.value : 0d)
				+ this.centerOffset);
		}}
	//ENDOF private properties

	//private methods
		private void Update (float? timeStep)
		{
			if (this.primarySubject == null)
			{
				//Debug.Log("Joint lacks primary subject.");
				return;
			}

			//float time = timeStep.EValidateDeltaTime();

			this.primarySubject.AddMomentum(this.force * timeStep.EValidateDeltaTime()); //time);
		}
	//ENDOF private methods
	}
}
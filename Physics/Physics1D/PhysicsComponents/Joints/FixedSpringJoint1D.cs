using UnityEngine;

using static PHATASS.Utils.Extensions.TimeExtensions;

using Physics = PHATASS.Utils.Physics;

using IDoubleRange = PHATASS.Utils.Types.Ranges.IDoubleRange;
using DoubleRange = PHATASS.Utils.Types.Ranges.DoubleRange;

using IDoubleValue = PHATASS.Utils.Types.Values.IDoubleValue;

namespace PHATASS.Utils.Physics.Physics1D
{
//Represents a 1D Physics spring that pulls primary subject body towards given value
	[System.Serializable]
	public class FixedSpringJoint1D :
		BasePhysics1DComponent,
		IFixedJoint1D
	{
	//serialized fields
		[Tooltip("Spring force. Spring will pull back towards the center as long as the parameter's value is outside from the dead zone. Formula: springForce = distanceFromDeadZone * springForce")]
		[SerializeField]
		private double springForce;// = 1d;

		[Tooltip("Offset of the dead zone from the central position, which is usually 0 unless centerValue is set through code.")]
		[SerializeField]
		private double centerOffset;// = 0d;

		[Tooltip("Spring dead zone. Parameter values between the upper and lower dead zone will not activate the restitution spring. Default: 0d-0d.")]
		[SerializeField]
		private PHATASS.Utils.Types.Ranges.DoubleRange _springDeadZone;// = 0d;
		private IDoubleRange springDeadZone { get { return this._springDeadZone; }}
	//ENDOF serialized

	//IFixedJoint1D
		//this value will determine the centerpoint. if null, this centerpoint is 0
		IDoubleValue IFixedJoint1D.centerValue
		{ get { return this.centerValue; } set { this.centerValue = value; } }
	//ENDOF IFixedJoint1D

	//constructor
		public FixedSpringJoint1D (
			IPhysicsBody1D targetBody,
			double force,
			double offset,
			DoubleRange deadZone, // = (DoubleRange) 0d,
			IDoubleValue referenceCenterValue = null,
			bool startEnabled = true
		) {
			primarySubject = targetBody;
			springForce = force;
			centerOffset = offset;
			_springDeadZone = deadZone;
			centerValue = referenceCenterValue;
			enabled = startEnabled;
		}

		//constructor overload that copies the joints values from another FixedSpringJoint1D
		// Additionally specific values can be provided to be used instead of the sample's
		public FixedSpringJoint1D (
			FixedSpringJoint1D sample,
			IPhysicsBody1D? targetBody = null,
			double? force = null,
			double? offset = null,
			DoubleRange? deadZone = null,
			IDoubleValue? referenceCenterValue = null,
			bool? startEnabled = null
		) {
			//copy values from sample
			primarySubject = sample.primarySubject;
			springForce = sample.springForce;
			centerOffset = sample.centerOffset;
			_springDeadZone = sample._springDeadZone;
			centerValue = sample.centerValue;
			enabled = sample.enabled;

			//then set value overrides received
			if (targetBody != null) { primarySubject = (IPhysicsBody1D) targetBody; }
			if (force != null) { springForce = (double) force; }
			if (offset != null) { centerOffset = (double) offset; }
			if (deadZone != null) { _springDeadZone = (DoubleRange) deadZone; }
			if (referenceCenterValue != null) { centerValue = (IDoubleValue) referenceCenterValue; }
			if (startEnabled != null) { enabled = (bool) startEnabled; }
		}
	//ENDOF constructor

	//private fields
		//Value relay used as joint's centerpoint. It can fluctuate. If this is null, center will be considered 0
		private IDoubleValue centerValue;
	//ENDOF private fields

	//private properties
		// Force of the restitution spring
		private double force
		{ get { return this.distanceFromDeadZone * this.springForce * -1d; }}

		private double distanceFromDeadZone
		{ get { return this.springDeadZone.DistanceFromRange(this.subjectPosition - this.centerPoint, true); }}

		private double subjectPosition
		{ get { return this.primarySubject.position; }}

		//calculated final center point of the joint
		private double centerPoint
		{ get {
			return (((this.centerValue == null) ? 0d : this.centerValue.value)
				+ this.centerOffset);
		}}
	//ENDOF private properties

	//overrides
		protected override void Update (float? timeStep)
		{
			//Debug.Log("FixedSpringJoint1D.Update()");
			if (this.primarySubject == null)
			{
				Debug.Log("FixedSpringJoint1D lacks primary subject.");
				return;
			}

			//float time = timeStep.EValidateDeltaTime();

			this.primarySubject.AddMomentum(this.force * timeStep.EValidateDeltaTime()); //time);
		}
	//ENDOF overrides
	}
}
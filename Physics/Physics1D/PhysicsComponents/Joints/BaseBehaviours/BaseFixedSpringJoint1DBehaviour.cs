using UnityEngine;

using IDoubleValue = PHATASS.Utils.Types.Values.IDoubleValue;

using SerializedTypeRestrictionAttribute = PHATASS.Utils.Attributes.SerializedTypeRestrictionAttribute;

namespace PHATASS.Utils.Physics.Physics1D
{
// Base MonoBehaviour component that contains and handles a single Physics1D joint
	public abstract class BaseFixedSpringJoint1DBehaviour :
		MonoBehaviour
		//does not implement IFixedJoint1D nor IPhysics1DJoint as this monobehaviour is not meant to be accessed through code after initialization
	{
	//serialized fields
		[Tooltip("IPhysicsBody1D Object this set of components (spring + brake) acts upon.")]
		[SerializeField]
		[SerializedTypeRestriction(typeof(IPhysicsBody1D))]
		private UnityEngine.Object? _subjectBody = null;
		private IPhysicsBody1D subjectBody
		{ get {
			if (this._subjectBody == null) { return null; }
			else { return this._subjectBody as IPhysicsBody1D; }
		}}

		[Tooltip("This value will determine the centerpoint towards which the joint pulls. If null, centerpoint is considered to be 0.")]
		[SerializeField]
		[SerializedTypeRestriction(typeof(IDoubleValue))]
		private UnityEngine.Object? _centerValue = null;
		private IDoubleValue centerValue
		{ get {
			if (this._centerValue == null) { return null; }
			else { return this._centerValue as IDoubleValue; }
		}}

		[Tooltip("Fixed joint configuration - this spring pulls primarySubject towards centerValue.")]
		[SerializeField]
		private FixedSpringJoint1D _fixedJointComponent;
		protected IFixedJoint1D jointComponent { get { return this._fixedJointComponent; }}

		[Tooltip("Braking force applied in opposite direction to current momentum each second.")]
		[SerializeField]
		private ConstantBrakePhysics1DEffector _constantBrake;
		private IPhysics1DEffector constantBrake { get { return this._constantBrake;}}


	//ENDOF serialized

	//MonoBehaviour lifecycle
		protected virtual void Awake ()
		{
			this.jointComponent.centerValue = this.centerValue;
			this.jointComponent.primarySubject = this.subjectBody;

			this.constantBrake.primarySubject = this.subjectBody;
		}
	//ENDOF MonoBehaviour lifecycle

	//by-sample configuration methods
		//[TO-DO] [!!] FINISH THIS? ConfigureFromSample
		/* check TransformPositionCenteredSpringJointAxisPair_Physics1D_MonoBehaviour
		//configures this object by replicating a sample's member values and returns itself
		public BaseFixedSpringJoint1DBehaviour ConfigureFromSample (
			BaseFixedSpringJoint1DBehaviour sample,
			IPhysicsBody1D targetBody = null,
			IDoubleValue centerValue = null
		) {
		}
		*/
	//ENDOF by-sample configuration methods

	//overridable abstract members

	//ENDOF abstract

	//protected members
		protected virtual void PhysicsUpdate (float timeStep)
		{
			this.jointComponent.Update(Time.deltaTime);
		}
	//ENDOF protected members
	}
}
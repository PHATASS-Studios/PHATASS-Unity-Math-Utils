using UnityEngine;

using DoubleRange = PHATASS.Utils.Types.Ranges.DoubleRange;
using IDoubleRange = PHATASS.Utils.Types.Ranges.IDoubleRange;

//using IDoubleValue = PHATASS.Utils.Types.Values.IDoubleValue;

using SerializedTypeRestrictionAttribute = PHATASS.Utils.Attributes.SerializedTypeRestrictionAttribute;

namespace PHATASS.Utils.Physics.Physics1D
{
// Base MonoBehaviour component that contains and handles a single OuterLimitPhysics1DConstraint
	public abstract class BaseOuterLimitConstraint1DBehaviour :
		MonoBehaviour
		//does not implement any interfaces as this monobehaviour is not meant to be accessed through code after initialization
	{
	//serialized fields
		[Tooltip("IPhysicsBody1D Object this set of components (spring + brake) acts upon. Note this serialized field is NOT updated at runtime.")]
		[SerializeField]
		[SerializedTypeRestriction(typeof(IPhysicsBody1D))]
		private UnityEngine.Object? _subjectBody = null;
		private IPhysicsBody1D subjectBody
		{ get {
			if (this._subjectBody == null) { return null; }
			else { return this._subjectBody as IPhysicsBody1D; }
		}}

		[Tooltip("Outer limit range. Subject body's position/value won't be allowed to go OUTSIDE these values. Note this serialized field is NOT updated at runtime.")]
		[SerializeField]
		private DoubleRange _outerLimit;
		private IDoubleRange outerLimit { get { return this._outerLimit; }}

		[Tooltip("Outer Limit constraint configuration")]
		[SerializeField]
		private OuterLimitPhysics1DConstraint _constraintComponent;
		protected IPhysics1DLimitConstraint constraintComponent { get { return this._constraintComponent; }}
	//ENDOF serialized

	//MonoBehaviour lifecycle
		protected virtual void Awake ()
		{
			this.constraintComponent.primarySubject = this.subjectBody;
			this.constraintComponent.outerLimit = this.outerLimit;
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
			this.constraintComponent.Update(Time.deltaTime);
		}
	//ENDOF protected members
	}
}
using UnityEngine;

using IDoubleValue = PHATASS.Utils.Types.Values.IDoubleValue;

namespace PHATASS.Utils.Physics.Physics1D
{
// Base MonoBehaviour component that contains and handles a single Physics1D joint
	public abstract class BaseFixedSpringJoint1DOnUpdateMonoBehaviour :
		MonoBehaviour
		//does not implement IFixedJoint1D nor IPhysics1DJoint as this monobehaviour is not meant to be accessed through code after initialization
	{
	//serialized fields
		[Tooltip("Fixed joint configuration")]
		[SerializeField]
		private FixedSpringJoint1D _fixedJointComponent;
		private IFixedJoint1D jointComponent { get { return this._fixedJointComponent; }}
	//ENDOF serialized

	//MonoBehaviour lifecycle
		//MonoBehaviour update calls joint update
		protected virtual void Update ()
		{
			this.jointComponent.Update(Time.deltaTime);
		}
	//ENDOF MonoBehaviour lifecycle

	//overridable abstract members

	//ENDOF abstract

	//protected class members
		protected IPhysicsBody1D primarySubject
		{
			get { return this.jointComponent.primarySubject; }
			set { this.jointComponent.primarySubject = value; }
		}

		protected IDoubleValue centerValue
		{
			get { return this.jointComponent.centerValue; }
			set { this.jointComponent.centerValue = value; }
		}
	//ENDOF protected
	}
}
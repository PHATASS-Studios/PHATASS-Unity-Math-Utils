using UnityEngine;

using Physics = PHATASS.Utils.Physics;
using Values = PHATASS.Utils.Types.Values;


namespace PHATASS.Utils.Physics.Physics1D
{
// Base MonoBehaviour implementation of a 1D physics body as implemented in PHATASS.Utils.Physics
// NOTE THIS CANNOT BE USED AS IS: PhysicsUpdate() MUST BE CALLED on any of FixedUpdate, Update, LateUpdate...
	public abstract class BasePhysics1DBodyBehaviour :
		MonoBehaviour,
		IPhysicsBody1D,
		Values.IFloatValueMutable,
		Values.IDoubleValueMutable
	{
	//serialized fields
		[Tooltip("Properties of this physics body. Position represents current value.")]
		[SerializeField]
		protected PhysicsBody1D_SimpleMomentumBased physicsBody;
	//ENDOF serialized

	//IPhysicsBody1D
		// scalar (unsigned) value representing total kinetic energy in the body, in Joules
		double Physics.IKineticBody.totalEnergyMagnitude { get { return ((IUpdatablePhysicsBody1D) this.physicsBody).totalEnergyMagnitude; }}

		// Inertial mass of this body. Velocity = (momentum / mass) = (√(2 * KineticEnergy / mass))
		double Physics.IKineticBody.mass
		{
			get { return ((IUpdatablePhysicsBody1D) this.physicsBody).mass; }
			set { ((IUpdatablePhysicsBody1D) this.physicsBody).mass = value; }
		}

		// momentum present in the body (m*v)
		double Physics.IKineticBodyNDimensional<double>.momentum
		{
			get { return ((IUpdatablePhysicsBody1D) this.physicsBody).momentum; }
			set { ((IUpdatablePhysicsBody1D) this.physicsBody).momentum = value; }
		}

		// Value representing current position/value of this kinetic body
		double Physics.IKineticBodyNDimensional<double>.position
		{
			get { return ((IUpdatablePhysicsBody1D) this.physicsBody).position; }
			set { ((IUpdatablePhysicsBody1D) this.physicsBody).position = value; }
		}

		//Adds a 1D momentum to the body, with a force & direction depending on momentum value and sign.
		void Physics.IForceReceiverNDimensional<double>.AddMomentum (double momentum)
		{ ((IUpdatablePhysicsBody1D) this.physicsBody).AddMomentum(momentum); }

		// While asleep = true, the following is true:
		//	> A body's energy/momentum is considered 0
		//	> All physics operations that operate upon an object's current energy/momentum can be skipped
		//	> Physics operations that add forces should NOT be skipped. They will awake the object as necessary.
		bool Physics.ISleepable.asleep
		{ get { return ((IUpdatablePhysicsBody1D) this.physicsBody).asleep; } }
	//ENDOF IPhysicsBody1D

	//IFloatValueMutable
		float Values.IValue<float>.value { get { return (float) ((Values.IValue<float>) this.physicsBody).value; }}
		float Values.IValueMutable<float>.value {
			get { return (float) ((Values.IValueMutable<float>) this.physicsBody).value; }
			set { ((Values.IValueMutable<float>) this.physicsBody).value = value; }
		}
	//ENDOF IFloatValueMutable

	//IDoubleValueMutable
		double Values.IValue<double>.value { get { return ((Values.IValue<double>) this.physicsBody).value; }}
		double Values.IValueMutable<double>.value {
			get { return ((Values.IValueMutable<double>) this.physicsBody).value; }
			set { ((Values.IValueMutable<double>) this.physicsBody).value = value; }
		}
	//ENDOF IDoubleValueMutable

	//MonoBehaviour lifecycle
	//ENDOF MonoBehaviour lifecycle

	//protected members
		protected virtual void PhysicsUpdate (float timeStep)
		{ ((IUpdatablePhysicsBody1D) this.physicsBody).Update(timeStep); }
	//ENDOF protected members
	}
}
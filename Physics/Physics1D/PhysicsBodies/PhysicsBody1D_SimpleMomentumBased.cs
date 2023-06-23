using UnityEngine;

using Physics = PHATASS.Utils.Physics;
using Values = PHATASS.Utils.Types.Values;

using static PHATASS.Utils.Extensions.DoubleExtensions;
using static PHATASS.Utils.Extensions.TimeExtensions;
using static PHATASS.Utils.Extensions.FrameIndependentSmoothingExtensions;

namespace PHATASS.Utils.Physics.Physics1D
{
// Implementation of a basic 1-dimensional physics body.
// It must be constantly updated by calling IPhysicsUpdatable.Update(timeStep) every frame/fixedUpdate
	[System.Serializable]
	public class PhysicsBody1D_SimpleMomentumBased :
		IUpdatablePhysicsBody1D,
		Values.IFloatValueMutable,
		Values.IDoubleValueMutable
	{
	//serialized fields
		[Tooltip("Inertial mass. MUST NOT BE ZERO. This dictates how much applied forces alter this object's momentum. Default: 1f")]
		[SerializeField]
		private double mass = 1f;

		[Tooltip("Motion dampener. Slows current momentum by a fraction of its current value each second.")]
		[SerializeField]
		private double dampingRate = 0.05f;

		[Tooltip("Sleep threshold - when momentum magnitude is smaller than this the body sleeps. Default 1e-19.")]
		[SerializeField]
		private double sleepThreshold = 0.0000000000000000001f;

		[Tooltip("Value of this body's 1D position.")]
		[SerializeField]
		private double value = 0f;
	//ENDOF serialized

	//IUpdatablePhysicsBody1D
		// scalar (unsigned) value representing total kinetic energy in the body, in Joules
		double Physics.IKineticBody.totalEnergyMagnitude { get { return this.kineticEnergy; }}

		// Inertial mass of this body. Velocity = (momentum / mass) = (√(2 * KineticEnergy / mass))
		double Physics.IKineticBody.mass
		{
			get { return this.mass; }
			set { this.mass = value; }
		}

		// momentum present in the body (m*v)
		double Physics.IKineticBodyNDimensional<double>.momentum
		{
			get { return this.momentum; }
			set { this.momentum = value; }
		}

		// Value representing current position/value of this kinetic body
		double Physics.IKineticBodyNDimensional<double>.position
		{
			get { return this.value; }
			set { this.value = value; }
		}

		//Adds a 1D momentum to the body, with a force & direction depending on momentum value and sign.
		void Physics.IForceReceiverNDimensional<double>.AddMomentum (double momentum)
		{ this.AddMomentum(momentum); }

		// While asleep = true, the following is true:
		//	> A body's energy/momentum is considered 0
		//	> All physics operations that operate upon an object's current energy/momentum can be skipped
		//	> Physics operations that add forces should NOT be skipped. They will awake the object as necessary.
		bool Physics.ISleepable.asleep
		{ get { return this.asleep; } }


		void Physics.IPhysicsUpdatable.Update (float? timeStep)
		{ this.PhysicsUpdate(timeStep); }
	//ENDOF IUpdatablePhysicsBody1D

	//IFloatValueMutable
		float Values.IValue<float>.value { get { return (float) this.value; }}
		float Values.IValueMutable<float>.value {
			get { return (float) this.value; }
			set { this.value = (double) value; }
		}
	//ENDOF IFloatValueMutable

	//IDoubleValueMutable
		double Values.IValue<double>.value { get { return this.value; }}
		double Values.IValueMutable<double>.value {
			get { return this.value; }
			set { this.value = value; }
		}
	//ENDOF IDoubleValueMutable

	//private members
		//currently accumulated momentum in the body
		private double momentum = 0f;

		private double kineticEnergy
		{ get { return (this.mass/2) * (this.velocity * this.velocity); }}

		//velocity of this body
		private double velocity
		{ get { return this.momentum / this.mass; }}

		//wether the body is currently considered asleep
		private bool asleep { get { return this.momentum.EAbs() < this.sleepThreshold; }}

		//adds momentum to the kinetic body in the direction of given sign
		private void AddMomentum (double momentum)
		{ this.momentum += momentum; }

		//sets the body as sleeping
		private void Sleep ()
		{
			this.momentum = 0f;
		}
	//ENDOF private members

	//Physics Update exclusive methods
		private void PhysicsUpdate (float? timeStep)
		{
			//check for sleeping conditions. If body is asleep, abort the rest of the physics update
			if (this.asleep)
			{
				this.Sleep();
				return;
			}

			//validate time step value so it is not null
			float validatedTime = timeStep.EValidateDeltaTime();
			
			//move the object's value by accumulated force
			this.ApplyMomentum(validatedTime);

			//Finally apply the force drag
			this.DampenMomentum(validatedTime);	
		}

		private void ApplyMomentum (float timeStep)
		{
			this.value += (this.velocity * timeStep);
		}

		//partially dampen current momentum, at a rate of a fraction of current momentum per second
		private void DampenMomentum (float timeStep)
		{
			this.momentum = this.momentum.EFrameIndependentDamp(dampingRate: this.dampingRate, deltaTime: timeStep);
		}
	//ENDOF Physics update
	}
}
using UnityEngine;

using static PHATASS.Utils.Extensions.TimeExtensions;
using static PHATASS.Utils.Extensions.DoubleExtensions;

namespace PHATASS.Utils.Physics.Physics1D
{
// Interface representing a component that constantly brakes an object's current momentum by a flat amount each second
	public struct ConstantBrakePhysics1DEffector: IPhysics1DEffector
	{
	//serialized fields
		[Tooltip("Flat amount of momentum mitigated by the constant brake each second, in newton/seconds")]
		[SerializeField]
		private double constantBrake;
	//ENDOF serialized

	//IPhysics1DComponent
		IPhysicsBody1D IPhysics1DComponent.primarySubject
		{ get { return this.primarySubject; } set { this.primarySubject = value; } }
	//ENDOF IPhysics1DComponent

	//IPhysicsUpdatable
		void Physics.IPhysicsUpdatable.Update (float? timeStep)
		{ this.Update(timeStep); }
	//ENDOF IPhysicsUpdatable

	//private fields
		//Physics body constrained
		private IPhysicsBody1D primarySubject;
	//ENDOF private fields

	//private methods
		private void Update (float? timeStep)
		{
			if (this.primarySubject == null)
			{
				Debug.Log("ConstantBrakePhysics1DEffector lacks primary subject.");
				return;
			}

			if (this.constantBrake == 0d) { return; }
			
			double brakingForce = this.constantBrake * (double) timeStep.EValidateDeltaTime();

			//force set momentum to 0 if brake is stronger than momentum to avoid causing an opposite bounce
			if (brakingForce >= this.primarySubject.momentum.EAbs()) { this.primarySubject.momentum = 0d; }
			//otherwise, apply the dampener in momentum's opposite direction
			else { this.primarySubject.AddMomentum(brakingForce * (this.primarySubject.momentum.ESign() * -1d)); }
		}
	//ENDOF private
	}
}
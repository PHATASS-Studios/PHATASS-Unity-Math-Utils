using UnityEngine;

using static PHATASS.Utils.Extensions.TimeExtensions;
using static PHATASS.Utils.Extensions.DoubleExtensions;

namespace PHATASS.Utils.Physics.Physics1D
{
// Interface representing a component that constantly brakes an object's current momentum by a flat amount each second
	[System.Serializable]
	public class ConstantBrakePhysics1DEffector :
		BasePhysics1DComponent,
		IPhysics1DEffector
	{
	//serialized fields
		[Tooltip("Flat amount of momentum mitigated by the constant brake each second, in newton/seconds")]
		[SerializeField]
		private double constantBrake;
	//ENDOF serialized

	//overrides
		protected override void Update (float? timeStep)
		{
			//Debug.Log("ConstantBrakePhysics1DEffector.Update()");

			if (this.primarySubject == null)
			{
			//	Debug.Log("ConstantBrakePhysics1DEffector lacks primary subject.");
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
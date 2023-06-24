using UnityEngine;

using Physics = PHATASS.Utils.Physics;

using static PHATASS.Utils.Extensions.DoubleExtensions;

using DoubleRange = PHATASS.Utils.Types.Ranges.DoubleRange;
using IDoubleRange = PHATASS.Utils.Types.Ranges.IDoubleRange;

namespace PHATASS.Utils.Physics.Physics1D
{
// Interface representing a component that acts upon an object's position, constraining it to a delimited range
	[System.Serializable]
	public class OuterLimitPhysics1DConstraint: IPhysics1DLimitConstraint
	{
	//serialized fields
		/*[Tooltip("Outer limits. When position goes outside the outer limits, it is clamped back inside and bounce is applied if necessary.")]
		[SerializeField]
		private DoubleRange _outerLimit;// = 0d;
		private IDoubleRange outerLimit { get { return this._outerLimit; }}*/

		[Tooltip("Bounciness of the outer limits. Body will keep this portion of its momentum when bouncing off of the limits. 0d = no bounce, 1d = full force bounce")]
		[SerializeField]
		private double outerLimitBounciness;
	//ENDOF serialized

	//IPhysics1DComponent
		IPhysicsBody1D IPhysics1DComponent.primarySubject
		{
			get { return this.primarySubject; }
			set {
				Debug.Log(value);
				this.primarySubject = value;
				Debug.Log(this.primarySubject);
				}
		}
	//ENDOF IPhysics1DComponent

	//IPhysics1DLimitConstraint
		IDoubleRange IPhysics1DLimitConstraint.outerLimit { get { return this.outerLimit; } set { this.outerLimit = value; }}
	//ENDOF IPhysics1DLimitConstraint

	//IPhysicsUpdatable
		void Physics.IPhysicsUpdatable.Update (float? timeStep)
		{ this.Update(timeStep); }
	//ENDOF IPhysicsUpdatable

	//constructor
	//ENDOF constructor

	//private fields
		private IDoubleRange outerLimit;

		//Physics body constrained
		private IPhysicsBody1D primarySubject;
	//ENDOF private fields

	//private properties
	//ENDOF private properties

	//private methods
		private void Update (float? timeStep)
		{
			Debug.Log("OuterLimitPhysics1DConstraint.Update()");
			if (this.primarySubject == null)
			{
				Debug.Log("OuterLimitPhysics1DConstraint lacks primary subject.");
				return;
			}

			//float time = timeStep.EValidateDeltaTime();

			//check upper limit
			if (this.primarySubject.position > this.outerLimit.maximum)
			{
				//reset position
				this.primarySubject.position = this.outerLimit.maximum;
				//bounce
				if (this.primarySubject.momentum.ESign() > 0)
				{
					this.primarySubject.momentum = this.primarySubject.momentum * this.outerLimitBounciness * -1d;
				}
			}
			//check lower limit
			else if (this.primarySubject.position < this.outerLimit.minimum)
			{
				//reset position
				this.primarySubject.position = this.outerLimit.minimum;
				//bounce
				if (this.primarySubject.momentum.ESign() < 0)
				{
					this.primarySubject.momentum = this.primarySubject.momentum * this.outerLimitBounciness * -1d;
				}
			}
		}
	//ENDOF private methods
	}
}
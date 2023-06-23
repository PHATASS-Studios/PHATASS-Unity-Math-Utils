using Physics = PHATASS.Utils.Physics;

namespace PHATASS.Utils.Physics.Physics1D
{
// Interface representing a component that acts upon
	public struct SymmetricOuterLimitsPhysics1DConstraint: IPhysics1DConstraint
	{
	//IPhysics1DComponent
		IPhysicsBody1D IPhysics1DComponent.primarySubject
		{ get { return this.primarySubject; } set { this.primarySubject = value; } }
	//ENDOF IPhysics1DComponent

	//IPhysicsUpdatable
		void Physics.IPhysicsUpdatable.Update (float? timeStep)
		{ this.Update(timeStep); }
	}
	//ENDOF IPhysicsUpdatable

	//constructor
	//ENDOF constructor

	//private fields
		//Physics body constrained
		private IPhysicsBody1D primarySubject;

	//ENDOF private fields
	}
}
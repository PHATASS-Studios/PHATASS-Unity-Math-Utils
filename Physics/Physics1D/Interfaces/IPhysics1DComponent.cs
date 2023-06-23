namespace PHATASS.Utils.Physics.Physics1D
{
//Represents a 1D Physics component, like springs and constraints
	public interface IPhysics1DComponent :
		PHATASS.Utils.Physics.IPhysicsComponent
	{
		// Primary physics body affected by this component
		IPhysicsBody1D primarySubject { get; set; }
	}
}
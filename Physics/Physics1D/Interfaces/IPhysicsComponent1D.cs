namespace PHATASS.Utils.Physics.Physics1D
{
	public interface IPhysics1DComponent :
		PHATASS.Utils.Physics.IPhysicsComponent
	{
		IPhysicsBody1D primarySubject { get; set; }
	}
}
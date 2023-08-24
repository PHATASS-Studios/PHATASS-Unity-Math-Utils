namespace PHATASS.Utils.Physics.Physics1D
{
// Base for any updatable physics1D component, like springs or contraints.
	[System.Serializable]
	public abstract class BasePhysics1DComponent :
		BasePhysicsUpdatable,
		IPhysics1DComponent
	{
	//serialized fields
	//ENDOF serialized fields

	//IPhysics1DComponent
		IPhysicsBody1D IPhysics1DComponent.primarySubject
		{
			get { return this.primarySubject; }
			set { this.primarySubject = value; }
		}
	//ENDOF IPhysics1DComponent

	//inheritable members
		//primary physics body handled by this component
		protected IPhysicsBody1D primarySubject;
	//ENDOF inheritable members

	//private members
	//ENDOF private members
	}
}
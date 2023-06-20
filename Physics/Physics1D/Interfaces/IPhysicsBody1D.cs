namespace PHATASS.Utils.Physics.Physics1D
{
// Interface representing a 1-dimensional body/magnitude with physics simulation
//	Implements methods to add force and properties to get set current momentum
	public interface IPhysicsBody1D :
		IKineticBody1D,		// properties to get/set energy stored in the system
		IForceReceiver1D	// method to add energy to the system
	{}
}
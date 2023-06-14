namespace PHATASS.Utils.Types.Physics1D
{
// Interface representing a 1-dimensional body/magnitude with physics
//	Implements methods to add force and properties to get set current momentum
	public interface IPhysicsBody1D :
		IForceReceiver1D,
		IMomentumBody1D
	{}
}
namespace PHATASS.Utils.Types.Physics1D
{
//Represents a body with a specific physical momentum
	public interface IMomentumBody1D
	{
		//momentum in this body. Sign indicates direction.
		float momentum { get; set; }
	}
}
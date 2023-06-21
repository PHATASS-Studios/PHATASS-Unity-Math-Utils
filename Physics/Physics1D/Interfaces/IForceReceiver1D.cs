namespace PHATASS.Utils.Physics.Physics1D
{
	public interface IForceReceiver1D
	{
		//Adds a 1D momentum to the body, with a force & direction depending on momentum value and sign.
		void AddMomentum (double momentum);
	}
}
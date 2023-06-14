namespace PHATASS.Utils.Types.Physics1D
{
	public interface IForceReceiver1D
	{
		//Adds a 1D force/momentum to the body, with a force & direction depending on force value and sign.
		void AddForce (float force);
	}
}
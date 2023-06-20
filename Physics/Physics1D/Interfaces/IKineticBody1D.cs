namespace PHATASS.Utils.Physics.Physics1D
{
//Represents a 1-Dimensional object/magnitude with the ability to store kinetic energy
	public interface IKineticBody1D
	{
		//momentum in this body. Sign indicates direction.
		float momentum { get; set; }
	}
}
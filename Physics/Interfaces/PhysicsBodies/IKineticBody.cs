namespace PHATASS.Utils.Physics
{
// Base interface representing an object capable of holding kinetic energy
//	this offers no dimensional specialization and likely needs to be extended as a 1D, 2D or 3D body
	public interface IKineticBody
	{
		// scalar (unsigned) value representing total kinetic energy in the body, in Joules
		// n-dimensional bodies must return the total energy magnitude across all its dimensions
		double totalEnergyMagnitude { get; }

		// Inertial mass of this body. Velocity = (momentum / mass) = (√(2 * KineticEnergy / mass))
		double mass { get; set; }
	}
}

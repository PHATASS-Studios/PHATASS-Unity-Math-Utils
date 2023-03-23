using Particle = UnityEngine.ParticleSystem.Particle;

namespace PHATASS.Utils.Types.Wrappers
{
// offers access to a managed list of UnityEngine.Particle objects, handling allocation of memory
	public interface IParticleAccessor
	{
		// On get will get a copy of the managed particlesystem's particles and update count
		// On set will update that particlesystem with given particles
		// To use, read this array, iterate over it altering particles, then set this array to your updated copy
		Particle[] particles { get; set; }

		//gets the ammount of living particles in the particles array.
		//ONLY UPDATES AFTER particles.get HAS BEEN ACCESSED
		int particleCount { get; }
	}
}
using Debug = UnityEngine.Debug;

using ParticleSystem = UnityEngine.ParticleSystem;
using Particle = UnityEngine.ParticleSystem.Particle;

namespace PHATASS.Utils.Types.Wrappers
{
// gets a struct wrapping a reference to a ParticleSystem and a preallocated particle buffer
// allows getting and setting the particleSystem's particles through a preallocated array
	[System.Serializable]
	public struct PreallocatedParticleSystemWrapper : IParticleAccessor
	{
	//IParticleAccessor
		// On get will get a copy of the managed particlesystem's particles and update count
		// On set will update that particlesystem with given particles
		// To use, read this array, iterate over it altering particles, then set this array to your updated copy
		Particle[] IParticleAccessor.particles
		{
			get
			{
				this.RefreshParticleCache();
				return this.particles;
			}
			set
			{
				this.managedParticleSystem.SetParticles(value);
			}
		}

		//gets the ammount of living particles in the particles array.
		//ONLY UPDATES AFTER particles.get HAS BEEN ACCESSED
		int IParticleAccessor.particleCount { get { return this.count; }}
	//ENDOF IParticleAccessor

	//private
		[UnityEngine.SerializeField]
		private ParticleSystem managedParticleSystem;

		private Particle[] particles;
		private int count;

		private void RefreshParticleCache ()
		{
			if (this.managedParticleSystem == null)
			{
				Debug.LogError("PreallocatedParticleSystemWrapper managedParticleSystem not initialized");
				return;
			}
			if (this.particles == null || this.particles.Length != this.managedParticleSystem.main.maxParticles)
			{ this.particles = new Particle[managedParticleSystem.main.maxParticles]; }
			this.count = this.managedParticleSystem.GetParticles(this.particles);
		}
	//ENDOF private
	}

}
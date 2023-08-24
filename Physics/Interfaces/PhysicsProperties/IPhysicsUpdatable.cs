namespace PHATASS.Utils.Physics
{
//interface representing an object that is updatable for the purposes of physics simulation
// IToggleable.state represents enabled state of the updatable:
//	if IToggleable.state == false, update calls will be ignored
	public interface IPhysicsUpdatable : PHATASS.Utils.Types.Toggleables.IToggleable
	{
	// Calculates one physics update for given timeStep
	// This should be used to update a physics element every frame or physics update.
	// If timeStep is omitted, implementor should by default use UnityEngine.Time.deltaTime, as it represents current frame or physics frame time.
		void Update (float? timeStep = null);
	}
}
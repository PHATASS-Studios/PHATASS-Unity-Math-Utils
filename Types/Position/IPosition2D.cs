namespace PHATASS.Utils.Types
{
//Interface representing any object with a readable position
// note position MUST be in world-space
	public interface IPosition2D
	{
		UnityEngine.Vector2 position { get; } // object's position in WORLD SPACE
	}
}
namespace PHATASS.Utils.Types
{
//Interface representing any object with a writable position
// note position MUST be in world-space
	public interface IWritablePosition2D : IPosition2D
	{
		UnityEngine.Vector2 position { set; get; } // object's position in WORLD SPACE
	}
}
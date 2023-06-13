namespace PHATASS.Utils.Types
{
//Interface representing any object with a writable position
// note position MUST be in world-space
	public interface IWritablePosition3D : IPosition3D
	{
		UnityEngine.Vector3 position { set; get; } // object's position in WORLD SPACE
	}
}
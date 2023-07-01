using GameObject = UnityEngine.GameObject;

namespace PHATASS.Utils.Extensions
{
//ExtensionMethods for UnityEngine.GameObject
// Class fragment containing methods for managing a GameObject's properties
//
	public static partial class GameObjectExtensions//GameObjectManagement
	{
	// Sets the gameObject's tag and physics layer
		// if targetTag is null or tagetLayer < 0 they will be ignored
		public static void ESetTagAndLayer (this GameObject gameObject, string targetTag, int targetLayer)
		{
			if (targetTag != null) { gameObject.tag = targetTag; }
			if (targetLayer >= 0) { gameObject.layer = targetLayer; }
		}
	}
}

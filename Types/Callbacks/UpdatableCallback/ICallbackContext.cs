using GameObject = UnityEngine.GameObject;

namespace PHATASS.Utils.Callbacks
{
	//base params object interface for action callbacks
	public interface ICallbackContext
	{
		GameObject gameObject {get;}
	}
}
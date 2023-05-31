using GameObject = UnityEngine.GameObject;
using IAction = PHATASS.ActionSystem.IAction;

namespace PHATASS.Utils.Callbacks
{
	//base params object interface for action callbacks
	public interface ICallbackContext
	{
		GameObject gameObject {get;}
	}
}
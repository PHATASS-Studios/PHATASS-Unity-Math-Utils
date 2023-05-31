using GameObject = UnityEngine.GameObject;

namespace PHATASS.Utils.Callbacks
{
	public static class CallbackContexts
	{
	//basic context object
		public static ICallbackContext FromGameObject (GameObject gameObject)
		{ return new CallbackContextBase(gameObject); }

		private class CallbackContextBase : ICallbackContext
		{
		//ICallbackContext
			GameObject ICallbackContext.gameObject
			{ get { return this._gameObject; }}
		//ENDOF ICallbackContext

			private GameObject _gameObject;
			public CallbackContextBase (GameObject gameObject)
			{ this._gameObject = gameObject; }
		}
	//ENDOF basic context object
	}
}
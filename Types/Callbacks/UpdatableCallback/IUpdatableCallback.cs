namespace PHATASS.Utils.Callbacks
{
	//interface defining an action callback, including start, update, and ended
	public interface IUpdatableCallback
	{		
		void ExecuteStart (ICallbackContext context);
		void ExecuteUpdate (ICallbackContext context);
		void ExecuteEnded (ICallbackContext context);
	}
}				
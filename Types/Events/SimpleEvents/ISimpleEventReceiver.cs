namespace PHATASS.Utils.Events
{
	//base interface for all event receivers
	public interface ISimpleEventReceiver <TParam0>: IEventReceiver
	{
		void Event (TParam0 param0);
	}
}
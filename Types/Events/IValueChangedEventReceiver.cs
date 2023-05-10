namespace PHATASS.Utils.Events
{
//interface representing an event receiver triggered on a value change of generic type
// ValueChangedEvent value is the new value, delta represents the change in value from previous value
    //if TValueType is a type whose delta can't somehow be represented, NULL may be passed
	public interface IValueChangedEventReceiver <TValueType> : IEventReceiver
	{
		void ValueChangedEvent (TValueType value, TValueType delta);
	}
}
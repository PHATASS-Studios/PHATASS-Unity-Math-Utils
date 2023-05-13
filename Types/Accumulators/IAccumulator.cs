namespace PHATASS.Utils.Types
{
	public interface IAccumulator <TValueType> :
		IValue<TValueType>,
		PHATASS.Utils.Events.ISimpleEventReceiver<TValueType>,
		IResettable
	{
	}
}
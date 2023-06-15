namespace PHATASS.Utils.Types
{
	public interface IAccumulator <TValueType> :
		PHATASS.Utils.Types.Values.IValue<TValueType>,
		PHATASS.Utils.Events.ISimpleEventReceiver<TValueType>,
		IResettable
	{
	}
}
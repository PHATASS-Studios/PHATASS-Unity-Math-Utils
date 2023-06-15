namespace PHATASS.Utils.Types
{
	public interface IIntAccumulator :
		IAccumulator <int>,
		PHATASS.Utils.Events.IIntEventReceiver,
		PHATASS.Utils.Types.Values.IIntValue
	{}
}
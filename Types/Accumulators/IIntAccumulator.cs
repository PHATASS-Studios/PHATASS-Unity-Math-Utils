namespace PHATASS.Utils.Types
{
	public interface IIntAccumulator :
		IAccumulator <int>,
		PHATASS.Utils.Events.IIntEventReceiver,
		IIntValue
	{}
}
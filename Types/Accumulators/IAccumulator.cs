namespace PHATASS.Utils.Types
{
	public interface IAccumulator <TValueType> :
		IValue<TValueType>,
		IResettable
	{
		void Add (TValueType addendum);
	}
}
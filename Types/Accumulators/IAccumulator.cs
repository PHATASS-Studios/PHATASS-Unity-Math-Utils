namespace PHATASS.Utils.Types
{
	public interface IAccumulator <TValueType>
	{
		void Add (TValueType addendum);
	}
}
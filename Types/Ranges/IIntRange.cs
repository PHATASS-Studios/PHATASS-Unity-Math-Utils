namespace PHATASS.Utils.Types.Ranges
{
// int-specific ILimitedRange
	public interface IIntRange : ILimitedRange <int>
	{}

	public interface IIntRangeMutable :
		ILimitedRangeMutable<int>, 
		IIntRange
	{}
}

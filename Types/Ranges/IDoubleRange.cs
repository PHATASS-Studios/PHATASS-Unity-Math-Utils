namespace PHATASS.Utils.Types.Ranges
{
// Double-specific ILimitedRange
	public interface IDoubleRange : ILimitedRange <double>
	{}

	public interface IDoubleRangeMutable :
		ILimitedRangeMutable<double>, 
		IDoubleRange
	{}
}

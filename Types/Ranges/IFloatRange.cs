namespace PHATASS.Utils.Types.Ranges
{
// Float-specific ILimitedRange
	public interface IFloatRange : ILimitedRange <float>
	{}

	public interface IFloatRangeMutable :
		ILimitedRangeMutable<float>, 
		IFloatRange
	{}
}

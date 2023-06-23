namespace PHATASS.Utils.Physics.Physics1D
{
// Interface representing a constraint that follows a specific range delimitation
	public interface IPhysics1DLimitConstraint : IPhysics1DConstraint
	{
		//set or get the constraining outer limits
		PHATASS.Utils.Types.Ranges.IDoubleRange outerLimit { get; set; }
	}
}
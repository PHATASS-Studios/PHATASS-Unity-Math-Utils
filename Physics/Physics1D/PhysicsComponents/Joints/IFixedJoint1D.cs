using IDoubleValue = PHATASS.Utils.Types.Values.IDoubleValue;

namespace PHATASS.Utils.Physics.Physics1D
{
// Interface representing a component that acts exclusively upon desired primarySubject, around a value that is left unaltered.
	public interface IFixedJoint1D :
		IPhysics1DComponent
	{
		// central value towards which this joint pulls primary subject
		IDoubleValue centerValue { get; set; }
	}
}
using IAngle2D = PHATASS.Utils.Types.Angles.IAngle2D;

namespace PHATASS.Utils.Events
{
//interface representing an object containing information about a 2d-angled intensity value
	public interface IAngle2DIntensity
	{
		IAngle2D angle { get; } //Angular direction
		float intensity { get; } //intensity
	}
}
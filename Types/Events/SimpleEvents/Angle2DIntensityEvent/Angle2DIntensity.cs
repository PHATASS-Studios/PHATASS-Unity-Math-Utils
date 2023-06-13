using IAngle2D = PHATASS.Utils.Types.Angles.IAngle2D;
namespace PHATASS.Utils.Events
{
//object containing information about a 2d-angled intensity value
	public struct Angle2DIntensity : IAngle2DIntensity
	{
	//IAngle2DIntensity
		IAngle2D IAngle2DIntensity.angle { get { return this._angle; }}
		float IAngle2DIntensity.intensity { get { return this._intensity; }}
	//ENDOF IAngle2DIntensity

	//constructor
		public Angle2DIntensity (float intensity, IAngle2D angle)
		{
			_intensity = intensity;
			_angle = angle;
		}
	//ENDOF constructor

	//private fields
		private float _intensity;
		private IAngle2D _angle;
	//ENDOF private
	}
}
using Mathf = UnityEngine.Mathf;

namespace PHATASS.Utils.MathUtils
{
	// Represents an angle, both accessible as degrees or radians
	// value is automatically clamped to 0-360 degrees (0 - 2pi rads)
	public class Angle2D : IAngle2D
	{
	//IAngle2D Implementation
		float IAngle2D.degrees
		{
			get { return this.degrees; }
			set { this.degrees = value; }
		}

		float IAngle2D.radians
		{
			get { return this.radians; }
			set { this.radians = value; }
		}
	//ENDOF IAngle2D

	//Constructor
		//constructor takes no parameters to avoid degrees/radians ambiguity
		//construction must be made through one of the properly named static factory methods
		public Angle2D () {}

		public static Angle2D FromDegrees (float degrees)
		{
			Angle2D angle = new Angle2D();
			angle.degrees = degrees;
			return angle;
		}

		public static Angle2D FromRadians (float radians)
		{
			Angle2D angle = new Angle2D();
			angle.radians = radians;
			return angle;
		}

		public static Angle2D FromAngle (Angle2D originalAngle)
		{
			Angle2D angle = new Angle2D();
			angle.degrees = originalAngle.degrees;
			return angle;
		}
	//ENDOF Constructor

	//private properties
		private float degrees
		{
			get { return this._degrees; }
			set { this._degrees = this.ClampDegrees(degrees); }
		}
		private float _degrees = 0.0f;

		private float radians
		{
			get { return this.degrees * Mathf.Deg2Rad; }
			set { this.degrees = value * Mathf.Rad2Deg; }
		}
	//ENDOF private properties

	//private methods
		private float ClampDegrees (float degrees)
		{
			float clampedDegrees = degrees % 360;

			//if initial degrees value was negative, clampedDegrees result will be negative and need to be wrapped upwards one last time
			if (clampedDegrees < 0) { clampedDegrees += 360; }

			return clampedDegrees;
		}
	//ENDOF private methods
	}
}
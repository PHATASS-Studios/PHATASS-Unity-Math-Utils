using Mathf = UnityEngine.Mathf;

namespace PHATASS.Utils.MathUtils
{
	// Represents an angle, both accessible as degrees or radians
	// value is automatically clamped to 0-360 degrees (0 - 2pi rads)
	public readonly struct Angle2D : IAngle2D
	{
	//IAngle2D Implementation
		float IAngle2D.degrees { get { return this.degrees; }}
		float IAngle2D.radians { get { return this.radians; }}
	//ENDOF IAngle2D

	//Constructor
		//no public constructor to avoid ambiguity between degrees and radians
		//construction must be made through one of the properly named static factory methods
		private Angle2D (float __degrees)
		{
			this._degrees = Angle2D.ClampDegrees(__degrees);
		}

		public static Angle2D FromDegrees (float degrees)
		{
			return new Angle2D(degrees);
		}

		public static Angle2D FromRadians (float radians)
		{
			return new Angle2D(radians * Mathf.Rad2Deg);
		}

		public static Angle2D FromAngle2D (Angle2D originalAngle)
		{
			return Angle2D.FromDegrees(originalAngle.degrees);
		}
	//ENDOF Constructor


	//public properties
		public float degrees { get { return this._degrees; }}
		public float radians {	get { return this.degrees * Mathf.Deg2Rad; }}

		private readonly float _degrees;
	//ENDOF public properties

	//private fields
	//private fields

	//private methods
		private static float ClampDegrees (float degrees)
		{
			float clampedDegrees = degrees % 360;

			//if initial degrees value was negative, clampedDegrees result will be negative and need to be wrapped upwards one last time
			if (clampedDegrees < 0) { clampedDegrees += 360; }

			return clampedDegrees;
		}
	//ENDOF private methods

	//Operator overrides
		public override string ToString () { return $"{this.degrees}°"; }

		// Negation operator
		public static Angle2D operator - (Angle2D angle)
		{ return Angle2D.FromDegrees(360 - angle.degrees); }

		// Addition operator
		public static Angle2D operator + (Angle2D a, Angle2D b)
		{ return Angle2D.FromDegrees(a.degrees + b.degrees); }

		// Subtraction operator
		public static Angle2D operator - (Angle2D a, Angle2D b)
		{ return Angle2D.FromDegrees(a.degrees - b.degrees); }

		// Multiplication operator
		public static Angle2D operator * (float a, Angle2D b)
		{ return Angle2D.FromDegrees(a * b.degrees); }
		public static Angle2D operator * (Angle2D a, float b)
		{ return Angle2D.FromDegrees(a.degrees * b); }

		// Division operator
		public static Angle2D operator / (Angle2D a, float b)
		{ return Angle2D.FromDegrees(a.degrees / b); }


		// Modulus operator
		public static Angle2D operator % (Angle2D a, Angle2D b)
		{ return Angle2D.FromDegrees(a.degrees % b.degrees); }
	//ENDOF Operators
	}
}
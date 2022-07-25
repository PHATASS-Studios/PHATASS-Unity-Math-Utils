namespace PHATASS.Utils.Types
{
	// Exposes properties and ways to manage a single angle
	// Degrees/radians must always be wrapped around the 0-360 degrees range
	public interface IAngle2D
	{
	//value accessors
		float degrees { get; }
		float radians { get; }

	//Mathematical operations
		IAngle2D Invert ();	//inverts the sign of the angle

		IAngle2D Add (IAngle2D angle);
		IAngle2D Subtract (IAngle2D angle);

		IAngle2D Multiply (float multiplier);
		IAngle2D Divide (float divisor);

		IAngle2D Modulus (IAngle2D divisor);



	// Operator overrides
		// Negation operator
		public static IAngle2D operator - (IAngle2D angle)
		{ return angle.Invert(); }

		// Addition operator
		public static IAngle2D operator + (IAngle2D a, IAngle2D b)
		{ return a.Add(b); }

		// Subtraction operator
		public static IAngle2D operator - (IAngle2D a, IAngle2D b)
		{ return a.Subtract(b); }

		// Multiplication operator
		public static IAngle2D operator * (IAngle2D a, float b)
		{ return a.Multiply(b); }

		// Division operator
		public static IAngle2D operator / (IAngle2D a, float b)
		{ return a.Divide(b); }

		// Modulus operator
		public static IAngle2D operator % (IAngle2D a, IAngle2D b)
		{ return a.Modulus(b); }
	//ENDOF Operator overrides
	}
}

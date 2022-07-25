namespace PHATASS.Utils.Types
{
	public static class IIAngle2DOperators
	{
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

		// ToString
		public static string ToString (this IAngle2D angle)
		{ return $"{angle.degrees}°"; }
	}
}
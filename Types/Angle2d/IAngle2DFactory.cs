namespace PHATASS.Utils.Types
{
	public static class IIAngle2DFactory
	{
	// Factory static methods
		public static IAngle2D FromDegrees (float degrees)
		{ return Angle2D.FromDegrees(degrees); }

		public static IAngle2D FromRadians (float radians)
		{ return Angle2D.FromRadians(radians); }

		public static IAngle2D FromAngle2D (Angle2D originalAngle)
		{
			return Angle2D.FromAngle2D(originalAngle);
		}

	// Extensions designed to transform floats into angle objects
		public static IAngle2D AsDegrees (this float degrees)
		{ return Angle2D.FromDegrees(degrees); }
		public static IAngle2D AsDegrees (this double degrees)
		{ return Angle2D.FromDegrees(degrees); }

		public static IAngle2D AsRadians (this float radians)
		{ return Angle2D.FromRadians(radians); }
		public static IAngle2D AsRadians (this double radians)
		{ return Angle2D.FromRadians(radians); }
	}
}
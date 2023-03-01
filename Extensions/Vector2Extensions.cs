using UnityEngine;

using IAngle2D = PHATASS.Utils.Types.Angles.IAngle2D;
using static PHATASS.Utils.Types.Angles.IAngle2DFactory;

namespace PHATASS.Utils.Extensions
{
	public static class Vector2Extensions
	{
	//Vector2 creation methods
		//Creates a Vector2 of length 1 representing given angle
		public static Vector2 EAngle2DToVector2 (this IAngle2D angle)
		{ return angle.degrees.EDegreesToVector2(); }
		//Creates a Vector2 of length 1 from given angle in degrees
		public static Vector2 EDegreesToVector2 (this float degrees)
		{
			return new Vector2 (Mathf.Cos(Mathf.Deg2Rad * degrees), Mathf.Sin(Mathf.Deg2Rad * degrees));
		}
	//ENDOF Vector2 creation methods

	//EDistanceTo2D
	// Returns the distance to another point in a 2D X,Y plane
		public static float EDistanceTo2D (this Vector2 originVector, Transform destinationTransform)
		{ return originVector.EDistanceTo2D((Vector2) destinationTransform.position); }
		public static float EDistanceTo2D (this Vector2 originVector, Vector3 destinationVector)
		{ return originVector.EDistanceTo2D((Vector2) destinationVector); }
		public static float EDistanceTo2D (this Vector2 originVector, Vector2 destinationVector)
		{
			return (originVector - destinationVector).magnitude;
		}

		// Vector3 alternatives - included here for implicit Vector3 accessibility
		public static float EDistanceTo2D (this Vector3 originVector, Transform destinationTransform)
		{ return ((Vector2)originVector).EDistanceTo2D(destinationTransform); }
		public static float EDistanceTo2D (this Vector3 originVector, Vector3 destinationVector)
		{ return ((Vector2)originVector).EDistanceTo2D((Vector2) destinationVector); }
		public static float EDistanceTo2D (this Vector3 originVector, Vector2 destinationVector)
		{ return ((Vector2)originVector).EDistanceTo2D((Vector2) destinationVector); }
	//ENDOF EDistanceTo2D

	//EFromToVector2
	// Returns a vector which added to fromVector results in toVector
		public static Vector2 EFromToVector2 (this Vector2 fromVector, Vector2 toVector)
		{
			return toVector - fromVector;
		}

		// Vector3 alternatives
		public static Vector2 EFromToVector2 (this Vector3 fromVector, Vector2 toVector)
		{
			return ((Vector2) fromVector).EFromToVector2(toVector);
		}
	//ENDOF EFromToVector2

	//EFromToVector2Normalized
	// Normalized (length 1) version of EFromToVector2()
		public static Vector2 EFromToVector2Normalized (this Vector2 fromVector, Vector2 toVector)
		{
			return fromVector.EFromToVector2(toVector).normalized;
		}

		// Vector3 alternatives
		public static Vector2 EFromToVector2Normalized (this Vector3 fromVector, Vector2 toVector)
		{
			return ((Vector2) fromVector).EFromToVector2Normalized(toVector);
		}
	//ENDOF EFromToVector2Normalized
	
	//EFromToDegrees2D
	// Returns the angular directiom from fromVector to toVector, in degrees
		public static float EFromToDegrees (this Vector2 fromVector, Vector2 toVector)
		{
			return Vector2.SignedAngle( //transform directional vector into a degrees value
				from: Vector2.right,
				to: fromVector.EFromToVector2Normalized(toVector) //generate a directional vector
			);
		}
	//ENDOF EFromToDegrees2D

	//EFromToAngle2D
	// Returns the angular directiom from fromVector to toVector
		public static IAngle2D EFromToAngle2D (this Vector2 fromVector, Vector2 toVector)
		{
			return fromVector.EFromToDegrees(toVector).EDegreesToAngle2D();
		}
	//ENDOF EFromToAngle2D

	//ESignedAngle
	// Returns Vector2.SignedAngle(a, b) but accessible as an extension method
		public static float ESignedAngle (this Vector2 fromVector, Vector2 toVector)
		{ return Vector2.SignedAngle(fromVector, toVector); }
	//ENDOF ESignedAngle
	}
}
using UnityEngine;

namespace PHATASS.Utils.Extensions
{
	public static class Vector2Extensions
	{
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
	// Returns the angular directiom from fromVector to toVector
		public static float EFromToDegrees2D (this Vector2 fromVector, Vector2 toVector)
		{
			return Vector2.SignedAngle( //transform directional vector into a degrees value
				from: Vector2.right,
				to: fromVector.EFromToVector2Normalized(toVector) //generate a directional vector
			);
		}
	//ENDOF EFromToDegrees

	//EDegreesToVector2
	// Returns a normalized (length 1) Vector2 representing the direction given in degrees
		public static Vector2 EDegreesToVector2 (this float degrees)
		{ 
			Vector2 vector = new Vector2(
				x: Mathf.Cos(degrees * Mathf.Deg2Rad),
				y: Mathf.Sin(degrees * Mathf.Deg2Rad)
			);

			Debug.Log("EDegreesToVector2(" + degrees + ") vector: " + vector + " length: " + vector.magnitude);
			return vector;
			//return new Vector2(Mathf.Cos(degrees * Mathf.Deg2Rad), Mathf.Sin(degrees * Mathf.Deg2Rad));
		}
	//ENDOF EDegreesToVector2

	//ESignedAngle
	// Returns Vector2.SignedAngle(a, b) but accessible as an extension method
		public static float ESignedAngle (this Vector2 fromVector, Vector2 toVector)
		{ return Vector2.SignedAngle(fromVector, toVector); }
	//ENDOF ESignedAngle
	}
}
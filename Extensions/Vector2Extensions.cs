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
	}
}
using UnityEngine;

namespace PHATASS.Utils.Extensions
{
	//methods for Rect manipulation
	public static class Vector3Extensions
	{
	//Vector3 arithmetic operations
		//multiplies two Vector3 component-wise
		public static Vector3 EMultiplyBy (this Vector3 dividend, Vector3 divisor)
		{
			return new Vector3(
				x: dividend.x * divisor.x,
				y: dividend.y * divisor.y,
				z: dividend.z * divisor.z
			);
		}

		//divides two Vector3 component-wise
		public static Vector3 EDivideBy (this Vector3 dividend, Vector3 divisor)
		{
			return new Vector3(
				x: dividend.x / divisor.x,
				y: dividend.y / divisor.y,
				z: dividend.z / divisor.z
			);
		}
	//ENDOF Vector3 arithmetic operations

	//Vector3 creation methods
		public static Vector3 EAngleToVector3 (this float angle)
		{
			return new Vector3 (Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle), 0);
		}
	//ENDOF Vector3 creation methods

	//Vector3 information methods
		public static float EComponentSum (this Vector3 vector)
		{
			return vector.x + vector.y + vector.z;
		}
	//ENDOF Vector3 information methods

	//EDistanceTo3D
	// Returns the distance to another point in a 3 dimensions
		public static float EDistanceTo3D (this Vector3 originVector, Vector3 destinationVector)
		{ return (originVector - destinationVector).magnitude; }

		//Type overloads
		public static float EDistanceTo3D (this Vector3 originVector, Transform destinationTransform)
		{ return originVector.EDistanceTo3D(destinationTransform.position); }
		public static float EDistanceTo3D (this Transform originTransform, Vector3 destinationVector)
		{ return originTransform.position.EDistanceTo3D(destinationVector); }
		public static float EDistanceTo3D (this Transform originTransform, Transform destinationTransform)
		{ return originTransform.position.EDistanceTo3D(destinationTransform.position); }
	//ENDOF EDistanceTo3D

	}
}
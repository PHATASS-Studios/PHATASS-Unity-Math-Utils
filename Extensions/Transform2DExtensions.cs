using UnityEngine;

namespace PHATASS.Utils.Extensions
{
	public static class Transform2DExtensions
	{
	//ELookAt2D
	// Rotates this transform so the +X axis is looking towards the target
		public static void ELookAt2D (this Transform transform, Transform targetTransform)
		{ transform.ELookAt2D(targetTransform.position); }
		public static void ELookAt2D (this Transform transform, Vector3 target)
		{ transform.ELookAt2D((Vector2) target); }
		public static void ELookAt2D (this Transform transform, Vector2 target)
		{
			//rotate the transform by making the right-hand vector (positive X axis) aim towards target position
			transform.right = new Vector3 (x: target.x, y: target.y, z: 0f) - transform.position;
		}
	//ENDOF ELookAt2D

	//EMoveTowards2D
	// Moves this transform in WORLD SPACE, towards target, by a maximum of distance units
		public static void EMoveTowards2D (this Transform transform, Transform targetTransform, float distance)
		{ transform.EMoveTowards2D(targetTransform.position, distance); }
		public static void EMoveTowards2D (this Transform transform, Vector3 target, float distance)
		{ transform.EMoveTowards2D((Vector2) target, distance); }
		public static void EMoveTowards2D (this Transform transform, Vector2 target, float distance)
		{
			//translation vector is the difference between positions, scaled to be the length given by distance
			transform.Translate(
				translation: (target - ((Vector2) transform.position)).normalized * distance,
				relativeTo: Space.World
			);
		}
	//ENDOF EMoveTowards2D
	}
}
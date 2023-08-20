#if UNITY_EDITOR

using System.Collections.Generic;

using Gizmos = UnityEngine.Gizmos;

using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using Color = UnityEngine.Color;

using static PHATASS.Utils.Enumerables.ConsecutivePairsEnumerables;

using IAngle2D = PHATASS.Utils.Types.Angles.IAngle2D;
using static PHATASS.Utils.Types.Angles.IAngle2DFactory;

namespace PHATASS.Utils.Types.Boundaries
{
	//Contains methods for drawing editor gizmos for IBoundary2D objects
	//Should only be called from MonoBehaviour.OnDrawGizmos() or OnDrawGizmosSelected()
	//Only accessible from #if UNITY_EDITOR blocks
	public static class IBoundary2DGizmos
	{
	//static const
		private const ushort outlinePoints = 48;//96;
		private static Color colorA = Color.white;
		private static Color colorB = Color.black;
	//ENDOF static const

	//public static methods
		public static void DoBoundaryGizmoFull (this IBoundary2D boundary, Vector3 zDepthVector = default(Vector3))
		{
			boundary.DoBoundaryGizmoOutline(zDepthVector);
			boundary.DoBoundaryGizmoCentralCross(zDepthVector);
		}

		public static void DoBoundaryGizmoOutline (this IBoundary2D boundary, Vector3 zDepthVector = default(Vector3))
		{
			foreach ((Vector2, Vector2) pointPair in boundary.EnumerateBoundaryPoints(outlinePoints).EToConsecutivePairs())
			{
				ToggleColor();
				Gizmos.DrawLine(
					from: zDepthVector + (Vector3) pointPair.Item1,
					to: zDepthVector + (Vector3) pointPair.Item2
				);
			}
		}

		public static void DoBoundaryGizmoCentralCross (this IBoundary2D boundary, Vector3 zDepthVector = default(Vector3))
		{
			ToggleColor();
			Gizmos.DrawLine(
				from: zDepthVector + (Vector3) boundary.PointAtAngleFromCenter(1, boundary.rotation + 0f.EDegreesToAngle2D()),
				to: zDepthVector + (Vector3) boundary.PointAtAngleFromCenter(1, boundary.rotation + 180f.EDegreesToAngle2D())
			);

			ToggleColor();
			Gizmos.DrawLine(
				from: zDepthVector + (Vector3) boundary.PointAtAngleFromCenter(1, boundary.rotation + 90f.EDegreesToAngle2D()),
				to: zDepthVector + (Vector3) boundary.PointAtAngleFromCenter(1, boundary.rotation + 270f.EDegreesToAngle2D())
			);
		}
	//ENDOF public static methods

	//private static methods
		private static void ToggleColor ()
		{
			if (Gizmos.color == colorA)
			{ Gizmos.color = colorB; }
			else
			{ Gizmos.color = colorA; }
		}
	//ENDOF private static methods
	}
}
#endif
using UnityEngine;

namespace PHATASS.Utils.MathUtils
{
	//methods for Rect manipulation
	public static class Vector3Extensions
	{
	//Vector3 creation methods
		public static Vector3 EAngleToVector3 (this float angle)
		{
			return new Vector3 (Mathf.Sin(angle), Mathf.Cos(angle), 0);
		}
	//ENDOF Vector3 creation methods
	}
}
using UnityEngine;

namespace PHATASS.Utils.Extensions
{
	//methods for Rect manipulation
	public static class Vector3Extensions
	{
	//Vector3 creation methods
		public static Vector3 EAngleToVector3 (this float angle)
		{
			return new Vector3 (Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle), 0);
		}
	//ENDOF Vector3 creation methods
	}
}
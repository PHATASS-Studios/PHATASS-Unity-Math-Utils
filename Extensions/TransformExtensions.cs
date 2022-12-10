using Transform = UnityEngine.Transform;

namespace PHATASS.Utils.Extensions
{
	public static class TransformExtensions
	{
		//deletes every child transform this transform is parent of
		public static void EDestroyAllChildren (this Transform transform)
		{
			for (int i = transform.childCount-1; i >= 0; i--)
			{ UnityEngine.Object.Destroy(transform.GetChild(i).gameObject); }
		}

		//deletes every child transform this transform is parent of
		public static void EDestroyImmediateAllChildren (this Transform transform)
		{
			for (int i = transform.childCount-1; i >= 0; i--)
			{ UnityEngine.Object.DestroyImmediate(transform.GetChild(i).gameObject); }
		}
	}
}

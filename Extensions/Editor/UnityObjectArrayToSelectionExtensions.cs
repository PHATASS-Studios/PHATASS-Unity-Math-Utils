using System.Collections.Generic;

using Selection = UnityEditor.Selection;

namespace PHATASS.Utils.Extensions.Editor
{
	public static class UnityObjectArrayToSelectionExtensions
	{
	//	These methods take lists of unity objects and selects them in the editor
		public static void ESetObjectListAsSelected (this IList<UnityEngine.Object> objectList)
		{
			UnityEngine.Object[] objectArray = new UnityEngine.Object[objectList.Count];
			objectList.CopyTo(objectArray, 0);
			Selection.objects = objectArray;
		}
	}
}
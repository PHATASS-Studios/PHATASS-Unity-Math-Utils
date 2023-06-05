using System.Collections.Generic;

using Selection = UnityEditor.Selection;
using Component = UnityEngine.Component;
using GameObject = UnityEngine.GameObject;

using static PHATASS.Utils.Enumerables.ComponentToGameObjectEnumerables;

namespace PHATASS.Utils.Extensions.Editor
{
	public static class UnityObjectArrayToSelectionExtensions
	{
//	Takes an enumeration of unity objects and sets them as selected in the editor
		public static void ESetUnityObjectsAsSelected (this IEnumerable<UnityEngine.Object> objectEnumerable)
		{
			Selection.objects = new List<UnityEngine.Object>(objectEnumerable).ToArray();
		}

// Selects the gameobjects received or the gameobjects containing given component list
		public static void ESetGameObjectsAsSelected (this IEnumerable<Component> componentEnumerable)
		{ componentEnumerable.EToGameObjects().ESetGameObjectsAsSelected(); }

		public static void ESetGameObjectsAsSelected (this IEnumerable<GameObject> gameObjectEnumerable)
		{ gameObjectEnumerable.ESetUnityObjectsAsSelected(); }
	}
}
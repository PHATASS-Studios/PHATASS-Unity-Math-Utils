using System.Collections.Generic;

using Debug = UnityEngine.Debug;

using Component = UnityEngine.Component;
using Vector3 = UnityEngine.Vector3;

namespace PHATASS.Utils.Extensions
{
	public static class ComponentExtensions
	{
		//finds and returns the 
		public static TComponent EFindClosestComponent <TComponent> (this IEnumerable<TComponent> componentList, Vector3 point)
			where TComponent : UnityEngine.Component
		{
			if (componentList == null)
			{
				Debug.LogWarning("EFindClosestComponent() no componentList provided");
				return null;
			}

			float closestDistance = float.MaxValue;
			TComponent closestComponent = null;
			foreach (TComponent component in componentList)
			{
				if (component == null) { continue; }

				float distance = Vector3.Distance(point, component.transform.position);
				if (distance < closestDistance)
				{
						closestComponent = component;
						closestDistance = distance;
				}
			}

			if (closestComponent == null) { Debug.LogWarning("EFindClosestComponent() list received contained a non-zero length array containing only null elements"); }

			return closestComponent;
		}
	}
}
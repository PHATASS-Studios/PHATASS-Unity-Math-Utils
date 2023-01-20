using UnityEngine;

using Type = System.Type;
using System.Reflection;	//PropertyInfo

namespace PHATASS.Utils.Extensions
{
	public static class ColliderConfigurationExtensions
	{
	//Constants
		private const string offsetPropertyName = "center";
		private static readonly BindingFlags defaultBindingFlags =
			BindingFlags.Instance |
			BindingFlags.Public |
			BindingFlags.SetProperty |
			BindingFlags.GetProperty;
	//ENDOF Constants

	//Collider property getters
		//extension method letting a 3d collider report its worldspace position
		//considers its offset property if it has one
		public static Vector3 EGetColliderAbsolutePosition (this Collider collider)
		{
			//return collider's transform position adding offset value if available
			return collider.transform.position + collider.EGetColliderTransformOffset();
		}

		//Reports the collider's component position offset in relation to the containing transform
		//returns Vector3.zero if collider sub-type doesn't declare a "center" property
		public static Vector3 EGetColliderTransformOffset (this Collider collider)
		{
			PropertyInfo offsetProperty = collider
				.GetType()					//fetch received collider's type signature
				.GetProperty(offsetPropertyName, defaultBindingFlags);	//try to fetch offset value property

			return (offsetProperty != null
						? (Vector3) offsetProperty.GetValue(collider)
						: Vector3.zero);
		}
	}
}
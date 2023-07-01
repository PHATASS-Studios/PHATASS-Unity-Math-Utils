using Transform = UnityEngine.Transform;
using Component = UnityEngine.Component;

namespace PHATASS.Utils.Extensions
{
//ExtensionMethods for UnityEngine.GameObject
// Class fragment containing shorthands for some GameObject extensions
//
	public static partial class TransformExtensions//GameObjectExtensionsShorthands
	{

//shorthands for GameObject extensions
	//Transform configuration extensions
		public static void ESetTagAndLayer (this Transform transform, string targetTag, int targetLayer)
		{ transform.gameObject.ESetTagAndLayer(targetTag: targetTag, targetLayer: targetLayer); }
	//ENDOF Transform configuration extensions

	//Component configuration methods
		//Ensures transform contains one component of type T and applies sample settings if received. Creates a new TComponent if one did not exist.
		//Returns the TComponent found or created.
		public static TComponent ESetupComponent <TComponent> (this Transform transform, TComponent sample)
			where TComponent: Component
		{ return transform.gameObject.ESetupComponent<TComponent>(sample); }

		public static TComponent ESetupComponent <TComponent> (this Transform transform)
			where TComponent: Component
		{ return transform.gameObject.ESetupComponent<TComponent>(); }

		//Simply creates a new component of type TComponent on target transform using the most adequate implementation
		public static TComponent ECreateComponent <TComponent> (this Transform transform)
			where TComponent: Component
		{ return transform.gameObject.ECreateComponent<TComponent>(); }
	//ENDOF Component configuration methods
	}
}

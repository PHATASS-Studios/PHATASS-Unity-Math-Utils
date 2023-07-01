using GameObject = UnityEngine.GameObject;
using Component = UnityEngine.Component;

namespace PHATASS.Utils.Extensions
{
//ExtensionMethods for UnityEngine.GameObject
// Class fragment containing methods to create, configure, and manage a GameObject's components
//
	public static partial class GameObjectExtensions//ComponentManagement
	{
	//Component configuration methods
		//Ensures transform contains one component of type T and applies sample settings if received. Creates a new TComponent if one did not exist.
		//Returns the TComponent found or created.
		public static TComponent ESetupComponent <TComponent> (this GameObject gameObject, TComponent sample)
			where TComponent: Component
		{
			if (sample == null) { return gameObject.ESetupComponent<TComponent>(); }
			return gameObject.ESetupComponent<TComponent>().EApplySettingsGeneric<TComponent>(sample);
		}
		public static TComponent ESetupComponent <TComponent> (this GameObject gameObject)
			where TComponent: Component
		{
			TComponent component = gameObject.GetComponent<TComponent>();
			
			if (component == null) { component = gameObject.ECreateComponent<TComponent>(); }
			return component;
		}

		//Simply creates a new component of type TComponent on target transform using the most adequate implementation
		public static TComponent ECreateComponent <TComponent> (this GameObject gameObject)
			where TComponent: Component
		{
			#if UNITY_EDITOR
				if (UnityEditor.EditorApplication.isPlaying) { return gameObject.AddComponent<TComponent>(); }
				else { return UnityEditor.ObjectFactory.AddComponent<TComponent>(gameObject); }
			#else
				return gameObject.AddComponent<TComponent>();
			#endif
		}
	//ENDOF Component configuration methods
	}
}

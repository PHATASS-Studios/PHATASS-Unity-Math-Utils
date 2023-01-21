using Transform = UnityEngine.Transform;
using Component = UnityEngine.Component;

namespace PHATASS.Utils.Extensions
{
	public static class TransformExtensions
	{
	//Transform configuration extensions
		public static void ESetTagAndLayer (this Transform transform, string targetTag, int targetLayer)
		{
			if (targetTag != null) { transform.gameObject.tag = targetTag; }
			if (targetLayer >= 0) { transform.gameObject.layer = targetLayer; }
		}
	//ENDOF Transform configuration extensions

	//Destruction methods
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
	//ENDOF Destruction methods

	//Component configuration methods
		//Ensures transform contains one component of type T and applies sample settings if received. Creates a new TComponent if one did not exist.
		//Returns the TComponent found or created.
		public static TComponent ESetupComponent <TComponent> (this Transform transform, TComponent sample)
			where TComponent: Component
		{
			if (sample == null) { return transform.ESetupComponent<TComponent>(); }
			return transform.ESetupComponent<TComponent>().EApplySettingsGeneric<TComponent>(sample);
		}
		public static TComponent ESetupComponent <TComponent> (this Transform transform)
			where TComponent: Component
		{
			TComponent component = transform.gameObject.GetComponent<TComponent>();
			
			if (component == null) { component = transform.ECreateComponent<TComponent>(); }
			return component;
		}

		//Simply creates a new component of type TComponent on target transform using the most adequate implementation
		public static TComponent ECreateComponent <TComponent> (this Transform transform)
			where TComponent: Component
		{
			#if UNITY_EDITOR
				if (UnityEditor.EditorApplication.isPlaying) { return transform.gameObject.AddComponent<TComponent>(); }
				else { return UnityEditor.ObjectFactory.AddComponent<TComponent>(transform.gameObject); }
			#else
				return transform.gameObject.AddComponent<TComponent>();
			#endif
		}
	//ENDOF Component configuration methods
	}
}

using System.Collections.Generic;
using IEnumerator = System.Collections.IEnumerator;
using IEnumerable = System.Collections.IEnumerable;
using IDisposable = System.IDisposable;

using static PHATASS.Utils.Enumerables.TypeCastedEnumerables;

using Component = UnityEngine.Component;
using GameObject = UnityEngine.GameObject;

namespace PHATASS.Utils.Enumerables
{
	public static class ComponentToGameObjectEnumerables
	{
// ComponentToGameObjectEnumerables
//	Encapsulates an IEnumerator<Component> as a IEnumerator<GameObject> returning each input Component's gameObject
//
//extension methods
		public static IEnumerable<GameObject> EToGameObjects (this IEnumerable<Component> enumerable)
		{ return new ComponentToGameObjectEnumerable(enumerable); }

		public static IEnumerable<GameObject> EToGameObjects (this IEnumerable<UnityEngine.Transform> enumerable)
		{ return enumerable.ETypeCast<Component>().EToGameObjects(); }
//ENDOF extension methods	

// IEnumerables/IEnumerators
		private struct ComponentToGameObjectEnumerator : IEnumerator<GameObject>
		{
		//IEnumerator
			object IEnumerator.Current { get { return this.enumerator.Current; }}
			bool IEnumerator.MoveNext () { return this.enumerator.MoveNext(); }
			void IEnumerator.Reset () { this.enumerator.Reset(); }
		//ENDOF IEnumerator

		//IEnumerator<GameObject>
			GameObject IEnumerator<GameObject>.Current { get { return this.currentGameObject; }}
		//ENDOF IEnumerator<GameObject>

		//IDisposable
			void IDisposable.Dispose () { (this.enumerator as IDisposable)?.Dispose(); }
		//ENDOF IDisposable

		//Constructor
			public ComponentToGameObjectEnumerator (IEnumerator<Component> enumerator)
			{ this.enumerator = enumerator; }
		//ENDOF Constructor

		//private
			private IEnumerator<Component> enumerator;

			private GameObject currentGameObject { get { return this.enumerator.Current?.gameObject; }}
		//ENDOF private
		}

		private struct ComponentToGameObjectEnumerable : IEnumerable<GameObject>
		{
			IEnumerator IEnumerable.GetEnumerator ()
			{ return new ComponentToGameObjectEnumerator(enumerable.GetEnumerator()); }

			IEnumerator<GameObject> IEnumerable<GameObject>.GetEnumerator ()
			{ return new ComponentToGameObjectEnumerator(enumerable.GetEnumerator()); }

			public ComponentToGameObjectEnumerable (IEnumerable<Component> enumerable)
			{ this.enumerable = enumerable; }

			private IEnumerable<Component> enumerable;
		}
	}
//ENDOF IEnumerables/IEnumerators
}
using System.Collections.Generic;
using IEnumerator = System.Collections.IEnumerator;
using IEnumerable = System.Collections.IEnumerable;
using IDisposable = System.IDisposable;

using Transform = UnityEngine.Transform;
using GameObject = UnityEngine.GameObject;

namespace PHATASS.Utils.Enumerables
{
	public static partial class TransformEnumerables
	{
// TransformToGameObjectEnumerables
//	Encapsulates an IEnumerator<Transform> as a IEnumerator<GameObject> returning each input transform's gameObject
//
//extension methods
		public static IEnumerable<GameObject> EToGameObjects (this IEnumerable<Transform> enumerable)
		{ return new TransformToGameObjectEnumerable(enumerable); }
//ENDOF extension methods	

// IEnumerables/IEnumerators
		private struct TransformToGameObjectEnumerator : IEnumerator<GameObject>
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
			public TransformToGameObjectEnumerator (IEnumerator<Transform> enumerator)
			{ this.enumerator = enumerator; }
		//ENDOF Constructor

		//private
			private IEnumerator<Transform> enumerator;

			private GameObject currentGameObject { get { return this.enumerator.Current?.gameObject; }}
		//ENDOF private
		}

		private struct TransformToGameObjectEnumerable : IEnumerable<GameObject>
		{
			IEnumerator IEnumerable.GetEnumerator ()
			{ return new TransformToGameObjectEnumerator(enumerable.GetEnumerator()); }

			IEnumerator<GameObject> IEnumerable<GameObject>.GetEnumerator ()
			{ return new TransformToGameObjectEnumerator(enumerable.GetEnumerator()); }

			public TransformToGameObjectEnumerable (IEnumerable<Transform> enumerable)
			{ this.enumerable = enumerable; }

			private IEnumerable<Transform> enumerable;
		}
	}
//ENDOF IEnumerables/IEnumerators
}
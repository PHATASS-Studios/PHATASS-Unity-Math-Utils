using System.Collections.Generic;
using System.Collections;
using IDisposable = System.IDisposable;

using GameObject = UnityEngine.GameObject;
using Joint = UnityEngine.Joint;

using static PHATASS.Utils.Extensions.JointExtensions; //EMJointToConnectedGameObject

namespace PHATASS.Utils.Enumerables
{
// Converts an enumeration of Joint components into an enumeration of their connected GameObject
	public static partial class JointEnumerables
	{
// extension methods
		public static IEnumerator<GameObject> EToConnectedGameObjects (this IEnumerator<Joint> enumerator)
		{ return new JointEnumeratorToConnectedGameObjectEnumerator(enumerator); }

		public static IEnumerable<GameObject> EToConnectedGameObjects (this IEnumerable<Joint> enumerable)
		{ return new JointEnumerableToConnectedGameObjectEnumerable(enumerable); }
//ENDOF extension methods

// IEnumerables/IEnumerators
		private struct JointEnumeratorToConnectedGameObjectEnumerator : IEnumerator<GameObject>
		{
		//IDisposable implementation
			void IDisposable.Dispose () { this.enumerator.Dispose(); }
		//ENDOF IDisposable implementation		

		//IEnumerator
			System.Object IEnumerator.Current { get { return this.Current; }}
			bool IEnumerator.MoveNext () { return this.enumerator.MoveNext(); }
			void IEnumerator.Reset () { this.enumerator.Reset(); }
		//ENDOF IEnumerator

		//IEnumerator<GameObject>
			GameObject IEnumerator<GameObject>.Current { get { return this.Current; }}
		//ENDOF IEnumerator<GameObject>

		//constructor
			public JointEnumeratorToConnectedGameObjectEnumerator (IEnumerator<Joint> enumerator)
			{ this.enumerator = enumerator; }
		//ENDOF constructor

		//private properties
			private GameObject Current
			{ get { return this.enumerator.Current?.EMJointToConnectedGameObject(); }}
		//ENDOF private properties

		//private fields
			private IEnumerator<Joint> enumerator;
		//ENDOF private fields
		}

		private struct JointEnumerableToConnectedGameObjectEnumerable : IEnumerable<GameObject>
		{
			IEnumerator IEnumerable.GetEnumerator ()
			{ return new JointEnumeratorToConnectedGameObjectEnumerator(enumerable.GetEnumerator()); }

			IEnumerator<GameObject> IEnumerable<GameObject>.GetEnumerator ()
			{ return new JointEnumeratorToConnectedGameObjectEnumerator(enumerable.GetEnumerator()); }

			public JointEnumerableToConnectedGameObjectEnumerable (IEnumerable<Joint> enumerable)
			{
				this.enumerable = enumerable;
			}

			private IEnumerable<Joint> enumerable;
		}
// IEnumerables/IEnumerators
	}
}
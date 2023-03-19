using System.Collections.Generic;
using System.Collections;

using static PHATASS.Utils.Enumerables.TypeCastedEnumerables;

using SerializedProperty = UnityEditor.SerializedProperty;

namespace PHATASS.Utils.Editor.Enumerables
{
// Enumerator that iterates over a SerializedProperty member values
//	For each sub-property, that sub-property's boxed value is returned
//	Includes methods that transform that enumerator into a list or array
	public static partial class SerializedPropertyEnumerables
	{
//extension methods
	// Array/list conversion methods
		public static T[] EToValueArray<T> (this SerializedProperty property)
		{ return property.EToValueList<T>().ToArray(); }

		public static List<T> EToValueList<T> (this SerializedProperty property)
		{ return new List<T>(property.EToValueEnumerable<T>()); }
	//ENDOF Array/list conversion methods

	// Enumerables
		public static IEnumerable EToValueEnumerable (this SerializedProperty property)
		{ return new SerializedPropertyToValueEnumerable(property); }

		public static IEnumerable<T> EToValueEnumerable<T> (this SerializedProperty property)
		{ return property.EToValueEnumerable().ETypeCast<T>(); }
	//ENDOF Enumerables
//ENDOF extension methods

// IEnumerables/IEnumerators
	// Enumerables
		private struct SerializedPropertyToValueEnumerable : IEnumerable
		{
			IEnumerator IEnumerable.GetEnumerator ()
			{ return new SerializedPropertyToValueEnumerator(this.property); }

			public SerializedPropertyToValueEnumerable (SerializedProperty property)
			{ this.property = property;	}

			private SerializedProperty property;
		}
	//ENDOF Enumerables

	// Enumerator
		private struct SerializedPropertyToValueEnumerator : IEnumerator
		{
		//IDisposable implementation
		//	void IDisposable.Dispose () { this.propertyEnumerator.Dispose(); }
		//ENDOF IDisposable implementation		

		//IEnumerator
			System.Object IEnumerator.Current { get { return this.current; }}
			bool IEnumerator.MoveNext () { return this.propertyEnumerator.MoveNext(); }
			void IEnumerator.Reset () { this.propertyEnumerator.Reset(); }
		//ENDOF IEnumerator

		//IEnumerator<T>
		//	T IEnumerator<T>.Current { get { return this.current; }}
		//ENDOF IEnumerator<T>

		//constructor
			public SerializedPropertyToValueEnumerator (SerializedProperty property)
			{
				this.propertyEnumerator = property.GetEnumerator().ETypeCast<SerializedProperty>();
			}
		//ENDOF constructor

		//private
			private System.Object current { get { return propertyEnumerator.Current.boxedValue; }}//this.property.GetArrayElementAtIndex(this.index); }}

			private IEnumerator<SerializedProperty> propertyEnumerator;
		//ENDOF private
		}
	//ENDOF Enumerator
// IEnumerables/IEnumerators
	}
}
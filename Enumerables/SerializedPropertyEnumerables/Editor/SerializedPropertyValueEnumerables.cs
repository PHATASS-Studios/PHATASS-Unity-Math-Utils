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
		{ return new SerializedPropertyValueEnumerable(property); }

		public static IEnumerable<T> EToValueEnumerable<T> (this SerializedProperty property)
		{ return property.EToValueEnumerable().ETypeCast<T>(); }
	//ENDOF Enumerables
//ENDOF extension methods

// IEnumerables/IEnumerators
	// Enumerables
		private struct SerializedPropertyValueEnumerable : IEnumerable
		{
			IEnumerator IEnumerable.GetEnumerator ()
			{ return new SerializedPropertyEnumeratorToValueEnumerator(this.property.GetEnumerator().ETypeCast<SerializedProperty>()); }

			public SerializedPropertyValueEnumerable (SerializedProperty property)
			{ this.property = property;	}

			private SerializedProperty property;
		}
	//ENDOF Enumerables

	// Enumerator
		private struct SerializedPropertyEnumeratorToValueEnumerator : IEnumerator
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
			public SerializedPropertyEnumeratorToValueEnumerator (IEnumerator<SerializedProperty> propertyEnumerator)
			{
				this.propertyEnumerator = propertyEnumerator;
				this.propertyEnumerator.Reset();
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
using System;	//Type.GetProperties
using System.Reflection; //BindingFlags
using System.Linq; //ienumerable.any

using UnityEngine;
//using Object = UnityEngine.Object;

//[TO-DO] [WARNING] Move dees to PHATASS.Utils
namespace PHATASS.Utils.Extensions
{
	public static class ComponentConfigurationExtensions
	{
	//constants
		//default binding flags
		private static readonly BindingFlags propertyBindingFlags =
			BindingFlags.Instance |
			BindingFlags.Public |
			BindingFlags.SetProperty |
			BindingFlags.GetProperty |
			BindingFlags.DeclaredOnly;

		/*
		private static readonly BindingFlags fieldBindingFlags =
			BindingFlags.Instance |
			BindingFlags.Public |
			BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;
		//*/

		private static readonly BindingFlags staticMethodBindingFlags =
			BindingFlags.NonPublic |
			BindingFlags.Static;
	//ENDOF constants

	//public static methods
		//applies right-hand properties to left-hand objects. returns reference to altered object
		public static T EApplySettingsGeneric <T> (this T _this, T sample) where T: Component
		{
			//*[DEBUG]*/ Debug.Log("EMApplySettings<" + typeof(T) + ">(" + _this + ", " + sample + ")");
			ApplySettingsRecursive<T>(_this, sample);
			return _this;
		}
	//ENDOF public static methods

	//private static methods
		//applies the properties of a single inheritance level and repeats until a class that directly inherits from component
		private static void ApplySettingsRecursive <T> (T _this, T sample) where T: Component
		{
			Type type = typeof(T);

			PropertyInfo[] properties = type.GetProperties(propertyBindingFlags);
			foreach (PropertyInfo property in properties)
			{
				ApplyProperty(property, _this, sample);
			}

			/*
			FieldInfo[] fields = type.GetFields(fieldBindingFlags);
			foreach (FieldInfo field in fields)
			{
				ApplyField(field, _this, sample);
			}
			//*/

			//if current object is NOT a component and base class is not component, reiterate with inherited class
			if (type != typeof(Component) && type.BaseType != typeof(Component))
			{
				PropagateApplySettingsRecursive<T>(_this, sample);
			}
		}

		private static void PropagateApplySettingsRecursive <T> (T _this, T sample) where T: Component
		{
			typeof(ComponentConfigurationExtensions)
				.GetMethod("ApplySettingsRecursive", staticMethodBindingFlags)
				.MakeGenericMethod(new Type[] {typeof(T).BaseType})
				.Invoke(null, new System.Object[] {_this, sample});
		}

		//copy the value of a field object from sample to target object
		private static void ApplyField (FieldInfo field, System.Object target, System.Object sample)
		{
			//*[DEBUG]*/ Debug.Log("----\nfield " + field);
			//if member is obsolete ignore it
			if (field.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(ObsoleteAttribute)))
			{ return; }

			field.SetValue(target, field.GetValue(sample));
			//*[DEBUG]*/ Debug.Log("  modified value: " + field.GetValue(target));
		}

		//copies the value of one specific property from sample to target object
		private static void ApplyProperty (PropertyInfo property, System.Object target, System.Object sample)
		{
			//*[DEBUG]*/ Debug.Log("----\nproperty " + property);

			//if member is obsolete ignore it
			if (property.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(ObsoleteAttribute)))
			{
				//*[DEBUG]*/ Debug.Log("  Property is obsolete");
				return;
			}

			//ignore read-only properties
			if (!property.CanWrite || !property.CanRead)
			{
				//*[DEBUG]*/ Debug.Log("  Property is not read/write");
				return;
			}

			/*
			//Debug.Log("attributes " + property.Attributes);
			//foreach (var attribute in property.Attributes) { Debug.Log("> " + attribute); }
			//Debug.Log("custom attributes: " + property.CustomAttributes);
			//foreach (var customAttribute in property.CustomAttributes) { Debug.Log("> " + customAttribute); }
			Debug.Log("  original value: " + property.GetValue(target));
			Debug.Log("  sample value: " + property.GetValue(sample));
			//*/
	
			if (property.GetIndexParameters().Length == 0)
			{
				ApplyPropertyNonIndexed(property, target, sample);
			}
			else 
			{
				ApplyPropertyIndexed(property, target, sample);	
			}

			//*[DEBUG]*/ Debug.Log("  modified value: " + property.GetValue(target));
		}
		private static void ApplyPropertyNonIndexed (PropertyInfo property, System.Object target, System.Object sample)
		{
			property.SetValue(target, property.GetValue(sample));
		}
		private static void ApplyPropertyIndexed (PropertyInfo property, System.Object target, System.Object sample)
		{
			Debug.LogWarning("!! ComponentConfigurerGeneric.ApplyPropertyIndexed() unimplemented - property \"" + property.Name + "\" ignored");
		}
	//ENDOF private static methods
	}
}

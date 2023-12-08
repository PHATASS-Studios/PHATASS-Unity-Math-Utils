using UnityEngine;

using PHATASS.Utils.Types.Values;

//using Angle2D = PHATASS.Utils.Types.Angles.Angle2D;
using IAngle2D = PHATASS.Utils.Types.Angles.IAngle2D;
using static PHATASS.Utils.Types.Angles.IAngle2DFactory;

using SerializedTypeRestrictionAttribute = PHATASS.Utils.Attributes.SerializedTypeRestrictionAttribute;

namespace PHATASS.Utils.Types.Values.ValueTools
{
// this behaviour exposes another value as an IAngle2D object
//	Exposes IAngle2DValue
	public abstract class BaseIAngle2DValueFromFloatValueBehaviour :
		MonoBehaviour,
		IAngle2DValue
	{
	//IAngle2DValue
		IAngle2D IValue<IAngle2D>.value { get { return this.value; }}
	//ENDOF IAngle2DValue

	//serialized fields
		[Tooltip("Reference to input IFloatValue. This float is transformed into an Angle2D object and exposed as an IAngle2DValue. REQUIRED.")]
		[SerializeField]
		[SerializedTypeRestriction(typeof(IFloatValue))]
		private UnityEngine.Object? _inputValue = null;
		private IFloatValue inputValue
		{ get {
			if (this._inputValue == null) { return null; }
			else { return this._inputValue as IFloatValue; }
		}}

		[Tooltip("What units is the source float value taken as.")]
		[SerializeField]
		private EAngleUnits inputUnitType;
		
		[Tooltip("Scale - Input value will be multiplied by this.")]
		[SerializeField]
		private float flatScale = 1f;

		[Tooltip("Scale IFloatValue source. IF this is given, inputValue is also multiplied by this. Fully optional.")]
		[SerializeField]
		[SerializedTypeRestriction(typeof(IFloatValue))]
		private UnityEngine.Object? _inputScaleValue = null;
		private IFloatValue inputScaleValue
		{ get {
			if (this._inputScaleValue == null) { return null; }
			else { return this._inputScaleValue as IFloatValue; }
		}}		
	//ENDOF serialized fields

	//properties
		private IAngle2D value
		{ get { return this.GetAngle(); }}
	//ENDOF properties

	//methods
		private IAngle2D GetAngle()
		{
			//check if input is properly assigned
			if (this.inputValue == null)
			{
				Debug.LogError(this.name + " IFloatValue source not set");
				return 0f.EDegreesToAngle2D();
			}

			//apply source value scaling
			float scaledInput = this.inputValue.value * this.flatScale;
			if (this.inputScaleValue != null)
			{ scaledInput = scaledInput * this.inputScaleValue.value; }

			//transform input value according to desired type and return
			if (this.inputUnitType == EAngleUnits.Degrees)
			{ return scaledInput.EDegreesToAngle2D(); }
			if (this.inputUnitType == EAngleUnits.Radians)
			{ return scaledInput.ERadiansToAngle2D(); }
			return (scaledInput * 360f).EDegreesToAngle2D();
		}
	//ENDOF methods

	//private classes
		private enum EAngleUnits
		{
			Degrees = 0,
			Radians = 1,
			FullRotations = 2
		}
	//ENDOF private classes
	}
}

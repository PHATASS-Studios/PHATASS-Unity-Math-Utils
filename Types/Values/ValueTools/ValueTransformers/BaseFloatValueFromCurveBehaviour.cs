using UnityEngine;
using PHATASS.Utils.Types.Values;

using SerializedTypeRestrictionAttribute = PHATASS.Utils.Attributes.SerializedTypeRestrictionAttribute;

namespace PHATASS.Utils.Types.Values.ValueTools
{
// this behaviour exposes a value that is dictated by a given curve, by taking the point in time T from a referenced IFloatValue
//	Exposes IFloatValue
	public abstract class BaseFloatValueFromCurveBehaviour :
		MonoBehaviour,
		IFloatValue
	{
	//IFloatValue
		float IValue<float>.value { get { return this.value; }}
	//ENDOF IFloatValue

	//serialized fields
		[Tooltip("Reference to input value. This input value will dictate what point T of the valueCurve will be used. This is mandatory.")]
		[SerializeField]
		[SerializedTypeRestriction(typeof(IFloatValue))]
		private UnityEngine.Object? _inputValue = null;
		private IFloatValue inputValue
		{ get {
			if (this._inputValue == null) { return null; }
			else { return this._inputValue as IFloatValue; }
		}}

		[Tooltip("Curve defining output value. Output value is equal to the curve's point T, given by inputValue.")]
		[SerializeField]
		private AnimationCurve valueCurve;
	//ENDOF serialized fields

	//properties
		private float value
		{ get {
			if (this.inputValue != null) { return this.valueCurve.Evaluate(this.inputValue.value); }
			else { return 0f; }
		}}
	//ENDOF properties
	}
}

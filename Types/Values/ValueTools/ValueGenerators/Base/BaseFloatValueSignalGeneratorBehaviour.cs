using UnityEngine;
//using PHATASS.Utils.Types.Values;

using SerializedTypeRestrictionAttribute = PHATASS.Utils.Attributes.SerializedTypeRestrictionAttribute;

namespace PHATASS.Utils.Types.Values.ValueTools
{
// signal float value generator. Inherit this to use in a behaviour.
	public abstract class BaseFloatValueSignalGeneratorBehaviour :
		BaseFloatValueBehaviour
	{
	//serialized fields
/*
		[Tooltip("Initial/current phase of the signal cycle, in DEGREES.")]
		[SerializeField]
		private Angle2D signalPhase;
*/
		[Tooltip("Peak value of this signal generator.")]
		[SerializeField]
		private float signalAmplitude = 1f;

		[Tooltip("Multiplier value for signalAmplitude. 1 if not assigned.")]
		[SerializeField]
		[SerializedTypeRestriction(typeof(IFloatValue))]
		private UnityEngine.Object? _signalAmplitudeMultiplier = null;
		private IFloatValue signalAmplitudeMultiplier
		{ get {
			if (this._signalAmplitudeMultiplier == null) { return null; }
			else { return this._signalAmplitudeMultiplier as IFloatValue; }
		}}

		[Tooltip("Frequency of this signal. A value of 1 means one full cycle each second.")]
		[SerializeField]
		private float signalFrequency = 1f;

		[Tooltip("Multiplier value for signalFrequency. 1 if not assigned.")]
		[SerializeField]
		[SerializedTypeRestriction(typeof(IFloatValue))]
		private UnityEngine.Object? _signalFrequencyMultiplier = null;
		private IFloatValue signalFrequencyMultiplier
		{ get {
			if (this._signalFrequencyMultiplier == null) { return null; }
			else { return this._signalFrequencyMultiplier as IFloatValue; }
		}}
	//ENDOF serialized

	//MonoBehaviour lifecycle
	//ENDOF MonoBehaviour

	//properties
		protected float amplitude
		{ get { return this.signalAmplitude * this.amplitudeMultiplier; }}
		
			private float amplitudeMultiplier
			{ get {
				if (this.signalAmplitudeMultiplier == null) { return 1f; }
				else { return this.signalAmplitudeMultiplier.value; }
			}}

		protected float frequency
		{ get { return this.signalFrequency * this.frequencyMultiplier; }}

			private float frequencyMultiplier
			{ get{
				if (this.signalFrequencyMultiplier == null) { return 1f; }
				else { return this.signalFrequencyMultiplier.value; }
			}}
	//ENDOF properties
	}
}

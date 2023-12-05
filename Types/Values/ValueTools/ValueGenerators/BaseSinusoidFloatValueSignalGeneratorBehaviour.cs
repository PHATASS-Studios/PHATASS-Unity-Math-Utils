using UnityEngine;
//using PHATASS.Utils.Types.Values;

using IAngle2D = PHATASS.Utils.Types.Angles.IAngle2D;
using Angle2D = PHATASS.Utils.Types.Angles.Angle2D;

using static PHATASS.Utils.Types.Angles.IAngle2DExtensions;
using static PHATASS.Utils.Types.Angles.IAngle2DFactory;

using SerializedTypeRestrictionAttribute = PHATASS.Utils.Attributes.SerializedTypeRestrictionAttribute;

namespace PHATASS.Utils.Types.Values.ValueTools
{
// signal float value generator. Inherit this to use in a behaviour.
//	Over time it generates a sinusoid signal exposed as IFloatValue.value, using the sine of an angle
	public abstract class BaseSinusoidFloatValueSignalGeneratorBehaviour : 
		BaseFloatValueSignalGeneratorBehaviour
	{
	//serialized fields
		[Tooltip("Initial/current phase of the signal cycle, in DEGREES. Value is the sine of the signalPhase angle (times amplitude and scale).")]
		[SerializeField]
		private Angle2D _signalPhase;
		private IAngle2D signalPhase
		{
			get { return this._signalPhase;	}
			set { if (value is Angle2D) { this._signalPhase = (Angle2D) value; }}
		}
	//ENDOF serialized

	//MonoBehaviour lifecycle
		private void Update ()
		{
			this.signalPhase += this.currentStep;
		}
	//ENDOF MonoBehaviour

	//overrides
		protected override float value
		{ get { return this.signalPhase.ESine(); }}
	//ENDOF overrides

	//properties
		private IAngle2D currentStep { get { return (360f.EDegreesToAngle2D()) * (this.frequency * Time.deltaTime); }}
	//ENDOF properties
	}
}

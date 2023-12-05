using UnityEngine;
using PHATASS.Utils.Types.Values;

namespace PHATASS.Utils.Types.Values.ValueTools
{
// base behaviour for any IFloatValue behaviour
//	Exposes IFloatValue
	public abstract class BaseFloatValueBehaviour :
		MonoBehaviour,
		IFloatValue
	{
	//IFloatValue
		float IValue<float>.value { get { return this.value; }}
		protected abstract float value { get; }		
	//ENDOF IFloatValue
	}
}

using UnityEngine;

namespace PHATASS.Utils.Types
{
	//Class handling the (de)serialization of the identifier for a UnityEngine.Animator variable name
	//this serializes the variable name as a string for editor purposes, then exposes the identifier as the more efficient hash
	[System.Serializable]
	public struct SerializableAnimatorVariableIdentifier :
		IAnimatorVariableIdentifier,
		ISerializationCallbackReceiver
	{
	//Serialized fields
		[SerializeField]
		private string variableName;
	//ENDOF Serialized fields

	//IAnimatorVariableIdentifier
		int IAnimatorVariableIdentifier.variableID { get { return this.variableID; }}
	//ENDOF IAnimatorVariableIdentifier

	//ISerializationCallbackReceiver
		//OnBeforeSerialize empty - no help needed with serialization
		void ISerializationCallbackReceiver.OnBeforeSerialize () {}

		//cache variable name's hash on deserialization
		void ISerializationCallbackReceiver.OnAfterDeserialize ()
		{ this.variableID = Animator.StringToHash(this.variableName); }
	//ENDOF ISerializationCallbackReceiver

	//private fields
		private int variableID;
	//ENDOF fields
	}
}
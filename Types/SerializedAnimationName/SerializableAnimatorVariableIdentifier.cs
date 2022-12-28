using UnityEngine;

namespace PHATASS.Utils.Types
{
	//Class handling the (de)serialization of the identifier for a UnityEngine.Animator variable name
	//this serializes the variable name as a string for editor purposes, then exposes the identifier as the more efficient hash
	[System.Serializable]
	public readonly struct SerializableAnimatorVariableIdentifier :
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
		void ISerializationCallbackReceiver.OnAfterDeserialize () { this.Init(this.variableName); }
	//ENDOF ISerializationCallbackReceiver

	//Operators
		public static implicit operator SerializableAnimatorVariableIdentifier(string name)
		{ return new SerializableAnimatorVariableIdentifier(name: name); }
	//ENDOF Operators

	//Constructor 
		public SerializableAnimatorVariableIdentifier (string name)
		{	
			this.variableName = name;
			this.Init(name);
		}
		private Init (string name)
		{ this.variableID = Animator.StringToHash(name); }
	//ENDOF Constructor

	//private fields
		private int variableID;
	//ENDOF fields
	}
}
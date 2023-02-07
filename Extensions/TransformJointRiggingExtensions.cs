using Debug = UnityEngine.Debug;

//using static PHATASS.Utils.Extensions.TransformExtensions;
//using static PHATASS.Utils.Extensions.JointConfigurationExtensions;

using Transform = UnityEngine.Transform;
using Rigidbody = UnityEngine.Rigidbody;

using Joint = UnityEngine.Joint;
using ConfigurableJoint = UnityEngine.ConfigurableJoint;
using ArticulationBody = UnityEngine.ArticulationBody;

namespace PHATASS.Utils.Extensions
{
	public static class TransformJointRiggingExtensions
	{
	//Joint search methods
		//finds a joint of type TJoint connected to target Transform or Rigidbody or ArticulationBody
		//returns null if target is not connected or non-existant
		public static TJoint EFindJointConnectingTo <TJoint> (this Transform transform, Transform target)
			where TJoint: Joint
		{
			if (target == null) { return transform.EFindJointConnectingTo<TJoint>(targetRigidbody: null); }

			Rigidbody rigidbody = target.GetComponent<Rigidbody>();
			ArticulationBody articulationBody = target.GetComponent<ArticulationBody>();


			if (rigidbody != null)
			{
				return transform.EFindJointConnectingTo<TJoint>(rigidbody);
			}
			else if (articulationBody != null)
			{
				return transform.EFindJointConnectingTo<TJoint>(articulationBody);
			}
			else //if (rigidbody == null && articulationBody == null) { return null; }
			{ return null; }
		}
		public static TJoint EFindJointConnectingTo <TJoint> (this Transform transform, Rigidbody targetRigidbody)
			where TJoint: Joint
		{
			//get a list of all the joints of type TJoint contained in the origin transform
			TJoint[] jointList = transform.GetComponents<TJoint>();
			//find a joint connected to target rigidbody and return it
			foreach (TJoint joint in jointList)
			{
				if (joint.connectedBody == targetRigidbody)
				{
					if (targetRigidbody == null && joint.connectedArticulationBody != null) { continue; }
					else { return joint; }
				}
			}
			return null;//return null if none found
		}
		public static TJoint EFindJointConnectingTo <TJoint> (this Transform transform, ArticulationBody targetArticulationBody)
			where TJoint: Joint
		{
			if (targetArticulationBody == null) { return transform.EFindJointConnectingTo<TJoint>(targetRigidbody: null); }
			//get a list of all the joints of type TJoint contained in the origin transform
			TJoint[] jointList = transform.GetComponents<TJoint>();
			//find a joint connected to target rigidbody and return it
			foreach (TJoint joint in jointList)
			{
				if (joint.connectedArticulationBody == targetArticulationBody)
				{ return joint; }
			}
			return null; //return null if none found
		}		
	//ENDOF Joint search methods

	//Joint creation methods
		//Finds or creates a joint from this transform to target transform/rigidbody, and applies sample settings
		public static TJoint ESetupJointConnectingTo <TJoint> (this Transform transform, Transform target, TJoint sample)
			where TJoint: Joint
		{
			if (target == null) { return transform.ESetupJointConnectingTo(targetRigidbody: null, sample); }
			Rigidbody rigidbody = target.GetComponent<Rigidbody>();

			if (rigidbody != null)
			{
				return transform.ESetupJointConnectingTo<TJoint>(rigidbody, sample);
			}
			else
			{
				return transform.ESetupJointConnectingTo(target.GetComponent<ArticulationBody>(), sample);
			}
		}
		public static TJoint ESetupJointConnectingTo <TJoint> (this Transform transform, Rigidbody targetRigidbody, TJoint sample)
			where TJoint: Joint
		{
			//validate input data and abort if necessary
			if (transform == null) { Debug.LogWarning("ESetupJointConnectingTo(): received null transform, can't create joint"); return null;}
			if (transform == targetRigidbody.transform) { Debug.LogWarning("ESetupJointConnectingTo(): Can't create a joint between an object and itself."); return null; }

			//first try to find a pre-existing joint of adequate type and connected target
			TJoint joint = transform.EFindJointConnectingTo<TJoint>(targetRigidbody);

			//if desired joint did not exist, create a new joint
			if (joint == null)
			{ joint = transform.ECreateComponent<TJoint>(); }

			//copy public properties from sample object. Try to use the more efficient ConfigurableJoint concretion if opossible
			if (typeof(TJoint) == typeof(ConfigurableJoint)) { (joint as ConfigurableJoint).EApplySettings(sample as ConfigurableJoint); }
			else { joint.EApplySettingsGeneric<TJoint>(sample); }

			//Connect the joint to the target
			joint.connectedBody = targetRigidbody;
			joint.connectedArticulationBody = null;

			return joint;
		}
		public static TJoint ESetupJointConnectingTo <TJoint> (this Transform transform, ArticulationBody targetArticulationBody, TJoint sample)
			where TJoint: Joint
		{
			//validate input data and abort if necessary
			if (transform == null) { Debug.LogWarning("ESetupJointConnectingTo(): received null transform, can't create joint"); return null;}
			if (transform == targetArticulationBody.transform) { Debug.LogWarning("ESetupJointConnectingTo(): Can't create a joint between an object and itself."); return null; }

			//first try to find a pre-existing joint of adequate type and connected target
			TJoint joint = transform.EFindJointConnectingTo<TJoint>(targetArticulationBody);

			//if desired joint did not exist, create a new joint
			if (joint == null)
			{ joint = transform.ECreateComponent<TJoint>(); }

			//copy public properties from sample object. Try to use the more efficient ConfigurableJoint concretion if opossible
			if (typeof(TJoint) == typeof(ConfigurableJoint)) { (joint as ConfigurableJoint).EApplySettings(sample as ConfigurableJoint); }
			else { joint.EApplySettingsGeneric<TJoint>(sample); }

			//Connect the joint to the target
			joint.connectedArticulationBody = targetArticulationBody;
			joint.connectedBody = null;

			return joint;
		}

		//Creates joints connecting both transforms.
		//If mutual = true, creates a spring from each transform. Otherwise, ensures no joint exists from transform2 to transform1 to avoid duplicity
		public static void ESetupJointInterconnection <TJoint> (this Transform transform1, Transform transform2, TJoint sample, bool mutual = false)
			where TJoint: Joint
		{
			if (transform1 == transform2) { return; }

			transform1.ESetupJointConnectingTo<TJoint>(transform2, sample);

			//if connection is mutual create the opposite joint. if not, ensure there is no opposite joint
			if (mutual) { transform2.ESetupJointConnectingTo<TJoint>(transform1, sample); }
			else { transform2.ERemoveJointConnectingTo<TJoint>(transform1); }
		}
	//ENDOF Joint creation methods

	//Joint removal methods
		//find and remove spring joint connected to target. if removeAll == false will only remove first joint. If true, will remove all joints connecting to target found
		public static void ERemoveJointConnectingTo <TJoint> (this Transform transform, Transform connectedTarget, bool removeAll = false)
			where TJoint: Joint
		{
			TJoint foundJoint = transform.EFindJointConnectingTo<TJoint>(connectedTarget);
			if (foundJoint != null) 
			{
				UnityEngine.Object.DestroyImmediate(foundJoint);
				if (removeAll) { transform.ERemoveJointConnectingTo<TJoint>(connectedTarget, removeAll); }
			}
		}
	//Joint removal methods
	}
}
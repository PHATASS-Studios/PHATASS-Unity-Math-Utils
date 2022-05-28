using Joint = UnityEngine.Joint;
using GameObject = UnityEngine.GameObject;
using Component = UnityEngine.Component;

namespace PHATASS.Utils.Extensions
{
	public static class JointExtensions
	{
	//returns a joint's connected Component (Rigidbody or ArticulationBody). Prioritizes RigidBody over ArticulationBody
		public static Component EMJointToConnectedComponent (this Joint joint)
		{
			if (joint.connectedBody != null) { return joint.connectedBody; }
			return joint.connectedArticulationBody;
		}

	//returns a joint's connected gameObject. Prioritizes RigidBody over ArticulationBody
		public static GameObject EMJointToConnectedGameObject (this Joint joint)
		{
			return joint.EMJointToConnectedComponent().gameObject;
		}
	}
}
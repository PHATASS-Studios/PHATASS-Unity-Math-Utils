using Joint = UnityEngine.Joint;

namespace PHATASS.Utils.Extensions
{
// Extensions for UnityEngine.Joint objects
//		sub-class dealing with a joint's anchor
	public static partial class JointExtensions //AnchorConfiguration
	{	
	//sets the anchors so they rest on the connected body's localspace 0,0,0
		public static Joint EMSetChainAnchor (
			this Joint joint
		) {
			joint.autoConfigureConnectedAnchor = false;
			joint.connectedAnchor = UnityEngine.Vector3.zero;
			joint.anchor = joint.transform.InverseTransformPoint(joint.connectedBody.transform.position);

			return joint;
		}
	}
}
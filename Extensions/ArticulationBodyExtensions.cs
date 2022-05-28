using ArticulationBody = UnityEngine.ArticulationBody;
using Transform = UnityEngine.Transform;

namespace PHATASS.Utils.Extensions
{
	public static class ArticulationBodyExtensions
	{
		//Returns the first parent articulationBody found. If this is the root returns null.
		public static ArticulationBody EMFindParentArticulationBody (this ArticulationBody self)
		{
			if (self.isRoot) { return null; }

			//search in our parent or any of its parents for an ArticulationBody
			return self.transform.parent.gameObject.GetComponentInParent<ArticulationBody>();
		}
	}
}
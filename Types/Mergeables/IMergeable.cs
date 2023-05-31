using System.Collections.Generic;

namespace PHATASS.Utils.Types.Mergeables
{
	//Mergeable object interface.
	//Can be merged with other objects of type TMergeable, and will return an object as TMergeable
	public interface IMergeable <TMergeable> : IMerger <TMergeable>
		where TMergeable : IMergeable <TMergeable>
	{
	}
}
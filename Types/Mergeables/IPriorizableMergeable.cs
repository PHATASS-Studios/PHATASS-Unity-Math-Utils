using PHATASS.Utils.Types.Priorizables;

namespace PHATASS.Utils.Types.Mergeables
{
	//interface for objects mergeable by their priority value
	//implements both IMergeable and IPriorizable
	//Can be merged with other objects of type TMergeable, and will return an object as TMergeable
	public interface IPriorizableMergeable <TMergeable> :
		IMergeable <TMergeable>,
		IPriorizable <TMergeable>
		where TMergeable : IMergeable <TMergeable>, IPriorizable <TMergeable>
	{
	}
}

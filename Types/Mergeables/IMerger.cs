using System.Collections.Generic;

namespace PHATASS.Utils.Types.Mergeables
{
	//interface representing an object capable of merging objects of type TMergeable
	//takes a list of TMergeable, and will return a TMergeable
	public interface IMerger <TMergeable>
		where TMergeable : IMergeable <TMergeable>
	{
		//Returns an object representing the combination of every object in a list  of mergeables
		TMergeable Merge (IList<TMergeable> mergeables);
		//[TO-DO] Maybe replace with an enumerator?
	}
}
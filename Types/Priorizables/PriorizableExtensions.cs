using System.Collections.Generic;

using System.Linq;

namespace PHATASS.Utils.Types.Priorizables
{
//collection of extension methods affection IPriorizable<T> objects
	public static class PriorizableExtensions
	{
		//Returns a NEW IList result of sorting input by their priority
		public static IList<TPriorizable> ESortByPriority <TPriorizable> (this IEnumerable<TPriorizable> input )
			where TPriorizable : IPriorizable<TPriorizable>
		{
			// IF PERFORMANCE PROBLEMS ARISE:
			// might need to find a way to sort in-place
			List<TPriorizable> output = new List<TPriorizable>(input); 
			
			output.Sort();
			//IList<T>.Order<T>() & IList<T>.OrderDescending<T>() are good alternates

			return output;
		}
/*
		//Returns a NEW IList inversely sorting input by priority
		public static IList<TPriorizable> ESortByPriorityInverse <TPriorizable> (this IEnumerable<TPriorizable> input )
			where TPriorizable : IPriorizable<TPriorizable>
			//[TO-DO]: maybe new implementation that sorts directly would be more efficient?
		{ return input.ESortByPriority().Reverse<TPriorizable>(); }
*/
	}
}
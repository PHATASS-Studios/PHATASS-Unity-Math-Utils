namespace PHATASS.Utils.Types.Priorizables
{
	//priorizable object interface.
	//allows comparison of provided objects based on priority value
	public interface IPriorizable <TPriorizable> :
		//System.IComparable,
		System.IComparable<TPriorizable>
		where TPriorizable : IPriorizable <TPriorizable>
	{
		//dictates this object's priority over other priorizables
		int priority {get;}
	}
}
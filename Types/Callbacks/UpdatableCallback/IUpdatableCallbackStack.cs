using PHATASS.Utils.Types.Mergeables;

namespace PHATASS.Utils.Callbacks
{
	//interface defining a container of a set of callbacks
	//two stacks can be merged, creating a new stack including both callbacks
	//SettingUpdatableCallbackStack is enumerable and iterating it returns every individual callback contained
	public interface IUpdatableCallbackStack
	:
		IUpdatableCallback,
		IPriorizableMergeable<IUpdatableCallbackStack>,
		System.Collections.Generic.IList<IUpdatableCallback>
	{}
}
namespace PHATASS.Utils.Attributes
{
	//attribute defining a field as a type-restricted field (by base class or by interface)
	[System.AttributeUsage(
		System.AttributeTargets.Field,
		AllowMultiple = false,
		Inherited = true
	)]
	public class SerializedTypeRestrictionAttribute : UnityEngine.PropertyAttribute
	{
		public System.Type typeRestriction { get; private set; }

	//attribute constructor
		public SerializedTypeRestrictionAttribute (System.Type typeRestriction)
		{ this.typeRestriction = typeRestriction; }
	//ENDOF attribute constructor
	}
}
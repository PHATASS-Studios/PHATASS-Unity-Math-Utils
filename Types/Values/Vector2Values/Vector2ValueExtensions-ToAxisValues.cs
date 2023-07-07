namespace PHATASS.Utils.Types.Values
{
//Extension methods for IVector2Value (IValue<Vector2>) and Vector2
//	Vector2 & IVector2 to single-axis IValue wrappers/accessors
	public static class IVector2ValueExtensions
	{
	//extension methods
		// Takes a Vector2 value and returns an IValue representing one of its axes
		public static IFloatValue EVector2ValueToAxisFloatValue (this IVector2Value vector2Value, Vector2Axis axis)
		{ return vector2Value.EVector2ValueToAxisAccessor(axis: axis); }

		public static IDoubleValue EVector2ValueToAxisDoubleValue (this IVector2Value vector2Value, Vector2Axis axis)
		{ return vector2Value.EVector2ValueToAxisAccessor(axis: axis); }
	
		//alternative overloads
		public static IFloatValue EVector2ValueToAxisFloatValue (this IVector2Value vector2Value, int axisIndex)
		{ return vector2Value.EVector2ValueToAxisFloatValue(axis: (Vector2Axis) axisIndex); }

		public static IDoubleValue EVector2ValueToAxisDoubleValue (this IVector2Value vector2Value, int axisIndex)
		{ return vector2Value.EVector2ValueToAxisDoubleValue(axis: (Vector2Axis) axisIndex); }
	//ENDOF extension methods

	//private extension methods
		private static IVector2ValueAxisAccessor EVector2ValueToAxisAccessor (this IVector2Value vector2Value, Vector2Axis axis)
		{
			//[TO-DO]: cache this result?
			return new IVector2ValueAxisAccessor(value: vector2Value, axis: axis);
		}
	//ENDOF private extension methods

	//support types
		private struct IVector2ValueAxisAccessor :
			IFloatValue,
			IDoubleValue
		{
		//IFloatValue
			float IValue<float>.value { get { return this.axisValue; }}
		//ENDOF IFloatValue

		//IDoubleValue
			double IValue<double>.value { get { return this.axisValue; }}
		//ENDOF IDoubleValue
			
		//constructor
			public IVector2ValueAxisAccessor (IVector2Value value, Vector2Axis axis)
			{
				this.vector2Value = value;
				this.vector2axis = axis;
			}

			public IVector2ValueAxisAccessor (IVector2Value value, int axisIndex)
			{
				this.vector2Value = value;
				this.vector2axis = (Vector2Axis) axisIndex;
			}
		//ENDOF constructor

		//private members
			private IVector2Value vector2Value;
			private Vector2Axis vector2axis;
			private int axisIndex { get { return (int) this.vector2axis; }}
			
			private float axisValue
			{ get { return this.vector2Value.value[this.axisIndex]; }}
		//ENDOF private
		}
	//ENDOF support types
	}
}
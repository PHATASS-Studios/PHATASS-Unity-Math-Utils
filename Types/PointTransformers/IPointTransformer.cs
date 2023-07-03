namespace PHATASS.Utils.Types.PointTransformers
{
// Interface representing any object capable of transforming an N-Dimensional vector between two spaces/reference frames
	public interface IPointTransformer <TDimensionalVector>
	{
	// Transforms a point from primary space ("world") into secondary ("reference") space
		TDimensionalVector TransformPoint (TDimensionalVector point);

	// Transforms a point from secondary space into primary space ("world")
		TDimensionalVector InverseTransformPoint (TDimensionalVector point);
	}
}
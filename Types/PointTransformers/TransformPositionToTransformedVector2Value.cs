using UnityEngine;

using IVector2Value = PHATASS.Utils.Types.Values.IVector2Value;
/*
#if UNITY_EDITOR
	using static PHATASS.Utils.Extensions.RectEditorExtensions;
#endif 
*/
namespace PHATASS.Utils.Types.PointTransformers
{
//PointTransformer that transforms between one rect's space and another
	[System.Serializable]
	public class TransformPositionToTransformedVector2Value :
		//RectSpaceToRectSpaceVector2PointTransformer,
		IVector2Value
	{
	//serialized fields
		[Tooltip("Transformer used to transform between world space and reference space")]
		[SerializeField]
		private RectSpaceVector2PointTransformer pointTransformer;

		[Tooltip("The position of this transform will be transformed as configured and exposed as IVector2Value.Value")]
		[SerializeField]
		private Transform originTransform;
	//ENDOF serialized fields

	//IVector2Value
		Vector2 PHATASS.Utils.Types.Values.IValue<Vector2>.value
		{ get { return this.transformedPosition; }}
	//ENDOF IVector2Value

	//private members
		private Vector2 currentPosition
		{ get { return this.originTransform.position; }}

		private Vector2 transformedPosition
		{ get {	return this.castedPointTransformer.TransformPoint(this.currentPosition); }}

		private IVector2PointTransformer castedPointTransformer { get { return this.pointTransformer; }}
	//ENDOF private

	//Constructor
		public TransformPositionToTransformedVector2Value (Transform transform, RectSpaceVector2PointTransformer transformer)
		{
			pointTransformer = transformer;
			originTransform = transform;
		}

		//construct from copy overload.
		//takes a sample object and creates a shallow copy. Optionally takes any of the base parameters, which will override the sample's values when given.
		public TransformPositionToTransformedVector2Value (
			TransformPositionToTransformedVector2Value sample,
			Transform? transform,
			RectSpaceVector2PointTransformer? transformer)
		{
			if (transform == null)
			{ originTransform = sample.originTransform; }
			else
			{ originTransform = (Transform) transform; }

			if (transformer == null)
			{ pointTransformer = sample.pointTransformer; }
			else
			{ pointTransformer = (RectSpaceVector2PointTransformer) transformer; }
		}
	//ENDOF Constructor


	//Editor gizmos
	/*#if UNITY_EDITOR
		public void DrawWorldSpaceRectGizmo ()
		{
			this.primarySpaceRect.EDrawGizmo(Color.Black);
		}
	#endif*/
	//ENDOF Editor gizmos
	}
}
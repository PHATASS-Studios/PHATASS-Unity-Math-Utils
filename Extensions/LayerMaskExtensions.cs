using Convert = System.Convert;

using LayerMask = UnityEngine.LayerMask;

namespace PHATASS.Utils.Extensions
{
	public static class LayerMaskExtensions
	{
		//returns this layer mask as a string of 0's and 1 for debug purposes
		public static string EToString (this LayerMask layerMask)
		{ return $"{Convert.ToString(layerMask.value, toBase: 2).PadLeft(32, '0'), 32}"; }

		//Determines wether layer index received is contained in this LayerMask
		public static bool EContainsLayer (this LayerMask layerMask, int layerIndex)
		{
			//if at least one bit is true in both the layer mask and desired layer index, the target layer is contained in the layer mask
			return (layerMask.value & (1 << layerIndex)) != 0;
		}

		//Determines wether the second layer mask is fully contained by the first. That means, every layer defined in the second mask is defined in the first mask
		public static bool EContainsLayerMask (this LayerMask outerLayerMask, LayerMask innerLayerMask)
		{
			//if every bit that is true for innerLayerMask is also true for outerLayerMask
			return (outerLayerMask.value & innerLayerMask.value) == innerLayerMask.value;
		}

		//Returns a new layer mask that contains every layer defined in both received layer masks
		public static LayerMask EIntersection (this LayerMask layerMaskA, LayerMask layerMaskB)
		{
			return (LayerMask) (layerMaskA.value & layerMaskB.value);
		}
	}
}

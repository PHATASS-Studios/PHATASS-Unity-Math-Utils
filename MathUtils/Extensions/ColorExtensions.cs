using Color = UnityEngine.Color;

using Debug = UnityEngine.Debug;

namespace PHATASS.Utils.MathUtils
{
	public static class ColorExtensions
	{
		//alters this color's hue by the given hue value (0.0f-1.0f)
		//if wrapAround = false hue doesn't automatically wrap around
		public static Color EChangeHue (this Color color, float step, bool wrapAround = true)
		{
			//get color's current HSV values
			float hue;
			float saturation;
			float value;
			Color.RGBToHSV(
				color,
				out hue,
				out saturation,
				out value
			);

			Debug.Log("In hue: " + hue);

			//alter desired HSV properties
			hue += step;
			if (wrapAround)
			{
				hue = hue % 1.0f;
			}

			Debug.Log("Out hue: " + hue);

			//re-store altered color as RGB
			Color updatedColor = Color.HSVToRGB(
				H: hue,
				S: saturation,
				V: value
			);

			updatedColor.a = color.a;

			return updatedColor;
		}
	}
}

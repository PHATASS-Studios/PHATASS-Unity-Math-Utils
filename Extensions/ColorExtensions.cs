using Color = UnityEngine.Color;

using Debug = UnityEngine.Debug;
using Mathf = UnityEngine.Mathf;

namespace PHATASS.Utils.Extensions
{
	public static class ColorExtensions
	{
	//HSV color notation getters
		public static float EGetHue (this Color color)
		{
			float hue, saturation, value;
			Color.RGBToHSV(color, out hue, out saturation, out value);
			return hue;
		}

		public static float EGetSaturation (this Color color)
		{
			float hue, saturation, value;
			Color.RGBToHSV(color, out hue, out saturation, out value);
			return saturation;
		}

		public static float EGetValue (this Color color)
		{
			float hue, saturation, value;
			Color.RGBToHSV(color, out hue, out saturation, out value);
			return value;
		}
	//ENDOF HSV getters

		//alters this color's hue by the given hue value (0.0f-1.0f)
		//if wrapAround = false hue doesn't automatically wrap around
		public static Color EChangeHue (this Color color, float step, bool wrapAround = true)
		{
			//get color's current HSV values
			float hue, saturation, value;
			Color.RGBToHSV(rgbColor: color, H: out hue, S: out saturation, V: out value);

			//alter desired HSV properties
			hue += step;
			if (wrapAround)
			{
				hue = hue % 1.0f;
			}

			//re-store altered color as RGB
			Color updatedColor = Color.HSVToRGB(H: hue, S: saturation, V: value);
			updatedColor.a = color.a;

			return updatedColor;
		}

		//Lerps this color's HUE towards target. lerpRate 0 keeps fromColor's original Hue, 1 uses new Hue
		public static Color ELerpHue (this Color fromColor, Color toColor, float lerpRate)
		{ return fromColor.ELerpHue(toHue: toColor.EGetHue(), lerpRate: lerpRate); }
		public static Color ELerpHue (this Color fromColor, float toHue, float lerpRate)
		{
			//get color's current HSV values
			float hue, saturation, value;
			Color.RGBToHSV(rgbColor: fromColor, H: out hue, S: out saturation, V: out value);

			//alter desired HSV properties
			hue = Mathf.Lerp(hue, toHue, lerpRate);

			//re-store altered color as RGB
			Color updatedColor = Color.HSVToRGB(H: hue, S: saturation, V: value);
			updatedColor.a = fromColor.a;

			return updatedColor;
		}

		//Lerps this color's VALUE towards target. lerpRate 0 keeps fromColor's original value, 1 uses new value
		public static Color ELerpValue (this Color fromColor, Color toColor, float lerpRate)
		{ return fromColor.ELerpValue(toValue: toColor.EGetValue(), lerpRate: lerpRate); }
		public static Color ELerpValue (this Color fromColor, float toValue, float lerpRate)
		{
			//get color's current HSV values
			float hue, saturation, value;
			Color.RGBToHSV(rgbColor: fromColor, H: out hue, S: out saturation, V: out value);

			//alter desired HSV properties
			value = Mathf.Lerp(value, toValue, lerpRate);

			//re-store altered color as RGB
			Color updatedColor = Color.HSVToRGB(H: hue, S: saturation, V: value);
			updatedColor.a = fromColor.a;

			return updatedColor;
		}

		//Lerps this color's saturation towards target. lerpRate 0 keeps fromColor's original, 1 uses new
		public static Color ELerpSaturation (this Color fromColor, Color toColor, float lerpRate)
		{ return fromColor.ELerpSaturation(toSaturation: toColor.EGetSaturation(), lerpRate: lerpRate); }
		public static Color ELerpSaturation (this Color fromColor, float toSaturation, float lerpRate)
		{
			//get color's current HSV values
			float hue, saturation, value;
			Color.RGBToHSV(rgbColor: fromColor, H: out hue, S: out saturation, V: out value);

			//alter desired HSV properties
			saturation = Mathf.Lerp(saturation, toSaturation, lerpRate);

			//re-store altered color as RGB
			Color updatedColor = Color.HSVToRGB(H: hue, S: saturation, V: value);
			updatedColor.a = fromColor.a;

			return updatedColor;
		}
	}
}

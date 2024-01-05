using UnityEngine;

using System.Runtime.InteropServices;

namespace PHATASS.Utils.ImageExporters
{
	public static class PngExporter
	{
	//plugin imports
	#if UNITY_EDITOR
		//unity editor doesn't export
	#elif UNITY_WEBGL
	    [DllImport("__Internal")]
    	private static extern void JSDownloadBase64PNG(string content, string filename);
    #endif
    //ENDOF plugin imports
//[TO-DO]:Sanitize
	//public static namespace
		public static void ExportAsPNG (Texture2D texture2d, string filename)
		{
		#if UNITY_EDITOR
			Debug.Log("PngExporter.ExportAsPng() does nothing in the editor lol");
		#elif UNITY_WEBGL
			Debug.Log("Downloading " + filename);
			JSDownloadBase64PNG(Texture2dToBase64PNG(texture2d), filename);
		#else
			Debug.LogWarning("PngExporter.ExportAsPng(): platform unsupported");
		#endif
		}
	//ENDOF public static namespace

	//private static
		private static string Texture2dToBase64PNG (Texture2D texture2d)
		{
			return System.Convert.ToBase64String(ImageConversion.EncodeToPNG(texture2d));
		}
	//ENDOF private static
	}
}
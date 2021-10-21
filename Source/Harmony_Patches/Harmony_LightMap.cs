using HarmonyLib;
using System;
using Verse;

namespace ProgressRenderer
{
	public static class Harmony_LightMap
	{
		public static void TryPatch(Harmony harmony)
		{
			try
			{
				var type = Type.GetType("LightMap.Main, LightMap");
				if (type != null)
				{
					harmony.Patch(
						AccessTools.Method(type, "UpdateMaps"),
						prefix: new HarmonyMethod(typeof(Harmony_LightMap), nameof(Harmony_LightMap.Prefix)));
				}
			}
			catch (Exception)
			{ }
		}

		public static bool Prefix()
		{
			return Find.CurrentMap?.GetComponent<MapComponent_RenderManager>()?.Rendering != true;
		}
	}
}

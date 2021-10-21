using HarmonyLib;
using System;
using Verse;

namespace ProgressRenderer
{
	public static class Harmony_HeatMap
	{
		public static void TryPatch(Harmony harmony)
		{
			try
			{
				var type = Type.GetType("HeatMap.Main, HeatMap");
				if (type != null)
				{
					harmony.Patch(
						AccessTools.Method(type, "UpdateHeatMap"),
						prefix: new HarmonyMethod(typeof(Harmony_HeatMap), nameof(Harmony_HeatMap.Prefix)));
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

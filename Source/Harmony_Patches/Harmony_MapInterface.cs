using HarmonyLib;
using RimWorld;
using System;
using Verse;

namespace ProgressRenderer
{
	[HarmonyPatch(typeof(MapInterface))]
	[HarmonyPatch(nameof(MapInterface.MapInterfaceUpdate))]
	public static class Harmony_MapInterface
	{
		[HarmonyPriority(Priority.High)]
		public static bool Prefix()
		{
			return Find.CurrentMap?.GetComponent<MapComponent_RenderManager>()?.Rendering != true;
		}
	}
}

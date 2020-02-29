using System.Diagnostics;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace ProgressRenderer
{

    [StaticConstructorOnStartup]
    class HarmonySetup
    {
        static HarmonySetup()
        {
            var harmony = new Harmony("rimworld.neptimus7.progressrenderer");
            Harmony.DEBUG = true;
            harmony.PatchAll(Assembly.GetExecutingAssembly());            
        }
    }
}

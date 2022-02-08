using HarmonyLib;
using Locks2.Core;
using RimWorld;
using Verse;

namespace Locks2.Harmony
{
    [HarmonyPatch(typeof(Building_Bed), nameof(Building_Bed.SpawnSetup))]
    public class Building_Bed_SpawnSetup_Patch
    {
        public static void Postfix(Map map)
        {
            map?.reachability?.cache?.Clear();
            LockConfig.Notify_Dirty();
        }
    }

    [HarmonyPatch(typeof(Building_Bed), nameof(Building_Bed.DeSpawn))]
    public class Building_Bed_DeSpawn_Patch
    {
        public static void Prefix(Building_Bed __instance)
        {
            __instance.Map?.reachability?.cache?.Clear();
            LockConfig.Notify_Dirty();
        }
    }
}
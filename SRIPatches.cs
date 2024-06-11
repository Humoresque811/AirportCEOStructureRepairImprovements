using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace AirportCEOStructureRepairImprovements;

[HarmonyPatch]
public static class SRIPatches
{
    [HarmonyPatch(typeof(RunwayModel), "UseObject")]
    public static void Prefix(RunwayModel __instance, ref float multiplier)
    {
        __instance.repairAt = SRIConfig.StructureRepairLevel.Value;

        multiplier /= SRIConfig.StructureRepairLevel.Value;
    }


    [HarmonyPatch(typeof(StandModel), "UseObject")]
    public static void Prefix(StandModel __instance, ref float multiplier)
    {
        multiplier /= SRIConfig.StructureRepairLevel.Value;
    }


    [HarmonyPatch(typeof(StandModel), "RepairAt", MethodType.Getter)]
    [HarmonyPrefix]
    public static bool StructureRepairMod2(StandModel __instance, ref float __result)
    {
        __result = SRIConfig.StructureRepairLevel.Value;
        return false;
    }
}

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
    public static void Prefix(RunwayModel __instance)
    {
        __instance.repairAt = SRIConfig.StructureRepairLevel.Value;
    }

    [HarmonyPatch(typeof(StandModel), "RepairAt", MethodType.Getter)]
    public static bool Prefix(StandModel __instance, ref float __result)
    {
        __result = SRIConfig.StructureRepairLevel.Value;
        return false;
    }
}

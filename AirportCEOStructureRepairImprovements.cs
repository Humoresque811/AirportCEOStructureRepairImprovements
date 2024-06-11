using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace AirportCEOStructureRepairImprovements;

[BepInPlugin("org.airportceostructurerepairimprovements.humoresque", "AirportCEO Structure Repair Improvements", PluginInfo.PLUGIN_VERSION)]
[BepInDependency("org.airportceomodloader.humoresque")]
public class AirportCEOStructureRepairImprovements : BaseUnityPlugin
{
    public static AirportCEOStructureRepairImprovements Instance { get; private set; }
    internal static Harmony Harmony { get; private set; }
    internal static ManualLogSource SRILogger { get; private set; }
    internal static ConfigFile ConfigReference {  get; private set; }

    private void Awake()
    {
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        Harmony = new Harmony(PluginInfo.PLUGIN_GUID);
        Harmony.PatchAll(); 

        Instance = this;
        SRILogger = Logger;
        ConfigReference = Config;

        // Config
        Logger.LogInfo($"{PluginInfo.PLUGIN_GUID} is setting up config.");
        SRIConfig.SetUpConfig();
        Logger.LogInfo($"{PluginInfo.PLUGIN_GUID} finished setting up config.");

    }
}

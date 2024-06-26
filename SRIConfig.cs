﻿using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportCEOStructureRepairImprovements;

internal class SRIConfig
{
    internal static ConfigEntry<float> StructureRepairLevel { get; private set; }
    internal static ConfigEntry<float> ConcreteDurabilityMultiplier { get; private set; }

    internal static void SetUpConfig()
    {
        StructureRepairLevel = AirportCEOStructureRepairImprovements.ConfigReference.Bind("General", "Structure Repair Level", 0.75f, 
            new ConfigDescription("Level (0-1) that structures should be repaired at. Vanilla is 0.25", new AcceptableValueRange<float>(0, 1)));
        ConcreteDurabilityMultiplier = AirportCEOStructureRepairImprovements.ConfigReference.Bind("General", "Concrete Durability Multiplier", 2f,
            new ConfigDescription("Multiplier for the durability of concrete stands and runways", new AcceptableValueRange<float>(1, 4)));
    }
}

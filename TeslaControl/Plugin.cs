using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TeslaControl
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance { get; private set; }

        public ConfigEntry<string> TeslaIgnoreRoles;
        public ConfigEntry<bool> IsTeslaIgnoreCuffedPlayers;

        private static Harmony Harmony;

        public void Awake()
        {
            Instance = this;

            TeslaIgnoreRoles = Config.Bind("General", "TeslaIgnoreRoles",
                "Scientist, FacilityGuard, NtfCadet, NtfLieutenant, NtfCommander",
                "Roles that the Tesla gate should ignore.");

            IsTeslaIgnoreCuffedPlayers = Config.Bind("General", "IsTeslaIgnoreCuffedPlayers", true,
                "If true, Tesla gates will ignore cuffed (handcuffed) players and won't trigger on them.");

            Harmony = new Harmony("tajmod.tesla-control");
            Harmony.PatchAll();
        }

        public void OnDestroy()
        {
            Harmony.UnpatchSelf();
            Harmony = null;
            Instance = null;
        }

        public List<RoleType> GetAllowedRoles()
        {
            return TeslaIgnoreRoles.Value
                .Split(',')
                .Select(r => Enum.TryParse<RoleType>(r, true, out var role) ? role : (RoleType?)null)
                .Where(r => r.HasValue)
                .Select(r => r.Value)
                .ToList();
        }
    }
}

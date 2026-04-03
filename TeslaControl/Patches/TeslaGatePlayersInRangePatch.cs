using HarmonyLib;
using System.Collections.Generic;

namespace TeslaControl.Patches
{
    [HarmonyPatch(typeof(TeslaGate), nameof(TeslaGate.PlayersInRange))]
    public class TeslaGatePlayersInRangePatch
    {
        private static void Postfix(ref PlayerStats[] __result)
        {
            if (__result == null || __result.Length == 0)
                return;

            var ignoreRoles = Plugin.Instance.GetAllowedRoles();
            var ignoreCuffedSetting = Plugin.Instance.IsTeslaIgnoreCuffedPlayers.Value;

            PlayerStats[] original = __result;
            List<PlayerStats> newResult = new List<PlayerStats>(original.Length);
            for (int i = 0; i < original.Length; i++)
            {
                PlayerStats player = original[i];
                if (!ignoreRoles.Contains(player.ccm.curClass) && (ignoreCuffedSetting && !player.hub.playerInteract.IsCuffed()))
                    newResult.Add(player);
            }

            __result = newResult.ToArray();
        }
    }
}

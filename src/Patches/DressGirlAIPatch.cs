using HarmonyLib;

namespace GirlBegone.Patches
{
    [HarmonyPatch(typeof(DressGirlAI))]
    internal class DressGirlAIPatch
    {
        [HarmonyPatch(typeof(DressGirlAI), "Start")]
        [HarmonyPostfix]
        static void fuckGirlPatch(DressGirlAI __instance)
        {
            __instance.KillEnemyOnOwnerClient(true);

            GirlBegone.Log.LogInfo("Killed Girl");
        }
    }
}

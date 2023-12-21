using HarmonyLib;

namespace GirlBegone.Patches
{
    [HarmonyPatch]    
    internal class RoundManagerPatcher
    {
        /// <summary>
        /// Prevent any girls from spawning by pretending that they're too powerful for the current conditions.
        /// This happens during a server-only planning stage so this works even if clients do not have the mod.
        /// </summary>
        [HarmonyPostfix]
        [HarmonyPatch(typeof(RoundManager), "EnemyCannotBeSpawned")]
        private static void PreventGirlSpawns(RoundManager __instance, ref bool __result, int enemyIndex)
        {
            var enemy = __instance.currentLevel.Enemies[enemyIndex];
            if (enemy.enemyType.enemyName.ToLower().Contains("girl"))
            {                
                GirlBegone.Log.LogInfo("Prevented girl spawn.");
                __result = true;
            }
        }
    }
}
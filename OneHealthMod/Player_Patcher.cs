using Harmony;
using UnityEngine;


namespace OneHealthMod
{
    [HarmonyPatch(typeof(Player))]  // We're patching the Player class.
    [HarmonyPatch("Start")]         // The Player class's Start method specifically.
    internal class Player_Start_Patch
    {
        [HarmonyPostfix]            // Run this after the default game's Player Start method runs.
        public static void Postfix(Player __instance)
        {
            // flag if the mod should be applied
            bool doMod = false;

            // do we have our option?
            bool optionExists = PlayerPrefs.HasKey("ActivateOneHealthMod");
            if (optionExists)
            {
                // and is it active?
                doMod = (PlayerPrefs.GetInt("ActivateOneHealthMod") == 1);
            }

            // if the option is active, can we change the health
            if (doMod && __instance.liveMixin)
            {
                // then reduce the health to 1
                __instance.liveMixin.health = 1f;
                Debug.Log("[OneHealthMod] liveMixin.health set to 1f");
            }
            else
            {
                Debug.Log("[OneHealthMod] liveMixin does not exist");
            }
        }
    }
}

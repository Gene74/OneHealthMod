using System.Reflection;
using Harmony;
using SMLHelper.V2.Handlers;
using UnityEngine;

namespace OneHealthMod
{
    public class MainPatcher
    {
        public static void Patch()
        {
            // Show the option for this mod in the Game Options
            var modOption = new OneHealthModOptions("One Health Mod");
            OptionsPanelHandler.RegisterModOptions(modOption);

            /*<--- Bugfix: The Game remembers this Options Setting but it was not showing */
            if (PlayerPrefs.HasKey("ActivateOneHealthMod"))
            {
                modOption.SetIsActive(PlayerPrefs.GetInt("ActivateOneHealthMod") == 1);
            }
            /* Bugfix --->*/


            // Inject the code extension to the Player Object
            var harmony = HarmonyInstance.Create("com.gene74.subnautica.onehealthmod.mod");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}

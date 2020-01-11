using System;
using SMLHelper.V2.Options;
using UnityEngine;


namespace OneHealthMod
{
    public class OneHealthModOptions : ModOptions
    {
        // Flag for remembering if the option has been activated
        public static bool isActive = false;

        // Add Event that is triggered if the option is changed
        public OneHealthModOptions(string name) : base(name)
        {
            base.ToggleChanged += OneHealthModOptions.OptionChanged;
        }

        public override void BuildModOptions()
        {
            base.AddToggleOption("ActivateOneHealthMod", "Keep HP at Minimum", isActive);
        }

        // Event that gets triggered if the optin is changed
        public static void OptionChanged(object sender, ToggleChangedEventArgs args)
        {
            // has "our" option been changed?
            if (args.Id == "ActivateOneHealthMod")
            {
                // read the set option value
                isActive = args.Value;

                // also set this in the PlayerPrefs
                PlayerPrefs.SetInt("ActivateOneHealthMod", isActive ? 1 : 0);
            }
        }

        /*<--- Bugfix: needed to manually correct the setting. See MainPatcher.cs */
        public void SetIsActive(bool val)
        {
            isActive = val;
        }
        /* End Bugfix --->*/
    }
}

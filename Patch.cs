using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Aki.Reflection.Patching;
using Comfort.Common;
using EFT;
using EFT.Interactive;
using EFT.InventoryLogic;
using EFT.UI;
using EFT.UI.DragAndDrop;
using HarmonyLib;
using BepInEx.Configuration;
using BepInEx;

namespace ZeroingQOL
{

    public class DefAmmoPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return typeof(WeaponTemplate).GetMethod("get_DefAmmoTemplate", BindingFlags.Instance | BindingFlags.Public);

        }


        [PatchPrefix]
        private static bool Prefix(WeaponTemplate __instance, ref AmmoTemplate __result)
        {
            AmmoTemplate defAmmo = (Singleton<ItemFactory>.Instance.ItemTemplates[__instance.defAmmo] as AmmoTemplate);
            string caliber = defAmmo.Caliber;

            if (AmmoDictionaries.DictionaryCollection.TryGetValue(caliber, out Dictionary<string, string> ammoDictionary))
            {
                if (Plugin.ConfigCollection.TryGetValue(caliber, out ConfigEntry<string> configEntry))
                {
                    string configValueToUse = configEntry.Value;
                    if (ammoDictionary.TryGetValue(configValueToUse, out string ammoId))
                    {
                        AmmoTemplate newDefAmmo = (Singleton<ItemFactory>.Instance.ItemTemplates[ammoId] as AmmoTemplate);
                        __result = newDefAmmo;
                        return false;
                    }
                    else
                    {
                        Logger.LogError($"Cannot find ammo ID with key: {configValueToUse}");
                    }
                }
                else
                {
                    Logger.LogError($"Cannot find config entry with key: {caliber}");
                }
            }
            else
            {
                Logger.LogError($"Cannot find dictionary with key: {caliber}");
            }

            __result = defAmmo;
            return false;
        }
    } 
}
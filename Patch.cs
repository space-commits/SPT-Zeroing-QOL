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
using Aki.Reflection.Utils;

namespace ZeroingQOL
{

    public class DefAmmoPatch : ModulePatch
    {
        private static Type _ItemFactoryType;
        private static Type _WeaponTemplateType;
        private static Type _AmmoTemplateType;

        private static FieldInfo _WeaponTemplateDefAmmoField;
        private static FieldInfo _ItemFactoryItemTemplatesField;
        private static FieldInfo _AmmoTemplateCaliberField;

        private static MethodInfo _ItemFactoryInstanceGetter;

        protected override MethodBase GetTargetMethod()
        {
            _ItemFactoryType = PatchConstants.EftTypes.Single(x => x.GetMethod("GetDiscardLimits") != null);
            _WeaponTemplateType = PatchConstants.EftTypes.Single(x => x.GetField("_defAmmoTemplate", BindingFlags.Instance | BindingFlags.NonPublic) != null);
            _AmmoTemplateType = PatchConstants.EftTypes.Single(x => x.GetMethod("GetCachedReadonlyQualities") != null);

            _WeaponTemplateDefAmmoField = AccessTools.Field(_WeaponTemplateType, "defAmmo");
            _ItemFactoryItemTemplatesField = AccessTools.Field(_ItemFactoryType, "ItemTemplates");
            _AmmoTemplateCaliberField = AccessTools.Field(_AmmoTemplateType, "Caliber");

            Type ItemFactorySingletonType = typeof(Singleton<>).MakeGenericType(_ItemFactoryType);
            _ItemFactoryInstanceGetter = AccessTools.PropertyGetter(ItemFactorySingletonType, "Instance");

            return AccessTools.Method(_WeaponTemplateType, "get_DefAmmoTemplate");
        }


        [PatchPrefix]
        private static bool Prefix(object __instance, ref object __result)
        {
            var itemFactory = _ItemFactoryInstanceGetter.Invoke(null, null);

            var defAmmoName = _WeaponTemplateDefAmmoField.GetValue(__instance) as string;
            var itemTemplates = _ItemFactoryItemTemplatesField.GetValue(itemFactory) as IDictionary;

            var defAmmo = itemTemplates[defAmmoName];
            var caliber = _AmmoTemplateCaliberField.GetValue(defAmmo) as string;

            if (AmmoDictionaries.DictionaryCollection.TryGetValue(caliber, out Dictionary<string, string> ammoDictionary))
            {
                if (Plugin.ConfigCollection.TryGetValue(caliber, out ConfigEntry<string> configEntry))
                {
                    string configValueToUse = configEntry.Value;
                    if (ammoDictionary.TryGetValue(configValueToUse, out string ammoId))
                    {
                        var newDefAmmo = itemTemplates[ammoId];
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
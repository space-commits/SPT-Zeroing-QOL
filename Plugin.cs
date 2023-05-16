using BepInEx;
using BepInEx.Configuration;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using System;
using Newtonsoft.Json.Linq;

namespace ZeroingQOL
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {

        public static ConfigEntry<string> _556x45 { get; set; }
        public static ConfigEntry<string> _545x39 { get; set; }
        public static ConfigEntry<string> _300blk { get; set; }
        public static ConfigEntry<string> _9x39 { get; set; }
        public static ConfigEntry<string> _366tkm { get; set; }
        public static ConfigEntry<string> _762x39 { get; set; }
        public static ConfigEntry<string> _127x55 { get; set; }
        public static ConfigEntry<string> _127x108 { get; set; }
        public static ConfigEntry<string> _762x51 { get; set; }
        public static ConfigEntry<string> _762x54R { get; set; }
        public static ConfigEntry<string> _338Lapua { get; set; }

        public static ConfigEntry<string> _46x30 { get; set; }
        public static ConfigEntry<string> _57x28 { get; set; }
        public static ConfigEntry<string> _762x25 { get; set; }
        public static ConfigEntry<string> _9x18 { get; set; }
        public static ConfigEntry<string> _9x19 { get; set; }
        public static ConfigEntry<string> _9x21 { get; set; }
        public static ConfigEntry<string> _357 { get; set; }
        public static ConfigEntry<string> _45ACP { get; set; }

        public static ConfigEntry<string> _12x70 { get; set; }
        public static ConfigEntry<string> _20x70 { get; set; }
        public static ConfigEntry<string> _23x75 { get; set; }

        public static ConfigEntry<string> _30x29 { get; set; }
        public static ConfigEntry<string> _40x46 { get; set; }
        public static ConfigEntry<string> _40x53 { get; set; }

        public static ConfigEntry<string> _26x75 { get; set; }

        public static Dictionary<string, ConfigEntry<string>> ConfigCollection = new Dictionary<string, ConfigEntry<string>>();

        private void Awake()
        {

            try
            {
                string pluginDirectory = Path.Combine(BepInEx.Paths.PluginPath, "Zeroing");
                string jsonFilePath = Path.Combine(pluginDirectory, "ammo.json");

                if (!Directory.Exists(pluginDirectory))
                {
                    Logger.LogError($"Plugin directory does not exist: {pluginDirectory}");
                    return;
                }

                if (!File.Exists(jsonFilePath))
                {
                    Logger.LogError($"JSON file does not exist: {jsonFilePath}");
                    return;
                }

                string ammoJSON = File.ReadAllText(jsonFilePath);
                JObject jsonObject = JObject.Parse(ammoJSON);

                foreach (JProperty property in jsonObject.Properties())
                {
                    JObject ammoData = (JObject)property.Value;

                    string id = property.Name;
                    string name = ammoData.Value<string>("name");
                    string caliber = ammoData.Value<string>("caliber");

                    if (AmmoDictionaries.DictionaryCollection.TryGetValue(caliber, out Dictionary<string, string> ammoDictionary))
                    {
                        ammoDictionary.Add(name, id);
                    }
                    else
                    {
                        Logger.LogError($"Cannot find dictionary with key: {caliber}");
                    }
                }
            }
            catch (Exception e)
            {
                Logger.LogError($"An error occurred while processing JSON data: {e}");
            }

            new DefAmmoPatch().Enable();

            string[] _556x45Options = AmmoDictionaries._556x45Dict.Keys.ToArray();
            string[] _545x39Options = AmmoDictionaries._545x39Dict.Keys.ToArray();
            string[] _300BLKOptions = AmmoDictionaries._300blkDict.Keys.ToArray();
            string[] _9x39Options = AmmoDictionaries._9x39Dict.Keys.ToArray();
            string[] _366TKMOptions = AmmoDictionaries._366tkmDict.Keys.ToArray();
            string[] _762x39Options = AmmoDictionaries._762x39Dict.Keys.ToArray();
            string[] _127x55Options = AmmoDictionaries._127x55Dict.Keys.ToArray();
            string[] _127x108Options = AmmoDictionaries._127x108Dict.Keys.ToArray();
            string[] _762x51Options = AmmoDictionaries._762x51Dict.Keys.ToArray();
            string[] _762x54ROptions = AmmoDictionaries._762x54RDict.Keys.ToArray();
            string[] _338LapuaOptions = AmmoDictionaries._338LapuaDict.Keys.ToArray();
            string[] _46x30Options = AmmoDictionaries._46x30Dict.Keys.ToArray();
            string[] _57x28Options = AmmoDictionaries._57x28Dict.Keys.ToArray();
            string[] _762x25Options = AmmoDictionaries._762x25Dict.Keys.ToArray();
            string[] _9x18Options = AmmoDictionaries._9x18Dict.Keys.ToArray();
            string[] _9x19Options = AmmoDictionaries._9x19Dict.Keys.ToArray();
            string[] _9x21Options = AmmoDictionaries._9x21Dict.Keys.ToArray();
            string[] _357Options = AmmoDictionaries._357Dict.Keys.ToArray();
            string[] _45ACPOptions = AmmoDictionaries._45ACPDict.Keys.ToArray();
            string[] _12x70Options = AmmoDictionaries._12x70Dict.Keys.ToArray();
            string[] _20x70Options = AmmoDictionaries._20x70Dict.Keys.ToArray();
            string[] _23x75Options = AmmoDictionaries._23x75Dict.Keys.ToArray();
            string[] _30x29Options = AmmoDictionaries._30x29Dict.Keys.ToArray();
            string[] _40x46Options = AmmoDictionaries._40x46Dict.Keys.ToArray();
            string[] _40x53Options = AmmoDictionaries._40x53Dict.Keys.ToArray();
            string[] _26x75Options = AmmoDictionaries._26x75Dict.Keys.ToArray();

            string rifles = "Rifles";
            string pistols = "Pistols";
            string shotguns = "Shotguns";
            string grenades = "Grenades";
            string special = "Special";


            _556x45 = Config.Bind<string>(rifles, "5.56x45", _556x45Options[0], new ConfigDescription("", new AcceptableValueList<string>(_556x45Options), new ConfigurationManagerAttributes { Order = 110 }));
            _545x39 = Config.Bind<string>(rifles, "5.45x39", _545x39Options[0], new ConfigDescription("", new AcceptableValueList<string>(_545x39Options), new ConfigurationManagerAttributes { Order = 100 }));
            _300blk = Config.Bind<string>(rifles, ".300 BLK", _300BLKOptions[0], new ConfigDescription("", new AcceptableValueList<string>(_300BLKOptions), new ConfigurationManagerAttributes { Order = 90 }));
            _9x39 = Config.Bind<string>(rifles, "9x39", _9x39Options[0], new ConfigDescription("", new AcceptableValueList<string>(_9x39Options), new ConfigurationManagerAttributes { Order = 80 }));
            _366tkm = Config.Bind<string>(rifles, ".366 TKM", _366TKMOptions[0], new ConfigDescription("", new AcceptableValueList<string>(_366TKMOptions), new ConfigurationManagerAttributes { Order = 70 }));
            _127x55 = Config.Bind<string>(rifles, "12.7x55", _127x55Options[0], new ConfigDescription("", new AcceptableValueList<string>(_127x55Options), new ConfigurationManagerAttributes { Order = 60 }));
            _127x108 = Config.Bind<string>(rifles, "12.7x108", _127x108Options[0], new ConfigDescription("", new AcceptableValueList<string>(_127x108Options), new ConfigurationManagerAttributes { Order = 50 }));
            _762x51 = Config.Bind<string>(rifles, "7.62x51", _762x51Options[0], new ConfigDescription("", new AcceptableValueList<string>(_762x51Options), new ConfigurationManagerAttributes { Order = 40 }));
            _762x54R = Config.Bind<string>(rifles, "7.62x54R", _762x54ROptions[0], new ConfigDescription("", new AcceptableValueList<string>(_762x54ROptions), new ConfigurationManagerAttributes { Order = 30 }));
            _338Lapua = Config.Bind<string>(rifles, "338 Lapua", _338LapuaOptions[0], new ConfigDescription("", new AcceptableValueList<string>(_338LapuaOptions), new ConfigurationManagerAttributes { Order = 20 }));
            _762x39 = Config.Bind<string>(rifles, "7.62x39", _762x39Options[0], new ConfigDescription("", new AcceptableValueList<string>(_762x39Options), new ConfigurationManagerAttributes { Order = 10 }));


            _46x30 = Config.Bind<string>(pistols, "4.6x30", _46x30Options[0], new ConfigDescription("", new AcceptableValueList<string>(_46x30Options), new ConfigurationManagerAttributes { Order = 80 }));
            _57x28 = Config.Bind<string>(pistols, "5.7x28", _57x28Options[0], new ConfigDescription("", new AcceptableValueList<string>(_57x28Options), new ConfigurationManagerAttributes { Order = 70 }));
            _762x25 = Config.Bind<string>(pistols, "7.62x25", _762x25Options[0], new ConfigDescription("", new AcceptableValueList<string>(_762x25Options), new ConfigurationManagerAttributes { Order = 60 }));
            _9x18 = Config.Bind<string>(pistols, "9x18", _9x18Options[0], new ConfigDescription("", new AcceptableValueList<string>(_9x18Options), new ConfigurationManagerAttributes { Order = 50 }));
            _9x19 = Config.Bind<string>(pistols, "9x19", _9x19Options[0], new ConfigDescription("", new AcceptableValueList<string>(_9x19Options), new ConfigurationManagerAttributes { Order = 40 }));
            _9x21 = Config.Bind<string>(pistols, "9x21", _9x21Options[0], new ConfigDescription("", new AcceptableValueList<string>(_9x21Options), new ConfigurationManagerAttributes { Order = 30 }));
            _357 = Config.Bind<string>(pistols, ".357", _357Options[0], new ConfigDescription("", new AcceptableValueList<string>(_357Options), new ConfigurationManagerAttributes { Order = 20 }));
            _45ACP = Config.Bind<string>(pistols, ".45 ACP", _45ACPOptions[0], new ConfigDescription("", new AcceptableValueList<string>(_45ACPOptions), new ConfigurationManagerAttributes { Order = 10 }));

            _12x70 = Config.Bind<string>(shotguns, "12ga", _12x70Options[0], new ConfigDescription("", new AcceptableValueList<string>(_12x70Options), new ConfigurationManagerAttributes { Order = 30 }));
            _20x70 = Config.Bind<string>(shotguns, "20ga", _20x70Options[0], new ConfigDescription("", new AcceptableValueList<string>(_20x70Options), new ConfigurationManagerAttributes { Order = 20 }));
            _23x75 = Config.Bind<string>(shotguns, "23x75", _23x75Options[0], new ConfigDescription("", new AcceptableValueList<string>(_23x75Options), new ConfigurationManagerAttributes { Order = 10 }));

            _30x29 = Config.Bind<string>(grenades, "30x29", _30x29Options[0], new ConfigDescription("", new AcceptableValueList<string>(_30x29Options), new ConfigurationManagerAttributes { Order = 30 }));
            _40x46 = Config.Bind<string>(grenades, "40x46", _40x46Options[0], new ConfigDescription("", new AcceptableValueList<string>(_40x46Options), new ConfigurationManagerAttributes { Order = 20 }));
            _40x53 = Config.Bind<string>(grenades, "40x53", _40x53Options[0], new ConfigDescription("", new AcceptableValueList<string>(_40x53Options), new ConfigurationManagerAttributes { Order = 10 }));

            _26x75 = Config.Bind<string>(special, "26x75", _26x75Options[0], new ConfigDescription("", new AcceptableValueList<string>(_26x75Options), new ConfigurationManagerAttributes { Order = 10 }));

            ConfigCollection.Add("Caliber556x45NATO", _556x45);
            ConfigCollection.Add("Caliber545x39", _545x39);
            ConfigCollection.Add("Caliber762x35", _300blk);
            ConfigCollection.Add("Caliber9x39", _9x39);
            ConfigCollection.Add("Caliber366TKM", _366tkm);
            ConfigCollection.Add("Caliber762x39", _762x39);
            ConfigCollection.Add("Caliber127x55", _127x55);
            ConfigCollection.Add("Caliber127x108", _127x108);
            ConfigCollection.Add("Caliber762x51", _762x51);
            ConfigCollection.Add("Caliber762x54R", _762x54R);
            ConfigCollection.Add("Caliber86x70", _338Lapua);
            ConfigCollection.Add("Caliber46x30", _46x30);
            ConfigCollection.Add("Caliber57x28", _57x28);
            ConfigCollection.Add("Caliber762x25TT", _762x25);
            ConfigCollection.Add("Caliber9x18PM", _9x18);
            ConfigCollection.Add("Caliber9x19PARA", _9x19);
            ConfigCollection.Add("Caliber9x21", _9x21);
            ConfigCollection.Add("Caliber9x33R", _357);
            ConfigCollection.Add("Caliber1143x23ACP", _45ACP);
            ConfigCollection.Add("Caliber12g", _12x70);
            ConfigCollection.Add("Caliber20g", _20x70);
            ConfigCollection.Add("Caliber23x75", _23x75);
            ConfigCollection.Add("Caliber30x29", _30x29);
            ConfigCollection.Add("Caliber40x46", _40x46);
            ConfigCollection.Add("Caliber40mmRU", _40x53);
            ConfigCollection.Add("Caliber26x75", _26x75);

            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}

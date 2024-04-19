using System;
using System.Collections.Generic;
using System.Text;

namespace ZeroingQOL
{
    public class AmmoDataTemplate 
    {
        public string name { get; set; }
        public string caliber { get; set; }
    }


    public static class AmmoDictionaries
    {
        public static Dictionary<string, string> _68x51Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _556x45Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _545x39Dict = new Dictionary<string, string>();  

        public static Dictionary<string, string> _300blkDict = new Dictionary<string, string>();

        public static Dictionary<string, string> _9x39Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _366tkmDict = new Dictionary<string, string>();

        public static Dictionary<string, string> _127x55Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _127x108Dict = new Dictionary<string, string>();  

        public static Dictionary<string, string> _762x51Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _762x54RDict = new Dictionary<string, string>();

        public static Dictionary<string, string> _338LapuaDict = new Dictionary<string, string>();

        public static Dictionary<string, string> _762x39Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _46x30Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _57x28Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _9x21Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _9x19Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _9x18Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _357Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _45ACPDict = new Dictionary<string, string>();

        public static Dictionary<string, string> _762x25Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _12x70Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _20x70Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _23x75Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _26x75Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _30x29Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _40x53Dict = new Dictionary<string, string>();

        public static Dictionary<string, string> _40x46Dict = new Dictionary<string, string>();

        public static Dictionary<string, Dictionary<string, string>> DictionaryCollection = new Dictionary<string, Dictionary<string, string>>()
        {
            {"Caliber556x45NATO", _556x45Dict },
            {"Caliber545x39", _545x39Dict },
            {"Caliber762x35", _300blkDict},
            {"Caliber9x39", _9x39Dict },
            {"Caliber366TKM", _366tkmDict },
            {"Caliber762x39", _762x39Dict},
            {"Caliber127x55", _127x55Dict},
            {"Caliber127x108", _127x108Dict},
            {"Caliber762x51", _762x51Dict},
            {"Caliber762x54R", _762x54RDict},
            {"Caliber86x70", _338LapuaDict},
            {"Caliber46x30", _46x30Dict},
            {"Caliber57x28", _57x28Dict},
            {"Caliber762x25TT", _762x25Dict},
            {"Caliber9x18PM", _9x18Dict},
            {"Caliber9x19PARA", _9x19Dict},
            {"Caliber9x21", _9x21Dict},
            {"Caliber9x33R", _357Dict},
            {"Caliber1143x23ACP", _45ACPDict},
            {"Caliber12g", _12x70Dict},
            {"Caliber20g", _20x70Dict},
            {"Caliber23x75", _23x75Dict},
            {"Caliber30x29", _30x29Dict},
            {"Caliber40x46", _40x46Dict},
            {"Caliber40mmRU", _40x53Dict},
            {"Caliber26x75", _26x75Dict},
            {"Caliber68x51", _68x51Dict}
        };

    }
}

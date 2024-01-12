using BepInEx;
using BepInEx.Logging;
using GameNetcodeStuff;
using HarmonyLib;
using LCMarathoner.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMarathoner
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class MarathonerBase : BaseUnityPlugin
    {
        private const string modGUID = "FreakyFriday.LCMarathoner";
        private const string modName = "LC Marathoner Mod";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static MarathonerBase Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("Marathoner has awaken :)");

            harmony.PatchAll(typeof(MarathonerBase));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
        }
    }
}

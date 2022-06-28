using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.ModHelper;
using NoMansSky.Api;
using libMBIN.NMS.Globals;
using NoMansSky.DebuggerReloaded.Configuration;

namespace NoMansSky.DebuggerReloaded
{
    /// <summary>
    /// Your mod logic goes here.
    /// </summary>
    public class Mod : NMSMod
    {
        /// <summary>
        /// Initializes your mod along with some necessary info.
        /// </summary>
        public Mod(IModConfig _config, IReloadedHooks _hooks, IModLogger _logger) : base(_config, _hooks, _logger)
        {
            // This is how to log a message to the Reloaded II Console.
            Logger.WriteLine("Hello World!");


            // The API relies heavily on Mod Events.
            // Below are 3 examples of using them.
            Game.OnProfileSelected += () => Logger.WriteLine("The player just selected a save file");
            Game.OnMainMenu += OnMainMenu;
            Game.OnGameJoined.AddListener(GameJoined);

            
        }

        /// <summary>
        /// Called once every frame.
        /// </summary>
        public override void Update()
        {
            // Here is an example of checking for keyboard keys
            if (Keyboard.IsPressed(Key.Plus))
            {
                debuggerActivate();
                Logger.WriteLine("Debug Settings Activated");
            }

            if(Keyboard.IsPressed(Key.Minus))
            {
                debuggerDeactivate();
                Logger.WriteLine("Debug Settings Deactivated");
            }
        }

        private void OnMainMenu()
        {
            Logger.WriteLine("Main Menu shown!");


            GlobalMbinModding();
        }

        // here is an example of modding globals with the new MemoryManager
        private void GlobalMbinModding()
        {
            var memoryMgr = new MemoryManager(); // create a memory manager.

            // example of getting the run speed from the player globals
            float currentRunSpeed = memoryMgr.GetValue<float>("GcPlayerGlobals.GroundRunSpeed");

            // example of settng the run speed to twice it's original value.
            memoryMgr.SetValue("GcPlayerGlobals.GroundRunSpeed", currentRunSpeed * 2);
        }

        private void debuggerActivate()
        {
            Config configRef = new Config();
            var memMgr = new MemoryManager();

            memMgr.SetValue("GcDebugOptions.ForceScanEventsToGoPrime", configRef.ForceScanEventsToGoPrime);
            memMgr.SetValue("GcDebugOptions.DebugGalaxyMapInQuickMenu", configRef.DebugGalaxyMapInQuickMenu);
            memMgr.SetValue("GcDebugOptions.GodMode", configRef.GodMode);
            memMgr.SetValue("GcDebugOptions.TakeNoDamage", configRef.TakeNoDamage);
            memMgr.SetValue("GcDebugOptions.EverythingIsFree", configRef.EverythingIsFree);
            memMgr.SetValue("GcDebugOptions.EverythingIsKnown", configRef.EverythingIsKnown);
            memMgr.SetValue("GcDebugOptions.MapWarpCheckIgnoreFuel", configRef.MapWarpCheckIgnoreFuel);
            memMgr.SetValue("GcDebugOptions.MapWarpCheckIgnoreDrive", configRef.MapWarpCheckIgnoreDrive);
            memMgr.SetValue("GcDebugOptions.DisableSaveSlotSorting", configRef.DisableSaveSlotSorting);
        }

        private void debuggerDeactivate()
        {
            Config configRef = new Config();
            var memMgr = new MemoryManager();

            bool ScanEventsInverseValue = configRef.ForceScanEventsToGoPrime;
            bool GalaxyMapInverseValue = configRef.DebugGalaxyMapInQuickMenu;
            bool GodModeInverseValue = configRef.GodMode;
            bool TakeNoDamageInverseValue = configRef.TakeNoDamage;
            bool EverythingIsFreeInverseValue = configRef.EverythingIsFree;
            bool EverythingIsKnownInverseValue = configRef.EverythingIsKnown;
            bool MapWarpCheckIgnoreFuelInverseValue = configRef.MapWarpCheckIgnoreFuel;
            bool MapWarpCheckIgnoreDriveInverseValue = configRef.MapWarpCheckIgnoreDrive;
            bool DisableSaveSlotSortingInverseValue = configRef.DisableSaveSlotSorting;

            if (configRef.ForceScanEventsToGoPrime == true)
            {
                ScanEventsInverseValue = false;
            }
            else if(configRef.ForceScanEventsToGoPrime == false)
            {
                ScanEventsInverseValue = true;

            }

            if(configRef.DebugGalaxyMapInQuickMenu == true)
            {
                GalaxyMapInverseValue = false;
            }
            else if(configRef.DebugGalaxyMapInQuickMenu == false)
            {
                GalaxyMapInverseValue = true;
            }

            if (configRef.GodMode == true)
            {
                GodModeInverseValue = false;
            }
            else if (configRef.DebugGalaxyMapInQuickMenu == false)
            {
                GodModeInverseValue = true;
            }

            if (configRef.TakeNoDamage == true)
            {
                TakeNoDamageInverseValue = false;
            }
            else if (configRef.TakeNoDamage == false)
            {
                TakeNoDamageInverseValue = true;
            }

            if (configRef.EverythingIsFree == true)
            {
                EverythingIsFreeInverseValue = false;
            }
            else if (configRef.EverythingIsFree == false)
            {
                EverythingIsFreeInverseValue = true;
            }

            if (configRef.EverythingIsKnown == true)
            {
                EverythingIsKnownInverseValue = false;
            }
            else if (configRef.EverythingIsKnown == false)
            {
                EverythingIsKnownInverseValue = true;
            }

            if (configRef.MapWarpCheckIgnoreFuel == true)
            {
                MapWarpCheckIgnoreFuelInverseValue = false;
            }
            else if (configRef.MapWarpCheckIgnoreFuel == false)
            {
                MapWarpCheckIgnoreFuelInverseValue = true;
            }

            if (configRef.MapWarpCheckIgnoreDrive == true)
            {
                MapWarpCheckIgnoreDriveInverseValue = false;
            }
            else if (configRef.MapWarpCheckIgnoreDrive == false)
            {
                MapWarpCheckIgnoreDriveInverseValue = true;
            }

            if (configRef.DisableSaveSlotSorting == true)
            {
                DisableSaveSlotSortingInverseValue = false;
            }
            else if (configRef.DisableSaveSlotSorting == false)
            {
                DisableSaveSlotSortingInverseValue = true;
            }

            memMgr.SetValue("GcDebugOptions.ForceScanEventsToGoPrime", ScanEventsInverseValue);
            memMgr.SetValue("GcDebugOptions.DebugGalaxyMapInQuickMenu", GalaxyMapInverseValue);
            memMgr.SetValue("GcDebugOptions.GodMode", GodModeInverseValue);
            memMgr.SetValue("GcDebugOptions.TakeNoDamage", TakeNoDamageInverseValue);
            memMgr.SetValue("GcDebugOptions.EverythingIsFree", EverythingIsFreeInverseValue);
            memMgr.SetValue("GcDebugOptions.EverythingIsKnown", EverythingIsKnownInverseValue);
            memMgr.SetValue("GcDebugOptions.MapWarpCheckIgnoreFuel", MapWarpCheckIgnoreFuelInverseValue);
            memMgr.SetValue("GcDebugOptions.MapWarpCheckIgnoreDrive", MapWarpCheckIgnoreDriveInverseValue);
            memMgr.SetValue("GcDebugOptions.DisableSaveSlotSorting", DisableSaveSlotSortingInverseValue);


        }
        private void GameJoined()
        {
            Logger.WriteLine("The game was joined!");
        }
    }
}
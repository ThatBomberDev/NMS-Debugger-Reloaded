using NoMansSky.ModTemplate.Configuration.Implementation;
using System.ComponentModel;

namespace NoMansSky.DebuggerReloaded.Configuration
{
    public class Config : Configurable<Config>
    {
        /*
            User Properties:
                - Please put all of your configurable properties here.
                - Tip: Consider using the various available attributes https://stackoverflow.com/a/15051390/11106111
        
            By default, configuration saves as "Config.json" in mod folder.    
            Need more config files/classes? See Configuration.cs
        */

        [DisplayName("Prime Scan Events")]
        [Description("Force Each Specified Scan To Find The Best Value?")]
        public bool ForceScanEventsToGoPrime { get; set; } = true;

        [DisplayName("Galaxy Map Everywhere")]
        [Description("Add The Galaxy Map In Each Instance Of The Quick Menu")]
        public bool DebugGalaxyMapInQuickMenu { get; set; } = true;

        [DisplayName("God Mode")]
        [Description("Enable God Mode")]
        public bool GodMode { get; set; } = true;

        [DisplayName("Disable Damage")]
        [Description("Add The Galaxy Map In Each Instance Of The Quick Menu")]
        public bool TakeNoDamage { get; set; } = true;

        [DisplayName("Disable Costs")]
        [Description("Disable All Forms Of Requirements")]
        public bool EverythingIsFree { get; set; } = true;

        [DisplayName("Learn Everything")]
        [Description("Aquire Every Blueprint / Recipe In The Game")]
        public bool EverythingIsKnown { get; set; } = true;

        [DisplayName("Ignore Hyperdrive Fuel")]
        [Description("Warp Without Regarding Hyperdrive Fuel")]
        public bool MapWarpCheckIgnoreFuel { get; set; } = true;

        [DisplayName("Ignore Hyperdrive Upgrade Requirements")]
        [Description("Warp Without Regarding Hyperdrive Upgrade Requirements")]
        public bool MapWarpCheckIgnoreDrive { get; set; } = true;

        [DisplayName("Disable Save Slot Sorting")]
        [Description("Set Saves To Sort By First Created")]
        public bool DisableSaveSlotSorting { get; set; } = true;



    }
}

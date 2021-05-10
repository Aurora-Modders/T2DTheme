using System.Drawing;
using System.Collections.Generic;

using HarmonyLib;

namespace T2DTheme
{
    public class T2DTheme : AuroraPatch.Patch
    {
        public override string Description => "twice2double's Dark Aurora Theme";
        public override IEnumerable<string> Dependencies => new[] { "ThemeCreator" };

        protected override void Loaded(Harmony harmony)
        {
            LogInfo("Loading T2DTheme...");
            // -- Fonts -- //
            ThemeCreator.ThemeCreator.SetGlobalFont(new Font(FontFamily.GenericSansSerif, 11f));

            // -- Colors -- //
            // Black background.
            ThemeCreator.ThemeCreator.AddGlobalColorSwap(Color.FromArgb(0, 0, 64), Color.Black);
            // White foreground.
            ThemeCreator.ThemeCreator.AddGlobalColorSwap(Color.FromArgb(255, 255, 192), Color.White);
        }
    }
}

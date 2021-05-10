using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using HarmonyLib;

namespace T2DTheme
{
    public class T2DTheme : AuroraPatch.Patch
    {
        public override string Description => "twice2double's Dark Aurora Theme";
        public override IEnumerable<string> Dependencies => new[] { "ThemeCreator" };

        // The global font used.
        public static Font font = null;

        protected override void Loaded(Harmony harmony)
        {
            LogInfo("Loading T2DTheme...");

            // -- Settings -- //
            try
            {
                font = Deserialize<Font>("font");
            }
            catch (Exception)
            {
                LogInfo("Saved font not found");
            }

            // -- Fonts -- //
            if (font != null) ThemeCreator.ThemeCreator.SetGlobalFont(font);

            // -- Colors -- //
            // Black background.
            ThemeCreator.ThemeCreator.AddGlobalColorSwap(Color.FromArgb(0, 0, 64), Color.Black);
            // White foreground.
            ThemeCreator.ThemeCreator.AddGlobalColorSwap(Color.FromArgb(255, 255, 192), Color.White);
        }

        protected override void ChangeSettings()
        {
            var dialog = new FontDialog();
            if (font != null) dialog.Font = font;
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                font = dialog.Font;
                Serialize("font", font);
            }
        }
    }
}

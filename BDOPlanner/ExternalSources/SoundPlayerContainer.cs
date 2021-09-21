using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace BDOPlanner.ExternalSources
{
    public static class SoundPlayerContainer
    {

        private static SoundPlayer player = new SoundPlayer();
       
        // Sets up the SoundPlayer object.
        public static void PlayNotifySound()
        {
            player.SoundLocation=@"Resources\\mixkit-positive-notification-951.wav";
            player.Play();

        }
    }
}

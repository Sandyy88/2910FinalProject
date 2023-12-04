using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Playback;
using Windows.Media.Core;

namespace Demo5.Helpers
{
    public class Music
    {
        public MediaPlayer player { get; set; }

        public Music(MediaPlayer player)
        {
            this.player = player;
        }
    }
}

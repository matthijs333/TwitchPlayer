using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchPlayer
{
    static class LiveStreamerAPI
    {
        public static void StartStream(string Stream, StreamQuality Quality)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C livestreamer twitch.tv/" + Stream + " " + Quality;
            process.StartInfo = startInfo;
            process.Start();

        }
        public enum StreamQuality
        {
            best,
            source,
            high,
            medium,
            low,
            mobile,
            audio,
            worst
        }
    }
}

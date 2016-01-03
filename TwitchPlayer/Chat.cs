using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchPlayer
{
    public partial class Chat : Form
    {
        public Chat(string Name, int Transparancy = 70)
        {
            InitializeComponent();
            webBrowser1.Url = new Uri("http://www.twitch.tv/" + Name + "/chat?popout=");
          // trackBar1.Value = Transparancy;
           // this.Opacity = Convert.ToDouble(Transparancy, NumberFormatInfo.InvariantInfo);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
          this.Opacity = Convert.ToDouble(trackBar1.Value, NumberFormatInfo.InvariantInfo);
        }
    }
}

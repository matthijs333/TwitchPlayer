using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchPlayer
{
    public partial class Form1 : Form
    {
        TwitchAPI myAPI = new TwitchAPI();
        public Form1()
        {
            InitializeComponent();
            Chat newChat = new Chat("abfnggshka");
            newChat.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {     
            List<gamesResponse.Game> Games = myAPI.GetTopGames(30);
            List<StreamsResponse.Stream> Streams = myAPI.GetStreams(Games[0].name);

            Display.DrawGames(flowLayoutPanel1, dataGridView1, Games);
           dataGridView1.DrawStreams(Streams);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow Row = dataGridView1.Rows[e.RowIndex];
            StreamsResponse.Stream Stream = (StreamsResponse.Stream)Row.Tag;
            LiveStreamerAPI.StartStream(Stream.channel.name, LiveStreamerAPI.StreamQuality.best);
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TwitchPlayer
{
    class TwitchAPI
    {
        WebClient client = new WebClient();

        public List<gamesResponse.Game> GetTopGames(int Limit = 15)
        {
            return getResponse<gamesResponse.Rootobject>(Requests.GetGames(Limit)).top.Select(s => s.game).ToList();
        }
        public ChannelResponse.Channel GetChannel(string Name)
        {
            return getResponse<ChannelResponse.Channel>(Requests.GetChannel(Name));
        }
        public List<ChannelResponse.Channel> GetChannels(List<string> Names)
        {
            List<ChannelResponse.Channel> Channels = new List<ChannelResponse.Channel>();
            foreach (string Name in Names)
            {
                Channels.Add(GetChannel(Name));
            }
            return Channels;
        }
        public List<StreamsResponse.Stream> GetStreams(string Game, int Limit = 25)
        {
            return getResponse<StreamsResponse.Rootobject>(Requests.GetStreams(Game, Limit)).streams.ToList();
        }

        private T getResponse<T>(string Request)
        {
            Stream stream = client.OpenRead(Request);
            StreamReader reader = new StreamReader(stream);
            return JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
        }

    }
    class Requests
    {
        public static string GetGames(int Limit = 15)
        {
            return @"https://api.twitch.tv/kraken/games/top?limit=" + Convert.ToString(Limit);
        }
        public static string GetChannel(string Name)
        {
            return @"https://api.twitch.tv/kraken/channels/" + Name;
        }
        public static string GetStreams(string Game, int Limit = 25)
        {
            return @"https://api.twitch.tv/kraken/streams?game=" + Game + @"&limit=" + Limit;
        }
    }
    public class gamesResponse
    {
        public class Rootobject
        {
            public int _total { get; set; }
            public _Links _links { get; set; }
            public Top[] top { get; set; }
        }

        public class _Links
        {
            public string self { get; set; }
            public string next { get; set; }
        }

        public class Top
        {
            public int viewers { get; set; }
            public int channels { get; set; }
            public Game game { get; set; }
        }

        public class Game
        {
            public string name { get; set; }
            public int _id { get; set; }
            public int giantbomb_id { get; set; }
            public Box box { get; set; }
            public Logo logo { get; set; }
            public _Links1 _links { get; set; }
        }

        public class Box
        {
            public string large { get; set; }
            public string medium { get; set; }
            public string small { get; set; }
            public string template { get; set; }
        }

        public class Logo
        {
            public string large { get; set; }
            public string medium { get; set; }
            public string small { get; set; }
            public string template { get; set; }
        }

        public class _Links1
        {
        }
    }
    public class ChannelResponse
    {

        public class Channel
        {
            public bool mature { get; set; }
            public string status { get; set; }
            public string broadcaster_language { get; set; }
            public string display_name { get; set; }
            public string game { get; set; }
            public string language { get; set; }
            public int _id { get; set; }
            public string name { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public object delay { get; set; }
            public string logo { get; set; }
            public object banner { get; set; }
            public string video_banner { get; set; }
            public object background { get; set; }
            public string profile_banner { get; set; }
            public object profile_banner_background_color { get; set; }
            public bool partner { get; set; }
            public string url { get; set; }
            public int views { get; set; }
            public int followers { get; set; }
            public _Links _links { get; set; }
        }

        public class _Links
        {
            public string self { get; set; }
            public string follows { get; set; }
            public string commercial { get; set; }
            public string stream_key { get; set; }
            public string chat { get; set; }
            public string features { get; set; }
            public string subscriptions { get; set; }
            public string editors { get; set; }
            public string teams { get; set; }
            public string videos { get; set; }
        }

    }
    public class StreamsResponse
    {

        public class Rootobject
        {
            public Stream[] streams { get; set; }
            public int _total { get; set; }
            public _Links _links { get; set; }
        }

        public class _Links
        {
            public string self { get; set; }
            public string next { get; set; }
            public string featured { get; set; }
            public string summary { get; set; }
            public string followed { get; set; }
        }

        public class Stream
        {
            public long _id { get; set; }
            public string game { get; set; }
            public int viewers { get; set; }
            public DateTime created_at { get; set; }
            public int video_height { get; set; }
            public float average_fps { get; set; }
            public int delay { get; set; }
            public bool is_playlist { get; set; }
            public _Links1 _links { get; set; }
            public Preview preview { get; set; }
            public Channel channel { get; set; }
        }

        public class _Links1
        {
            public string self { get; set; }
        }

        public class Preview
        {
            public string small { get; set; }
            public string medium { get; set; }
            public string large { get; set; }
            public string template { get; set; }
        }

        public class Channel
        {
            public bool? mature { get; set; }
            public string status { get; set; }
            public string broadcaster_language { get; set; }
            public string display_name { get; set; }
            public string game { get; set; }
            public string language { get; set; }
            public int _id { get; set; }
            public string name { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public object delay { get; set; }
            public string logo { get; set; }
            public object banner { get; set; }
            public string video_banner { get; set; }
            public object background { get; set; }
            public string profile_banner { get; set; }
            public string profile_banner_background_color { get; set; }
            public bool partner { get; set; }
            public string url { get; set; }
            public int views { get; set; }
            public int followers { get; set; }
            public _Links2 _links { get; set; }
        }

        public class _Links2
        {
            public string self { get; set; }
            public string follows { get; set; }
            public string commercial { get; set; }
            public string stream_key { get; set; }
            public string chat { get; set; }
            public string features { get; set; }
            public string subscriptions { get; set; }
            public string editors { get; set; }
            public string teams { get; set; }
            public string videos { get; set; }
        }

    }
}

using System.Collections.Generic;
using Newtonsoft.Json;

namespace ApiTheMusicalKind.Backend.Models
{
    public class Search
    {
        [JsonProperty("tracks")]
        public Track Tracks { get; set; }

        [JsonProperty("artists")]
        public Artist Artists { get; set; }
    }

    public class Artist
    {
        [JsonProperty("hits")]
        public IEnumerable<object> Hits { get; set; }
    }

    //public class ArtistHits
    //{
    //    [JsonProperty("avatar")]
    //    public string Avatar { get; set; }

    //    [JsonProperty("id")]
    //    public string Id { get; set; }

    //    [JsonProperty("name")]
    //    public string Name { get; set; }

    //    [JsonProperty("verified")]
    //    public bool Verified { get; set; } 
    //}

    public class Track
    {
        [JsonProperty("hits")]
        public IEnumerable<Hit> Hits { get; set; }
    }

    public class Hit
    {
        [JsonProperty("track")]
        public HitTrack Track { get; set; }
    }

    public class HitTrack
    {
        [JsonProperty("layout")]
        public int Layout { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }

        [JsonProperty("share")]
        public Share Share { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("hub")]
        public Hub Hub { get; set; }

        [JsonProperty("artists")]
        public IEnumerable<HitArtist> Artists { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("lyricWordCount")]
        public int LyricWordCount { get; set; }
    }

    public class Share
    {
        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("twitter")]
        public string Twitter { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("snapchat")]
        public string Snapchat { get; set; }
    }

    public class Images
    {
        [JsonProperty("background")]
        public string Background { get; set; }

        [JsonProperty("coverart")]
        public string Coverart { get; set; }

        [JsonProperty("coverarthq")]
        public string Coverarthq { get; set; }
    }

    public class Hub
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("actions")]
        public IEnumerable<Action> Actions { get; set; }

        [JsonProperty("options")]
        public IEnumerable<Option> Options { get; set; }

        [JsonProperty("providers")]
        public IEnumerable<Provider> Providers { get; set; }

        [JsonProperty("explicit")]
        public bool Explicit { get; set; }

        [JsonProperty("displayname")]
        public string DisplayName { get; set; }
    }

    public class Action
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class Option
    {
        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("actions")]
        public IEnumerable<Action> Actions { get; set; }

        [JsonProperty("beacondata")]
        public BeaconData BeaconData { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("listcaption")]
        public string ListCaption { get; set; }

        [JsonProperty("overflowimage")]
        public string OverflowImage { get; set; }

        [JsonProperty("colouroverflowimage")]
        public bool ColourOverflowImage { get; set; }
    }

    public class BeaconData
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("providername")]
        public string ProviderName { get; set; }
    }

    public class Provider
    {
        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("images")]
        public Image Images { get; set; }

        [JsonProperty("actions")]
        public IEnumerable<Action> Actions { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Image
    {
        [JsonProperty("overflow")]
        public string Overflow { get; set; }

        [JsonProperty("default")]
        public string Default { get; set; }
    }

    public class HitArtist
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("adamid")]
        public string Adamid { get; set; }
    }
}

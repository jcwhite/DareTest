using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.YouTube
{
    public class YouTubePlaylist
    {
        [JsonProperty("items")]
        public List<YouTubePlaylistItem> Items { get; set; }
    }

    public class YouTubePlaylistItem
    {

        [JsonProperty("snippet")]
        public YouTubePlaylistSnippet Snippet { get; set; }
    }

    public class YouTubePlaylistSnippet
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("thumbnails")]
        public YouTubePlaylistThumbnails Thumbnails { get; set; }

        [JsonProperty("resourceId")]
        public YouTubePlaylistResourceId ResourceId { get; set; }
    }

    public class YouTubePlaylistThumbnails
    {
        [JsonProperty("default")]
        public YouTubePlaylistThumbnailsDefault Default { get; set; }
    }
    public class YouTubePlaylistThumbnailsDefault
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class YouTubePlaylistResourceId
    {
        [JsonProperty("videoId")]
        public string VideoId { get; set; }
    }
}

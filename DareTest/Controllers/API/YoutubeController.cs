using Core.Models;
using Core.Models.YouTube;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Services;
using Umbraco.Web.WebApi;

namespace DareTest.Controllers.API
{
    public class YoutubeController : UmbracoApiController
    {
        private readonly IContentService _contentService;

        public YoutubeController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public YouTubePlaylist GetVideos(int id)
        {
            var youtubeApiEndpoint = "https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&key=AIzaSyBH-iQyQ7JMkxn7C-FZEz8wpmusBg5RzBg&maxResults=5&playlistId=PL4A1F702CEBDEAAA3";
            var youtubeJson = new WebClient().DownloadString(youtubeApiEndpoint);
            var youtubeVideos = JsonConvert.DeserializeObject<YouTubePlaylist>(youtubeJson);

            var homepage = _contentService.GetById(id);
            var newVideosList = new List<Dictionary<string, string>>();

            foreach (var youtubeVideo in youtubeVideos.Items)
            {
                var newGuid = Guid.NewGuid();
                newVideosList.Add(new Dictionary<string, string>(){
                    {"key", newGuid.ToString()},
                    {"name", "Video List"},
                    {"ncContentTypeAlias", "videoItem"},
                    {"title", youtubeVideo.Snippet.Title},
                    {"thumbnail", youtubeVideo.Snippet.Thumbnails.Default.Url},
                    {"link", $"https://www.youtube.com/watch?v={ youtubeVideo.Snippet.ResourceId.VideoId }" }
                });
            }

            homepage.SetValue("videos", JsonConvert.SerializeObject(newVideosList));

            _contentService.SaveAndPublish(homepage);

            return youtubeVideos;
        }
    }
}
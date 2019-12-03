using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsApp.Core.Models
{
    public partial class Films
    {
        public long Count { get; set; }
        public object Next { get; set; }
        public object Previous { get; set; }
        public List<FilmResult> Results { get; set; }
    }

    public partial class FilmResult
    {
        public string Title { get; set; }
        public long EpisodeId { get; set; }
        public string opening_crawl { get; set; }
        public string director { get; set; }
        public string producer { get; set; }
        public DateTimeOffset release_date { get; set; }
        public List<Uri> characters { get; set; }
        public List<Uri> planets { get; set; }
        public List<Uri> starships { get; set; }
        public List<Uri> vehicles { get; set; }
        public List<Uri> species { get; set; }
        public DateTimeOffset created { get; set; }
        public DateTimeOffset edited { get; set; }
        public Uri url { get; set; }
    }
}

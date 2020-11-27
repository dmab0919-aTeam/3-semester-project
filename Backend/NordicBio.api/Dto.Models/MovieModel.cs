using System;

namespace NordicBio.model
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public double VoteAverage { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
        public string Description { get; set; }

        public MovieModel(int id, string title, string releaseDate, double voteAverage, string posterPath, string backdropPath, string description)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            VoteAverage = voteAverage;
            PosterPath = posterPath;
            BackdropPath = backdropPath;
            Description = description;
        }
    }
}

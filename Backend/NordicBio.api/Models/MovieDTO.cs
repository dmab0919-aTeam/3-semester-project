namespace NordicBio.model
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public double VoteAverage { get; set; }
        public string PosterPath { get; set; }
        public string Description { get; set; }


        public MovieDTO()
        {

        }
        public MovieDTO(int id, string title, string releaseDate, double voteAverage, string posterPath, string description)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            VoteAverage = voteAverage;
            PosterPath = posterPath;
            Description = description;
        }
    }
}

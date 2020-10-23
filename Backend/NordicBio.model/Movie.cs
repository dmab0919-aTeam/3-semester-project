﻿using System;

namespace NordicBio.model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public double VoteAverage { get; set; }
        public string PosterPath { get; set; }
        public string Description { get; set; }
    }
}

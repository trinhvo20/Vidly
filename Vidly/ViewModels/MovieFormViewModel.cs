﻿using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
    }
}

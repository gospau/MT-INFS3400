using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pau_Go_FinalProject
{
    class Movies
    {
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public int Total { get; set; }

        public Movies( string director, string actors, string plot, string title, string genre, int year, int total )
        {
            Director = director;
            Actors = actors;
            Plot = plot;
            Title = title;
            Genre = genre;
            Year = year;
            Total = total;
        }


    }
}

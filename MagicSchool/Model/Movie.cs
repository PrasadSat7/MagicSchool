using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSchool.Model
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieLanguage { get; set; }

        [ForeignKey("MovieId")]
        public MovieDetails MovieDetails { get; set; }
    }

    public class GetItemrequest
    {
        public int id;
    }

    public class InsertItem
    {
        public string MovieName { get; set; }
        public string MovieLanguage { get; set; }
    }


}

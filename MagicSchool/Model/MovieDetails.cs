using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSchool.Model
{
    public class MovieDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Details_Id { get; set; }
        public int Movie_ID { get; set; }
        public string Movie_Hero { get; set; }
        public string Movie_Heroin { get; set; }       

        [Required]
        public string ReleaseYear { get; set; }

        public Movie Movie { get; set; }

    }
}

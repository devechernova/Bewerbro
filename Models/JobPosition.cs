using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bewerbro.Models
{
    public class JobPosition
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string JobUrl { get; set; }

        public List<string> Technologies { get; set; } = new List<string>();

        public Ansprechpartner Ansprechpartner { get; set; }

        public Application Application { get; set; }
    }
}

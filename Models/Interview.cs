using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bewerbro.Models
{
    public class Interview
    {
        public int Id { get; set; }

        public DateTime InterviewDate { get; set; }

        public string Type { get; set; }

        public string Notes { get; set; }
    }
}

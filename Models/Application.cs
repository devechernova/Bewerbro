using Bewerbro.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bewerbro.Models
{
    public class Application
    {
        public int Id { get; set; }

        public DateTime ApplyDate { get; set; }

        public ApplicationStatus Status { get; set; }

        public int MatchScore { get; set; }

        public string Notes { get; set; }
    }
}

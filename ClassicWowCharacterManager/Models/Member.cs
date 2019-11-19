using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicWowCharacterManager.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string Faction { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string Profession1 { get; set; }
        public string Profession2 { get; set; }
        public bool Active { get; set; }
        public string Notes { get; set; }

    }
}

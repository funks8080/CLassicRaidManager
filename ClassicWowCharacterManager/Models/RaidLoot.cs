using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicWowCharacterManager.Models
{
    public class RaidLoot
    {
        public int ID { get; set; }
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string ItemType { get; set; } 
        public string ItemRarity { get; set; }
        public string ItemName { get; set; }
        public DateTime Recieved { get; set; }
        public string RaidName { get; set; }
    }
}

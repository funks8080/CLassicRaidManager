using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicWowCharacterManager.Models
{
    public class RaidMember
    {
        public int ID { get; set; }
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public int RaidID { get; set; }
        public int RaidRoleID { get; set; }
        public string RaidRole { get; set; }
        public string RoleDescription { get; set; }
    }
}

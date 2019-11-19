using ClassicWowCharacterManager.Models;
using ClassicWowCharacterManager.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassicWowCharacterManager
{
    public partial class Main : Form
    {
        MemberView MemberPane;
        LootTrackView LootTrack;
        RaidView RaidPane;
        AppManagerView AppManager;
        public Main()
        {
            InitializeComponent();
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            MemberPane = new MemberView();
            MemberPane.Dock = DockStyle.Fill;
            LoadPanel(MemberPane);
        }

        private void LoadPanel(UserControl control)
        {
            try
            {
                panel1.SuspendLayout();
                foreach (UserControl item in panel1.Controls)
                    panel1.Controls.Remove(item);
                panel1.Controls.Add(control);
            }
            finally
            {
                panel1.ResumeLayout();
            }
        }

        private void btnRaids_Click(object sender, EventArgs e)
        {
            RaidPane = new RaidView();
            RaidPane.Dock = DockStyle.Fill;
            LoadPanel(RaidPane);
        }

        private void btnLoot_Click(object sender, EventArgs e)
        {
            LootTrack = new LootTrackView();
            LootTrack.Dock = DockStyle.Fill;
            LoadPanel(LootTrack);
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            AppManager = new AppManagerView();
            AppManager.Dock = DockStyle.Fill;
            LoadPanel(AppManager);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lootTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<RaidLoot> list = GetRaidLoot();
            ExportListToCSV(list);
        }
        private List<RaidLoot> GetRaidLoot()
        {
            List<RaidLoot> list = new List<RaidLoot>();
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT r.ID, r.Member_ID, m.Name, r.Item_Name, it.Name as ItemType, ir.name as ItemRarity, r.Timestamp, rr.Name as RaidName ");
            sb.Append("FROM RaidLoot r ");
            sb.Append("INNER JOIN Member m ");
            sb.Append("ON r.Member_ID = m.ID ");
            sb.Append("INNER JOIN ItemType it ");
            sb.Append("ON r.Item_Type_ID = it.ID ");
            sb.Append("INNER JOIN ItemRarity ir ");
            sb.Append("ON r.Item_Rarity_ID = ir.ID ");
            sb.Append("INNER JOIN RaidGroup rg ");
            sb.Append("ON rg.ID = r.ID ");
            //sb.Append(string.Format("WHERE r.Raid_ID = {0}", raidID));
            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sb.ToString(), conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new RaidLoot()
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            MemberID = int.Parse(reader["Member_ID"].ToString()),
                            MemberName = reader["Name"].ToString().Trim(),
                            ItemName = reader["Item_Name"].ToString().Trim(),
                            ItemType = reader["ItemType"].ToString().Trim(),
                            ItemRarity = reader["ItemRarity"].ToString().Trim(),
                            Recieved = DateTime.Parse(reader["Timestamp"].ToString()),
                            RaidName = reader["RaidName"].ToString().Trim(),
                        });
                    }
                }
            }
            return list;
        }

        private void ExportListToCSV(List<RaidLoot> list)
        {

        }
    }
}

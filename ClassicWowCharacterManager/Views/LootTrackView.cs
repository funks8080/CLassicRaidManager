using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ClassicWowCharacterManager.Models;
using System.Text.RegularExpressions;

namespace ClassicWowCharacterManager.Views
{
    public partial class LootTrackView : UserControl
    {
        private List<RaidLoot> LootList;
        public LootTrackView()
        {
            InitializeComponent();
            LoadRaids();
            LoadRaidMembers();
            LoadSlots();
            LoadRarity();
            LoadLootTable();
        }

        private void LoadRaids()
        {
            List<Raid> list = new List<Raid>();
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            var cmdText = string.Format("SELECT * FROM RaidGroup");
            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(cmdText, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Raid()
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            Name = reader["Name"].ToString().Trim()
                        });
                    }
                }
            }

            cbRaidGroup.Items.Clear();
            cbRaidGroup.DataSource = new BindingSource(list, null);
            cbRaidGroup.DisplayMember = "Name";
            cbRaidGroup.ValueMember = "ID";
        }

        private void cbRaidGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRaidMembers();
        }

        private void LoadRaidMembers()
        {
            var raidID = cbRaidGroup.SelectedValue.ToString();
            List<RaidMember> list = new List<RaidMember>();
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT r.ID, m.ID as MemberID, m.Name, r.ID as raid ");
            sb.Append("FROM RaidGroup r ");
            sb.Append("INNER JOIN RaidGroupMember rm ");
            sb.Append("ON rm.Raid_ID = r.ID ");
            sb.Append("INNER JOIN Member m ");
            sb.Append("ON rm.Member_ID = m.ID ");
            sb.Append("INNER JOIN RaidRole rr ");
            sb.Append("ON rm.Role_ID = rr.ID ");
            sb.Append(string.Format("WHERE r.ID = {0} ", raidID));
            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sb.ToString(), conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new RaidMember()
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            MemberID = int.Parse(reader["MemberID"].ToString()),
                            MemberName = reader["Name"].ToString().Trim(),
                            RaidID = int.Parse(reader["Raid"].ToString())
                        });
                    }
                }
            }

            cbMember.DataSource = new BindingSource(list, null);
            cbMember.DisplayMember = "MemberName";
            cbMember.ValueMember = "MemberID";
        }

        private void LoadSlots()
        {
            List<ItemType> list = new List<ItemType>();
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            var cmdText = string.Format("SELECT * FROM ItemType");
            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(cmdText, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ItemType()
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            Name = reader["Name"].ToString().Trim()
                        });
                    }
                }
            }

            cbSlot.Items.Clear();
            cbSlot.DataSource = new BindingSource(list, null);
            cbSlot.DisplayMember = "Name";
            cbSlot.ValueMember = "ID";
        }

        private void LoadRarity()
        {
            List<ItemRarity> list = new List<ItemRarity>();
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            var cmdText = string.Format("SELECT * FROM ItemRarity");
            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(cmdText, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ItemRarity()
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            Name = reader["Name"].ToString().Trim()
                        });
                    }
                }
            }

            cbRarity.Items.Clear();
            cbRarity.DataSource = new BindingSource(list, null);
            cbRarity.DisplayMember = "Name";
            cbRarity.ValueMember = "ID";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var memberID = cbMember.SelectedValue.ToString();
            var raidID = cbRaidGroup.SelectedValue.ToString();
            var itemTypeID = cbSlot.SelectedValue.ToString();
            var itemRarityID = cbRarity.SelectedValue.ToString();
            var itemName = txtItem.Text;

            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            var cmdText = string.Format("INSERT INTO RaidLoot(Member_ID, Raid_ID, Item_Type_ID, Item_Rarity_ID, Item_Name, Timestamp) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')", memberID, raidID, itemTypeID, itemRarityID, itemName, DateTime.Now);
            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(cmdText, conn))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Successfully Added!");
                        LoadLootTable();
                        txtItem.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occured adding character: " + ex.Message);
                    }
                }
            }
        }

        private void LoadLootTable()
        {
            var raidID = cbRaidGroup.SelectedValue.ToString();
            List<RaidLoot> list = new List<RaidLoot>();
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT r.ID, r.Member_ID, m.Name, r.Item_Name, it.Name as ItemType, ir.name as ItemRarity, r.Timestamp ");
            sb.Append("FROM RaidLoot r ");
            sb.Append("INNER JOIN Member m ");
            sb.Append("ON r.Member_ID = m.ID ");
            sb.Append("INNER JOIN ItemType it ");
            sb.Append("ON r.Item_Type_ID = it.ID ");
            sb.Append("INNER JOIN ItemRarity ir ");
            sb.Append("ON r.Item_Rarity_ID = ir.ID ");
            sb.Append(string.Format("WHERE r.Raid_ID = {0}", raidID));
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
                        });
                    }
                }
            }

            LootList = list;

            PopulateGrid(LootList);
            

            //dataGridView1.DataSource = list;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<RaidLoot> list = new List<RaidLoot>();
            var x = WildCardToRegular(string.Format("*{0}*", txtSearch.Text));
            list = LootList.Where(w => Regex.IsMatch(w.MemberName, x, RegexOptions.IgnoreCase)).ToList();
            PopulateGrid(list);
        }
        private string WildCardToRegular(string value)
        {
            return "^" + Regex.Escape(value).Replace("\\*", ".*") + "$";
        }

        private void PopulateGrid(List<RaidLoot> list)
        {
            dataGridView1.Rows.Clear();
            var dgList = new List<DataGridViewRow>();
            foreach (var item in list)
            {
                var dgRow = new DataGridViewRow();
                dgRow.CreateCells(dataGridView1);
                dgRow.Cells[0].Value = item.ID;
                dgRow.Cells[1].Value = item.MemberName;
                dgRow.Cells[2].Value = item.ItemType;
                dgRow.Cells[3].Value = item.ItemRarity;
                dgRow.Cells[4].Value = item.ItemName;
                dgRow.Cells[5].Value = item.Recieved;
                dgList.Add(dgRow);
            }

            dataGridView1.Rows.AddRange(dgList.ToArray());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var index = dataGridView1.SelectedRows[0].Index;
            DeleteRecord(index);
        }

        private void DeleteRecord(int index)
        {
            var id = dataGridView1.Rows[index].Cells["ID"].Value.ToString();
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            var cmdText = string.Format("DELETE RaidLoot WHERE ID = '{0}'", id);
            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(cmdText, conn))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Successfully Deleted!");
                        LoadLootTable();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occured adding character: " + ex.Message);
                    }
                }
            }
        }
    }
}

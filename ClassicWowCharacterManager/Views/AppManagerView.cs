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

namespace ClassicWowCharacterManager.Views
{
    public partial class AppManagerView : UserControl
    {
        public AppManagerView()
        {
            InitializeComponent();
            PopulateGrids();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNew addNewForm = new AddNew();
            var result = addNewForm.ShowDialog();
            var name = "";
            var type = "";
            var desc = "";
            if (result == DialogResult.OK)
            {
                name = addNewForm.ElementName;
                type = addNewForm.Type;
                desc = addNewForm.Description;

                InsertNewItem(type, name, desc);
                PopulateGrids();
            }
        }

        private void InsertNewItem(string type, string name, string desc)
        {
            string cmdText = "";
            var table = GetTable(type);
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            if(string.IsNullOrWhiteSpace(desc))
                cmdText = string.Format("INSERT INTO {0}(Name) VALUES ('{1}')", table, name);
            else
                cmdText = string.Format("INSERT INTO {0}(Name, Description) VALUES ('{1}','{2}')", table, name, desc);
            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(cmdText, conn))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Successfully Added!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occured adding character: " + ex.Message);
                    }
                }
            }
        }

        private string GetTable(string type)
        {
            return type.Replace(" ", "");
        }

        private void PopulateGrids()
        {
            var RankList = new List<Rank>();
            var RaidList = new List<Raid>();
            var ItemTypeList = new List<ItemType>();
            var ItemRarityList = new List<ItemRarity>();
            var ProfessionList = new List<Profession>();
            var RoleList = new List<RaidRole>();

            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            var cmdText = "SELECT * FROM Rank";
            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(cmdText, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RankList.Add(new Rank()
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            Name = reader["Name"].ToString().Trim(),
                            Description = reader["Description"].ToString().Trim()
                        });
                    }
                }

                cmdText = "SELECT * FROM Profession";
                using (SqlCommand command = new SqlCommand(cmdText, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProfessionList.Add(new Profession()
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            Name = reader["Name"].ToString().Trim()
                        });
                    }
                }

                cmdText = "SELECT * FROM ItemType";
                using (SqlCommand command = new SqlCommand(cmdText, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ItemTypeList.Add(new ItemType()
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            Name = reader["Name"].ToString().Trim()
                        });
                    }
                }

                cmdText = "SELECT * FROM ItemRarity";
                using (SqlCommand command = new SqlCommand(cmdText, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ItemRarityList.Add(new ItemRarity()
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            Name = reader["Name"].ToString().Trim()
                        });
                    }
                }

                cmdText = "SELECT * FROM RaidGroup";
                using (SqlCommand command = new SqlCommand(cmdText, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RaidList.Add(new Raid()
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            Name = reader["Name"].ToString().Trim()
                        });
                    }
                }

                cmdText = "SELECT * FROM RaidRole";
                using (SqlCommand command = new SqlCommand(cmdText, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RoleList.Add(new RaidRole()
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            Name = reader["Name"].ToString().Trim(),
                            Description = reader["Description"].ToString().Trim()
                        });
                    }
                }
            }

            dgRaids.Rows.Clear();
            var dgList = new List<DataGridViewRow>();
            foreach (var item in RaidList)
            {
                var dgRow = new DataGridViewRow();
                dgRow.CreateCells(dgRaids);
                dgRow.Cells[0].Value = item.ID;
                dgRow.Cells[1].Value = item.Name;
                dgList.Add(dgRow);
            }
            dgRaids.Rows.AddRange(dgList.ToArray());
            //dgRaids.DataSource = RaidList;

            dgProfs.Rows.Clear();
            dgList = new List<DataGridViewRow>();
            foreach (var item in ProfessionList)
            {
                var dgRow = new DataGridViewRow();
                dgRow.CreateCells(dgProfs);
                dgRow.Cells[0].Value = item.ID;
                dgRow.Cells[1].Value = item.Name;
                dgList.Add(dgRow);
            }
            dgProfs.Rows.AddRange(dgList.ToArray());
            //dgProfs.DataSource = ProfessionList;

            dgItemTypes.Rows.Clear();
            dgList = new List<DataGridViewRow>();
            foreach (var item in ItemTypeList)
            {
                var dgRow = new DataGridViewRow();
                dgRow.CreateCells(dgItemTypes);
                dgRow.Cells[0].Value = item.ID;
                dgRow.Cells[1].Value = item.Name;
                dgList.Add(dgRow);
            }
            dgItemTypes.Rows.AddRange(dgList.ToArray());
            //dgItemTypes.DataSource = ItemTypeList;

            dgItemRarity.Rows.Clear();
            dgList = new List<DataGridViewRow>();
            foreach (var item in ItemRarityList)
            {
                var dgRow = new DataGridViewRow();
                dgRow.CreateCells(dgItemRarity);
                dgRow.Cells[0].Value = item.ID;
                dgRow.Cells[1].Value = item.Name;
                dgList.Add(dgRow);
            }
            dgItemRarity.Rows.AddRange(dgList.ToArray());
            //dgItemRarity.DataSource = ItemRarityList;

            dgRank.Rows.Clear();
            dgList = new List<DataGridViewRow>();
            foreach (var item in RankList)
            {
                var dgRow = new DataGridViewRow();
                dgRow.CreateCells(dgRank);
                dgRow.Cells[0].Value = item.ID;
                dgRow.Cells[1].Value = item.Name;
                dgRow.Cells[2].Value = item.Description;
                dgList.Add(dgRow);
            }
            dgRank.Rows.AddRange(dgList.ToArray());
            //dgRank.DataSource = RankList;

            dgRoles.Rows.Clear();
            dgList = new List<DataGridViewRow>();
            foreach (var item in RoleList)
            {
                var dgRow = new DataGridViewRow();
                dgRow.CreateCells(dgRoles);
                dgRow.Cells[0].Value = item.ID;
                dgRow.Cells[1].Value = item.Name;
                dgRow.Cells[2].Value = item.Description;
                dgList.Add(dgRow);
            }
            dgRoles.Rows.AddRange(dgList.ToArray());
            //dgRoles.DataSource = RoleList;

        }

        private void UpdateDataGrid(DataGridView dg, object source)
        {
            dg.DataSource = source;
        }

        private void btnDeleteRaid_Click(object sender, EventArgs e)
        {
            if (dgRaids.SelectedRows.Count < 1)
                return;
            var ID = (int)dgRaids.SelectedRows[0].Cells[0].Value;
            DeleteRow("RaidGroup", ID);
            PopulateGrids();
        }

        private void btnDeleteProf_Click(object sender, EventArgs e)
        {
            if (dgProfs.SelectedRows.Count < 1)
                return;
            var ID = (int)dgProfs.SelectedRows[0].Cells[0].Value;
            DeleteRow("Profession", ID);
            PopulateGrids();
        }

        private void btnDeleteType_Click(object sender, EventArgs e)
        {
            if (dgItemTypes.SelectedRows.Count < 1)
                return;
            var ID = (int)dgItemTypes.SelectedRows[0].Cells[0].Value;
            DeleteRow("ItemType", ID);
            PopulateGrids();
        }

        private void btnDeleteRarity_Click(object sender, EventArgs e)
        {
            if (dgItemRarity.SelectedRows.Count < 1)
                return;
            var ID = (int)dgItemRarity.SelectedRows[0].Cells[0].Value;
            DeleteRow("ItemRarity", ID);
            PopulateGrids();
        }

        private void btnDeleteRank_Click(object sender, EventArgs e)
        {
            if (dgRank.SelectedRows.Count < 1)
                return;
            var ID = (int)dgRank.SelectedRows[0].Cells[0].Value;
            DeleteRow("Rank", ID);
            PopulateGrids();
        }
        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            if (dgRoles.SelectedRows.Count < 1)
                return;
            var ID = (int)dgRoles.SelectedRows[0].Cells[0].Value;
            DeleteRow("RaidRole", ID);
            PopulateGrids();
        }

        private void DeleteRow(string table, int ID)
        {
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            var cmdText = string.Format("DELETE {0} WHERE ID = '{1}'", table, ID);
            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(cmdText, conn))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting record: " + ex.Message);
                    }
                }
            }
        }
    }
}

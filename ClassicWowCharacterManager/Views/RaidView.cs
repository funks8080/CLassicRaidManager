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
    public partial class RaidView : UserControl
    {
        public RaidView()
        {
            InitializeComponent();
            LoadRaids();
            LoadRoles();
            LoadAvailableMembers();
            LoadRaidMembers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRaidMember();

            LoadRaidMembers();
        }

        private void AddRaidMember()
        {
            var memberID = cbMember.SelectedValue.ToString();
            var roleID = cbRole.SelectedValue.ToString();
            var raidID = cbRaidGroup.SelectedValue.ToString();

            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            var cmdText = string.Format("INSERT INTO RaidGroupMember(Member_ID, Raid_ID, Role_ID) VALUES ('{0}','{1}','{2}')", memberID, raidID, roleID);
            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(cmdText, conn))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Successfully Added!");
                        LoadRaidMembers();
                        LoadAvailableMembers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occured adding character: " + ex.Message);
                    }
                }
            }
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

            cbRaidGroup.DataSource = new BindingSource(list, null);
            cbRaidGroup.DisplayMember = "Name";
            cbRaidGroup.ValueMember = "ID";
        }

        private void LoadRoles()
        {
            List<RaidRole> list = new List<RaidRole>();
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            var cmdText = string.Format("SELECT * FROM RaidRole");
            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(cmdText, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new RaidRole()
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            Name = reader["Name"].ToString().Trim()
                        });
                    }
                }
            }

            cbRole.DataSource = new BindingSource(list, null);
            cbRole.DisplayMember = "Name";
            cbRole.ValueMember = "ID";
        }

        private void cbRaidGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadRaidMembers();
            LoadAvailableMembers();
        }

        private void LoadAvailableMembers()
        {
            var raidID = cbRaidGroup.SelectedValue.ToString();
            List<RaidMember> list = new List<RaidMember>();
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT m.ID, m.Name, r.ID as RaidID ");
            sb.Append("FROM Member m ");
            sb.Append("LEFT JOIN RaidGroupMember rm ");
            sb.Append("ON m.ID = rm.Member_ID ");
            sb.Append("LEFT JOIN RaidGroup r ");
            sb.Append("ON r.ID = rm.Raid_ID ");
            sb.Append(string.Format("WHERE m.Active = 1 AND(r.ID != '{0}' OR r.ID IS NULL) ", raidID));

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
                            MemberName = reader["Name"].ToString().Trim(),
                            RaidID = reader["RaidID"] == DBNull.Value ? -1 : int.Parse(reader["RaidID"].ToString())
                        });
                    }
                }
            }

            cbMember.DataSource = new BindingSource(list, null);
            cbMember.DisplayMember = "MemberName";
            cbMember.ValueMember = "ID";
        }

        private void LoadRaidMembers()
        {
            var raidID = cbRaidGroup.SelectedValue.ToString();
            List<RaidMember> list = new List<RaidMember>();
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            var cmdText = string.Format("SELECT * FROM RaidGroupMember");
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT r.ID, m.ID as MemberID, m.Name, r.ID as RaidID, rr.Name as RoleName, rr.ID as RoleID, rr.Description ");
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
                            MemberID = int.Parse(reader["MemberID"].ToString().Trim()),
                            MemberName = reader["Name"].ToString().Trim(),
                            RaidID = int.Parse(reader["RaidID"].ToString()),
                            RaidRole = reader["RoleName"].ToString(),
                            RaidRoleID = int.Parse(reader["RoleID"].ToString()),
                            RoleDescription = reader["Description"].ToString()
                        });
                    }
                }
            }

            dataGridView1.Rows.Clear();
            var dgList = new List<DataGridViewRow>();
            foreach (var item in list)
            {
                var dgRow = new DataGridViewRow();
                dgRow.CreateCells(dataGridView1);
                dgRow.Cells[0].Value = item.ID;
                dgRow.Cells[1].Value = item.MemberName;
                dgRow.Cells[2].Value = item.RaidRole;
                dgRow.Cells[3].Value = item.RoleDescription;
                dgList.Add(dgRow);
            }
            dataGridView1.Rows.AddRange(dgList.ToArray());

            //dataGridView1.DataSource = list;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var index = dataGridView1.SelectedRows[0].Index;
            RemoveMember(index);
        }

        private void RemoveMember(int index)
        {
            var id = dataGridView1.Rows[index].Cells["ID"].Value.ToString();
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            var cmdText = string.Format("DELETE RaidGroupMember WHERE ID = '{0}'", id);
            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(cmdText, conn))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Successfully Removed!");
                        LoadRaidMembers();
                        LoadAvailableMembers();
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

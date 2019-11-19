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
    public partial class MemberView : UserControl
    {
        private List<FactionRaceClass> FacRaceClassList;
        private List<Member> MembersList;
        private string MemberNotes;
        //private List<Member>;
        public MemberView()
        {
            InitializeComponent();
            FacRaceClassList = GetFactionRaceClassList();
            FillFactionDrop(FacRaceClassList);
            var ProfessionList = GetProfessionList();
            FillProfessionDrop(ProfessionList);
            var RankList = GetRankList();
            FillRankDrop(RankList);
            LoadMembers();
        }

        private void FillFactionDrop(List<FactionRaceClass> list)
        {
            var Factions = list.Select(s => s.Faction).Distinct().ToArray();
            Array.Sort(Factions);
            cbFaction.Items.Clear();
            cbFaction.Items.AddRange(Factions);
            cbFaction.SelectedIndex = 0;
        }

        private void FillRaceDrop(List<FactionRaceClass> list)
        {
            var Races = list.Select(s => s.Race).Distinct().ToArray();
            Array.Sort(Races);
            cbRace.Items.Clear();
            cbRace.Items.AddRange(Races);
            cbRace.SelectedIndex = 0;
        }

        private void FillClassDrop(List<FactionRaceClass> list)
        {
            var Classes = list.Select(s => s.Class).ToArray();
            Array.Sort(Classes);
            cbClass.Items.Clear();
            cbClass.Items.AddRange(Classes);
            cbClass.SelectedIndex = 0;
        }

        private void FillProfessionDrop(List<Profession> list)
        {
            cbProf1.Items.Clear();
            cbProf1.DataSource = new BindingSource(list, null);
            cbProf1.DisplayMember = "Name";
            cbProf1.ValueMember = "ID";

            cbProf2.Items.Clear();
            cbProf2.DataSource = new BindingSource(list, null);
            cbProf2.DisplayMember = "Name";
            cbProf2.ValueMember = "ID";
        }

        private void FillRankDrop(List<Rank> list)
        {
            cbRank.Items.Clear();
            cbRank.DataSource = new BindingSource(list, null);
            cbRank.DisplayMember = "Name";
            cbRank.ValueMember = "ID";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddMember();

            ResetValues();
            LoadMembers();
        }

        private void AddMember()
        {
            var name = txtName.Text;
            var faction = cbFaction.SelectedItem.ToString();
            var race = cbRace.SelectedItem.ToString();
            var cls = cbClass.SelectedItem.ToString();
            var rank = (int)cbRank.SelectedValue;
            var prof1 = (int)cbProf1.SelectedValue;
            var prof2 = (int)cbProf2.SelectedValue;
            var notes = MemberNotes;
            var active = chkActive.Checked;
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            var cmdText = string.Format("INSERT INTO Member(Name, Faction, Race, Class, Rank, Prof1, Prof2, Notes, Active ) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", name, faction, race, cls, rank, prof1, prof2, notes, active);
            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(cmdText, conn))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Successfully Added!");
                        ResetValues();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occured adding character: " + ex.Message);
                    }
                }
            }
        }

        private void ResetValues()
        {
            txtName.Text = "";
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var name = txtName.Text;
            var faction = cbFaction.SelectedItem.ToString();
            var race = cbRace.SelectedItem.ToString();
            var cls = cbClass.SelectedItem.ToString();
            var rank = cbRank.SelectedValue.ToString();
            var prof1 = cbProf1.SelectedValue.ToString();
            var prof2 = cbProf2.SelectedValue.ToString();
            var notes = MemberNotes;
            var active = chkActive.Checked;
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            var cmdText = string.Format("UPDATE Member SET Faction = '{0}', Race = '{1}', Class = '{2}', Rank = '{3}', Prof1 = '{4}', Prof2 = '{5}', Notes = '{6}', Active = '{7}' WHERE Name = '{8}'", faction, race, cls, rank, prof1, prof2, notes, active, name);
            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(cmdText, conn))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Successfully Updated!");
                        ResetValues();
                        LoadMembers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occured adding character: " + ex.Message);
                    }
                }
            }
        }

        private List<FactionRaceClass> GetFactionRaceClassList()
        {
            var list = new List<FactionRaceClass>();
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            var cmdText = "SELECT * FROM FactionRaceClass";
            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(cmdText, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new FactionRaceClass()
                        {
                            Faction = reader["Faction"].ToString().Trim(),
                            Race = reader["Race"].ToString().Trim(),
                            Class = reader["Class"].ToString().Trim()
                        });
                    }
                }
            }
            return list;
        }
        private List<Profession> GetProfessionList()
        {
            var list = new List<Profession>();
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            var cmdText = "SELECT * FROM Profession";
            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(cmdText, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Profession()
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            Name = reader["Name"].ToString().Trim()
                        });
                    }
                }
            }
            return list;
        }

        private List<Rank> GetRankList()
        {
            var list = new List<Rank>();
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
                        list.Add(new Rank()
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            Name = reader["Name"].ToString().Trim()
                        });
                    }
                }
            }
            return list;
        }

        private void cbFaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = FacRaceClassList.Where(w => w.Faction == cbFaction.SelectedItem.ToString()).Select(s => s).ToList();
            FillRaceDrop(list);
        }

        private void cbRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = FacRaceClassList.Where(w => w.Faction == cbFaction.SelectedItem.ToString() && w.Race == cbRace.SelectedItem.ToString()).Select(s => s).ToList();
            FillClassDrop(list);
        }

        private void LoadMembers()
        {
            var list = new List<Member>();
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT m.ID, m.Name, m.Faction, m.Race, m.Class, r.Name as Rank, p.Name as Prof1, p2.name as Prof2, m.Active, m.Notes ");
            sb.Append("FROM Member m ");
            sb.Append("INNER JOIN Rank r ");
            sb.Append("ON r.ID = m.Rank ");
            sb.Append("INNER JOIN Profession p ");
            sb.Append("ON p.ID = m.Prof1 ");
            sb.Append("INNER JOIN Profession p2 ");
            sb.Append("ON p2.ID = m.Prof2 ");

            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sb.ToString(), conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Member()
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            Name = reader["Name"].ToString().Trim(),
                            Rank = reader["Rank"].ToString().Trim(),
                            Class = reader["Class"].ToString().Trim(),
                            Faction = reader["Faction"].ToString().Trim(),
                            Race = reader["Race"].ToString().Trim(),
                            Profession1 = reader["Prof1"].ToString().Trim(),
                            Profession2 = reader["Prof2"].ToString().Trim(),
                            Active = Convert.ToBoolean(reader["Active"]),
                            Notes = reader["Notes"].ToString().Trim()
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
                dgRow.Cells[1].Value = item.Faction;
                dgRow.Cells[2].Value = item.Race;
                dgRow.Cells[3].Value = item.Name;
                dgRow.Cells[4].Value = item.Rank;
                dgRow.Cells[5].Value = item.Class;
                dgRow.Cells[6].Value = item.Profession1;
                dgRow.Cells[7].Value = item.Profession2;
                dgRow.Cells[8].Value = item.Active;
                dgRow.Cells[9].Value = item.Notes;

                if(!item.Active)
                    dgRow.DefaultCellStyle.BackColor = Color.Red;
                dgList.Add(dgRow);
            }
            dataGridView1.Rows.AddRange(dgList.ToArray());

            MembersList = list;
            //dataGridView1.DataSource = list;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            PopulateMemberInfo(e.RowIndex);
            //txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            //cbFaction.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["Faction"].Value.ToString();
            //cbRace.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["Race"].Value.ToString();
            //cbClass.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["Class"].Value.ToString();
            //cbRank.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["Rank"].Value.ToString();
            //cbProf1.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["Profession1"].Value.ToString();
            //cbProf2.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["Profession2"].Value.ToString();
            //chkActive.Checked = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["Active"].Value);
            //MemberNotes = dataGridView1.Rows[e.RowIndex].Cells["Notes"].Value.ToString();
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            Notes noteBox = new Notes(MemberNotes);

            var result = noteBox.ShowDialog();
            if (result == DialogResult.OK)
            {
                MemberNotes = noteBox.MemberNotes;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            var name = txtName.Text.ToUpper();

            var member = MembersList.Where(w => w.Name.ToUpper() == name).FirstOrDefault();
            if(member == null)
            {
                btnUpdate.Enabled = false;
                btnAdd.Enabled = true;
                MemberNotes = "";
                chkActive.Checked = true;
            }
            else
            {
                btnUpdate.Enabled = true;
                btnAdd.Enabled = false;
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    if(row.Cells["MemberName"].Value.ToString().ToUpper() == name)
                    {
                        PopulateMemberInfo(row.Index);
                        break;
                    }
                }
            }
        }

        private void PopulateMemberInfo(int index)
        {
            txtName.Text = dataGridView1.Rows[index].Cells["MemberName"].Value.ToString();
            cbFaction.SelectedItem = dataGridView1.Rows[index].Cells["Faction"].Value.ToString();
            cbRace.SelectedItem = dataGridView1.Rows[index].Cells["Race"].Value.ToString();
            cbClass.SelectedItem = dataGridView1.Rows[index].Cells["Class"].Value.ToString();
            cbRank.SelectedItem = dataGridView1.Rows[index].Cells["Rank"].Value.ToString();
            cbProf1.SelectedItem = dataGridView1.Rows[index].Cells["Prof1"].Value.ToString();
            cbProf2.SelectedItem = dataGridView1.Rows[index].Cells["Prof2"].Value.ToString();
            chkActive.Checked = Convert.ToBoolean(dataGridView1.Rows[index].Cells["Active"].Value);
            MemberNotes = dataGridView1.Rows[index].Cells["Notes"].Value.ToString();
            dataGridView1.ClearSelection();
            dataGridView1.Rows[index].Selected = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var index = dataGridView1.SelectedRows[0].Index;
            DeleteMember(index);
        }

        private void DeleteMember(int index)
        {
            var memberID = dataGridView1.Rows[index].Cells["ID"].Value.ToString();
            //var x = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\0023806\source\repos\ClassicWowCharacterManager\ClassicWowCharacterManager\WoWServer.mdf;Integrated Security=True";
            var x = DatabaseConnection.DB2;
            var cmdText = string.Format("DELETE Member WHERE ID = '{0}'", memberID);
            using (SqlConnection conn = new SqlConnection(x))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(cmdText, conn))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Successfully Deleted!");
                        ResetValues();
                        LoadMembers();
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace SQLProcessKill
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        ConnectionSettings settings;

        List<ListViewItem> listItems = new List<ListViewItem>();

        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
            chkShowMore.Checked = true;
            chkShowMore.Checked = false;
            chkBlocking.Checked = true;
        }

        public void InitializeDatabase()
        {
            settings = new ConnectionSettings();

            if(!settings.hasSettings)
            {
                ConnectionForm form = new ConnectionForm(this);
                form.ShowDialog();
            }
            else
            {
                conn = new SqlConnection(settings.connectionString);

                try
                {
                    UpdateProcessList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void UpdateProcessList()
        {
            lstProcesses.Items.Clear();
            listItems.Clear();

            try
            {
                conn.Open();

                string query = "sp_who2";                
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader.GetString(0);
                    string status = reader.GetString(1);
                    string login  = reader.GetString(2);
                    string hostname = reader.GetString(3);
                    string blockedBy = reader.GetString(4);

                    bool isBlocked = false;
                    if (blockedBy.Trim() != ".") //Change to !=
                    {
                        isBlocked = true;
                    }

                    string db = null;
                    if (reader["DBName"].GetType() != typeof(DBNull))
                        db = reader.GetString(5);

                    string com = null;
                    if (reader["Command"].GetType() != typeof(DBNull))
                        com = reader.GetString(6);

                    string time = reader.GetString(9);

                    if (!string.IsNullOrEmpty(id))
                    {
                        ListViewItem item = new ListViewItem(new string[] { id, status, hostname, blockedBy, db, com, time });
                        
                        if (isBlocked)
                            item.ForeColor = Color.Red;

                        listItems.Add(item);
                    }
                }

                if (!chkBlocking.Checked)
                    FillListView(showAll: chkShowAll.Checked);
                else
                    ShowBlockingProcesses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        public void KillProcess(string id)
        {
            try
            {
                conn.Open();

                string query = $"kill {id}";
                SqlCommand command = new SqlCommand(query, conn);

                int rows = command.ExecuteNonQuery();

                if (rows > 0)
                    MessageBox.Show($"Process killed successfully! Rows: {rows}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                UpdateProcessList();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateProcessList();
        }

        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if(chkShowAll.Checked)
                chkBlocking.Checked = false;

            FillListView(showAll: chkShowAll.Checked);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lstProcesses.SelectedItems.Count > 0) {
                string id = lstProcesses.SelectedItems[0].Text.Trim();
                DialogResult result = MessageBox.Show($"Are you sure you want to kill process with ID: {id}",
                    "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                        KillProcess(id);
            }
        }

        private void chkShowMore_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkShowMore.Checked)
            {
                lstProcesses.Columns[5].Width = 0;
                lstProcesses.Columns[6].Width = 0;
            }
            else
            {
                lstProcesses.Columns[5].Width = 80;
                lstProcesses.Columns[6].Width = 150;
            }
        }

        public void FillListView(bool showAll = false, List<string> blockingList = null)
        {
            lstProcesses.Items.Clear();
            foreach (ListViewItem item in listItems)
            {
                if (!chkBlocking.Checked && !showAll && item.ForeColor != Color.Red)
                    continue;

                if (!chkBlocking.Checked && !showAll && item.SubItems[1].Text.Trim() != "SUSPENDED")
                    continue;

                if (chkBlocking.Checked && blockingList != null && !blockingList.Contains(item.SubItems[0].Text.Trim()))
                    continue;

                lstProcesses.Items.Add(item);
            }
        }

        public void ShowBlockingProcesses()
        {
            bool isFirst = true;
            List<string> blocking = new List<string>();

            foreach(ListViewItem item in listItems)
            {
                if (item.SubItems[3].Text.Trim() != ".") //If there is another process blocking it
                {
                    if (isFirst)
                    {
                        isFirst = !isFirst;
                        blocking.Add(item.SubItems[0].Text.Trim());
                    }
                    string blockId = item.SubItems[3].Text.Trim();
                    
                    if (!blocking.Contains(blockId))
                        blocking.Add(blockId);
                }
            }

            if(blocking.Count > 0)
                FillListView(chkShowAll.Checked, blocking);
            else
                chkBlocking.Checked = false;
        }

        private void chkBlocking_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkBlocking.Checked)
                FillListView(chkShowAll.Checked);
            else
            {
                chkShowAll.Checked = false;
                ShowBlockingProcesses();
            }
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionForm form = new ConnectionForm();
            form.ShowDialog();
            InitializeDatabase();
        }
    }
}

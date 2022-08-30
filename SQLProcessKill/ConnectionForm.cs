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

namespace SQLProcessKill
{
    public partial class ConnectionForm : Form
    {
        Form1 callbackForm = null;

        public ConnectionForm()
        {
            InitializeComponent();
        }

        public ConnectionForm(Form1 form)
        {
            InitializeComponent();
            callbackForm = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionSettings settings = new ConnectionSettings();
            settings.SaveSettings(txtServer.Text, txtDB.Text, txtUser.Text, txtPass.Text);
            if(callbackForm != null)
                callbackForm.InitializeDatabase();
            this.Close();
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
            ConnectionSettings settings = new ConnectionSettings();
            settings.ReadSettings();

            if (settings.hasSettings)
            {
                txtServer.Text = settings.instance;
                txtDB.Text = settings.database;
                txtUser.Text = settings.user;
                txtPass.Text = settings.pwd;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionstring = GetConnectionString();

            if (connectionstring != null)
            {
                SqlConnection conn = new SqlConnection(connectionstring);

                try
                {
                    conn.Open();
                    conn.Close();
                    MessageBox.Show("The connection was successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
            {
                MessageBox.Show("Please fill in the information above first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string GetConnectionString()
        {
            string connectionString = "Server=@Instance;Database=@Database;User Id=@User;Password=@Password;";
            return connectionString.Replace("@Instance", txtServer.Text).Replace("@Database", txtDB.Text)
                    .Replace("@User", txtUser.Text).Replace("@Password", txtPass.Text);
        }
    }
}

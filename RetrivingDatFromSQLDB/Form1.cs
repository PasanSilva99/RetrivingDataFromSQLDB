using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace RetrivingDatFromSQLDB
{
    public partial class Form1 : Form
    {
        String 
            FirstName,
            LastName,
            UserName,
            Password;

        int Age;

        /// <summary>
        /// dqnicjdaco
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            FirstName = tb_firstName.Text;
            LastName = tb_lastName.Text;
            UserName = tb_userName.Text;
            Password = tb_password.Text;
            Age = int.Parse(tb_age.Text);

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\UserData7_21.mdf;Integrated Security=True;Connect Timeout=30");
            String qry = "INSERT INTO user VALUES('" + FirstName + "', '" + LastName + "', '" + UserName + "', '" + Password + "', '" + Age + "')";
            SqlCommand cmd = new SqlCommand(qry, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("✔ SignUp Successfull", "Successfull");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
           
        }
    }
}

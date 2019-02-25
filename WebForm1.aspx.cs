using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Text;

using System.Web.UI.WebControls;

using System.Data.OleDb;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string username;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

        protected void login_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\sanka\Desktop\userdetails.accdb";
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select * from userdetails where Username = '" + userid.Text + "'and Password = '" + password.Text + "'";
            OleDbDataReader reader = cmd.ExecuteReader();
            int count = 0;

            while (reader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                MessageBox.Show("Login successful");
                this.Hide();
                username = userid.Text;
                betting bet = new betting();
                bet.getusername(username.ToString());
                bet.Show();
                
                
               


            }
            else
            {
                MessageBox.Show("Invalid username or Password");

            }

            con.Close();
        }
    }
}

   
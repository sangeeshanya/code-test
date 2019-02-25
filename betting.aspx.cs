using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Text;


namespace WebApplication2
{
    public partial class betting : System.Web.UI.Page
    {
        string usernam;
        int bal;
        int match = 1; // let assume match = 1 is betting won 
        
       

        protected void Page_Load(object sender, EventArgs e)
        {

        }

       public void getusername(string username)
       {
            usernam = username.ToString();
       }
        protected void placebet_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\sanka\Desktop\userdetails.accdb";
            cmd.Connection = con;
            
                con.Open();
                cmd.CommandText = "select * from userdetails where Username = '" + usernam + "'";
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string balance = (reader["amount"].ToString());
                    bal = int.Parse(balance);
                if (bal < 50)
                {
                    MessageBox.Show("You have insufficient bal");
                }
                    MessageBox.Show("Your bal " + bal);
                else{



                    if (match == 1)
                    {
                        MessageBox.Show("You won the bet");
                        bal = bal + 50;

                    }
                    else
                    {
                        MessageBox.Show("You lost the bet");
                        bal = bal - 50;

                    }
                    MessageBox.Show("Your current bal is: " + bal);
                    cmd.CommandText = "Update userdetails set amount = '" + bal + "' where Username = '" + usernam + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();



                }


                }
                
            
            

        }
    }
}
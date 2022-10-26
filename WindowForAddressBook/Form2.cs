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
namespace WindowForAddressBook
{
    public partial class Form2 : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        ConnectionDB db=new ConnectionDB();
        Form1 form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            con = new SqlConnection(db.GetConnection());
            this.form1 = form1;
        }
        private void Clear()
        {
            txtEmployeeID.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtMiddelName.Clear();
            txtAddresss.Clear();
            txtContact.Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            txtEmployeeID.Focus();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtEmployeeID.Text==""||txtLastName.Text==""||txtFirstName.Text==""|| txtMiddelName.Text==""||txtAddresss.Text== ""||txtContact.Text=="")
                {
                    MessageBox.Show("Required missing filed!","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                con.Open();
                cmd = new SqlCommand("INSERT INTO tbl_Employees (employee_id,lastname,firstname,middlename,address,contact) VALUES (@employee_id,@lastname,@firstname,@middlename,@address,@contact)", con);
                cmd.Parameters.AddWithValue("@employee_id",txtEmployeeID.Text);
                cmd.Parameters.AddWithValue("@lastname",txtLastName.Text);
                cmd.Parameters.AddWithValue("@firstname",txtFirstName.Text);
                cmd.Parameters.AddWithValue("@middlename",txtMiddelName.Text);
                cmd.Parameters.AddWithValue("@address",txtAddresss.Text);
                cmd.Parameters.AddWithValue("@contact",txtContact.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("New employee has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form1.LoadRecords();
                Clear();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message,"WARNING",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }
            
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text == "" || txtLastName.Text == "" || txtFirstName.Text == "" || txtMiddelName.Text == "" || txtAddresss.Text == "" || txtContact.Text == "")
            {
                MessageBox.Show("Required missing filed!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                
                if (MessageBox.Show("Want to update this record?","Message",MessageBoxButtons.YesNo ,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE tbl_Employees SET lastname=@lastname,firstname=@firstname,middlename=@middlename,address=@address,contact=@contact WHERE employee_id=@employee_id",con);
                    cmd.Parameters.AddWithValue("@employee_id", txtEmployeeID.Text);
                    cmd.Parameters.AddWithValue("@lastname", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@firstname", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@middlename", txtMiddelName.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddresss.Text);
                    cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("employee has been successfully updated.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    form1.LoadRecords();
                    Clear();
                }


            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myData.tbl_Employees' table. You can move, or remove it, as needed.

        }
    }
}

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
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        ConnectionDB db=new ConnectionDB();
        public Form1()
        {
            InitializeComponent();
            con=new SqlConnection(db.GetConnection());
            LoadRecords();
        }
        public void LoadRecords()
        { 
            dgvEmployees.Rows.Clear();
          
            int i =0;
            con.Open();
            cmd = new SqlCommand("SELECT * FROM tbl_Employees", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvEmployees.Rows.Add(i,dr["employee_id"].ToString(), dr["lastname"].ToString(), dr["firstname"].ToString(), dr["middlename"].ToString(), dr["address"].ToString(), dr["contact"].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(this);
            frm.btnSave.Enabled = true;
            frm.btnUpdate.Enabled = false;
            frm.ShowDialog();
        }

        private void labAddressbook_Click(object sender, EventArgs e)
        {

        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvEmployees.Columns[e.ColumnIndex].Name;
            if (colName == "colEdit")
            {
                Form2 f = new Form2(this);
                f.txtEmployeeID.Text = dgvEmployees.Rows[e.RowIndex].Cells[1].Value.ToString();
                f.txtLastName.Text = dgvEmployees.Rows[e.RowIndex].Cells[2].Value.ToString();
                f.txtFirstName.Text = dgvEmployees.Rows[e.RowIndex].Cells[3].Value.ToString();
                f.txtMiddelName.Text = dgvEmployees.Rows[e.RowIndex].Cells[4].Value.ToString();
                f.txtAddresss.Text = dgvEmployees.Rows[e.RowIndex].Cells[5].Value.ToString();
                f.txtContact.Text = dgvEmployees.Rows[e.RowIndex].Cells[6].Value.ToString();
                f.txtEmployeeID.Enabled = false;
                f.btnSave.Enabled = false;
                f.btnUpdate.Enabled = true;
                f.ShowDialog();

            }
            else if (colName == "colDelete")
            {
                if (MessageBox.Show("Want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ;
                {
                    con.Open();
                    cmd = new SqlCommand(@"DELETE FROM tbl_Employees WHERE employee_id = '" + dgvEmployees.Rows[e.RowIndex].Cells[1].Value.ToString() + "'",con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //MessageBox.Show("Record hes been successfully deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecords();

                }
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close this windows?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myData.tbl_Employees' table. You can move, or remove it, as needed.

        }
    }
}

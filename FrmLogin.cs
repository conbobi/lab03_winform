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
namespace Tien_897
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        int loginAttempts = 0;
        private void mnuLogin_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string password = txtPass.Text;

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                return;
            }

            string connectionString = @"Data Source=ADMIN-PC;Initial Catalog=QLKHACHHANG;Integrated Security=True";
            string sql = "SELECT userr.Pasword FROM userr WHERE ID = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có Id này!", "Thông báo");
                        return;
                    }

                    string storedPassword = dataTable.Rows[0]["Pasword"].ToString();

                    if (password != storedPassword)
                    {
                        MessageBox.Show("Sai mật khẩu!", "Thông báo");
                        loginAttempts++;
                        if (loginAttempts >= 3)
                        {
                            MessageBox.Show("Sai mật khẩu quá 3 lần. Chương trình sẽ thoát.", "Thông báo");
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                        frmMDI frmMDI = new frmMDI(true);
                       frmMDI.ShowDialog();
                        this.Close(); // Đóng form đăng nhập
                        // Enable các chức năng mnuDataBase và mnuSolve
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi");
                }
            }
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtPass.Text = "";
            txtId.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form đăng nhập
        }
    }
}

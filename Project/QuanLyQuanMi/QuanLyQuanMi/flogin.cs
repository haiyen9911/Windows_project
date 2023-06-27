using QuanLyQuanMi.DAO;
using QuanLyQuanMi.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanMi
{
    public partial class flogin : Form
    {
        public flogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // Đóng chương trình
        private void flogin_FormClosing(object sender, FormClosingEventArgs e) 
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) 
            {
                e.Cancel = true;
            }
        }
        // Button thoát chương trình
        private void BtThoat_Click_1(object sender, EventArgs e) 
        {
            Application.Exit();
        }
        // Button đăng nhập
        private void BtDangNhap_Click(object sender, EventArgs e) 
        {
            string username = TextBoxDangNhap.Text;
            string password = TextBoxMatKhau.Text;
            if (TextBoxDangNhap.Text == "" || TextBoxMatKhau.Text == "") //Kiểm tra xem hai TextBox có giá trị trống hay không
            {
                MessageBox.Show("Điền đầy đủ tên đăng nhập và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            if (Login(username,password)) //gọi phương thức "Login" của đối tượng "AccountDAO.Instance" để kiểm tra xem tên đăng nhập và mật khẩu có khớp với cơ sở dữ liệu hay không.
            {
                Account loginaccount = AccountDAO.Instance.GetAccountByUserName(username); //lấy thông tin tài khoản đăng nhập bằng cách gọi phương thức "GetAccountByUserName(username)" của đối tượng "AccountDAO.Instance".(để xem loại tài khoản đăng nhập vào là gì)
                
                ftable f = new ftable(loginaccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu", "Thông Báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        bool Login(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }
    }
}

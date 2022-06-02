using CafeManager.DAO;
using CafeManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManager
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;
            if (Login(userName, passWord)) // đăng nhập form login với tên đăng nhập và mật khẩu
            {
                fTableManager f = new fTableManager(); // khởi tạo fTableManager
                this.Hide(); // ẩn form login
                f.ShowDialog(); // hiện form fTableManager lên
                this.Show(); // hiển thị lại form login
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!"); // hiển thị hộp tin nhắn có nội dung Sai tên tài khoản hoặc mật khẩu
            }
        }

        bool Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // thoát ứng dụng
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) // hiển thị hộp tin nhắn có tiêu đề Thông báo với nội dung Bạn có thật sự muốn thoát chương trình?, có 2 nút là OK và Cancel và không chọn OK
            {
                e.Cancel = true; // Cancel được thực hiện
            }
        }
    }
}

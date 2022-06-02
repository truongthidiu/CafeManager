using CafeManager.DAO;
using CafeManager.DTO;
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

namespace CafeManager
{
    public partial class fAdmin : Form
    {
        BindingSource foodList = new BindingSource(); // hạn chế mất kết nối binding

        BindingSource accountList = new BindingSource();

        BindingSource categoryList = new BindingSource();

        BindingSource tableList = new BindingSource();

        public fAdmin()
        {
            InitializeComponent();
            dtgvFood.DataSource = foodList;
            dtgvAccount.DataSource = accountList;
            dtgvCategory.DataSource = categoryList;
            dtgvTable.DataSource = tableList;
            LoadListFood();
            LoadListCategory();
            LoadListTable();
            LoadAccount();
            LoadCategoryIntoCombobox(cbFoodCategory);
            AddFoodBinding();
            AddCategoryBinding();
            AddAccountBinding();
            AddTableBinding();
        }

        

        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "NameCategory";
        }
        void AddFoodBinding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "NameFood", true, DataSourceUpdateMode.Never));//// thay đổi giá trị của thuộc tính “Text” bằng giá trị của “NameFood” nguồn từ dtgv.DataSource
            txbFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as CategoryDTO).IdFoodCategory;
            float price = (float)nmFoodPrice.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListFood();
            }
        }
        private void btnEditFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as CategoryDTO).IdFoodCategory;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();
            }
        }
        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListFood();
            }
        }

        void LoadListCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }
        void AddCategoryBinding()
        {
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "NameCategory", true, DataSourceUpdateMode.Never));
            txbCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "IdFoodCategory", true, DataSourceUpdateMode.Never));
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadListCategory();
        }
        private void btnAddCategory_Click_1(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;

            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm danh mục món thành công");
                LoadListCategory();
            }
        }
        private void btnEditCategory_Click_1(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;
            int id = Convert.ToInt32(txbCategoryID.Text);

            if (CategoryDAO.Instance.UpdateCategory(id, name))
            {
                MessageBox.Show("Sửa danh mục món thành công");
                LoadListCategory();
            }
        }
        private void btnDeleteCategory_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbCategoryID.Text);

            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListCategory();
            }
        }
        void LoadListTable()
        {
            tableList.DataSource = TableDAO.Instance.LoadTableList();
        }
        void AddTableBinding()
        {
            txbTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "NameTable", true, DataSourceUpdateMode.Never));
            txbTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "IdFoodTable", true, DataSourceUpdateMode.Never));
        }
        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadListTable();
        }
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string name = txbTableName.Text;

            if (TableDAO.Instance.InsertTable(name))
            {
                MessageBox.Show("Thêm bàn thành công");
                LoadListTable();
            }
        }
        private void btnEditTable_Click(object sender, EventArgs e)
        {
            string name = txbTableName.Text;
            int id = Convert.ToInt32(txbTableID.Text);

            if (TableDAO.Instance.UpdateTable(id, name))
            {
                MessageBox.Show("Sửa bàn thành công");
                LoadListTable();
            }
        }
        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbTableID.Text);

            if (TableDAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xóa bàn thành công");
                LoadListTable();
            }
        }


        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        private void btnShowAccount_Click_1(object sender, EventArgs e)
        {
            LoadAccount();
        }
        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            numericUpDown1.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "TypeAccount", true, DataSourceUpdateMode.Never));
        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)numericUpDown1.Value;

            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
            LoadAccount();
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)numericUpDown1.Value;

            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }
            LoadAccount();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }
            LoadAccount();
        }
        private void txbFoodID_TextChanged(object sender, EventArgs e)
        {
            if (dtgvFood.SelectedCells.Count > 0)
            {
                int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value; // từ dtgvFood, chọn 1 ô bất kì, lấy ra dòng đang chứa ô đó, lấy tất cả các ô của dòng đó, sau đó lấy ra ô có “CategoryID”, lấy giá trị rồi ép kiểu

                CategoryDTO category = CategoryDAO.Instance.GetCategoryByID(id);

                cbFoodCategory.SelectedItem = category;

                int index = -1;
                int i = 0;
                foreach (CategoryDTO item in cbFoodCategory.Items)
                {
                    if (item.IdFoodCategory == category.IdFoodCategory)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbFoodCategory.SelectedIndex = index;
            }
        }

        private void dtgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbFoodID_TextChanged(sender, e);
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void tpFood_Click(object sender, EventArgs e)
        {

        }
        private void panel3_PaddingChanged(object sender, EventArgs e)
        {

        }
        private void dtgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void tcAdmin_Click(object sender, EventArgs e)
        {
            
        }

        private void txbFoodName_TextChanged(object sender, EventArgs e)
        {

        }
        private void cbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cbAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void fAdmin_Load(object sender, EventArgs e)
        {
            
        }

        private void txbFoodID_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}

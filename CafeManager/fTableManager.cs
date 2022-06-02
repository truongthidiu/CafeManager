using CafeManager.DAO;
using CafeManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManager
{
    public partial class fTableManager : Form
    {

        
        public fTableManager()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
        }

        #region Method

        
        void LoadTable()
        {
            List<TableDTO> tableList = TableDAO.Instance.LoadTableList();

            foreach (TableDTO item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.NameTable + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }

                flpTable.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            
                lsvBill.Items.Clear();
                List<CafeManager.DTO.MenuDTO> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
                float totalPrice = 0;
                foreach (CafeManager.DTO.MenuDTO item in listBillInfo)
                {
                    ListViewItem lsvItem = new ListViewItem(item.NameFood.ToString());
                    lsvItem.SubItems.Add(item.Amount.ToString());
                    lsvItem.SubItems.Add(item.Price.ToString());
                    lsvItem.SubItems.Add(item.TotalPrice.ToString());
                    totalPrice += item.TotalPrice;
                    lsvBill.Items.Add(lsvItem);
                }
                CultureInfo culture = new CultureInfo("vi-VN");
                txbTotalPrice.Text = totalPrice.ToString("c", culture);
        }

        void LoadCategory()
        {
            List<CategoryDTO> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "NameCategory";// chỉ lấy tên
        }

        void LoadFoodListByCategoryID(int id)
        {
            List<FoodDTO> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "NameFood";
        }
        #endregion


        #region Events
        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as TableDTO).IdFoodTable;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }

        

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
        }

        

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin a = new fAdmin();
            a.ShowDialog();
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            CategoryDTO selected = cb.SelectedItem as CategoryDTO;
            id = selected.IdFoodCategory;

            LoadFoodListByCategoryID(id);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            TableDTO table = lsvBill.Tag as TableDTO;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.IdFoodTable);
            int foodID = (cbFood.SelectedItem as FoodDTO).ID;
            int count = (int)nmFoodCount.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.IdFoodTable);
                BillDetailDAO.Instance.InsertBillDetail(BillDAO.Instance.GetMaxIDBill(), foodID, count);
            }
            else
            {
                BillDetailDAO.Instance.InsertBillDetail(idBill, foodID, count);
            }

            ShowBill(table.IdFoodTable);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbFood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}


using QuanLyQuanMi.DAO;
using QuanLyQuanMi.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;


namespace QuanLyQuanMi
{
    public partial class fquanly : Form
    {
        BindingSource foodlist = new BindingSource();
        BindingSource accountlist = new BindingSource();
        BindingSource employeeslist = new BindingSource();
        List<Food> SearchFoodByName(String name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);
            return listFood;
        }
        public fquanly() // Main
        {
            InitializeComponent();
            dataGridView2.DataSource = foodlist;
            dataGridView4.DataSource = accountlist;
            dataGridView3.DataSource = employeeslist;
           
            AddFoodBinding();
            AddAccountBinding();
            AddEmployeesBinding();
            LoadListFood();
            LoadListAccount();
            LoadListEmployees();
            LoadDateTimePickerBill();
            LoadCategoryIntoCombobox(comboBox1);
            LoadGenderIntoCombobox(comboBox4);
            LoadTypeIntoCombobox(comboBox2);
            LoadTypeIntoCombobox(comboBox3);

            LoadListBillByDate(dateTimePicker1.Value, dateTimePicker2.Value);

        }

        // Load danh sách món ăn
        void LoadListFood() 
        {
            foodlist.DataSource = FoodDAO.Instance.GetListFood();
        }
        // Load danh sách nhân viên
        void LoadListEmployees() 
        {
            employeeslist.DataSource = EmployeesDAO.Instance.GetListEmployees();
        }
        // Load danh sách tài khoản
        void LoadListAccount() 
        {
            accountlist.DataSource = AccountDAO.Instance.GetListAccount();
        }

        void AddAccountBinding()
        {
            textBox8.DataBindings.Add(new Binding("Text", dataGridView4.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            textBox7.DataBindings.Add(new Binding("Text", dataGridView4.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            textBox3.DataBindings.Add(new Binding("Text", dataGridView4.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }
        // Load Tên món, ID, Giá lên TextBox
        void AddFoodBinding() 
        {
            textBox2.DataBindings.Add(new Binding("Text", dataGridView2.DataSource, "Name", true, DataSourceUpdateMode.Never));
            TextBoxID.DataBindings.Add(new Binding("Text", dataGridView2.DataSource, "ID", true, DataSourceUpdateMode.Never));
            numericUpDown1.DataBindings.Add(new Binding("Value", dataGridView2.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }

        void AddEmployeesBinding()
        {
            textBox5.DataBindings.Add(new Binding("Text", dataGridView3.DataSource, "id", true, DataSourceUpdateMode.Never));
            textBox6.DataBindings.Add(new Binding("Text", dataGridView3.DataSource, "name", true, DataSourceUpdateMode.Never));
            dateTimePicker3.DataBindings.Add(new Binding("Value", dataGridView3.DataSource, "dayin", true, DataSourceUpdateMode.Never));
            textBox4.DataBindings.Add(new Binding("Text", dataGridView3.DataSource, "totaltime", true, DataSourceUpdateMode.Never));
            textBox9.DataBindings.Add(new Binding("Text", dataGridView3.DataSource, "totalsalary", true, DataSourceUpdateMode.Never));
            textBox11.DataBindings.Add(new Binding("Text", dataGridView3.DataSource, "sdt", true, DataSourceUpdateMode.Never));
            comboBox4.DataBindings.Add(new Binding("Text", dataGridView3.DataSource, "gender", true, DataSourceUpdateMode.Never));
        }
        // Load tất cả category lên combobox
        void LoadCategoryIntoCombobox(ComboBox cb) 
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }
        // Load giới tính lên Combobox
        void LoadGenderIntoCombobox(ComboBox cb) 
        {
            cb.Items.Add("Nam");
            cb.Items.Add("Nữ");
            cb.Items.Add("Khác");
        }
        // Load tất cả Type lên combobox
        void LoadTypeIntoCombobox(ComboBox cb) 
        {
            cb.DataSource = AccountTypeDAO.Instance.GetListType();
            cb.DisplayMember = "Name";
        }
       
        

        void ResetTime(int id) // reset tổng giờ làm về 0
        {
            if (EmployeesDAO.Instance.ResetTotaltime(id))
            {
                MessageBox.Show("Reset giờ làm thành công");
            }
            else
            {
                MessageBox.Show("Reset giờ làm thất bại");
            }
        }

        void ResetSalary(int id) // reset lương về 0
        {
            EmployeesDAO.Instance.ResetTotalSalary(id);
        }

        void ResetAllTime() // Reset tất cả giờ làm và lương nhân viên về 0
        {
            EmployeesDAO.Instance.ResetAllTime();
        }

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut) // Load danh sách hóa đơn từ DB
        {
            ListBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }

        private void button1_Click(object sender, EventArgs e) // button thống kê hóa đơn
        {
            LoadListBillByDate(dateTimePicker1.Value, dateTimePicker2.Value);
            LoadRevenue();
        }
        // Tính Doanh thu
        private void LoadRevenue() 
        {
            int sum = 0;
            for (int i = 0; i < ListBill.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(ListBill.Rows[i].Cells[1].Value);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            textBox12.Text = sum.ToString("c", culture);
        }
        // Thống kê từ đầu tháng --> cuối tháng
        void LoadDateTimePickerBill() 
        {
            DateTime today = DateTime.Now;
            // lấy ngày đầu tháng
            dateTimePicker1.Value = new DateTime(today.Year, today.Month, 1);
            // lấy ngày cuối tháng
            dateTimePicker2.Value = dateTimePicker1.Value.AddMonths(1).AddDays(-1); //  VD: ngày 1/11 + 1 tháng = 1/12 - 1 ngày = ngày cuối tháng 11
        }
        // load Category theo ID lên combobox
        private void TextBoxID_TextChanged(object sender, EventArgs e) 
        {
            try
            {
                if (dataGridView2.SelectedCells.Count > 0)
                {
                    int id = (int)dataGridView2.SelectedCells[0].OwningRow.Cells["CategoryID"].Value; //lấy cột CategoryID

                    Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                    comboBox1.SelectedItem = cateogory;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in comboBox1.Items)
                    {
                        if (item.ID == cateogory.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    comboBox1.SelectedIndex = index;
                }
            }
            catch { }

        }
        // Button thêm món ăn
        private void button2_Click(object sender, EventArgs e) 
        {
            string name = textBox2.Text;
            int categoryID = (comboBox1.SelectedItem as Category).ID;
            float price = (float)numericUpDown1.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm món");
            }
        }
        // Button sửa món ăn
        private void button4_Click(object sender, EventArgs e) 
        {
            string name = textBox2.Text;
            int categoryID = (comboBox1.SelectedItem as Category).ID;
            float price = (float)numericUpDown1.Value;
            int id = Convert.ToInt32(TextBoxID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn");
            }
        }
        // Button xóa món ăn
        private void button3_Click(object sender, EventArgs e) 
        {
            int id = Convert.ToInt32(TextBoxID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }
        #region Event
        private event EventHandler updateEmployees;
        public event EventHandler UpdateEmployees
        {
            add { updateEmployees += value; }
            remove { updateEmployees -= value; }
        }
        private event EventHandler deleteEmployees;
        public event EventHandler DeleteEmployees
        {
            add { deleteEmployees += value; }
            remove { deleteEmployees -= value; }
        }
        private event EventHandler insertEmployees;
        public event EventHandler InsertEmployees
        {
            add { insertEmployees += value; }
            remove { insertEmployees -= value; }
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }
        #endregion
        // Button tìm kiếm món ăn
        private void button6_Click(object sender, EventArgs e) 
        {
            foodlist.DataSource = SearchFoodByName(textBox1.Text);
        }

        private void fquanly_Load_1(object sender, EventArgs e)
        {

        }
        // load danh sách tài khoản
        private void button11_Click(object sender, EventArgs e) 
        {
            LoadListAccount();
        }
        // Lấy quyền theo ID nhân viên
        private void textBox3_TextChanged(object sender, EventArgs e) 
        {
            try
            {
                if (dataGridView4.SelectedCells.Count > 0)
                {
                    int type = (int)dataGridView4.SelectedCells[0].OwningRow.Cells["Type"].Value;

                    AccountType acctype = AccountTypeDAO.Instance.GetAccountByType(type);

                    comboBox2.SelectedItem = acctype;

                    int index = -1;
                    int i = 0;
                    foreach (AccountType item in comboBox2.Items)
                    {
                        if (item.Type == acctype.Type)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    comboBox2.SelectedIndex = index;
                }
            }
            catch { }
        }

        //private void button16_Click(object sender, EventArgs e) // Button tạo report thống kê
        // {
        // }

        // Button reset password về 0
        // private void button15_Click(object sender, EventArgs e) 
        //{ 
        //}

        // Xử lý xóa tài khoản
        void DeleteAccount(string name)
        {
            if (AccountDAO.Instance.DeleteAccount(name))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa");
            }
            LoadListAccount();
        }
        //Button xóa tài khoản
        private void button12_Click(object sender, EventArgs e) 
        {
            string username = textBox8.Text;
            DeleteAccount(username);
        }
        //Xử lí cập nhật thông tin tài khoản
        void EditAccount(string userName, string displayName, int type) 
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }

            LoadListAccount();
        }
        // Button Cập nhật thông tin tài khoản
        private void button13_Click(object sender, EventArgs e) 
        {
            string username = textBox8.Text;
            string dis = textBox7.Text;
            string Type = comboBox2.Text;
            int type = 0;
            if (Type.Equals("Quản lý"))
            {
                type = 1;
            }
            else
            {
                type = 0;
            }

            EditAccount(username, dis, type);
        }
        // xử lý Thêm tài khoản
        void AddAccount(string userName, string displayName, int type) 
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }

            LoadListAccount();
        }
        // Thêm tài khoản mới
        private void button14_Click(object sender, EventArgs e) 
        {
            string username = textBox8.Text;
            string dis = textBox7.Text;
            string Type = comboBox2.Text;
            int type = 0;
            if (Type.Equals("Quản lý"))
            {
                type = 1;
            }
            else
            {
                type = 0;
            }

            AddAccount(username, dis, type);
        }
        // Button xem danh sách nhân viên
        private void button7_Click(object sender, EventArgs e) 
        {
            LoadListEmployees();
        }
        // Get Chức vụ theo Id của nhân viên
        private void textBox5_TextChanged(object sender, EventArgs e) 
        {
            try
            {
                textBox10.Text = 0.ToString();
                if (dataGridView3.SelectedCells.Count > 0)
                {
                    int type = (int)dataGridView3.SelectedCells[0].OwningRow.Cells["position"].Value;

                    AccountType acctype = AccountTypeDAO.Instance.GetAccountByType(type);

                    comboBox3.SelectedItem = acctype;

                    int index = -1;
                    int i = 0;
                    foreach (AccountType item in comboBox3.Items)
                    {
                        if (item.Type == acctype.Type)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    comboBox3.SelectedIndex = index;
                }
            }
            catch { }
        }
        // Button đặt lại giờ làm của nhân viên
        private void button17_Click(object sender, EventArgs e) 
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("Không có giờ làm để đặt lại !!!");
            }
            else
            {
                int id = Convert.ToInt32(textBox5.Text);
                ResetTime(id);
                ResetSalary(id);
                textBox10.Clear();
                LoadListEmployees();
            }

        }
        // Buntton thêm nhân viên mới
        private void button10_Click(object sender, EventArgs e) 
        {
            string name = textBox6.Text;
            string gender = comboBox4.Text;
            string sdt = textBox11.Text;
            int position = (comboBox3.SelectedItem as AccountType).Type;
            DateTime dayin = dateTimePicker3.Value;
            int totaltime = Convert.ToInt32(textBox10.Text);
            int totalsalary = totaltime * 22000;

            if (EmployeesDAO.Instance.InsertEmployee(name, gender, position, sdt, dayin, totaltime, totalsalary))
            {
                MessageBox.Show("Thêm nhân viên thành công");
                LoadListEmployees();
                if (insertEmployees != null)
                    insertEmployees(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm nhân viên");
            }
        }
        // Button reset thêm Nhân viên
        private void button18_Click(object sender, EventArgs e) 
        {
            textBox5.Clear();
            textBox6.Clear();
            textBox11.Clear();
            textBox4.Clear();
            textBox9.Clear();
            textBox10.Clear();
            dateTimePicker3.Value = DateTime.Now;
        }
        // Button reset thêm tài khoản
        private void button19_Click(object sender, EventArgs e) 
        {
            textBox3.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }
        // Buntton reset thêm món ăn
        private void button20_Click(object sender, EventArgs e) 
        {
            textBox2.Clear();
            TextBoxID.Clear();
            numericUpDown1.Value = 0;
        }
        // Button xóa nhân viên
        private void button9_Click(object sender, EventArgs e) 
        {
            int id = Convert.ToInt32(textBox5.Text);

            if (EmployeesDAO.Instance.DeleteEmployees(id))
            {
                MessageBox.Show("Xóa nhân viên thành công");
                LoadListEmployees();
                if (deleteEmployees != null)
                    deleteEmployees(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa nhân viên");
            }
        }
        // button cập nhật nhân viên
        private void button8_Click(object sender, EventArgs e) 
        {
            int id = Convert.ToInt32(textBox5.Text);
            string name = textBox6.Text;
            string gender = comboBox4.SelectedItem.ToString();
            string sdt = textBox11.Text;
            int position = (comboBox3.SelectedItem as AccountType).Type;
            DateTime dayin = dateTimePicker3.Value;
            int totaltime = Convert.ToInt32(textBox4.Text);
            int totalsalary = Convert.ToInt32(textBox9.Text.Split(',')[0].Replace(".", ""));

            if (EmployeesDAO.Instance.UpdateEmployees(id, name, gender, position, sdt, dayin, totaltime, totalsalary))
            {
                MessageBox.Show("cập nhật thành công");
                LoadListEmployees();
                if (updateEmployees != null)
                    updateEmployees(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật");
            }
        }
        // Tổng giờ làm và lương thay đổi khi nhập giờ làm / ngày
        private void textBox10_TextChanged(object sender, EventArgs e) 
        {
            List<Employees> list1 = EmployeesDAO.Instance.GetListEmployees();
            CultureInfo culture = new CultureInfo("vi-VN");
            int temp = 0;
            int id;
            if (textBox5.Text.Equals(""))
            {
                if (textBox10.Text.Equals(""))
                {
                    textBox4.Text = temp.ToString();
                    textBox9.Text = (Convert.ToInt32(textBox4.Text) * 22000).ToString("c", culture);
                }
                else
                {
                    textBox4.Text = textBox10.Text;
                    textBox9.Text = (Convert.ToInt32(textBox4.Text) * 22000).ToString("c", culture);
                }
            }
            else
            {

                id = Convert.ToInt32(textBox5.Text);

                List<Employees> list = EmployeesDAO.Instance.GetTotaltimeEmployeesById(id);

                int a = list[0].Totaltime;

                int num = 0;
                // textbox 4: tổng giờ ------ textbox 10: giờ / ngày

                if (textBox10.Text.Equals(""))
                {
                    textBox4.Text = a.ToString();
                    textBox9.Text = (Convert.ToInt32(textBox4.Text) * 22000).ToString("c", culture);
                }
                else
                {
                    if (Int32.TryParse(textBox10.Text, out num))
                    {
                        textBox4.Text = (num + a).ToString();
                        textBox9.Text = (Convert.ToInt32(textBox4.Text) * 22000).ToString("c", culture);
                    }
                }
            }
        }
        // Button Reset giờ làm và lương về 0
        private void button21_Click(object sender, EventArgs e) 
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("Không có giờ làm để đặt lại !!!");
            }
            else
            {
                if (EmployeesDAO.Instance.ResetAllTime())
                {
                    MessageBox.Show("Reset thành công");
                    textBox10.Clear();
                    LoadListEmployees();
                }
                else
                {
                    MessageBox.Show("Reset thất bại");
                }
            }
        }

        private void ListBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }     
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class ManageRentalRecords : Form
    {
        private readonly CarRentalEntities _db;
        public ManageRentalRecords()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            try
            {
                var addRentalRecord = new AddEditRentalRecord();
                addRentalRecord.MdiParent = this.MdiParent;
                addRentalRecord.WindowState = FormWindowState.Maximized;
                addRentalRecord.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            try
            {


                var id = (int)gvRecordList.SelectedRows[0].Cells["Id"].Value;
                var record = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);

            
                var addEditRenatlRecord = new AddEditRentalRecord(record);
                addEditRenatlRecord.MdiParent = this.MdiParent;
                addEditRenatlRecord.WindowState = FormWindowState.Maximized;
                addEditRenatlRecord.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvRecordList.SelectedRows[0].Cells["Id"].Value;
                var record = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);
                _db.CarRentalRecords.Remove(record);
                _db.SaveChanges();
                
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void ManageRentalRecords_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void PopulateGrid()
        {
            try
            {
                var records = _db.CarRentalRecords.Select(q => new
                {
                    Customer = q.Customername,
                    DateOut = q.DateRented,
                    DateIn = q.DateReturned,
                    Id = q.id,
                    q.Cost,
                    Car = q.TypesOfCar.Make + " " + q.TypesOfCar.Model

                })
                .ToList();

                gvRecordList.DataSource = records;
                gvRecordList.Columns["DateIn"].HeaderText = "Date In";
                gvRecordList.Columns["DateOut"].HeaderText = "Date Out";
                gvRecordList.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            
        }

        internal void PoplulateGrid()
        {
            throw new NotImplementedException();
        }
    }
}

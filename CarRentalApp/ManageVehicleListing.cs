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
    public partial class ManageVehicleListing : Form
    {
        private readonly CarRentalEntities _db = new CarRentalEntities();
        public ManageVehicleListing()
        {

            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void ManageVehicleListing_Load(object sender, EventArgs e)
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

        public void PopulateGrid()
        {
            try
            {
                var cars = _db.TypesOfCars
                .Select(q => new
                {
                    Make = q.Make,
                    Model = q.Model,
                    VIN = q.VIN,
                    Year = q.Year,
                    LicensePlateNumber = q.LicensePlateNumber,
                    q.Id
                })
                .ToList();
                gvVehicleList.DataSource = cars;
                gvVehicleList.Columns[4].HeaderText = "License Plate Number";
                gvVehicleList.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }



        private void btnAddCar_Click(object sender, EventArgs e)
        {
            try
            {
                var addEditVehicle = new AddEditVehicle();
                addEditVehicle.MdiParent = this.MdiParent;
                addEditVehicle.WindowState = FormWindowState.Maximized;
                addEditVehicle.Show();
                this.Close();
            }
            catch (Exception ex )
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
           
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            try
            {


                var id = (int)gvVehicleList.SelectedRows[0].Cells["id"].Value;
                var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);
                var addEditVehicle = new AddEditVehicle(car);
                addEditVehicle.MdiParent = this.MdiParent;
                addEditVehicle.WindowState = FormWindowState.Maximized;
                addEditVehicle.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value;
                var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);

                DialogResult dr = MessageBox.Show("Are u sure you want to delete the record?", "Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if(dr == DialogResult.Yes)
                {
                    _db.TypesOfCars.Remove(car);
                    _db.SaveChanges();
                   // gvVehicleList.Refresh();
                   // MessageBox.Show("The record of the vehicle has been deleted");
                   // PopulateGrid();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
            gvVehicleList.Update();
            gvVehicleList.Refresh();

        }
    }
}

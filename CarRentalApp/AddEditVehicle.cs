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
    public partial class AddEditVehicle : Form
    {
        ManageVehicleListing manageVehicleListing = new ManageVehicleListing();
        private bool isEditMode;
        private readonly CarRentalEntities _db = new CarRentalEntities();

        public AddEditVehicle()
        {
            InitializeComponent();
            lbTitle.Text = "Add New Vehicle";
            this.Text = "add New Vehicle";
            isEditMode = false;
            _db = new CarRentalEntities();
        }

        public AddEditVehicle(TypesOfCar carToEdit)
        {
            InitializeComponent();
            lbTitle.Text = "Edit Vehicle";
            this.Text = "Edit Vehicle";
            if(carToEdit == null ) 
            {
                MessageBox.Show("Please ensure that you selected a valid recor to edit");
                Close();
            }
            else
            {
                isEditMode = true;
                _db = new CarRentalEntities();
                PopulateFields(carToEdit);
            }
            
            
        }

        private void PopulateFields(TypesOfCar car)
        {
            lblId.Text = car.Id.ToString();
            tbMake.Text = car.Make;
            tbModel.Text = car.Model;
            tbVIN .Text = car.VIN;
            tbYear.Text = car.Year.ToString();
            tbLicenseNum.Text = car.LicensePlateNumber;
        }
        private void OpenForm()
        {
            this.Close();
            manageVehicleListing.PopulateGrid();
            manageVehicleListing.MdiParent = CarRentalApp.MainWindow.ActiveForm;
            manageVehicleListing.WindowState = FormWindowState.Maximized;
            manageVehicleListing.Show();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                var errorMessage = "";
                var addEdit = true;

                if (isEditMode)
                {
                    var id = int.Parse(lblId.Text);
                    var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);
                    car.Make = tbMake.Text;
                    car.Model = tbModel.Text;
                    car.VIN = tbVIN.Text;
                    car.Year = int.Parse(tbYear.Text);
                    car.LicensePlateNumber = tbLicenseNum.Text;


                    if (string.IsNullOrWhiteSpace(tbMake.Text) || string.IsNullOrWhiteSpace(tbModel.Text))
                    {
                        addEdit = false;
                        errorMessage += "Please ensure that you provide a make and a model";
                    }
                    else if (car.Year == null)
                    {
                        addEdit = false;
                        errorMessage += "Please ensure that you provide Year";
                    }
                    if (addEdit)
                    {
                        _db.SaveChanges();
                        MessageBox.Show("The changes have been saved successully");
                        OpenForm();
                    }
                }
                else
                {
                    var newCar = new TypesOfCar
                    {
                        LicensePlateNumber = tbLicenseNum.Text,
                        Make = tbMake.Text,
                        Model = tbModel.Text,
                        VIN = tbVIN.Text,
                        Year = int.Parse(tbYear.Text)

                    };

                    if (string.IsNullOrWhiteSpace(tbMake.Text) || string.IsNullOrWhiteSpace(tbModel.Text))
                    {
                        addEdit = false;
                        errorMessage += "Please ensure that you provide a make and a model";
                    }
                    else if (newCar.Year == null)
                    {
                        addEdit = false;
                        errorMessage += "Please ensure that you provide Year";
                    }
                    if (addEdit)
                    {
                        _db.SaveChanges();
                        MessageBox.Show("The changes have been saved successully");
                        OpenForm();
                    }
                    else
                    {
                        MessageBox.Show(errorMessage);
                    }

                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

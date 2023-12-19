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
    public partial class AddEditRentalRecord : Form
    {

        private readonly CarRentalEntities _db = new CarRentalEntities();
        private bool isEditMode;
        ManageRentalRecords manageRentalRecord = new ManageRentalRecords();


        public AddEditRentalRecord()
        {
            InitializeComponent();
            lblTitle.Text = "Add New Rental ";
            this.Text = "add New Rental";
            isEditMode = false;


        }

        public AddEditRentalRecord(CarRentalRecord recordToEdit)
        {
            InitializeComponent();
            lblTitle.Text = "Edit Rental Record";
            this.Text = "Edit Rental Record";
            if (recordToEdit == null)
            {
                MessageBox.Show("Please ensure that you selected a valid recor to edit");
                Close();
            }
            else
            {
                isEditMode = true;
                PopulateFields(recordToEdit);
            }
        }

        private void PopulateFields(CarRentalRecord recordToEdit)
        {
            tbCustomerName.Text = recordToEdit.Customername;
            dtRented.Value = (DateTime)recordToEdit.DateRented;
            dtReturned.Value = (DateTime)recordToEdit.DateReturned;
            tbCost.Text = recordToEdit.Cost.ToString();
            lblRecoredId.Text = recordToEdit.id.ToString();

        }
        private void OpenForm()
        {
            this.Close();
            manageRentalRecord.PoplulateGrid();
            manageRentalRecord.MdiParent = CarRentalApp.MainWindow.ActiveForm;
            manageRentalRecord.WindowState = FormWindowState.Maximized;
            manageRentalRecord.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string customerName = tbCustomerName.Text;
                var dateOut = dtRented.Value;
                var dateIn = dtReturned.Value;
                double cost = Convert.ToDouble(tbCost.Text);
                var carType = cbTypeOfCar.Text;
                var isValid = true;
                var errorMessage = "";

                if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(carType))
                {
                    isValid = false;
                    errorMessage += "Please enter the missing data \n\r";
                }

                if (dateOut > dateIn)
                {
                    isValid = false;
                    errorMessage += "date selection is wrong \n\r";
                }

                if (isValid)
                {
                    var rentalRecord = new CarRentalRecord();
                    if (isEditMode)
                    {

                        var id = int.Parse(lblRecoredId.Text);
                        rentalRecord = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);
                    }
                    rentalRecord.Customername = customerName;
                    rentalRecord.DateRented = dateOut;
                    rentalRecord.DateReturned = dateIn;
                    rentalRecord.Cost = (decimal)cost;
                    rentalRecord.TypeOfCarId = (int)cbTypeOfCar.SelectedValue;

                    if (!isEditMode)

                        _db.CarRentalRecords.Add(rentalRecord);

                    _db.SaveChanges();

                    MessageBox.Show($"Customer Name: {customerName}\n\r" +
                      $"Date Rented: {dateOut}\n\r" +
                      $"Date Returned: {dateIn}\n\r" +
                      $"Cost: {cost}\n\r" +
                      $"Car Type: {carType}\n\r" +
                      $"THANKYOU FOR YOUR BUSINESS");
                    OpenForm();
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Reset()
        {
            tbCost.Text = "";
            tbCustomerName.Text = "";
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // var cars = carRentalEntities.TypesOfCars.ToList();

            var cars = _db.TypesOfCars
                .Select(q => new
                {
                    Id = q.Id,
                    Name = q.Make + " " + q.Model
                }).ToList();
            cbTypeOfCar.DisplayMember = "Name";
            cbTypeOfCar.ValueMember = "id";
            cbTypeOfCar.DataSource = cars; 
        }

    }
}


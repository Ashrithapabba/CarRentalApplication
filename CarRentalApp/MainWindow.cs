﻿using System;
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
    public partial class MainWindow : Form
    {
        private Login _login;
        public string _roleName;
        public User _user;
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(Login login, User user)
        {
            InitializeComponent();
            _login = login;
            _user = user;
            _roleName = user.UserRoles.FirstOrDefault().Role.shortname;
        }

        public MainWindow(Login login, string roleShortName)
        {
            InitializeComponent();
            _login = login;
            _roleName = roleShortName;
        }

        private void addRentalRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach(Form form in Application.OpenForms)
            {
                if(form.Text == "Add Rental Record")
                {
                    IsOpen = true;
                    form.Focus();
                    break;
                }
            }
            if(IsOpen == false)
            {
                var addRentalRecord = new AddEditRentalRecord();
                addRentalRecord.MdiParent = this;
                addRentalRecord.WindowState = FormWindowState.Maximized;
                addRentalRecord.Show();
            }
            
        }

        private void manageVehicleListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach(Form form in Application.OpenForms)
            {
                if (form.Text == "Manage Vehicle Listing")
                {
                    IsOpen = true;
                    form.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                var vehicleListing = new ManageVehicleListing();
                vehicleListing.MdiParent = this;
                vehicleListing.Show();
            }
        }

        private void viewArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Text == "Manage Vehicle Listing")
                {
                    IsOpen = true;
                    form.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                var manageRentalRecords = new ManageRentalRecords();
                manageRentalRecords.MdiParent = this;
                manageRentalRecords.Show();
            }
            
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Text == "Manage Users")
                {
                    IsOpen = true;
                    form.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                var manageUsers = new ManageUsers();
                manageUsers.MdiParent = this;
                manageUsers.WindowState = FormWindowState.Maximized;
                manageUsers.Show();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if(_user.password == Utils.DefaultHashPassword())
            {
                var resetPassword = new ResetPassword(_user);
                resetPassword.ShowDialog();
            }


            var username = _user.username;
            tsiLoginText.Text = $"Logged In As: { username}";
            if(_roleName != "admin")
            {
                manageUsersToolStripMenuItem.Visible = false;
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class ManageUsers : Form
    {
        private readonly CarRentalEntities _db = new CarRentalEntities();
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvUserList.SelectedRows[0].Cells["id"].Value;
                var user = _db.Users.FirstOrDefault(q => q.id == id);
                var genericPassword = Utils.DefaultHashPassword();
                var hashed_password = Utils.HashPassword(genericPassword);
                user.password  = hashed_password;
                _db.SaveChanges();

                MessageBox.Show($"{user.username}'s password has been Reset");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnDeactivateUser_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvUserList.SelectedRows[0].Cells["id"].Value;
                var user = _db.Users.FirstOrDefault(q => q.id == id);
                user.isActive = user.isActive == true ? false : true;

                _db.SaveChanges();

                MessageBox.Show($"{user.username} active status has changed");

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
                var cars = _db.Users
                .Select(q => new
                {
                    q.id,
                    q.username,
                    q.UserRoles.FirstOrDefault().Role.name,
                    q.isActive
                 })
                .ToList();

                gvUserList.DataSource = cars;
                gvUserList.Columns["username"].HeaderText = "Username";
                gvUserList.Columns["name"].HeaderText = "Role Name";
                gvUserList.Columns["isActive"].HeaderText = "Active";

                gvUserList.Columns["id"].Visible = false;
            }
            catch (Exception error)
            {

                MessageBox.Show($"error: {error.Message}");
            }
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void btnDeactivateUser_Click_1(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvUserList.SelectedRows[0].Cells["Id"].Value;
                var user = _db.Users.FirstOrDefault(column => column.id == id);
                //Toggles if isactivate is true or not to deactivate and activate users
                user.isActive = user.isActive == true ? false : true;
                _db.SaveChanges();

                MessageBox.Show($"{user.username}'s Active status has changed!");
                PopulateGrid();

            }
            catch (Exception error)
            {
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen("AddUser"))
            {
                var addUser = new AddUser(this);
                addUser.MdiParent = this.MdiParent;
                addUser.Show();
            }
        }
    }
}

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
    public partial class AddUser : Form
    {
        private readonly CarRentalEntities _db = new CarRentalEntities();


        private ManageUsers _manageUsers;


        public AddUser(ManageUsers manageUsers)
        {
            InitializeComponent();
            _manageUsers = manageUsers;
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            var roles = _db.Roles.ToList();
            cbRoles.DataSource = roles;
            cbRoles.ValueMember = "id";
            cbRoles.DisplayMember = "name";


        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var username = tbUsername.Text;
                var roleId = (int)cbRoles.SelectedValue;
                var password = Utils.DefaultHashPassword();
                var user = new User
                {
                    username = username,
                    password = password,
                    isActive = true
                };

                _db.Users.Add(user);
                _db.SaveChanges();

                var userid = user.id;
                var userRole = new UserRole
                {
                    roleid = roleId,
                    userid = user.id
                };

                _db.UserRoles.Add(userRole);
                _db.SaveChanges();

                MessageBox.Show("New User Added Successfully");
                _manageUsers.PopulateGrid();
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occured");
            }
            
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

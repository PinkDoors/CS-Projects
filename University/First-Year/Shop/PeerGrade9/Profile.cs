using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PeerGrade9
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Changes the client Firstname.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstnameTextBox_TextChanged(object sender, EventArgs e)
        {
            ClientForm.CurrentClient.FirstName = FirstnameTextBox.Text;
        }

        /// <summary>
        /// Changes the client Lastname.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LastnameTextBox_TextChanged(object sender, EventArgs e)
        {
            ClientForm.CurrentClient.LastName = LastnameTextBox.Text;
        }

        /// <summary>
        /// Changes the client Middlename.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiddlenameTextBox_TextChanged(object sender, EventArgs e)
        {
            ClientForm.CurrentClient.MiddleName = MiddlenameTextBox.Text;
        }

        /// <summary>
        /// Changes the client Phone.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            ulong phone;
            if (ulong.TryParse(PhoneTextBox.Text, out phone))
                ClientForm.CurrentClient.Phone = phone;
            else
                MessageBox.Show("Input must be a positive number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Changes the client Address.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {
            ClientForm.CurrentClient.Address = AddressTextBox.Text;
        }

        private void CloseProfile(object sender, EventArgs e)
        {
            Close();
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PeerGrade9
{
    public partial class LoginForm : Form
    {
        public List<Client> Clients { get; set; } = new List<Client>();

        public LoginForm()
        {
            InitializeComponent();
            LoadClients();
        }

        /// <summary>
        /// Registers the new user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            // Checking if the user has selected entity.
            if (LoginAsComboBox.SelectedItem == null)
            {
                MessageBox.Show("Select the user type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Checking is there is already a user with such a name.
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i].Login == EmailTextBox.Text)
                {
                    MessageBox.Show("A user with this name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("You have successfully registered", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Tuple<string, int> passwordCode = User.CreatePassword(PasswordTextBox.Text);
            Clients.Add(new Client(EmailTextBox.Text, passwordCode.Item1, passwordCode.Item2));
        }

        /// <summary>
        /// Opens the form for user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignInButton_Click(object sender, EventArgs e)
        {
            // Checking if the user has selected entity.
            if (LoginAsComboBox.SelectedItem == null)
            {
                MessageBox.Show("Select the user type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (LoginAsComboBox.SelectedItem == LoginAsComboBox.Items[0])
            {
                CreateClientForm();
            }
            else
            {
                CreateSellerForm();
            }
        }

        /// <summary>
        /// Opens seller form.
        /// </summary>
        private void CreateSellerForm()
        {
            bool isThereSuchAUser = false;
            if (EmailTextBox.Text == "admin")
            {
                if (PasswordTextBox.Text == "12345")
                {
                    this.Hide();
                    isThereSuchAUser = true;
                    SellerForm newSellerForm = new SellerForm();
                    newSellerForm.Activate();
                    newSellerForm.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!isThereSuchAUser)
                MessageBox.Show("Username does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Opens client form.
        /// </summary>
        private void CreateClientForm()
        {
            bool isThereSuchAUser = false;
            for (int i = 0; i < Clients.Count; i++)
            {
                if (EmailTextBox.Text == Clients[i].Login)
                {
                    // Checking if input encoding equals the client password.
                    if (Clients[i].GetPassword(PasswordTextBox.Text) == Clients[i].Password)
                    {
                        Hide();
                        isThereSuchAUser = true;
                        ClientForm.CurrentClient = Clients[i];
                        ClientForm newClientForm = new ClientForm();
                        newClientForm.Activate();
                        newClientForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            if (!isThereSuchAUser)
                MessageBox.Show("Username does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Changes the entity.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginAsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LoginAsComboBox.SelectedIndex == 1)
                RegisterButton.Visible = false;
            else
                RegisterButton.Visible = true;
        }

        /// <summary>
        /// Loads the list of clients from the file.
        /// </summary>
        private void LoadClients()
        {
            try
            {
                using (StreamReader sr = new StreamReader("ClientsList.json"))
                {
                    Clients = JsonConvert.DeserializeObject<List<Client>>(sr.ReadToEnd());
                }
                if (Clients == null)
                    Clients = new List<Client>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Saves all data when closing the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var json = JsonConvert.SerializeObject(Clients, Formatting.Indented,
                                new JsonSerializerSettings()
                                {
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                });
                using (StreamWriter sw = new StreamWriter("ClientsList.json"))
                {
                    sw.Write(json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

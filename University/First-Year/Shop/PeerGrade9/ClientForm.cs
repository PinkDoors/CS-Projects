using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PeerGrade9
{
    public partial class ClientForm : Form
    {
        public static Warehouse Storage { get; set; }
        public static Client CurrentClient { get; set; }


        public ClientForm()
        {
            //ClientNameLabel.Text = $"{currentClient.FirstName} {currentClient.LastName} {currentClient.MiddleName}";
            InitializeComponent();
            AddGoods();
            ClientNameLabel.Text = CurrentClient.Login;
        }

        private void OpenBasket(object sender, EventArgs e)
        {
            BasketForm newBasketForm = new BasketForm();
            newBasketForm.Show();
        }

        private void AddGoods()
        {
            try
            {
                using (StreamReader sr = new StreamReader("Storage.json"))
                {
                    Tree.Nodes.Clear();
                    // Loading data about sections and items.
                    Storage = JsonConvert.DeserializeObject<Warehouse>(sr.ReadToEnd());
                    // Creating tree based on this data.
                    if (Storage != null)
                        CreateTree();
                    else
                        Storage = new Warehouse(new Section(Tree.SelectedNode));
                    LoadAllImages();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads images for the selected item.
        /// </summary>
        private void LoadAllImages()
        {
            for (int i = 0; i < CurrentClient.Basket.Count; i++)
            {
                if (CurrentClient.Basket[i].PathToPicture != null)
                    CurrentClient.Basket[i].Photo = new Bitmap(CurrentClient.Basket[i].PathToPicture);
            }
            for (int i = 0; i < CurrentClient.AllOrders.Count; i++)
            {
                for (int j = 0; j < CurrentClient.AllOrders[i].OrderedItems.Count; j++)
                {
                    if (CurrentClient.AllOrders[i].OrderedItems[j].PathToPicture != null)
                        CurrentClient.AllOrders[i].OrderedItems[j].Photo = new Bitmap(CurrentClient.AllOrders[i].OrderedItems[j].PathToPicture);
                }

            }
        }

        private void CreateTree()
        {
            if (Storage.Root != null)
            {
                // Creating a root.
                TreeNode newTreeNode = new TreeNode(Storage.Root.Name);
                Storage.Root.TreeNode = newTreeNode;
                Tree.Nodes.Add(newTreeNode);
                Tree.SelectedNode = newTreeNode;
                // Adding sections and items to the root.
                AddSectionFromFile(Storage.Root, newTreeNode);
            }

        }

        private void AddSectionFromFile(Section currentSection, TreeNode ParentNode)
        {
            // Adding items.
            for (int i = 0; i < currentSection.ChildrenNodes.Count; i++)
            {
                if (currentSection.ChildrenNodes[i].PathToPicture != null)
                    currentSection.ChildrenNodes[i].Photo = new Bitmap(currentSection.ChildrenNodes[i].PathToPicture);
                TreeNode newTreeNode = new TreeNode(currentSection.ChildrenNodes[i].Name);
                ParentNode.Nodes.Add(newTreeNode);
                currentSection.ChildrenNodes[i].TreeNode = newTreeNode;
            }
            // Adding sections.
            for (int i = 0; i < currentSection.ChildrenSections.Count; i++)
            {
                TreeNode newTreeNode = new TreeNode(currentSection.ChildrenSections[i].Name);
                currentSection.ChildrenSections[i].TreeNode = newTreeNode;
                ParentNode.Nodes.Add(newTreeNode);
                // Repeating for current section.
                AddSectionFromFile(currentSection.ChildrenSections[i], newTreeNode);
            }
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Tree.SelectedNode != null)
            {
                Item SelectedItem = Storage.GetItemByTreeNode(Tree.SelectedNode, Storage.Root);
                if (SelectedItem != null)
                {
                    // Setting textboxes values according to the selected item properties.
                    NameTextBox.Text = Tree.SelectedNode.Text;
                    CodeTextBox.Text = SelectedItem.Code;
                    AmountTextBox.Text = SelectedItem.Amount.ToString();
                    PriceTextBox.Text = SelectedItem.Price.ToString();
                    DescriptionTextBox.Text = SelectedItem.Description;
                    PhotoBox.Image = SelectedItem.Photo;
                }
            }
        }

        /// <summary>
        /// Adds an item to the client basket.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddToBasketButton_Click(object sender, EventArgs e)
        {
            if (Tree.SelectedNode != null)
            {
                Item newItem = Storage.GetItemByTreeNode(Tree.SelectedNode, Storage.Root);
                if (newItem != null)
                {
                    CurrentClient.Basket.Add(newItem);
                    MessageBox.Show("The product was successfully added to the basket", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Choose the item first", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Choose the item first", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Opens the client profile.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenProfile(object sender, EventArgs e)
        {
            Profile openProfile = new Profile();
            openProfile.Show();
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Close();
        }
    }
}

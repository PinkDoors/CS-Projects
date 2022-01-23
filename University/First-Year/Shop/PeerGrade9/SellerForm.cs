using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeerGrade9
{

    public partial class SellerForm : Form
    {
        public static TreeNode ChildNode { get; set; }
        public static TreeNode ParentNode { get; set; }

        public static Warehouse newWarehouse { get; set; }
        private static Bitmap currentPhoto;
        private List<Client> allClients;

        public SellerForm()
        {
            InitializeComponent();
            Tree.SelectedNode = Tree.Nodes[0];
            // Creating new warehouse.
            newWarehouse = new Warehouse(new Section(Tree.SelectedNode));
            // Setting color for datagrid.
            SectionDataGrid.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Menu;
            SectionDataGrid.EnableHeadersVisualStyles = false;
            // Running "OpenImage", if the user clicks on photo
            SectionDataGrid.CellClick += OpenImage;
            LoadWarehouse();
            allClients = (Application.OpenForms[0] as LoginForm).Clients;
            LoadClientTree();
        }

        /// <summary>
        /// Adds the list with clients to the tree.
        /// </summary>
        private void LoadClientTree()
        {
            TreeNode root = new TreeNode("Clients");
            ClientsTree.Nodes.Add(root);
            for (int i = 0; i < allClients.Count; i++)
            {
                root.Nodes.Add(allClients[i].Login);
            }
        }

        /// <summary>
        /// Fills the datagrid for the selected client if the seller clicked on him.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            for (int i = 0; i < allClients.Count; i++)
            {
                if (ClientsTree.SelectedNode.Text == allClients[i].Login)
                {
                    ClientNameLabel.Text = $"{allClients[i].FirstName} {allClients[i].LastName} {allClients[i].MiddleName}";
                    FillClientDataGrid(allClients[i], ActiveOrdersCheckBox.Checked);
                }
            }
        }

        /// <summary>
        /// Fills the datagrid for the selected client.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="active"></param>
        private void FillClientDataGrid(Client client, bool active)
        {
            ClientDataGrid.Rows.Clear();
            ClientDataGrid.Columns.Clear();
            ClientDataGrid.Columns.Add("Goods", "Goods");
            ClientDataGrid.Columns.Add("Price", "Price");
            ClientDataGrid.Columns.Add("OrderNumber", "Order Number");
            ClientDataGrid.Columns.Add("RegistrationTime", "Registration Time");
            ClientDataGrid.Columns.Add("Processed", "Processed");
            ClientDataGrid.Columns.Add("Paid", "Paid");
            ClientDataGrid.Columns.Add("Shipped", "Shipped");
            ClientDataGrid.Columns.Add("Executed", "Executed");
            for (int i = 0; i < client.AllOrders.Count; i++)
            {
                Order newRow = client.AllOrders[i];
                string goods = newRow.GetAllGoods();
                double price = newRow.FindPrice();
                // Getting active orders.
                if (active && !newRow.OrderStatus.HasFlag(Status.Executed))
                    ClientDataGrid.Rows.Add(goods, price, newRow.OrderNumber, newRow.RegistrationTime,
                        newRow.OrderStatus.HasFlag(Status.Processed) ? "✓" : "",
                        newRow.OrderStatus.HasFlag(Status.Paid) ? "✓" : "",
                        newRow.OrderStatus.HasFlag(Status.Shipped) ? "✓" : "",
                        newRow.OrderStatus.HasFlag(Status.Executed) ? "✓" : "");
                // Getting all orders.
                else if (!active)
                    ClientDataGrid.Rows.Add(goods, price, newRow.OrderNumber, newRow.RegistrationTime,
                    newRow.OrderStatus.HasFlag(Status.Processed) ? "✓" : "",
                    newRow.OrderStatus.HasFlag(Status.Paid) ? "✓" : "",
                    newRow.OrderStatus.HasFlag(Status.Shipped) ? "✓" : "",
                    newRow.OrderStatus.HasFlag(Status.Executed) ? "✓" : "");
            }
        }

        /// <summary>
        /// Fills the datagrid only with active orders.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActiveOrdersCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < allClients.Count; i++)
            {
                if (ClientsTree.SelectedNode != null && ClientsTree.SelectedNode.Text == allClients[i].Login)
                    FillClientDataGrid(allClients[i], ActiveOrdersCheckBox.Checked);
            }
        }

        /// <summary>
        /// Changes selected status.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Client currentClient = null;
            for (int i = 0; i < allClients.Count; i++)
            {
                if (ClientsTree.SelectedNode.Text == allClients[i].Login)
                    currentClient = allClients[i];
            }
            if (currentClient == null)
                return;
            try
            {
                if (ClientDataGrid.SelectedCells[0].ColumnIndex == 4)
                {
                    ChangePaidStatus(currentClient);
                }
                else if (ClientDataGrid.SelectedCells[0].ColumnIndex == 6)
                {
                    ChangeShippedStatus(currentClient);
                }
                else if (ClientDataGrid.SelectedCells[0].ColumnIndex == 7)
                {
                    ChangeExecutedStatus(currentClient);
                }
            }
            catch { }
        }

        /// <summary>
        /// Changes "Executed" status.
        /// </summary>
        /// <param name="currentClient"></param>
        private void ChangeExecutedStatus(Client currentClient)
        {
            if (currentClient.AllOrders[ClientDataGrid.SelectedCells[0].RowIndex].OrderStatus.HasFlag(Status.Executed))
            {
                ClientDataGrid.SelectedCells[0].Value = "";
                currentClient.AllOrders[ClientDataGrid.SelectedCells[0].RowIndex].OrderStatus ^= Status.Executed;
            }
            else
            {
                if (!currentClient.AllOrders[ClientDataGrid.SelectedCells[0].RowIndex].OrderStatus.HasFlag(Status.Paid))
                {
                    MessageBox.Show("The product has not been paid for yet", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!currentClient.AllOrders[ClientDataGrid.SelectedCells[0].RowIndex].OrderStatus.HasFlag(Status.Shipped))
                {
                    MessageBox.Show("The product has not been shipped yet", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ClientDataGrid.SelectedCells[0].Value = "✓";
                    currentClient.AllOrders[ClientDataGrid.SelectedCells[0].RowIndex].OrderStatus |= Status.Executed;
                }
            }
        }

        /// <summary>
        /// Changes "Shipped" status.
        /// </summary>
        /// <param name="currentClient"></param>
        private void ChangeShippedStatus(Client currentClient)
        {
            if (currentClient.AllOrders[ClientDataGrid.SelectedCells[0].RowIndex].OrderStatus.HasFlag(Status.Shipped))
            {
                if (currentClient.AllOrders[ClientDataGrid.SelectedCells[0].RowIndex].OrderStatus.HasFlag(Status.Executed))
                {
                    MessageBox.Show("The order has been executed already", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ClientDataGrid.SelectedCells[0].Value = "";
                    currentClient.AllOrders[ClientDataGrid.SelectedCells[0].RowIndex].OrderStatus ^= Status.Shipped;
                }
            }
            else
            {
                if (!currentClient.AllOrders[ClientDataGrid.SelectedCells[0].RowIndex].OrderStatus.HasFlag(Status.Paid))
                {
                    MessageBox.Show("The product has not been paid for yet", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ClientDataGrid.SelectedCells[0].Value = "✓";
                    currentClient.AllOrders[ClientDataGrid.SelectedCells[0].RowIndex].OrderStatus |= Status.Shipped;
                }
            }
        }

        /// <summary>
        /// Changes "Paid" status.
        /// </summary>
        /// <param name="currentClient"></param>
        private void ChangePaidStatus(Client currentClient)
        {
            if (currentClient.AllOrders[ClientDataGrid.SelectedCells[0].RowIndex].OrderStatus.HasFlag(Status.Processed))
            {
                if (currentClient.AllOrders[ClientDataGrid.SelectedCells[0].RowIndex].OrderStatus.HasFlag(Status.Paid))
                {
                    MessageBox.Show("The product has been paid for already", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ClientDataGrid.SelectedCells[0].Value = "";
                    currentClient.AllOrders[ClientDataGrid.SelectedCells[0].RowIndex].OrderStatus ^= Status.Processed;
                }
            }
            else
            {
                ClientDataGrid.SelectedCells[0].Value = "✓";
                currentClient.AllOrders[ClientDataGrid.SelectedCells[0].RowIndex].OrderStatus |= Status.Processed;
            }
        }

        /// <summary>
        /// Loads last opened Warehouse when opening the program. 
        /// </summary>
        private void LoadWarehouse()
        {
            try
            {
                using (StreamReader sr = new StreamReader("Storage.json"))
                {
                    Tree.Nodes.Clear();
                    // Loading data about sections and items.
                    newWarehouse = JsonConvert.DeserializeObject<Warehouse>(sr.ReadToEnd());
                    // Creating tree based on this data.
                    if (newWarehouse != null)
                        CreateTree();
                    else
                        newWarehouse = new Warehouse(new Section(Tree.SelectedNode));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Creates contextMenu in relation to selected node.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditNodes_Opening(object sender, CancelEventArgs e)
        {
            EditNodes.Items.Clear();
            // Checking if there are any nodes in the tree.
            if (Tree.Nodes.Count != 0)
            {
                // Сhecking if the selected node is an item.
                if (newWarehouse.GetSectionByTreeNode(Tree.SelectedNode, newWarehouse.Root) == null)
                {
                    // Adding buttons "Delete" and "Rename" to the context Menu.
                    ItemContextMenu();
                }
                else
                {
                    // Adding buttons "Add Section" etc to the context Menu.
                    SectionContextMenu();
                }
            }
            else
            {
                ToolStripItem newtsi = new ToolStripMenuItem("Add Section");
                newtsi.Click += new EventHandler(AddSection);
                EditNodes.Items.Add(newtsi);
            }

        }

        /// <summary>
        /// Creates context menu with buttons for section.
        /// </summary>
        private void SectionContextMenu()
        {
            ToolStripItem newtsi = new ToolStripMenuItem("Add Section");
            newtsi.Click += new EventHandler(AddSection);
            EditNodes.Items.Add(newtsi);
            newtsi = new ToolStripMenuItem("Add Item");
            newtsi.Click += new EventHandler(AddItem);
            EditNodes.Items.Add(newtsi);
            newtsi = new ToolStripMenuItem("Delete");
            newtsi.Click += new EventHandler(Delete);
            EditNodes.Items.Add(newtsi);
            newtsi = new ToolStripMenuItem("Rename");
            newtsi.Click += new EventHandler(Rename);
            EditNodes.Items.Add(newtsi);
        }

        /// <summary>
        /// Creates context menu with buttons for item.
        /// </summary>
        private void ItemContextMenu()
        {
            ToolStripItem newtsi = new ToolStripMenuItem("Delete");
            newtsi.Click += new EventHandler(Delete);
            EditNodes.Items.Add(newtsi);
            newtsi = new ToolStripMenuItem("Rename");
            newtsi.Click += new EventHandler(Rename);
            EditNodes.Items.Add(newtsi);
            newtsi = new ToolStripMenuItem("Report a factory defect");
            newtsi.Click += new EventHandler(ReportDefect);
            EditNodes.Items.Add(newtsi);
        }

        /// <summary>
        /// Saves the CSV document with clients who has bought the defected item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportDefect(object sender, EventArgs e)
        {
            Item defectedItem = newWarehouse.GetItemByTreeNode(Tree.SelectedNode, newWarehouse.Root);
            string CSV = "";
            foreach (Client client in (Application.OpenForms[0] as LoginForm).Clients)
            {
                foreach (Order order in client.AllOrders)
                {
                    foreach (Item item in order.OrderedItems)
                    {
                        if (item.Name == defectedItem.Name)
                            CSV += $"{client.Login};{order.RegistrationTime}\n";
                    }
                }
            }
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.Write(CSV);
                }
            }
        }

        // Adds a section to the selected section.
        private void AddSection(object sender, EventArgs e)
        {
            TreeNode newTreeNode = new TreeNode();
            // If the tree is empty then we add section to the tree, else to the selected section.
            try
            {
                if (Tree.SelectedNode != null)
                {
                    Tree.SelectedNode.Nodes.Add(newTreeNode);
                    newWarehouse.GetSectionByTreeNode(Tree.SelectedNode, newWarehouse.Root).ChildrenSections.Add(new Section(newTreeNode));
                }
                else
                {
                    Tree.Nodes.Add(newTreeNode);
                    newWarehouse.Root = new Section(newTreeNode);
                    ParentNode = newTreeNode;
                }
                ChildNode = newTreeNode;
                Tree.SelectedNode = newTreeNode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Gives the new section a name.
            Rename(null, null);
        }

        /// <summary>
        /// Adds an item to the selected section.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItem(object sender, EventArgs e)
        {
            try
            {
                ParentNode = Tree.SelectedNode;
                TreeNode newTreeNode = new TreeNode();
                Tree.SelectedNode.Nodes.Add(newTreeNode);
                ChildNode = newTreeNode;
                Section ParentSection = newWarehouse.GetSectionByTreeNode(ParentNode, newWarehouse.Root);
                ParentSection.ChildrenNodes.Add(new Item(newTreeNode));
                Tree.SelectedNode = newTreeNode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Gives the new item a name.
            Rename(null, null);
        }

        /// <summary>
        /// Deletes the selected section or item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete(object sender, EventArgs e)
        {
            try
            {
                // Сhecking if the selected node is an item.
                if (newWarehouse.GetSectionByTreeNode(Tree.SelectedNode, newWarehouse.Root) == null)
                {
                    Item selectedItem = newWarehouse.GetItemByTreeNode(Tree.SelectedNode, newWarehouse.Root);
                    Section Parent = newWarehouse.GetSectionByTreeNode(Tree.SelectedNode.Parent, newWarehouse.Root);
                    // Removing selected item from parent section.
                    Parent.ChildrenNodes.Remove(selectedItem);
                    Tree.Nodes.Remove(Tree.SelectedNode);
                }
                else
                {
                    Section selectedSection = newWarehouse.GetSectionByTreeNode(Tree.SelectedNode, newWarehouse.Root);
                    // Checking if the selected section is empty.
                    if (selectedSection.ChildrenNodes.Count == 0 && selectedSection.ChildrenSections.Count == 0)
                    {
                        // Checking if the selected section is not first section in the tree.
                        if (Tree.SelectedNode.Parent != null)
                        {
                            Section parent = newWarehouse.GetSectionByTreeNode(Tree.SelectedNode.Parent, newWarehouse.Root);
                            parent.ChildrenSections.Remove(selectedSection);
                        }
                        else
                            newWarehouse.Root = null;
                        Tree.Nodes.Remove(Tree.SelectedNode);
                    }
                    else
                    {
                        MessageBox.Show("This section is not empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Changes the name of the selected section or item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rename(object sender, EventArgs e)
        {
            ParentNode = Tree.SelectedNode.Parent;
            ChildNode = Tree.SelectedNode;
            // Opening form for changing the name.
            NodeName changeNodeName = new NodeName();
            changeNodeName.Show();
        }

        /// <summary>
        /// Opens the DataGrid with information about items in the selected section or the panel with information about the item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SectionDataGrid.Columns.Clear();
            // Checking if the selected node is a section.
            if (newWarehouse.GetSectionByTreeNode(Tree.SelectedNode, newWarehouse.Root) != null)
            {
                SectionDataGrid.Visible = true;
                panel1.Visible = false;
                // Creating datatgrid.
                CreateDataGrid();
            }
            else
            {
                try
                {
                    CreatePanel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Creates a panel with information about the selected item.
        /// </summary>
        private void CreatePanel()
        {
            SectionDataGrid.Visible = false;
            panel1.Visible = true;
            // Setting textboxes values according to the selected item properties.
            NameTextBox.Text = Tree.SelectedNode.Text;
            Item SelectedItem = newWarehouse.GetItemByTreeNode(Tree.SelectedNode, newWarehouse.Root);
            CodeTextBox.Text = SelectedItem.Code;
            AmountTextBox.Text = SelectedItem.Amount.ToString();
            PriceTextBox.Text = SelectedItem.Price.ToString();
            DescriptionTextBox.Text = SelectedItem.Description;
            PhotoBox.Image = SelectedItem.Photo;
        }

        /// <summary>
        /// Creates a data grid for all items in the selected section.
        /// </summary>
        private void CreateDataGrid()
        {
            SectionDataGrid.Columns.Add("Name", "Name");
            SectionDataGrid.Columns.Add("ItemCode", "Item code");
            SectionDataGrid.Columns.Add("Amount", "Amount");
            SectionDataGrid.Columns.Add("Price", "Price");
            SectionDataGrid.Columns.Add("Description", "Description");
            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.Name = "Image";
            SectionDataGrid.Columns.Add(imgColumn);
            // Filling the datagrid.
            AddRows(newWarehouse.GetSectionByTreeNode(Tree.SelectedNode, newWarehouse.Root));
            // Changing the color of all rows.
            foreach (DataGridViewRow row in SectionDataGrid.Rows)
            {
                row.DefaultCellStyle.BackColor = SystemColors.ControlLight;
            }
            // Changing the color of rows of the current section.
            for (int i = 0; i < newWarehouse.GetSectionByTreeNode(Tree.SelectedNode, newWarehouse.Root).ChildrenNodes.Count; i++)
            {
                SectionDataGrid.Rows[i].DefaultCellStyle.BackColor = SystemColors.Menu;
            }
            foreach (DataGridViewColumn column in SectionDataGrid.Columns)
            {
                column.DefaultCellStyle.BackColor = SystemColors.Menu;
            }
        }

        /// <summary>
        /// Adds rows to the datagrid.
        /// </summary>
        /// <param name="currentSection"></param>
        private void AddRows(Section currentSection)
        {
            for (int i = 0; i < currentSection.ChildrenNodes.Count; i++)
            {
                Item newRow = currentSection.ChildrenNodes[i];
                SectionDataGrid.Rows.Add(newRow.Name, newRow.Code, newRow.Amount,
                    newRow.Price, newRow.Description, newRow.Photo);
            }
            for (int i = 0; i < currentSection.ChildrenSections.Count; i++)
            {
                AddRows(currentSection.ChildrenSections[i]);
            }
        }

        /// <summary>
        /// Opens image in the new window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenImage(object sender, EventArgs e)
        {
            // Checking if the user didn't select several cells.
            if (SectionDataGrid.SelectedCells.Count == 1 && SectionDataGrid.SelectedCells[0].ColumnIndex == SectionDataGrid.Columns.Count - 1)
            {
                try
                {
                    // Opening new form.
                    Photo newPhoto = new Photo();
                    newPhoto.Show();
                    // Index of the item = index of the selected row.
                    int index = SectionDataGrid.SelectedCells[0].RowIndex;
                    Section currentSection = newWarehouse.GetSectionByTreeNode(Tree.SelectedNode, newWarehouse.Root);
                    int currentIndex = 0;
                    Image defaultImage = Image.FromFile("DefaultImage.jpg");
                    currentPhoto = new Bitmap(defaultImage, defaultImage.Size);
                    GetItemPhoto(index, ref currentIndex, currentSection);
                    newPhoto.pictureBox1.Image = currentPhoto;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GetItemPhoto(int index, ref int currentIndex, Section currentSection)
        {
            for (int i = 0; i < currentSection.ChildrenNodes.Count; i++)
            {
                if (currentIndex == index)
                    currentPhoto = currentSection.ChildrenNodes[i].Photo;
                else
                {
                    currentIndex += 1;
                }
            }
            for (int i = 0; i < currentSection.ChildrenSections.Count; i++)
            {
                GetItemPhoto(index, ref currentIndex, currentSection.ChildrenSections[i]);
            }
        }

        /// <summary>
        /// Changes the name of the item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Tree.SelectedNode.Text == NameTextBox.Text)
                return;
            ParentNode = Tree.SelectedNode.Parent;
            ChildNode = Tree.SelectedNode;
            // Checking if the selected section is not the root.
            if (ParentNode != null)
            {
                Section parentSection = newWarehouse.GetSectionByTreeNode(ParentNode, newWarehouse.Root);
                // Checking if the parent section contains an item or a section with such a name.
                if (FindTheSameName(parentSection))
                {
                    MessageBox.Show("This name already exists or it is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ChildNode.Text = NameTextBox.Text;
                    Section section = newWarehouse.GetSectionByTreeNode(ChildNode, newWarehouse.Root);
                    Item item = newWarehouse.GetItemByTreeNode(ChildNode, newWarehouse.Root);
                    // Checking the type of the selected node and changing name.
                    if (section != null)
                        section.Name = NameTextBox.Text;
                    else
                        item.Name = NameTextBox.Text;
                    Tree_AfterSelect(null, null);
                }
            }
            else
            {
                newWarehouse.Root.Name = NameTextBox.Text;
                Tree_AfterSelect(null, null);
            }
        }

        /// <summary>
        /// Finds section with the same name.
        /// </summary>
        /// <param name="parentSection"></param>
        /// <returns></returns>
        private bool FindTheSameName(Section parentSection)
        {
            for (int i = 0; i < parentSection.ChildrenNodes.Count; i++)
            {
                if (parentSection.ChildrenNodes[i].Name == NameTextBox.Text)
                {
                    return true;
                }
            }
            for (int i = 0; i < parentSection.ChildrenSections.Count; i++)
            {
                if (parentSection.ChildrenSections[i].Name == NameTextBox.Text)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Changes the item's code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodeTextBox_TextChanged(object sender, EventArgs e)
        {
            Item Item = newWarehouse.GetItemByTreeNode(Tree.SelectedNode, newWarehouse.Root);
            Item.Code = CodeTextBox.Text;
        }

        /// <summary>
        /// Changing the item's amount.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AmountTextBox_TextChanged(object sender, EventArgs e)
        {
            int amount = 0;
            if (AmountTextBox.Text == "0")
                return;
            Item Item = newWarehouse.GetItemByTreeNode(Tree.SelectedNode, newWarehouse.Root);
            // Trying to parse the entered value.
            if (int.TryParse(AmountTextBox.Text, out amount) && amount >= 0)
            {
                Item.Amount = amount;
            }
            else
            {
                MessageBox.Show("The entered value must be a positive integer or zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Item.Amount = 0;
                AmountTextBox.Text = "0";
            }

        }

        /// <summary>
        /// Changes the item's price.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PriceTextBox_TextChanged(object sender, EventArgs e)
        {
            double price = 0;
            if (PriceTextBox.Text == "0")
                return;
            PriceTextBox.Text = PriceTextBox.Text.Replace(".", ",");
            Item Item = newWarehouse.GetItemByTreeNode(Tree.SelectedNode, newWarehouse.Root);
            // Trying to parse the entered value.
            if (double.TryParse(PriceTextBox.Text, out price) && price > 0)
            {
                Item.Price = price;
            }
            else
            {
                MessageBox.Show("The entered value must be a positive double", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Item.Amount = 0;
                PriceTextBox.Text = "0";
            }
        }

        /// <summary>
        /// Changes the item's description.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DescriprionTextBox_TextChanged(object sender, EventArgs e)
        {
            Item Item = newWarehouse.GetItemByTreeNode(Tree.SelectedNode, newWarehouse.Root);
            Item.Description = DescriptionTextBox.Text;
        }

        /// <summary>
        /// Loads an image for the selected item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhotoTextBox_DoubleClick(object sender, EventArgs e)
        {
            Bitmap image;
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Loading the image from the file.
                    image = new Bitmap(open_dialog.FileName);
                    this.PhotoBox.Size = image.Size;
                    PhotoBox.Image = image;
                    Item item = newWarehouse.GetItemByTreeNode(Tree.SelectedNode, newWarehouse.Root);
                    item.Photo = image;
                    // Setting path to the directory with saved images.
                    string name = open_dialog.SafeFileName;
                    string path = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Saves"), name);
                    // Saving image to this directory.
                    image.Save(path);
                    // Saving path (which is needed for deserialization).
                    item.PathToPicture = path;
                    PhotoBox.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Can't open this file",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Saves current warehouse to the selected directory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Json files (*.json)|*.json";
            saveFileDialog1.RestoreDirectory = true;

            // Seriazlizing the warehouse.
            try
            {
                var json = JsonConvert.SerializeObject(newWarehouse, Formatting.Indented,
                                new JsonSerializerSettings()
                                {
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                });
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                    {
                        sw.Write(json);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Opens the file with the saved warehouse.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Json files (*.json)|*.json";
            openFileDialog1.RestoreDirectory = true;

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                    {
                        Tree.Nodes.Clear();
                        // Loading data about sections and items.
                        newWarehouse = JsonConvert.DeserializeObject<Warehouse>(sr.ReadToEnd());
                        // Creating tree based on this data.
                        CreateTree();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateTree()
        {
            if (newWarehouse.Root != null)
            {
                // Creating a root.
                TreeNode newTreeNode = new TreeNode(newWarehouse.Root.Name);
                newWarehouse.Root.TreeNode = newTreeNode;
                Tree.Nodes.Add(newTreeNode);
                Tree.SelectedNode = newTreeNode;
                // Adding sections and items to the root.
                AddSectionFromFile(newWarehouse.Root, newTreeNode);
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

        /// <summary>
        /// Creates CSV Report for scarce goods.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CSVReport_Click(object sender, EventArgs e)
        {
            CostReportForm newCSVFile = new CostReportForm();
            newCSVFile.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm getHelp = new HelpForm();
            getHelp.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SellerForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            // Seriazlizing the warehouse.
            try
            {
                var json = JsonConvert.SerializeObject(newWarehouse, Formatting.Indented,
                                new JsonSerializerSettings()
                                {
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                });
                using (StreamWriter sw = new StreamWriter("Storage.json"))
                {
                    sw.Write(json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SellerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Close();
        }
    }
}

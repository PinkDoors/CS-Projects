using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PeerGrade9
{
    public partial class BasketForm : Form
    {
        Order currentOrder;

        public BasketForm()
        {
            InitializeComponent();
            CreateOrder(ClientForm.CurrentClient.Basket);
            currentOrder = null;
            CurrentGrid.Text = "Basket";
        }

        /// <summary>
        /// Creates a data grid for all items in the selected section.
        /// </summary>
        private void CreateOrder(List<Item> Order)
        {
            SectionDataGrid.Rows.Clear();
            SectionDataGrid.Columns.Clear();
            SectionDataGrid.Columns.Add("Name", "Name");
            SectionDataGrid.Columns.Add("ItemCode", "Item code");
            SectionDataGrid.Columns.Add("Amount", "Amount");
            SectionDataGrid.Columns.Add("Price", "Price");
            SectionDataGrid.Columns.Add("Description", "Description");
            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.Name = "Image";
            SectionDataGrid.Columns.Add(imgColumn);
            // Filling the datagrid.
            try
            {
                AddRowsToBasket(Order);
            }
            catch { }
            // Changing the color of all rows.
            foreach (DataGridViewRow row in SectionDataGrid.Rows)
            {
                row.DefaultCellStyle.BackColor = SystemColors.Menu;
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
        private void AddRowsToBasket(List<Item> Order)
        {
            for (int i = 0; i < Order.Count; i++)
            {
                Item newRow = Order[i];
                SectionDataGrid.Rows.Add(newRow.Name, newRow.Code, newRow.Amount,
                    newRow.Price, newRow.Description, newRow.Photo);
            }
        }

        /// <summary>
        /// Shows all client orders.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAllOrdersButton_Click(object sender, EventArgs e)
        {
            ShowAllOrdersButton.Visible = false;
            ShowBasketButton.Visible = true;
            CurrentGrid.Text = "Orders";
            // Showing all client orders.
            CreateGridWithOrders();
        }

        /// <summary>
        /// Shows basket.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowBasketButton_Click(object sender, EventArgs e)
        {
            ShowAllOrdersButton.Visible = true;
            ShowBasketButton.Visible = false;
            CurrentGrid.Text = "Basket";
            // Showing all information about basket.
            CreateOrder(ClientForm.CurrentClient.Basket);
        }

        /// <summary>
        /// Creates datagrid with all client oreders.
        /// </summary>
        private void CreateGridWithOrders()
        {
            SectionDataGrid.Rows.Clear();
            SectionDataGrid.Columns.Clear();
            SectionDataGrid.Columns.Add("OrderNumber", "Order Number");
            SectionDataGrid.Columns.Add("RegistrationTime", "Registration Time");
            SectionDataGrid.Columns.Add("Processed", "Processed");
            SectionDataGrid.Columns.Add("Paid", "Paid");
            SectionDataGrid.Columns.Add("Shipped", "Shipped");
            SectionDataGrid.Columns.Add("Executed", "Executed");
            SectionDataGrid.Click += new EventHandler(ShowOrder);
            // Changing the color of all rows.
            foreach (DataGridViewRow row in SectionDataGrid.Rows)
            {
                row.DefaultCellStyle.BackColor = SystemColors.Menu;
            }
            foreach (DataGridViewColumn column in SectionDataGrid.Columns)
            {
                column.DefaultCellStyle.BackColor = SystemColors.Menu;
            }
            AddRowsToOrders();
        }

        /// <summary>
        /// Adds rows to the datagrid.
        /// </summary>
        /// <param name="currentSection"></param>
        private void AddRowsToOrders()
        {
            for (int i = 0; i < ClientForm.CurrentClient.AllOrders.Count; i++)
            {
                Order newRow = ClientForm.CurrentClient.AllOrders[i];
                SectionDataGrid.Rows.Add(newRow.OrderNumber, newRow.RegistrationTime,
                    newRow.OrderStatus.HasFlag(Status.Processed) ? "✓" : "",
                    newRow.OrderStatus.HasFlag(Status.Paid) ? "✓" : "",
                    newRow.OrderStatus.HasFlag(Status.Shipped) ? "✓" : "",
                    newRow.OrderStatus.HasFlag(Status.Executed) ? "✓" : "");
            }
        }

        /// <summary>
        /// Sets an order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetAnOrderButton_Click(object sender, EventArgs e)
        {
            if (ClientForm.CurrentClient.Basket.Count == 0)
            {
                MessageBox.Show("Your basket is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("You have successfully set an order", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CurrentGrid.Text = "Order";
            List<Item> orderedItems = new List<Item>(ClientForm.CurrentClient.Basket);
            Order newOrder = new Order(ClientForm.CurrentClient, orderedItems);
            ClientForm.CurrentClient.AllOrders.Add(newOrder);
            ClientForm.CurrentClient.Basket.Clear();
            CreateOrder(orderedItems);
            currentOrder = newOrder;
        }

        /// <summary>
        /// Shows the selected order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowOrder(object sender, EventArgs e)
        {
            SectionDataGrid.Click -= new EventHandler(ShowOrder);
            ShowAllOrdersButton.Visible = true;
            ShowBasketButton.Visible = false;
            CurrentGrid.Text = "Order";
            try
            {
                currentOrder = ClientForm.CurrentClient.AllOrders[SectionDataGrid.SelectedCells[0].RowIndex];
                CreateOrder(ClientForm.CurrentClient.AllOrders[SectionDataGrid.SelectedCells[0].RowIndex].OrderedItems);
            }
            catch { }
        }

        /// <summary>
        /// Pays for the selected order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayButton_Click(object sender, EventArgs e)
        {
            if (currentOrder != null)
            {
                if (currentOrder.OrderStatus.HasFlag(Status.Processed))
                {
                    currentOrder.OrderStatus |= Status.Paid;
                    MessageBox.Show("You have successfully paid for the product", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("The order has not been processed yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("You should set an order first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

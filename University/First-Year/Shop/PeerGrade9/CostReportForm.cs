using System;
using System.IO;
using System.Windows.Forms;

namespace PeerGrade9
{
    public partial class CostReportForm : Form
    {
        public CostReportForm()
        {
            InitializeComponent();
        }

        private void GetCostButton_Click(object sender, EventArgs e)
        {
            int minAmount = GetMinAmount();
            if (minAmount == 0)
                MessageBox.Show("The entered value must be a positive integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string CSV = "";
                foreach (Client client in (Application.OpenForms[0] as LoginForm).Clients)
                {
                    double sum = GetOrderAmount(client);
                    if (sum >= minAmount)
                        CSV += $"{client.Login};{sum}\n";
                }
                // Savind data to CSV.
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
                Close();
            }
        }

        /// <summary>
        /// Finds the cost of all client orders.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private double GetOrderAmount(Client client)
        {
            double sum = 0;
            for (int i = 0; i < client.AllOrders.Count; i++)
            {
                if (client.AllOrders[i].OrderStatus.HasFlag(Status.Paid))
                    sum += client.AllOrders[i].FindPrice();
            }
            return sum;
        }

        /// <summary>
        /// Reads input data about minimal cost.
        /// </summary>
        /// <returns></returns>
        private int GetMinAmount()
        {
            int number = 0;
            if (MinimumAmount.Text == "")
                return 0;
            if (int.TryParse(MinimumAmount.Text, out number) && number > 0)
            {
                return number;
            }
            else
            {
                MinimumAmount.Text = "0";
                return 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text.RegularExpressions;

namespace Tables
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Dictionary value-quantity for histogram.
        private Dictionary<string, int> histogramDictionary = new Dictionary<string, int>();
        // Dictionary value-quantity for graph X->Y.
        private Dictionary<string, int> twoDimensionNumberDictionary = new Dictionary<string, int>();
        // Dictionary value-average value for graph X->Y.
        private Dictionary<string, double> twoDimensionAverageDictionary = new Dictionary<string, double>();
        private string filePath;

        /// <summary>
        /// This method open CSV file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenButton_Click(object sender, EventArgs e)
        {
            DataGrid.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            DataTable dataTable = new DataTable();
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "CSV Files (*.csv)|*.csv";
            try
            {
                // Choose the file.
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StreamReader streamReader = new StreamReader(sfd.FileName);
                    filePath = sfd.FileName;
                    AddColumns(dataTable, streamReader);
                    AddRows(dataTable, streamReader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DataGrid.DataSource = dataTable;
            // Changing the sortmode of the columns to make it possible to select a column by clicking on the name.
            foreach (DataGridViewColumn col in DataGrid.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.Selected = false;
            }
            DataGrid.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }

        /// <summary>
        /// Adds rows to the table.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="streamReader"></param>
        /// <param name="totalData"></param>
        private static void AddRows(DataTable dataTable, StreamReader streamReader)
        {
            while (!streamReader.EndOfStream)
            {
                // I use Regex.Split because i need to split the row with a comma only if there is no space after it.
                string[] totalData = Regex.Split(streamReader.ReadLine(), @",(?!\s)");
                for (int i = 0; i < totalData.Length; i++)
                {
                    totalData[i] = totalData[i].Trim('"');
                }
                // If there are more rows than columns, than we add columns.
                if (totalData.Length > dataTable.Columns.Count)
                {
                    while (totalData.Length != dataTable.Columns.Count)
                    {
                        dataTable.Columns.Add();
                    }
                    dataTable.Rows.Add(totalData);
                }
                else
                    dataTable.Rows.Add(totalData);
            }
        }

        /// <summary>
        /// Adds columns to the table.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="streamReader"></param>
        private static void AddColumns(DataTable dataTable, StreamReader streamReader)
        {
            // I use Regex.Split because i need to split the row with a comma only if there is no space after it.
            string[] totalData = Regex.Split(streamReader.ReadLine(), @",(?!\s)");
            for (int i = 0; i < totalData.Length; i++)
            {
                totalData[i] = totalData[i].Trim('"');
            }
            for (int i = 0; i < totalData.Length; i++)
            {
                dataTable.Columns.Add(totalData[i]);
            }
        }

        /// <summary>
        /// Builds a histogram.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistogramButton_Click(object sender, EventArgs e)
        {
            histogramDictionary.Clear();
            ChartForm newHistogram = new ChartForm();
            try
            {
                /*
                 * If the number of selected columns is equal to one,
                 * we build a simple histogram,
                 * otherwise a complex one(see point 6 of the technical specification).
                 */
                if (DataGrid.SelectedColumns.Count == 1)
                    QuantitativeHistogram(newHistogram);
                else if (DataGrid.SelectedCells.Count > 3 && DataGrid.SelectedCells.Count < 5000)
                {
                    int indexOfMinRow, indexOfMaxRow, indexOfMinColumn, indexOfMaxColumn;
                    ReadingSelectedPiece(newHistogram, out indexOfMinRow, out indexOfMaxRow, out indexOfMinColumn, out indexOfMaxColumn);
                    CreateComplexHistogramm(newHistogram, indexOfMinRow, indexOfMaxRow, indexOfMinColumn, indexOfMaxColumn);
                    newHistogram.Show();

                }
                else
                    throw new Exception("You should select one column");
            }
            catch
            {
                MessageBox.Show("You should select only one column or if you chose a rectangular area," +
                    " make sure that the values of all the cells in the columns," +
                    " except for the first one, are numeric values ");
            }

        }

        /// <summary>
        /// Сreates a histogram based on the selected area.
        /// </summary>
        /// <param name="newHistogram"></param>
        /// <param name="indexOfMinRow"></param>
        /// <param name="indexOfMaxRow"></param>
        /// <param name="indexOfMinColumn"></param>
        /// <param name="indexOfMaxColumn"></param>
        private void CreateComplexHistogramm(ChartForm newHistogram, int indexOfMinRow, int indexOfMaxRow, int indexOfMinColumn, int indexOfMaxColumn)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                // Reading the names of the x-values.
                string[] firstRow = Regex.Split(sr.ReadLine(), @",(?!\s)");
                int row = 0;
                // Skip the lines to the desired one.
                string line;
                while (row != indexOfMinRow && (line = sr.ReadLine()) != null)
                {
                    row++;
                }
                while (row - 1 != indexOfMaxRow && (line = sr.ReadLine()) != null)
                {
                    string[] nextRow = Regex.Split(line, @",(?!\s)");
                    Series newSeries;
                    // Checking if the name of x-value already exists.
                    if (histogramDictionary.ContainsKey(nextRow[indexOfMinColumn]))
                    {
                        // Changing the name of the series from "name" to "name(count)" 
                        newSeries = new Series($"{nextRow[indexOfMinColumn]}({histogramDictionary[nextRow[indexOfMinColumn]]})");
                        histogramDictionary[nextRow[indexOfMinColumn]] += 1;
                    }
                    else
                    {
                        newSeries = new Series(nextRow[indexOfMinColumn]);
                        histogramDictionary.Add(nextRow[indexOfMinColumn], 1);
                    }
                    // Creating the columns on the chart.
                    for (int i = indexOfMinColumn + 1; i <= indexOfMaxColumn; i++)
                    {
                        newSeries.Points.AddXY(firstRow[i], double.Parse(nextRow[i].Replace('.', ',').Trim('"')));
                    }
                    newHistogram.Chart.Series.Add(newSeries);
                    row++;
                }
            }
        }

        /// <summary>
        /// Returns the position of the selected table piece.
        /// </summary>
        /// <param name="newHistogram"></param>
        /// <param name="indexOfMinRow"></param>
        /// <param name="indexOfMaxRow"></param>
        /// <param name="indexOfMinColumn"></param>
        /// <param name="indexOfMaxColumn"></param>
        private void ReadingSelectedPiece(ChartForm newHistogram, out int indexOfMinRow, out int indexOfMaxRow, out int indexOfMinColumn, out int indexOfMaxColumn)
        {
            var cells = DataGrid.SelectedCells;
            newHistogram.Chart.Series.Clear();
            histogramDictionary.Clear();
            // Finding the index of the first and last row.
            indexOfMinRow = cells[0].RowIndex;
            indexOfMaxRow = cells[0].RowIndex;
            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].RowIndex < indexOfMinRow)
                    indexOfMinRow = cells[i].RowIndex;
                if (cells[i].RowIndex > indexOfMaxRow)
                    indexOfMaxRow = cells[i].RowIndex;
            }
            // Finding the index of the first and last column.
            indexOfMinColumn = cells[0].ColumnIndex;
            indexOfMaxColumn = cells[0].ColumnIndex;
            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].ColumnIndex < indexOfMinColumn)
                    indexOfMinColumn = cells[i].ColumnIndex;
                if (cells[i].ColumnIndex > indexOfMaxColumn)
                    indexOfMaxColumn = cells[i].ColumnIndex;
            }
        }

        /// <summary>
        /// Creates a simple histogram with axis value-quantity.
        /// </summary>
        /// <param name="newHistogram"></param>
        private void QuantitativeHistogram(ChartForm newHistogram)
        {
            int index = DataGrid.SelectedColumns[0].Index;
            StreamReader streamReader = new StreamReader(filePath);
            // Reading the selected column
            string[] totalData;
            totalData = Regex.Split(streamReader.ReadLine(), @",(?!\s)");
            string name = totalData[index].Trim('"');
            totalData = AddPointsInHistogram(newHistogram, index, streamReader, totalData);
            // Setting the interval between the x-values.
            if (newHistogram.Chart.Series[0].Points.Count < 99)
                newHistogram.Chart.ChartAreas[0].AxisX.Interval = 1;
            else if (newHistogram.Chart.Series[0].Points.Count < 300)
                newHistogram.Chart.ChartAreas[0].AxisX.Interval = 2;
            newHistogram.Chart.Series[0].IsVisibleInLegend = false;
            newHistogram.Chart.Titles.Add(new Title(name,
                Docking.Top, new Font("Times New Roman", 18), Color.Black));
            newHistogram.Show();
        }

        /// <summary>
        /// Counts the number of unique values.
        /// </summary>
        /// <param name="newHistogram"></param>
        /// <param name="index"></param>
        /// <param name="streamReader"></param>
        /// <param name="totalData"></param>
        /// <returns></returns>
        private string[] AddPointsInHistogram(ChartForm newHistogram, int index, StreamReader streamReader, string[] totalData)
        {
            while (!streamReader.EndOfStream)
            {
                // Counting the number of unique values.
                totalData = Regex.Split(streamReader.ReadLine(), @",(?!\s)");
                if (histogramDictionary.ContainsKey(totalData[index]))
                    histogramDictionary[totalData[index]] += 1;
                else
                    histogramDictionary.Add(totalData[index], 1);
            }
            // Sorting the dictionary.
            try
            {
                histogramDictionary = histogramDictionary.OrderBy(x => double.Parse(x.Key)).ToDictionary(x => x.Key, x => x.Value);
            }
            catch
            {
                histogramDictionary = histogramDictionary.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            }
            // Adding columns to the chart.
            foreach (var item in histogramDictionary)
            {
                newHistogram.Chart.Series[0].Points.AddXY(item.Key, item.Value);
            }
            return totalData;
        }

        /// <summary>
        /// Creates Two-dimension graph.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwoDimensionGraphButton_Click(object sender, EventArgs e)
        {
            twoDimensionAverageDictionary.Clear();
            twoDimensionNumberDictionary.Clear();
            ChartForm newHistogram = new ChartForm();
            try
            {
                if (DataGrid.SelectedColumns.Count != 2)
                    throw new Exception("You should select two columns");
                int index1 = DataGrid.SelectedColumns[1].Index;
                int index2 = DataGrid.SelectedColumns[0].Index;
                newHistogram.Chart.Series[0].ChartType = SeriesChartType.Line;
                newHistogram.Chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                StreamReader streamReader = new StreamReader(filePath);
                string[]  totalData = streamReader.ReadLine().Split(',');
                string name1 = totalData[index1].Trim('"');
                string name2 = totalData[index2].Trim('"');
                // Getting Points.
                totalData = AddPointsToGraph(index2, index1, streamReader, totalData);
                // Sorting the dictionary.
                try
                {
                    twoDimensionAverageDictionary = twoDimensionAverageDictionary.OrderBy(x => double.Parse(x.Key)).ToDictionary(x => x.Key, x => x.Value);
                }
                catch { }
                // Adding points to the graph.
                foreach (var item in twoDimensionAverageDictionary)
                {
                    newHistogram.Chart.Series[0].Points.AddXY(item.Key.ToString(), item.Value);
                }
                // Setting the interval for x.
                if (newHistogram.Chart.Series[0].Points.Count < 150)
                    newHistogram.Chart.ChartAreas[0].AxisX.Interval = 1;
                newHistogram.Chart.Series[0].IsVisibleInLegend = false;
                newHistogram.Chart.Titles.Add(new Title($"{name1}/{name2}",Docking.Top, new Font("Times New Roman", 18), Color.Black));
                newHistogram.Show();
            }
            catch (ArithmeticException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch
            {
                MessageBox.Show("You should select two columns");
            }
        }

        /// <summary>
        /// Adds columns to the graph.
        /// </summary>
        /// <param name="index2"></param>
        /// <param name="index1"></param>
        /// <param name="streamReader"></param>
        /// <param name="totalData"></param>
        /// <returns></returns>
        private string[] AddPointsToGraph(int index2, int index1, StreamReader streamReader, string[] totalData)
        {
            while (!streamReader.EndOfStream)
            {
                totalData = Regex.Split(streamReader.ReadLine(), @",(?!\s)");
                // Replacing a dot with a comma to Parse a value.
                for (int i = 0; i < totalData.Length; i++)
                {
                    totalData[i] = totalData[i].Trim('"');
                    totalData[i] = totalData[i].Replace(".", ",");
                }
                if (double.TryParse(totalData[index2], out double y))
                {
                    if (twoDimensionAverageDictionary.ContainsKey(totalData[index1]))
                    {
                        // Getting the number of y values for x.
                        twoDimensionNumberDictionary[totalData[index1]] += 1;
                        // Getting the average value for x.
                        twoDimensionAverageDictionary[totalData[index1]] = (twoDimensionAverageDictionary[totalData[index1]] * (twoDimensionNumberDictionary[totalData[index1]] - 1) + y) / twoDimensionNumberDictionary[totalData[index1]];
                    }
                    else
                    {
                        twoDimensionNumberDictionary.Add(totalData[index1], 1);
                        twoDimensionAverageDictionary.Add(totalData[index1], y);
                    }
                }
                else
                    throw new ArithmeticException("Second Column is incorrect (should be double)");
            }
            return totalData;
        }

        /// <summary>
        /// Setting the labels with math info.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_SelectionChanged(object sender, EventArgs e)
        {
            AverageValueLabel.Text = $"Average Value: {GetAverage()}";
            MedianLabel.Text = $"Median: {GetMedian()}";
            DispersionLabel.Text = $"Dispersion: {GetDispersion()}";
            MSELabel.Text = $"MSE: {GetMSE()}";
        }

        /// <summary>
        /// Gets the average value for the selected column.
        /// </summary>
        /// <returns></returns>
        private double GetAverage()
        {
            if (DataGrid.SelectedColumns.Count > 1)
                return 0;
            try
            {
                int index = DataGrid.SelectedColumns[0].Index;
                List<double> allElements = new List<double>();
                StreamReader streamReader = new StreamReader(filePath);
                string[] totalData;
                string input = streamReader.ReadLine();
                // Getting data from the selected column.
                while (!streamReader.EndOfStream)
                {
                    totalData = Regex.Split(streamReader.ReadLine(), @",(?!\s)");
                    // Replacing a dot with a comma to Parse a value.
                    for (int i = 0; i < totalData.Length; i++)
                    {
                        totalData[i] = totalData[i].Trim('"');
                        totalData[i] = totalData[i].Replace('.', ',');
                    }
                    if (double.TryParse(totalData[index], out double element))
                    {
                        allElements.Add(element);
                    }
                }
                if (allElements.Count == 0)
                    return 0;
                return allElements.Average();
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the median value for the selected column.
        /// </summary>
        /// <returns></returns>
        private double GetMedian()
        {
            if (DataGrid.SelectedColumns.Count > 1)
                return 0;
            try
            {
                int index = DataGrid.SelectedColumns[0].Index;
                List<double> allElements = new List<double>();
                StreamReader streamReader = new StreamReader(filePath);
                string[] totalData;
                string input = streamReader.ReadLine();
                // Getting data from the selected column.
                while (!streamReader.EndOfStream)
                {
                    totalData = Regex.Split(streamReader.ReadLine(), @",(?!\s)");
                    // Replacing a dot with a comma to Parse a value.
                    for (int i = 0; i < totalData.Length; i++)
                    {
                        totalData[i] = totalData[i].Trim('"');
                        totalData[i] = totalData[i].Replace('.', ',');
                    }
                    if (double.TryParse(totalData[index], out double element))
                    {
                        allElements.Add(element);
                    }
                }
                allElements.Sort();
                // Getting the median value.
                if (allElements.Count % 2 == 1)
                    return allElements[allElements.Count / 2];
                else
                    return (allElements[allElements.Count / 2] + allElements[allElements.Count / 2 - 1]) / 2;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the dispersion value for the selected column.
        /// </summary>
        /// <returns></returns>
        private double GetDispersion()
        {
            if (DataGrid.SelectedColumns.Count > 1)
                return 0;
            try
            {
                int index = DataGrid.SelectedColumns[0].Index;
                List<double> allElements = new List<double>();
                StreamReader streamReader = new StreamReader(filePath);
                string[] totalData;
                string input = streamReader.ReadLine();
                // Getting data from the selected column.
                while (!streamReader.EndOfStream)
                {
                    totalData = Regex.Split(streamReader.ReadLine(), @",(?!\s)");
                    // Replacing a dot with a comma to Parse a value.
                    for (int i = 0; i < totalData.Length; i++)
                    {
                        totalData[i] = totalData[i].Trim('"');
                        totalData[i] = totalData[i].Replace('.', ',');
                    }
                    if (double.TryParse(totalData[index], out double element))
                    {
                        allElements.Add(element);
                    }
                }
                allElements.Sort();
                double result = 0;
                double average = GetAverage();
                // Just using the formula.
                foreach (double element in allElements)
                {
                    result += Math.Pow((element - average), 2);
                }
                if (allElements.Count == 0)
                    return 0;
                return result / allElements.Count;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the MSE value for the selected column.
        /// </summary>
        /// <returns></returns>
        private double GetMSE()
        {
            if (DataGrid.SelectedColumns.Count > 1)
                return 0;
            try
            {
                // Just using the formula
                return Math.Sqrt(GetDispersion());
            }
            catch
            {
                return 0;
            }
        }
    }
}

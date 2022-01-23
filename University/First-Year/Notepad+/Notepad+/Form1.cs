using FastColoredTextBoxNS;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Formatting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Options;
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

namespace Notepad_
{
    public partial class Form1 : Form
    {
        static int numberOfPages = 0;

        /// <summary>
        /// Указывает, был ли когда-нибудь сохранен данный файл.
        /// </summary>
        Dictionary<TabPage, bool> isSaved = new Dictionary<TabPage, bool>();
        /// <summary>
        /// Содержит директорию, в которой сохранен данный файл.
        /// </summary>
        Dictionary<TabPage, string> saveDirectory = new Dictionary<TabPage, string>();
        /// <summary>
        /// Указывает, есть ли несохранненые изменения в файле.
        /// </summary>
        Dictionary<TabPage, bool> unSavedChanges = new Dictionary<TabPage, bool>();

        public Form1()
        {
            InitializeComponent();
            SettingData();
            InitialFiles();
            AutoSaveEnabled();
            BackupEnabled();
            Paint();
        }

        /// <summary>
        /// Данный метод устанавливает фильтры для файлов.
        /// </summary>
        private void SettingData()
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|RTF files(*.rtf)|*.rtf|С# files(*.cs)|*.cs";
            openFileDialog2.Filter = "Text files(*.txt)|*.txt|RTF files(*.rtf)|*.rtf|С# files(*.cs)|*.cs";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|RTF files(*.rtf)|*.rtf|С# files(*.cs)|*.cs";
            saveFileDialog1.DefaultExt = "*.rtf | *.txt | *.cs";
            openFileDialog1.DefaultExt = "*.rtf | *.txt | *.cs";
            openFileDialog2.DefaultExt = "*.rtf | *.txt | *.cs";
            openFileDialog2.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Backup");
        }

        /// <summary>
        /// Данный метод закрашивает окно в соотеветствии с выбранной темой.
        /// </summary>
        private new void Paint()
        {
            // Считываем данные о теме из файла.
            string[] settingsData = File.ReadAllLines("settings.txt");
            if (settingsData[2] == "Light")
            {
                LightTheme();
            }
            else
            {
                DarkTheme();
            }
        }

        /// <summary>
        /// Устанавливает светлую тему.
        /// </summary>
        private void LightTheme()
        {
            this.BackColor = Color.LightSeaGreen;
            this.menuStrip1.BackColor = Color.LightSeaGreen;
            this.notificationsTextBox.BackColor = Color.LightSeaGreen;
            this.notificationsTextBox.ForeColor = SystemColors.WindowText;
            // Перекрашиваем все кнопки.
            foreach (ToolStripMenuItem item in menuStrip1.Items)
                item.ForeColor = SystemColors.ControlText;
            // Перекрашиваем RichTextBox.
            foreach (TabPage item in tabControl1.TabPages)
            {
                item.Controls[0].BackColor = SystemColors.Control;
            }
        }

        /// <summary>
        /// Устанавливает темную тему.
        /// </summary>
        private void DarkTheme()
        {
            this.BackColor = Color.Black;
            this.menuStrip1.BackColor = Color.Black;
            this.notificationsTextBox.ForeColor = SystemColors.WindowText;
            this.notificationsTextBox.BackColor = Color.Black;
            // Перекрашиваем все кнопки.
            foreach (ToolStripMenuItem item in menuStrip1.Items)
                item.ForeColor = SystemColors.Window;
            // Перекрашиваем RichTextBox.
            foreach (TabPage item in tabControl1.TabPages)
            {
                item.Controls[0].BackColor = SystemColors.Control;
            }
        }

        /// <summary>
        /// Данный метод включает автосохранение при условии, что оно было включено в прошлый раз.
        /// </summary>
        private void AutoSaveEnabled()
        {
            // Считываем данные о данных автосохранения.
            string[] settingsData = File.ReadAllLines("settings.txt");
            autosaveTimer.Interval = int.Parse(settingsData[1]) * 60 * 1000;
            // Проверяем включено ли автосохранение.
            if (settingsData[0] == "True")
                autosaveTimer.Start();
        }

        private void BackupEnabled()
        {
            // Считываем данные о данных создания резервной копии.
            string[] settingsData = File.ReadAllLines("settings.txt");
            backupTimer.Interval = int.Parse(settingsData[4]) * 60 * 1000;
            // Проверяем включено ли создание резервной копии.
            if (settingsData[3] == "True")
                backupTimer.Start();
        }

        /// <summary>
        /// Открывает файлы, которые были открыты в последней работе приложения.
        /// </summary>
        private void InitialFiles()
        {
            string[] settingsData = File.ReadAllLines("settings.txt");
            // Если в файле с настройками нет адресов файлов, то создаем новый.
            if (settingsData.Length == 6)
            {
                CreateStartPage();
            }
            // В ином случае открываем старые файлы.
            else
            {
                try
                {
                    OpenOldFiles(settingsData);
                }
                // Если что-то пошло не так, просто создаем начальный файл и выводим информацию об ошибке.             
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                    if (tabControl1.TabPages.Count == 0)
                        CreateStartPage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    if (tabControl1.TabPages.Count == 0)
                        CreateStartPage();
                }
            }
        }

        /// <summary>
        /// Создает начальную вкладку.
        /// </summary>
        private void CreateStartPage()
        {
            string[] settingsData = File.ReadAllLines("settings.txt");
            TabPage newPage = new TabPage();
            // Знаю, что костыль, но иначе крестик, закрывающий файл, будет поверх названия.
            newPage.Text = "New Document          ";
            // Добавляем вкладку.
            tabControl1.TabPages.Add(newPage);
            tabControl1.SelectedTab = newPage;
            // Создаем и добавляем TextBox в зависимости от выбранного режима форматирования текста. 
            AddTextBoxWithoutText(settingsData, newPage);
            // Вносим изменения в словари, связанные со статусом сохранения файла.
            isSaved.Add(tabControl1.SelectedTab, false);
            saveDirectory.Add(tabControl1.SelectedTab, null);
            unSavedChanges.Add(tabControl1.SelectedTab, false);
        }

        private void AddTextBoxWithoutText(string[] settingsData, TabPage newPage)
        {
            if (settingsData[5] == "True")
            {
                var textBox = new FastColoredTextBox();
                textBox.Dock = DockStyle.Fill;
                textBox.Language = Language.CSharp;
                textBox.ContextMenuStrip = contextMenuStrip1;
                textBox.TextChanged += TextBox_TextChanged;
                newPage.Controls.Add(textBox);
            }
            else
            {
                var textBox = new RichTextBox();
                textBox.Dock = DockStyle.Fill;
                textBox.ContextMenuStrip = contextMenuStrip1;
                textBox.TextChanged += TextBox_TextChanged;
                newPage.Controls.Add(textBox);
            }
        }

        /// <summary>
        /// Данный метод открывает старые файлы
        /// </summary>
        /// <param name="settingsData"></param>
        private void OpenOldFiles(string[] settingsData)
        {
            // Для каждого адреса файла создаем вкладку в документе "settings.txt".
            for (int i = 6; i < settingsData.Length; i++)
            {
                TabPage newPage = new TabPage();
                newPage.Text = $"{Path.GetFileName(settingsData[i])}          ";
                string extension = Path.GetExtension(settingsData[i]);
                AddTextBoxWithText(settingsData, newPage, extension);
                // Добавляем созданную вкладку и делаем ее текущей.
                tabControl1.TabPages.Add(newPage);
                tabControl1.SelectedTab = newPage;
                // Вносим изменения в словари, связанные со статусом сохранения файла.
                isSaved.Add(tabControl1.SelectedTab, true);
                saveDirectory.Add(tabControl1.SelectedTab, Path.GetFileName(settingsData[i]));
                unSavedChanges.Add(tabControl1.SelectedTab, false);
            }
        }

        private void AddTextBoxWithText(string[] settingsData, TabPage newPage, string extension)
        {
            if (settingsData[5] == "True")
            {
                // Создаем RichTextBox для загрузки в него данных.(У FastColoredTextBox нет метода Load.)
                var textBoxForLoading = new RichTextBox();
                textBoxForLoading.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                var textBox = new FastColoredTextBox();
                textBox.Dock = DockStyle.Fill;
                textBox.Language = Language.CSharp;
                textBox.ContextMenuStrip = contextMenuStrip1;
                textBox.Text = textBoxForLoading.Text;
                textBox.TextChanged += TextBox_TextChanged;
                newPage.Controls.Add(textBox);
            }
            else
            {
                var textBox = new RichTextBox();
                textBox.Dock = DockStyle.Fill;
                textBox.ContextMenuStrip = contextMenuStrip1;             
                newPage.Controls.Add(textBox);
                if (extension == ".txt" || extension == ".cs")
                    textBox.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                else
                    textBox.LoadFile(openFileDialog1.FileName);
                textBox.TextChanged += TextBox_TextChanged;
            }
        }

        /// <summary>
        /// Данный метод открывает файлы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] settingsData = File.ReadAllLines("settings.txt");
            if (openFileDialog1.ShowDialog() == DialogResult.OK &&
      openFileDialog1.FileName.Length > 0)
            {
                try
                {
                    OpenFile(settingsData);
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Данного файла не существует");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Создает вкладку с содержимым выбранного файла.
        /// </summary>
        /// <param name="settingsData"></param>
        private void OpenFile(string[] settingsData)
        {
            TabPage newDocument = new TabPage();
            newDocument.Text = $"{openFileDialog1.SafeFileName}          ";
            string extension = Path.GetExtension(openFileDialog1.FileName);
            // Считываем файлы в формате, который выбрал пользователь.
            AddTextBoxWithText(settingsData, newDocument, extension);
            // Вносим изменения в словари, связанные со статусом сохранения файла.
            isSaved.Add(newDocument, true);
            saveDirectory.Add(newDocument, openFileDialog1.FileName);
            // Добавляем RichTextBox и вкладку.
            tabControl1.TabPages.Add(newDocument);
            tabControl1.SelectedTab = newDocument;
        }

        /// <summary>
        /// Сохраняет файл в выбранной директории.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string extension = Path.GetExtension(saveFileDialog1.FileName);
                    // Сохраняем в формате, выбранном пользователем.
                    SaveFile(saveFileDialog1.FileName, extension);
                    tabControl1.SelectedTab.Text = Path.GetFileName(saveFileDialog1.FileName);
                    // Вносим изменения в словари, связанные со статусом сохранения файла.
                    isSaved[tabControl1.SelectedTab] = true;
                    unSavedChanges[tabControl1.SelectedTab] = false;
                    saveDirectory[tabControl1.SelectedTab] = saveFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Данный метод перезаписывает файл, если он был уже сохранен, и сохраняет
        /// в выбранную директорию, если не был.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Проверяем, был ли сохранен файл.
            if (isSaved[tabControl1.SelectedTab])
            {
                // Просто перезаписываем содержимое файла.
                string path = saveDirectory[tabControl1.SelectedTab];
                string extension = Path.GetExtension(path);
                unSavedChanges[tabControl1.SelectedTab] = false;
                // Сохраняем в формате, выбранном пользователем.
                SaveFile(path, extension);
            }
            else
            {
                // Сохраняем в директорию.
                SaveAsToolStripMenuItem_Click(sender, e);
            }
        }

        /// <summary>
        /// Данный метод сохраняет все вкладки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAllStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Создаем копию "unSavedChanges", чтобы пройтись по нему foreach-ем.
            Dictionary<TabPage, bool> unsavedChanges = CopiedDictionary();
            foreach (TabPage item in unsavedChanges.Keys)
            {
                if (unSavedChanges[item])
                {
                    tabControl1.SelectedTab = item;
                    SaveToolStripMenuItem_Click(sender, e);
                }
            }
        }

        /// <summary>
        /// Создает новую вкладку.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] settingsData = File.ReadAllLines("settings.txt");
            numberOfPages += 1;
            // Создаем новую вкладку.
            TabPage newDocument = new TabPage();
            newDocument.Text = $"New Document({numberOfPages})     ";
            // Создаем и добавляем TextBox в зависимости от выбранного режима форматирования текста. 
            AddTextBoxWithoutText(settingsData, newDocument);
            // Вносим изменения в словари, связанные со статусом сохранения файла.
            unSavedChanges.Add(newDocument, false);
            isSaved.Add(newDocument, false);
            saveDirectory.Add(newDocument, null);
            // Добавляем вкладку
            tabControl1.TabPages.Add(newDocument);
            tabControl1.SelectedTab = newDocument;
        }

        /// <summary>
        /// Закрывает окно формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// При закрытии программы спрашивает про несохраненные файлы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Создаем новый словарь, чтобы идти по нему foreach-ем.
            Dictionary<TabPage, bool> unsavedChanges = CopiedDictionary();
            foreach (TabPage item in unsavedChanges.Keys)
            {
                // Проверяем, есть ли несохраненные изменения.
                if (unSavedChanges[item])
                {
                    tabControl1.SelectedTab = item;
                    DialogResult result = MessageBox.Show($"Сохранить изменения в файле {item.Text.Trim()}?", "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        SaveToolStripMenuItem_Click(sender, e);
                        tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                        isSaved.Remove(item);
                        saveDirectory.Remove(item);
                        unSavedChanges.Remove(item);
                    }
                    else if (result == DialogResult.No)
                    {
                        tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                        isSaved.Remove(item);
                        saveDirectory.Remove(item);
                        unSavedChanges.Remove(item);
                    }
                    else e.Cancel = true;
                }
            }
            // Сохраняем файл, чтобы потом открыть его при новом запуске программы. 
            SaveFileDirectory();
        }

        /// <summary>
        /// Данный метод сохраняет открытые файлы, чтобы при повторном запуске программы их открыть.
        /// </summary>
        /// <param name="settingsData"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        private void SaveFileDirectory()
        {
            string[] settingsData = File.ReadAllLines("settings.txt");
            // Чистим от мусора файл.
            Array.Resize(ref settingsData, 6);
            // Закидываем в "settings.txt" пути файлов.
            foreach (TabPage item in tabControl1.TabPages)
            {
                if (saveDirectory[item] != null)
                {
                    Array.Resize(ref settingsData, settingsData.Length + 1);
                    settingsData[settingsData.Length - 1] = $"{saveDirectory[item]}";
                }
            }
            File.WriteAllLines("settings.txt", settingsData);
        }

        /// <summary>
        /// Создает копию словаря "unSavedChanges"
        /// </summary>
        /// <returns></returns>
        private Dictionary<TabPage, bool> CopiedDictionary()
        {
            Dictionary<TabPage, bool> unsavedChanges = new Dictionary<TabPage, bool>();
            foreach (TabPage page in unSavedChanges.Keys)
            {
                unsavedChanges.Add(page, unSavedChanges[page]);
            }
            return unsavedChanges;
        }

        /// <summary>
        /// Запускает осно с настройками.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings newForm = new Settings();
            newForm.Owner = this;
            newForm.Show();
        }

        /// <summary>
        /// Реализует автосохранение файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            string result = "";
            foreach (TabPage item in unSavedChanges.Keys.ToList())
                if (unSavedChanges[item] && isSaved[item])
                {
                    unSavedChanges[item] = false;
                    autosaveTimer.Stop();
                    // Получаем путь к файлу и его расширение.
                    string path = saveDirectory[item];
                    string extension = Path.GetExtension(path);
                    // Сохраняем файл.
                    SaveFile(path, extension);
                    result += $"{item.Text.Trim()}, ";
                    autosaveTimer.Start();
                }
            // Выводим уведомление об автосохранении.
            if (result != "")
                notificationsTextBox.Text = $"Автосохранение прошло успешно. Сохраненные файлы: {result.Trim().Trim(',')}";
        }

        /// <summary>
        /// Сохраняет файл в выбранном расширении.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="extension"></param>
        private void SaveFile(string path, string extension)
        {
            try
            {
                // Проверяем расширение и TextBox-ы.        
                if (extension == ".txt")
                {
                    if (tabControl1.SelectedTab.Controls[0] is RichTextBox)
                        (tabControl1.SelectedTab.Controls[0] as RichTextBox).SaveFile(path, RichTextBoxStreamType.PlainText);
                    else
                        (tabControl1.SelectedTab.Controls[0] as FastColoredTextBox).SaveToFile(path, Encoding.UTF8);
                }
                else if (extension == ".rtf")
                {
                    if (tabControl1.SelectedTab.Controls[0] is RichTextBox)
                        (tabControl1.SelectedTab.Controls[0] as RichTextBox).SaveFile(path, RichTextBoxStreamType.RichText);
                    else
                        (tabControl1.SelectedTab.Controls[0] as FastColoredTextBox).SaveToFile(path, Encoding.UTF8);
                }
                else
                {
                    if (tabControl1.SelectedTab.Controls[0] is RichTextBox)
                        (tabControl1.SelectedTab.Controls[0] as RichTextBox).SaveFile(path, RichTextBoxStreamType.PlainText);
                    else
                        (tabControl1.SelectedTab.Controls[0] as FastColoredTextBox).SaveToFile(path, Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Реализует создание резервной копии.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer2_Tick(object sender, EventArgs e)
        {
            string result = "";
            foreach (TabPage item in unSavedChanges.Keys.ToList())
                if (isSaved[item])
                {
                    backupTimer.Stop();
                    DateTime date = DateTime.Now;
                    // Получаем путь к файлу и его расширение.
                    string name = Path.GetFileNameWithoutExtension(saveDirectory[item]);
                    string extension = Path.GetExtension(saveDirectory[item]);
                    string path = @"Backup\"
                                  + $"{name} {date.Day}_{date.Month}_{date.Year} {date.Hour}_{date.Minute}"
                                  + $"{extension}";
                    // Сохраняем файл.
                    SaveFile(path, extension);
                    result += $"{item.Text.Trim()}, ";
                    backupTimer.Start();
                }
            // Выводим уведомление об автосохранении.
            if (result != "")
                notificationsTextBox.Text = $"Создание резервной копии прошло успешно. Созданные файлы: {result.Trim().Trim(',')}";
        }

        /// <summary>
        /// Данный метод рисует вкладку и кнопку закрытия вкладки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 6, e.Bounds.Top + 4);
            e.Graphics.DrawString("X", e.Font, Brushes.Red, e.Bounds.Right - 15, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        /// <summary>
        /// Данный метод создает кнопку закрытия вкладки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            // Для каждой вкладки создаем кнопку.
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                // Получаем размер вкладки.
                Rectangle r = tabControl1.GetTabRect(i);
                // Создаем кнопку.
                Rectangle closeButton =
                    new Rectangle(r.Right - 15, r.Top + 5, 15, 15);
                // Проверяем указывает ли мышь на данную кнопку.
                if (closeButton.Contains(e.Location))
                {
                    DialogResult closeTab = MessageBox.Show(
                        $"Would you like to save the changes in: {tabControl1.TabPages[i].Text.Trim()}?",
                        "Save Changes",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question);
                    if (closeTab == DialogResult.Yes)
                    {
                        SaveToolStripMenuItem_Click(sender, e);
                        isSaved.Remove(tabControl1.TabPages[i]);
                        saveDirectory.Remove(tabControl1.TabPages[i]);
                        unSavedChanges.Remove(tabControl1.TabPages[i]);
                        tabControl1.TabPages.RemoveAt(i);
                        break;
                    }
                    else if (closeTab == DialogResult.No)
                    {
                        isSaved.Remove(tabControl1.TabPages[i]);
                        saveDirectory.Remove(tabControl1.TabPages[i]);
                        unSavedChanges.Remove(tabControl1.TabPages[i]);
                        tabControl1.TabPages.RemoveAt(i);
                        break;
                    }
                    else if (closeTab == DialogResult.Cancel)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Меняет формат шрифта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (tabControl1.SelectedTab.Controls[0] is RichTextBox)
                {
                    (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionFont = fontDialog1.Font;
                    (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionColor = fontDialog1.Color;
                }
                else
                {
                    (tabControl1.SelectedTab.Controls[0] as FastColoredTextBox).Font = fontDialog1.Font;
                    (tabControl1.SelectedTab.Controls[0] as FastColoredTextBox).SelectionColor = fontDialog1.Color;
                }
            }
        }

        /// <summary>
        /// Выделяет весь текст в TextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAll_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Controls[0] is RichTextBox)
            {
                (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionStart = 0;
                (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionLength = (tabControl1.SelectedTab.Controls[0] as RichTextBox).Text.Length;
                (tabControl1.SelectedTab.Controls[0] as RichTextBox).Focus();
            }
            else
            {
                (tabControl1.SelectedTab.Controls[0] as FastColoredTextBox).SelectionStart = 0;
                (tabControl1.SelectedTab.Controls[0] as FastColoredTextBox).SelectionLength = (tabControl1.SelectedTab.Controls[0] as FastColoredTextBox).Text.Length;
                (tabControl1.SelectedTab.Controls[0] as FastColoredTextBox).Focus();
            }

        }

        /// <summary>
        /// Вырезает выделенный текст и отправляет его в буфер обмена.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cut_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Controls[0] is RichTextBox)
            {
                Clipboard.SetData(DataFormats.Rtf,
               (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectedRtf);
                (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectedText = "";
            }
            else
            {
                Clipboard.SetData(DataFormats.Rtf,
               (tabControl1.SelectedTab.Controls[0] as FastColoredTextBox).SelectedText);
                (tabControl1.SelectedTab.Controls[0] as FastColoredTextBox).SelectedText = "";
            }


        }

        /// <summary>
        /// Копирует выделенный текст в буфер обмена.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Copy_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Controls[0] is RichTextBox)
            {
                Clipboard.SetData(DataFormats.Rtf,
              (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectedRtf);
            }
            else
            {
                Clipboard.SetData(DataFormats.Rtf,
              (tabControl1.SelectedTab.Controls[0] as FastColoredTextBox).SelectedText);
            }


        }

        /// <summary>
        /// Вставляет текст из буфера обмена в RichTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Insert_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Controls[0] is RichTextBox)
            {
                if (Clipboard.ContainsText(TextDataFormat.Rtf))
                    (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectedRtf
                        = Clipboard.GetData(DataFormats.Rtf).ToString();
            }
            else
            {
                if (Clipboard.ContainsText(TextDataFormat.Rtf))
                    (tabControl1.SelectedTab.Controls[0] as FastColoredTextBox).SelectedText
                        = Clipboard.GetData(DataFormats.Rtf).ToString();
            }


        }

        /// <summary>
        /// При изменении содержимого RichTextBox-а изменяет состояние unSavedChanges
        /// на true;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void TextBox_TextChanged(object sender, EventArgs e)
        {
            unSavedChanges[tabControl1.SelectedTab] = true;
        }

        /// <summary>
        /// Форматирует C# код.
        /// </summary>
        /// <returns></returns>
        private string FormatCode()
        {
            // Ну тут что-то происходит.
            var workspace = new AdhocWorkspace();

            OptionSet options = workspace.Options;
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInMethods, true);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInProperties, true);

            CompilationUnitSyntax compilationUnit = CreateCompilationUnit(
            (tabControl1.SelectedTab.Controls[0] as FastColoredTextBox).Text);

            SyntaxNode formattedNode = Formatter.Format(compilationUnit, workspace, options);

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                formattedNode.WriteTo(writer);
            }
            return sb.ToString();
        }

        private CompilationUnitSyntax CreateCompilationUnit(string text)
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(text);
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
            return root;
        }

        /// <summary>
        /// Открывает новое окно.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewWindowStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

        /// <summary>
        /// Создает резервную копию.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackupStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK &&
      openFileDialog2.FileName.Length > 0)
            {
                try
                {
                    string extension = Path.GetExtension(openFileDialog2.FileName);
                    // Считываем файлы в формате, который выбрал пользователь.
                    if (tabControl1.SelectedTab != null)
                    {
                        if (extension == ".txt" || extension == ".cs")
                            (tabControl1.SelectedTab.Controls[0] as RichTextBox).LoadFile(openFileDialog2.FileName, RichTextBoxStreamType.PlainText);
                        else
                            (tabControl1.SelectedTab.Controls[0] as RichTextBox).LoadFile(openFileDialog2.FileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        MessageBox.Show("Требуется открытая вкладка для замены ее содержимого на данные резервной копии");
                    }
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Данного файла не существует");
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Требуется открытая вкладка для замены ее содержимого на данные резервной копии");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Отменяет последнее действие.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Controls[0] is FastColoredTextBox)
                (tabControl1.SelectedTab.Controls[0] as FastColoredTextBox).Undo();
            else
                (tabControl1.SelectedTab.Controls[0] as RichTextBox).Undo();
        }

        /// <summary>
        /// Возвращает отмененное действие.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Controls[0] is FastColoredTextBox)
                (tabControl1.SelectedTab.Controls[0] as FastColoredTextBox).Redo();
            else
                (tabControl1.SelectedTab.Controls[0] as RichTextBox).Redo();
        }

        /// <summary>
        /// Меняет textBox на FastColored, если выбран режим работы с кодом C#.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl1_Selected(object sender, TabControlEventArgs e)
        {
            // Считываем данные о состоянии режима работы приложения.
            string[] settingsData = File.ReadAllLines("settings.txt");
            if (tabControl1.SelectedTab != null)
            {
                if ((settingsData[5] == "True") && (tabControl1.SelectedTab.Controls[0] is RichTextBox))
                {
                    // Меняем RichTextBox на FastColoredTextBox.
                    var newTextBox = new FastColoredTextBox();
                    newTextBox.Language = Language.CSharp;
                    newTextBox.AutoSize = false;
                    newTextBox.ContextMenuStrip = contextMenuStrip1;
                    newTextBox.TextChanged += TextBox_TextChanged;
                    newTextBox.Dock = DockStyle.Fill;
                    newTextBox.Text = (tabControl1.SelectedTab.Controls[0] as RichTextBox).Text;
                    tabControl1.SelectedTab.Controls.Clear();
                    tabControl1.SelectedTab.Controls.Add(newTextBox);
                }
            }
        }

        private void FormatCodeStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Controls[0] is FastColoredTextBox)
            {
                (tabControl1.SelectedTab.Controls[0] as FastColoredTextBox).Text = FormatCode();
            }
        }
    }

}

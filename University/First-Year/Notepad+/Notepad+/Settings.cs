using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Notepad_
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            SettingData();
        }

        /// <summary>
        /// Данный метод устанавливает настройки приложения в соответствии 
        /// с сохраненными значениями.
        /// </summary>
        private void SettingData()
        {
            string[] settingsData = File.ReadAllLines("settings.txt");
            // Ставим галочки у автосохранения.
            AutoSavesAndBackups(settingsData);
            // Устанавливаем тему.
            SettingMainTheme(settingsData);
            // Устанавливаем стандартные значения.
            numericUpDown1.Value = decimal.Parse(settingsData[1]);
            numericUpDown2.Value = decimal.Parse(settingsData[4]);
            comboBox1.Text = settingsData[2];
        }

        /// <summary>
        /// Устанавливает цвет шрифта и фона в зависимости от темы.
        /// </summary>
        /// <param name="settingsData"></param>
        private void SettingMainTheme(string[] settingsData)
        {
            if (settingsData[2] == "Light")
            {
                this.BackColor = Color.LightSeaGreen;
                checkBox1.ForeColor = SystemColors.ControlText;
                checkBox2.ForeColor = SystemColors.ControlText;
                codeFormatting.ForeColor = SystemColors.ControlText;
                label1.ForeColor = SystemColors.ControlText;
                label2.ForeColor = SystemColors.ControlText;
            }
            else
            {
                this.BackColor = Color.Black;
                checkBox1.ForeColor = SystemColors.Window;
                checkBox2.ForeColor = SystemColors.Window;
                codeFormatting.ForeColor = SystemColors.Window;
                label1.ForeColor = SystemColors.Window;
                label2.ForeColor = SystemColors.Window;
                labelmin.ForeColor = SystemColors.Window;
            }
        }

        private void AutoSavesAndBackups(string[] settingsData)
        {
            if (settingsData[0] == "True")
            {
                checkBox1.Checked = true;
                checkBox1.CheckState = CheckState.Checked;
            }
            else
            {
                checkBox1.Checked = false;
                checkBox1.CheckState = CheckState.Unchecked;
            }
            if (settingsData[3] == "True")
            {
                checkBox2.Checked = true;
                checkBox2.CheckState = CheckState.Checked;
            }
            else
            {
                checkBox2.Checked = false;
                checkBox2.CheckState = CheckState.Unchecked;
            }
            if (settingsData[5] == "True")
            {
                codeFormatting.Checked = true;
                codeFormatting.CheckState = CheckState.Checked;
            }
            else
            {
                codeFormatting.Checked = false;
                codeFormatting.CheckState = CheckState.Unchecked;
            }
        }

        /// <summary>
        /// Изменяет состояние автосохранения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutosaveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            string[] settingsData = File.ReadAllLines("settings.txt");
            settingsData[0] = checkBox1.Checked.ToString();
            File.WriteAllLines("settings.txt", settingsData);
            if (checkBox1.Checked)
            {
                // Если автосохранение активированно, то для всех окон запускаем таймер.
                checkBox1.CheckState = CheckState.Checked;
                foreach (var item in Application.OpenForms.OfType<Form1>())
                    item.autosaveTimer.Start();
            }
            else
            {
                // Если автосохранение не активированно, то для всех окон отключаем таймер.
                checkBox1.CheckState = CheckState.Unchecked;
                foreach (Form1 item in Application.OpenForms.OfType<Form1>())
                    item.autosaveTimer.Stop();
            }
        }

        /// <summary>
        /// Изменяет состояние создания резервных копий.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackupCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            string[] settingsData = File.ReadAllLines("settings.txt");
            settingsData[3] = checkBox2.Checked.ToString();
            File.WriteAllLines("settings.txt", settingsData);
            if (codeFormatting.Checked)
            {
                // Если создание резервных копий активированно, то для всех окон запускаем таймер.
                codeFormatting.CheckState = CheckState.Checked;
                foreach (var item in Application.OpenForms.OfType<Form1>())
                    item.backupTimer.Start();
            }
            else
            {
                // Если создание резервных копий не активированно, то для всех окон отключаем таймер.
                codeFormatting.CheckState = CheckState.Unchecked;
                foreach (Form1 item in Application.OpenForms.OfType<Form1>())
                    item.backupTimer.Stop();
            }
        }

        /// <summary>
        /// Изменяет состояние работы программы(текст или код).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodeFormatting_CheckedChanged(object sender, EventArgs e)
        {
            string[] settingsData = File.ReadAllLines("settings.txt");
            settingsData[5] = codeFormatting.Checked.ToString();
            File.WriteAllLines("settings.txt", settingsData);
            if (codeFormatting.Checked)
            {
                codeFormatting.CheckState = CheckState.Checked;
                // Меняем во всех вкладках RichTextBox-ы на FastColoredTextBox.
                foreach (Form1 item in Application.OpenForms.OfType<Form1>())
                    foreach (TabPage page in item.tabControl1.TabPages)
                    {
                        var newTextBox = new FastColoredTextBox();
                        if (page.Controls[0] is RichTextBox)
                            newTextBox.Text = (page.Controls[0] as RichTextBox).Text;
                        else
                            newTextBox.Text = (page.Controls[0] as FastColoredTextBox).Text;
                        newTextBox.Language = Language.CSharp;
                        newTextBox.AutoSize = false;
                        newTextBox.ContextMenuStrip = item.contextMenuStrip1;
                        newTextBox.TextChanged += item.TextBox_TextChanged;
                        newTextBox.Dock = DockStyle.Fill;
                        page.Controls.Clear();
                        page.Controls.Add(newTextBox);
                    }
            }
            else
            {
                // Меняем во всех вкладках FastColoredTextBox-ы на RichTextBox.
                codeFormatting.CheckState = CheckState.Unchecked;
                foreach (Form1 item in Application.OpenForms.OfType<Form1>())
                    foreach (TabPage page in item.tabControl1.TabPages)
                    {
                        var newTextBox = new RichTextBox();
                        if (page.Controls[0] is RichTextBox)
                            newTextBox.Text = (page.Controls[0] as RichTextBox).Text;
                        else
                            newTextBox.Text = (page.Controls[0] as FastColoredTextBox).Text;
                        newTextBox.AutoSize = false;
                        newTextBox.ContextMenuStrip = item.contextMenuStrip1;
                        newTextBox.TextChanged += item.TextBox_TextChanged;
                        newTextBox.Dock = DockStyle.Fill;
                        page.Controls.Clear();
                        page.Controls.Add(newTextBox);
                    }
            }
        }

        /// <summary>
        /// Изменяет интервал между автосохранениями.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Считываем данные об автосохранении.
            string[] settingsData = File.ReadAllLines("settings.txt");
            settingsData[1] = numericUpDown1.Value.ToString();
            foreach (var item in Application.OpenForms.OfType<Form1>())
                item.backupTimer.Interval = (int)numericUpDown1.Value * 60 * 1000;
            // Перезаписываем данные.
            File.WriteAllLines("settings.txt", settingsData);
        }
        /// <summary>
        /// Изменяет интервал между сохранением резервных копий.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            // Считываем данные об автосохранении.
            string[] settingsData = File.ReadAllLines("settings.txt");
            settingsData[4] = numericUpDown2.Value.ToString();
            foreach (var item in Application.OpenForms.OfType<Form1>())
                item.backupTimer.Interval = (int)numericUpDown2.Value * 60 * 1000;
            // Перезаписываем данные.
            File.WriteAllLines("settings.txt", settingsData);
        }

        /// <summary>
        /// Изменяет тему всех открытых окон.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox1_TextChanged(object sender, EventArgs e)
        {
            string[] settingsData = File.ReadAllLines("settings.txt");
            settingsData[2] = comboBox1.Text;
            // Перезаписывает выбранную тему.
            File.WriteAllLines("settings.txt", settingsData);
            // Перекрашиваем все формы.
            PaintAllForms();
        }

        /// <summary>
        /// Перекрашивает все формы в выбранную тему.
        /// </summary>
        public void PaintAllForms()
        {
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
        /// Перекрашивает все окна в темную тему.
        /// </summary>
        private void DarkTheme()
        {
            // Перекрашиваем элементы окон с файлами.
            foreach (Form1 item in Application.OpenForms.OfType<Form1>())
            {
                item.BackColor = Color.Black;
                item.menuStrip1.BackColor = Color.Black;
                item.notificationsTextBox.BackColor = Color.Black;
                item.notificationsTextBox.ForeColor = SystemColors.Window;
                foreach (ToolStripMenuItem tool in item.menuStrip1.Items)
                    tool.ForeColor = SystemColors.Window;
            }
            // Перекрашиваем элементы окон с настройками.
            foreach (Settings item in Application.OpenForms.OfType<Settings>())
            {
                item.BackColor = Color.Black;
            }
            label2.ForeColor = SystemColors.Window;
            labelmin.ForeColor = SystemColors.Window;
            checkBox2.ForeColor = SystemColors.Window;
            checkBox1.ForeColor = SystemColors.Window;
            codeFormatting.ForeColor = SystemColors.Window;
            label1.ForeColor = SystemColors.Window;
        }

        /// <summary>
        /// Перекрашивает все окна в светлую тему.
        /// </summary>
        private void LightTheme()
        {
            // Перекрашиваем элементы окон с файлами.
            foreach (Form1 item in Application.OpenForms.OfType<Form1>())
            {
                item.BackColor = Color.LightSeaGreen;
                item.menuStrip1.BackColor = Color.LightSeaGreen;
                item.notificationsTextBox.BackColor = Color.LightSeaGreen;
                item.notificationsTextBox.ForeColor = SystemColors.WindowText;
                foreach (ToolStripMenuItem tool in item.menuStrip1.Items)
                    tool.ForeColor = SystemColors.ControlText;
            }
            // Перекрашиваем элементы окон с настройками.
            foreach (Settings item in Application.OpenForms.OfType<Settings>())
            {
                item.BackColor = Color.LightSeaGreen;
            }
            label2.ForeColor = SystemColors.WindowText;
            labelmin.ForeColor = SystemColors.WindowText;
            checkBox1.ForeColor = SystemColors.ControlText;
            checkBox2.ForeColor = SystemColors.ControlText;
            codeFormatting.ForeColor = SystemColors.ControlText;
            label1.ForeColor = SystemColors.ControlText;
        }

    }
}
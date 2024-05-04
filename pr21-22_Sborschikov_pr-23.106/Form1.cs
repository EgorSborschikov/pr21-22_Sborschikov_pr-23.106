using System;
using System.IO;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr21_22_Sborschikov_pr_23._106
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // Создаем диалог открытия файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";

            // Если пользователь выбрал файл и нажал "Открыть"
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Читаем содержимое файла
                    string fileContent = File.ReadAllText(openFileDialog.FileName);
                    // Выводим содержимое в текстовое поле
                    textBox3.Text = fileContent;
                }
                catch (Exception ex)
                {
                    // Выводим сообщение об ошибке
                    MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Получаем текст из textBox1
            string textToSort = textBox1.Text;

            // Выбор языка для сортировки
            StringComparison comparison = StringComparison.CurrentCulture;
            if (MessageBox.Show("Выберите язык для сортировки:\nАнглийский - OK\nРусский - Cancel", "Выбор языка", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                comparison = StringComparison.CurrentCultureIgnoreCase; // Для русского языка
            }

            // Разбиваем текст на строки, сортируем и объединяем обратно
            string[] lines = textToSort.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(lines, (x, y) => string.Compare(x, y, comparison));
            textBox1.Text = string.Join(Environment.NewLine, lines);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; // Очистка текста в TextBox
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Получаем текст из textBox1
            string textToSort = textBox1.Text;

            // Выбор языка для сортировки
            StringComparison comparison = StringComparison.CurrentCulture;
            if (MessageBox.Show("Выберите язык для сортировки:\nАнглийский - OK\nРусский - Cancel", "Выбор языка", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                comparison = StringComparison.CurrentCultureIgnoreCase; // Для русского языка
            }

            // Разбиваем текст на строки, сортируем и объединяем обратно
            string[] lines = textToSort.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(lines, (x, y) => string.Compare(x, y, comparison));
            textBox2.Text = string.Join(Environment.NewLine, lines);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; // Очистка текста в TextBox
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем текст из textBox1 и textBox2
            string section1 = textBox1.Text;
            string section2 = textBox2.Text;

            // Выводим MessageBox с выбором раздела
            DialogResult result = MessageBox.Show("Выберите раздел:\n1. Раздел 1\n2. Раздел 2", "Выбор раздела", MessageBoxButtons.YesNoCancel);

            // Обрабатываем выбор пользователя
            if (result == DialogResult.Yes)
            {
                // Сдвигаем строку с курсором мыши на 1 таб вправо в textBox1
                int caretPosition = textBox1.SelectionStart;
                int currentLine = textBox1.GetLineFromCharIndex(caretPosition);
                string[] lines = textBox1.Lines;
                lines[currentLine] = "\t" + lines[currentLine];
                textBox1.Text = string.Join(Environment.NewLine, lines);
                textBox1.SelectionStart = textBox1.GetFirstCharIndexFromLine(currentLine);
            }
            else if (result == DialogResult.No)
            {
                // Выводим содержимое раздела 2 в MessageBox
                MessageBox.Show(section2, "Раздел 2");
            }
            else if (result == DialogResult.Cancel)
            {
                // Выводим содержимое раздела 1 в MessageBox
                MessageBox.Show(section1, "Раздел 1");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Получаем текст из textBox1
            string text = textBox1.Text;

            // Получаем позицию курсора
            int caretPosition = textBox1.SelectionStart;
            int currentLine = textBox1.GetLineFromCharIndex(caretPosition);

            // Разбиваем текст на строки
            string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            // Проверяем, что строка не находится у края границы
            if (lines[currentLine].StartsWith("\t"))
            {
                // Сдвигаем строку на 1 таб влево
                lines[currentLine] = lines[currentLine].Remove(0, 1);
                textBox1.Text = string.Join(Environment.NewLine, lines);
                textBox1.SelectionStart = caretPosition - 1;
            }
            else
            {
                MessageBox.Show("Ошибка: Строка находится у края границы и не может быть сдвинута влево.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Получаем текст из textBox1
            string text = textBox1.Text;

            // Получаем позицию курсора
            int caretPosition = textBox1.SelectionStart;
            int currentLine = textBox1.GetLineFromCharIndex(caretPosition);

            // Разбиваем текст на строки
            string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            // Сдвигаем строку на 2 таба вправо
            lines[currentLine] = "\t\t" + lines[currentLine];
            textBox1.Text = string.Join(Environment.NewLine, lines);
            textBox1.SelectionStart = caretPosition + 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Получаем текст из textBox1
            string text = textBox1.Text;

            // Получаем позицию курсора
            int caretPosition = textBox1.SelectionStart;
            int currentLine = textBox1.GetLineFromCharIndex(caretPosition);

            // Разбиваем текст на строки
            string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            // Проверяем, что строка не находится у края границы
            if (lines[currentLine].StartsWith("\t\t"))
            {
                // Сдвигаем строку на 2 таба влево
                lines[currentLine] = lines[currentLine].Remove(0, 2);
                textBox1.Text = string.Join(Environment.NewLine, lines);
                textBox1.SelectionStart = caretPosition - 2;
            }
            else
            {
                MessageBox.Show("Ошибка: Строка находится у края границы и не может быть сдвинута влево.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Запрашиваем у пользователя ввод слова через MessageBox
            string word = MessageBox.Show("Введите слово:", "Добавление слова", MessageBoxButtons.OKCancel) == DialogResult.OK ? Interaction.InputBox("Введите слово:", "Добавление слова") : "";

            // Если пользователь ввел слово
            if (!string.IsNullOrEmpty(word))
            {
                // Выводим MessageBox с выбором раздела
                DialogResult result = MessageBox.Show("Выберите раздел, в который добавить слово:\n1. Раздел 1\n2. Раздел 2", "Выбор раздела", MessageBoxButtons.YesNoCancel);

                // Обрабатываем выбор пользователя
                if (result == DialogResult.Yes)
                {
                    // Добавляем слово в ComboBox1
                    comboBox1.Items.Add(word);
                    MessageBox.Show($"Слово '{word}' добавлено в раздел 1.");
                }
                else if (result == DialogResult.No)
                {
                    // Добавляем слово в ComboBox2
                    comboBox2.Items.Add(word);
                    MessageBox.Show($"Слово '{word}' добавлено в раздел 2.");
                }
                else if (result == DialogResult.Cancel)
                {
                    // Пользователь отменил действие
                    MessageBox.Show("Действие отменено.");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получаем выбранное слово из comboBox1
            string selectedWord = comboBox1.SelectedItem.ToString();

            // Получаем текущую позицию курсора в textBox1
            int caretPosition = textBox1.SelectionStart;

            // Вставляем выбранное слово в textBox1 в позицию курсора
            textBox1.Text = textBox1.Text.Substring(0, caretPosition) + selectedWord + textBox1.Text.Substring(caretPosition);

            // Перемещаем курсор на позицию после вставленного слова
            textBox1.SelectionStart = caretPosition + selectedWord.Length;
            textBox1.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получаем выбранное слово из comboBox1
            string selectedWord = comboBox2.SelectedItem.ToString();

            // Получаем текущую позицию курсора в textBox1
            int caretPosition = textBox2.SelectionStart;

            // Вставляем выбранное слово в textBox1 в позицию курсора
            textBox2.Text = textBox2.Text.Substring(0, caretPosition) + selectedWord + textBox2.Text.Substring(caretPosition);

            // Перемещаем курсор на позицию после вставленного слова
            textBox2.SelectionStart = caretPosition + selectedWord.Length;
            textBox2.Focus();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Выводим MessageBox с выбором раздела
            DialogResult result = MessageBox.Show("Выберите раздел для удаления слова:", "Выбор раздела", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                // Раздел 1
                if (comboBox1.SelectedItem != null)
                {
                    // Получаем выбранное слово из comboBox1
                    string selectedWord = comboBox1.SelectedItem.ToString();

                    // Ищем и удаляем слово из textBox1
                    string text1 = textBox1.Text;
                    int index = text1.IndexOf(selectedWord);
                    if (index >= 0)
                    {
                        textBox1.Text = text1.Remove(index, selectedWord.Length);
                        comboBox1.Items.Remove(selectedWord);
                        MessageBox.Show($"Слово '{selectedWord}' удалено из раздела 1.");
                    }
                    else
                    {
                        MessageBox.Show("Слово не найдено в разделе 1.");
                    }
                }
                else
                {
                    MessageBox.Show("Выберите слово в ComboBox1.");
                }
            }
            else if (result == DialogResult.No)
            {
                // Раздел 2
                if (comboBox2.SelectedItem != null)
                {
                    // Получаем выбранное слово из comboBox2
                    string selectedWord = comboBox2.SelectedItem.ToString();

                    // Ищем и удаляем слово из textBox2
                    string text2 = textBox2.Text;
                    int index = text2.IndexOf(selectedWord);
                    if (index >= 0)
                    {
                        textBox2.Text = text2.Remove(index, selectedWord.Length);
                        comboBox2.Items.Remove(selectedWord);
                        MessageBox.Show($"Слово '{selectedWord}' удалено из раздела 2.");
                    }
                    else
                    {
                        MessageBox.Show("Слово не найдено в разделе 2.");
                    }
                }
                else
                {
                    MessageBox.Show("Выберите слово в ComboBox2.");
                }
            }
            else if (result == DialogResult.Cancel)
            {
                // Пользователь отменил действие
                MessageBox.Show("Действие отменено.");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // Считываем данные из textBox1 и textBox2
            string data1 = textBox1.Text;
            string data2 = textBox2.Text;

            // Записываем данные в textBox3 через пробел
            textBox3.Text = $"{data1} {data2}";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox3.SelectionLength > 0)
            {
                DialogResult result = MessageBox.Show("Выберите действие для выделенных слов:", "Удалить", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Стереть все
                    textBox3.SelectedText = "";
                }
                else if (result == DialogResult.No)
                {
                    // отменить
                    MessageBox.Show("Выйти из опции?");
                }
                
            }
            else
            {
                MessageBox.Show("Ничего не выбрано для применения действия.");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string text = textBox3.Text;
            string[] words = text.Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (radioButton1.Checked)
            {
                // Выделить все слова
                textBox3.Select(0, text.Length);
            }
            else if (radioButton2.Checked)
            {
                // Выделить слова, содержащие цифры
                foreach (string word in words)
                {
                    if (word.Any(char.IsDigit))
                    {
                        int startIndex = text.IndexOf(word);
                        textBox3.Select(startIndex, word.Length);
                    }
                }
            }
            else if (radioButton3.Checked)
            {
                // Выделить слова, содержащие e-mail
                foreach (string word in words)
                {
                    if (word.Contains("@gmail.com"))
                    {
                        int startIndex = text.IndexOf(word);
                        textBox3.Select(startIndex, word.Length);
                    }
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // Очистка comboBox1
            comboBox1.Items.Clear();

            // Очистка comboBox2
            comboBox2.Items.Clear();

            // Очистка textBox1
            textBox1.Clear();

            // Очистка textBox2
            textBox2.Clear();

            // Очистка textBox3
            textBox3.Clear();

            MessageBox.Show("Все данные были успешно удалены.");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string text4 = textBox4.Text;
            string text5 = textBox5.Text;

            if (checkBox1.Checked)
            {
                // Замена слова из textBox4 на слово из textBox5 в textBox1
                textBox1.Text = textBox1.Text.Replace(text4, text5);
            }
            else if (checkBox2.Checked)
            {
                // Замена слова из textBox4 на слово из textBox5 в textBox2
                textBox2.Text = textBox2.Text.Replace(text4, text5);
            }
        }
    }
}

using System;
using System.Text;
using System.Windows;
using System.Text.RegularExpressions;

namespace _12345_Ivanov_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Иванов - Вариант 1";
        }

        private void TransformButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = InputTextBox.Text.Trim();
                
                if (string.IsNullOrEmpty(input))
                {
                    ResultTextBlock.Text = "Ошибка: Введите текст";
                    ResultTextBlock.Foreground = System.Windows.Media.Brushes.Red;
                    return;
                }

                if (!IsEnglishText(input))
                {
                    ResultTextBlock.Text = "Ошибка: Текст должен содержать только английские буквы и пробелы";
                    ResultTextBlock.Foreground = System.Windows.Media.Brushes.Red;
                    return;
                }

                string result = TransformString(input);
                ResultTextBlock.Text = result;
                ResultTextBlock.Foreground = System.Windows.Media.Brushes.Black;
            }
            catch (Exception ex)
            {
                ResultTextBlock.Text = $"Ошибка: {ex.Message}";
                ResultTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            }
        }

        private bool IsEnglishText(string text)
        {
            return Regex.IsMatch(text, @"^[a-zA-Z\s]+$");
        }

        private string TransformString(string input)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder currentWord = new StringBuilder();
            bool firstWord = true;

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (c != ' ')
                {
                    currentWord.Append(c);
                }

                if (c == ' ' || i == input.Length - 1)
                {
                    if (currentWord.Length > 0)
                    {
                        if (!firstWord)
                        {
                            result.Append("это_пробел");
                        }

                        string word = currentWord.ToString();
                        if (word.Length == 1)
                        {
                            result.Append(char.ToUpper(word[0]));
                        }
                        else if (word.Length > 1)
                        {
                            result.Append(char.ToUpper(word[0]));
                            result.Append(word, 1, word.Length - 2);
                            result.Append(char.ToUpper(word[word.Length - 1]));
                        }

                        currentWord.Clear();
                        firstWord = false;
                    }
                }
            }

            return result.ToString();
        }
    }
}
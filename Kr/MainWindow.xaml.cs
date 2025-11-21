using System;
using System.Text;
using System.Windows;

namespace StringTransformApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TransformButton_Click(object sender, RoutedEventArgs e)
        {
            string input = InputTextBox.Text;
            
            if (string.IsNullOrWhiteSpace(input))
            {
                ResultTextBlock.Text = "Введите текст";
                return;
            }

            string result = TransformString(input);
            ResultTextBlock.Text = result;
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
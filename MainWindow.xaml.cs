using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace examination_card1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateGrade(object sender, RoutedEventArgs e)
        {
            try
            {
                int score1 = ParseScore(txtScore1);
                int score2 = ParseScore(txtScore2);
                int score3 = ParseScore(txtScore3);
                int score4 = ParseScore(txtScore4);

                if (IsValidScore(score1, 10) && IsValidScore(score2, 50) &&
                    IsValidScore(score3, 30) && IsValidScore(score4, 10))
                {
                    int totalScore = score1 + score2 + score3 + score4;
                    string grade = GetGrade(totalScore);

                    lblResult.Content = $"Сумма баллов: {totalScore}\nОценка: {grade}";
                }
                else
                {
                    lblResult.Content = "Ошибка: Проверьте введённые баллы!";
                }
            }
            catch (FormatException)
            {
                lblResult.Content = "Ошибка: Введите числовые значения!";
            }
        }

        private int ParseScore(TextBox textBox)
        {
            return int.TryParse(textBox.Text, out int score) ? score : throw new FormatException();
        }

        public bool IsValidScore(int score, int max)
        {
            return score >= 0 && score <= max;
        }

        public string GetGrade(int totalScore)
        {
            if (totalScore >= 70) return "5 (отлично)";
            if (totalScore >= 40) return "4 (хорошо)";
            if (totalScore >= 20) return "3 (удовлетворительно)";
            return "2 (неудовлетворительно)";
        }
    }
}

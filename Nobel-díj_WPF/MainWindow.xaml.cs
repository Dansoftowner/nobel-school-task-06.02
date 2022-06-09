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
using System.IO;

namespace Nobel_díj_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private const string OutputFilePath = "új_díjazott.txt";
        private const int MinYear = 1989;


        private bool FieldsAreFull
        {
            get
            {
                List<TextBox> textBoxes = new List<TextBox>() {
                    NameField,
                    YearField,
                    LifePeriodField,
                    CountryCodeField
                };

                string[] illegalValues = new[] { "", null };

                return textBoxes.Where(it => illegalValues.Contains(it.Text)).Count() == 0;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!FieldsAreFull)
            {
                MessageBox.Show("Töltsön ki minden mezőt!");
                return;
            }

            if (int.Parse(YearField.Text) < MinYear)
            {
                MessageBox.Show("Hiba! Az évszám nem megfelelő!");
                return;
            }


            AppendToFile(ClearFields, FailureMessage);
        }

        private void ClearFields()
        {
            new List<TextBox>() {
                    NameField,
                    YearField,
                    LifePeriodField,
                    CountryCodeField
            }.ForEach(it => it.Clear());
        }

        private void FailureMessage()
        {
            MessageBox.Show("Hiba az állomány írásánál!");
        }

        private void AppendToFile(Action onSuccess, Action onFailure)
        {
            try
            {
                List<string> outputLines = new List<string>();
                if (!File.Exists(OutputFilePath))
                {
                    outputLines.Add(string.Join(";", "Év", "Név", "SzületésHalálozás", "Országkód"));
                }

                outputLines.Add(
                    string.Join(
                          ";",
                          YearField.Text,
                          NameField.Text,
                          LifePeriodField.Text,
                          CountryCodeField.Text
                    )
               );

                File.AppendAllLines(OutputFilePath, outputLines);
                onSuccess();
            } 
            catch(Exception)
            {
                onFailure();
            }
        }
    }
}

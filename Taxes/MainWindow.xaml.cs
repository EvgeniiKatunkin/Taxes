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

namespace Taxes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Flat flat1;
        Flat flat2;
        public MainWindow()
        {
            InitializeComponent();
            GetLastMonthValues();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                flat1 = new Flat(heat1.Text.Replace('.', ','), yardCleaning1.Text.Replace('.', ','),
                    gas1.Text.Replace('.', ','), trash1.Text.Replace('.', ','),
                    electricity1.Text.Replace('.', ','), intercom1.Text.Replace('.', ','),
                    hotWater1LastMonth.Text, hotWater1Currently.Text, coldWater1LastMonth.Text,
                    coldWater1Currently.Text);

                flat2 = new Flat(heat2.Text.Replace('.', ','), yardCleaning2.Text.Replace('.', ','),
                    gas2.Text.Replace('.', ','), trash2.Text.Replace('.', ','),
                    electricity2.Text.Replace('.', ','), intercom2.Text.Replace('.', ','), 
                    hotWater2LastMonth.Text, hotWater2Currently.Text, coldWater2LastMonth.Text, 
                    coldWater2Currently.Text);

                payForColdWater1.Text = flat1.ColdWaterResult().ToString();
                payForWaterDisposal1.Text = flat1.WaterDisposalResult().ToString();
                result1.Text = flat1.Result().ToString();

                payForColdWater2.Text = flat2.ColdWaterResult().ToString();
                payForWaterDisposal2.Text = flat2.WaterDisposalResult().ToString();
                result2.Text = flat2.Result().ToString();

                overallResult.Text = (flat1.Result() + flat2.Result()).ToString();
            }

            catch
            {
                MessageBox.Show("Введите корректные значения (цифровые) и заполните все пустые строки нулями.");
            }

            SetLastMonthValues();
        }

        void GetLastMonthValues()
        {
            try
            {
                StreamReader lastMonthValuesReader = new StreamReader("lastMonthValues.txt");
                hotWater1LastMonth.Text = lastMonthValuesReader.ReadLine();
                coldWater1LastMonth.Text = lastMonthValuesReader.ReadLine();
                hotWater2LastMonth.Text = lastMonthValuesReader.ReadLine();
                coldWater2LastMonth.Text = lastMonthValuesReader.ReadLine();
                lastMonthValuesReader.Close();
                hotWater1Currently.Text = hotWater1LastMonth.Text;
                coldWater1Currently.Text = coldWater1LastMonth.Text;
                hotWater2Currently.Text = hotWater2LastMonth.Text;
                coldWater2Currently.Text = coldWater2LastMonth.Text;
            }

            catch
            {
                SetLastMonthValues();
            }
        }

        void SetLastMonthValues()
        {
            StreamWriter lastMonthValuesWriter = new StreamWriter("lastMonthValues.txt");
            lastMonthValuesWriter.WriteLine(hotWater1Currently.Text);
            lastMonthValuesWriter.WriteLine(coldWater1Currently.Text);
            lastMonthValuesWriter.WriteLine(hotWater2Currently.Text);
            lastMonthValuesWriter.WriteLine(coldWater2Currently.Text);
            lastMonthValuesWriter.Close();
        }
    }
}

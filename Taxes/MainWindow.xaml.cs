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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                flat1 = new Flat(Convert.ToDouble(heat1.Text.Replace('.', ',')), Convert.ToDouble(yardCleaning1.Text.Replace('.', ',')),
                    Convert.ToDouble(gas1.Text.Replace('.', ',')), Convert.ToDouble(trash1.Text.Replace('.', ',')),
                    Convert.ToDouble(electricity1.Text.Replace('.', ',')), Convert.ToDouble(intercom1.Text.Replace('.', ',')),
                    Convert.ToInt16(hotWater1LastMonth.Text), Convert.ToInt16(hotWater1Currently.Text), Convert.ToInt16(coldWater1LastMonth.Text),
                    Convert.ToInt16(coldWater1Currently.Text));

                flat2 = new Flat(Convert.ToDouble(heat2.Text.Replace('.', ',')), Convert.ToDouble(yardCleaning2.Text.Replace('.', ',')),
                    Convert.ToDouble(gas2.Text.Replace('.', ',')), Convert.ToDouble(trash2.Text.Replace('.', ',')),
                    Convert.ToDouble(electricity2.Text.Replace('.', ',')), Convert.ToDouble(intercom2.Text.Replace('.', ',')), 
                    Convert.ToInt16(hotWater2LastMonth.Text), Convert.ToInt16(hotWater2Currently.Text), Convert.ToInt16(coldWater2LastMonth.Text), 
                    Convert.ToInt16(coldWater2Currently.Text));

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
        }
    }
}

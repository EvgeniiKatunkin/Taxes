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
using System.Runtime.Serialization.Formatters.Binary;

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
            SetLastMonthValues();
        }

        void initializationOfTheFlats()
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
        }

        void results()
        {
            try
            {
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

        void GetLastMonthValues()
        {
            try
            {
                using(Stream inputForFlat1 = File.OpenRead("flat1.dat"))
                {
                    BinaryFormatter formatter1 = new BinaryFormatter();
                    flat1 = (Flat)formatter1.Deserialize(inputForFlat1);
                }

                using (Stream inputForFlat2 = File.OpenRead("flat2.dat"))
                {
                    BinaryFormatter formatter2 = new BinaryFormatter();
                    flat2 = (Flat)formatter2.Deserialize(inputForFlat2);
                }

                updateForm();
            }

            catch
            {
                SetLastMonthValues();
            }
        }

        void SetLastMonthValues()
        {
            initializationOfTheFlats();
            results();
            using (Stream outputForFlat1 = File.Create("flat1.dat"))
            {
                BinaryFormatter formatter1 = new BinaryFormatter();
                formatter1.Serialize(outputForFlat1, flat1);
            }

            using (Stream outputForFlat2 = File.Create("flat2.dat"))
            {
                BinaryFormatter formatter2 = new BinaryFormatter();
                formatter2.Serialize(outputForFlat2, flat2);
            }
        }

        void updateForm()
        {
            heat1.Text = flat1.heat;
            yardCleaning1.Text = flat1.yardCleaning;
            gas1.Text = flat1.gas;
            trash1.Text = flat1.trash;
            electricity1.Text = flat1.electricity;
            intercom1.Text = flat1.intercom;
            hotWater1LastMonth.Text = flat1.hotWaterLastMonth;
            hotWater1Currently.Text = flat1.hotWaterCurrently;
            coldWater1LastMonth.Text = flat1.coldWaterLastMonth;
            coldWater1Currently.Text = flat1.coldWaterCurrently;

            heat2.Text = flat2.heat;
            yardCleaning2.Text = flat2.yardCleaning;
            gas2.Text = flat2.gas;
            trash2.Text = flat2.trash;
            electricity2.Text = flat2.electricity;
            intercom2.Text = flat2.intercom;
            hotWater2LastMonth.Text = flat2.hotWaterLastMonth;
            hotWater2Currently.Text = flat2.hotWaterCurrently;
            coldWater2LastMonth.Text = flat2.coldWaterLastMonth;
            coldWater2Currently.Text = flat2.coldWaterCurrently;

            results();
        }

        private void dropButton_Click(object sender, RoutedEventArgs e)
        {
            updateForm();
        }
    }
}

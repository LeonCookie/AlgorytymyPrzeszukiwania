using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace AlgorytymyPrzeszukiwania
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //var
        List<String> Lista = new List<String>(); // our list for string
        int Irepeat = 1;  //repeat count
        string SSsearch;// searching value

    

        private void Btn_load_Click(object sender, RoutedEventArgs e)
        {
            Lista.Clear();
            stringholder.ItemsSource = "";//
            TabControl_Main.IsEnabled = true;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                using (var streamReader = File.OpenText(openFileDialog.FileName))// czytanie z pliku
                {
                    var s = string.Empty;
                    while ((s = streamReader.ReadLine()) != null)
                        Lista.Add(s);  //sam nwm
                }
                stringholder.ItemsSource = Lista;

            }
        }

        private void btn_repeat_Click(object sender, RoutedEventArgs e)
        {
            Irepeat = 1;
            void NumberInput_previewtextinput(object sender, TextCompositionEventArgs e)
            {
                e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);// tylko liczby w NumberInput-  ilosc powtorzen
            }
            Irepeat = int.Parse(repeatInput.Text);
            Debug.WriteLine(Irepeat);
            repeat_value.Text = "" + Irepeat;
        }

        private void btn_start_bf_Click(object sender, RoutedEventArgs e)
        {


            if (String.IsNullOrEmpty(SearchInput.Text)){
                MessageBox.Show("Uzupełnij pole z szukaną!");
            }
            else
            {
                Stopwatch stopwatch = new Stopwatch();//timer

                stopwatch.Start();
                //sorting(brutalforce)
                SSsearch = SearchInput.Text;
                

                for (int l = 0; l < Irepeat; l++)
                {

                }






                stopwatch.Stop();


                TEXT_time_BF.Text = "" + stopwatch.ElapsedMilliseconds;
            }
            

            
        }
    }
}

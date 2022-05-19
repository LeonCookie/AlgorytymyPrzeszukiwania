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


        int Hmany = 0;
        int Irepeat = 1;  //repeat count
        string SSsearch;// searching value
        string dane;// main string




        private void Btn_load_Click(object sender, RoutedEventArgs e)
        {
            dane = string.Empty;
            Debug.WriteLine("saassadddddddddddddsad plus " + dane);
            stringholder.ItemsSource = "";//
            TabControl_Main.IsEnabled = true;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                using (var streamReader = File.OpenText(openFileDialog.FileName))// czytanie z pliku
                {
                    dane = System.IO.File.ReadAllText(openFileDialog.FileName);
                }
                stringholder.ItemsSource = dane;
                


            }
            Debug.WriteLine(dane);
            MessageBox.Show("Długość twojego napisu to:" + dane.Length+"To twoj napis:" + dane);
          
            
        }

      
        private void repeatInput_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);// tylko liczby w NumberInput-  ilosc powtorzen
        }
        private void repeatInput_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);// tylko liczby w NumberInput-  ilosc powtorzen
        }
        private void btn_repeat_Click(object sender, RoutedEventArgs e)
        {
            Irepeat = 1;
           
            
            Irepeat = int.Parse(repeatInput.Text);
            repeatInput.Text = "";
            repeatInput.Text = "" + Irepeat;
            MessageBox.Show("twoja liczba powtorzen: " + Irepeat);
        }

        private void btn_start_bf_Click(object sender, RoutedEventArgs e)
        {


            if (String.IsNullOrEmpty(SearchInput.Text))
            {
                MessageBox.Show("Uzupełnij pole z szukaną!");
            }
            else
            {
                Stopwatch stopwatch = new Stopwatch();//timer
                SSsearch = SearchInput.Text;
            

                stopwatch.Start();
                //sorting(brutalforce)




                int SearchLong = SSsearch.Length;
                int DaneLong = dane.Length;

                char[]  SearchChar= SSsearch.ToCharArray();
                char[] daneChar= dane.ToCharArray();

                int textIndex = 0;
                


               
               
                for (int k = 0; k < Irepeat; k++)
                {
                    Debug.WriteLine("start");
                    Hmany = 0;

                    for (textIndex = 0; textIndex < DaneLong; textIndex++)
                    {
                       
                        int textIndexLocal = textIndex;
                        Boolean match = true;
                        int matchedIndex = textIndex;
                        for (int patternIndex = 0; patternIndex < SearchLong; patternIndex++)
                        {
                            if (daneChar[textIndexLocal] != SearchChar[patternIndex])
                            {
                                match = false;
                                break;
                                Debug.WriteLine("brake");
                            }
                            textIndexLocal = textIndexLocal + 1;
                        }
                        if (match)
                        {
                            Hmany++;
                        }
                    }
                    Debug.WriteLine("koniec");
                }







                stopwatch.Stop();
                
                MessageBox.Show("znalezniono " + Hmany);


                TEXT_time_BF.Text = "" + stopwatch.ElapsedMilliseconds;
            }


      
        }

        private void btn_start_kmp_Click(object sender, RoutedEventArgs e)
        {


            if (String.IsNullOrEmpty(SearchInput_KMP.Text))
            {
                MessageBox.Show("Uzupełnij pole z szukaną!");
            }
            else
            {
                SSsearch = SearchInput.Text;
             

             

               
                


                Stopwatch stopwatch = new Stopwatch();//timer

                stopwatch.Start();


                for (int k = 0; k < Irepeat; k++)
                {
                    
                }








                stopwatch.Stop();

                
                TEXT_time_KMF.Text = "" + stopwatch.ElapsedMilliseconds;

            }
        }


        private void btn_start_BM_Click(object sender, RoutedEventArgs e)
        {
            //https://www.programmingalgorithms.com/algorithm/boyer–moore-string-search-algorithm/

            if (String.IsNullOrEmpty(SearchInput_BM.Text))
            {
                MessageBox.Show("Uzupełnij pole z szukaną!");
            }
            else
            {
                Stopwatch stopwatch = new Stopwatch();//timer

                stopwatch.Start();


                for (int k = 0; k < Irepeat; k++)
                {

                }








                stopwatch.Stop();


                TEXT_time_BM.Text = "" + stopwatch.ElapsedMilliseconds;
            }
            

        }


        private void btn_start_RK_Click(object sender, RoutedEventArgs e)
        {

            

                int sum = 0;
            if (String.IsNullOrEmpty(SearchInput_RK.Text))
            {
                MessageBox.Show("Uzupełnij pole z szukaną!");
            }
            else
            {


               
                

                Stopwatch stopwatch = new Stopwatch();//timer

               

                SSsearch = SearchInput_RK.Text;
                stopwatch.Start();

                for (int k = 0; k < Irepeat; k++)
                {

                }

                stopwatch.Stop();

                TEXT_time_RK.Text = "" + stopwatch.ElapsedMilliseconds;
                Debug.WriteLine(sum);
                MessageBox.Show("znalenizono:" + sum.ToString() + " razy");

            }




        }

        
    }
}

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
        string[] lines;




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
                     lines= System.IO.File.ReadAllLines(openFileDialog.FileName);

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




            int bmResult = 0 ;
            

            if (String.IsNullOrEmpty(SearchInput_BM.Text))
            {
                MessageBox.Show("Uzupełnij pole z szukaną!");
            }
            else
            {
                 static int[] BuildBadCharTable2(char[] needle)
                {
                    int[] badShift = new int[256];
                    for (int i = 0; i < 256; i++)
                    {
                        badShift[i] = needle.Length;
                    }
                    int last = needle.Length - 1;
                    for (int i = 0; i < last; i++)
                    {
                        badShift[(int)needle[i]] = last - i;
                    }
                    return badShift;
                }



                 static int BoyerMoore(String pattern, String text)
                {
                    char[] needle = pattern.ToCharArray();
                    char[] haystack = text.ToCharArray();

                    if (needle.Length > haystack.Length)
                    {
                        return -1;
                    }
                    int[] badShift = BuildBadCharTable2(needle);
                    int offset = 0;
                    int scan = 0;
                    int last = needle.Length - 1;
                    int maxoffset = haystack.Length - needle.Length;
                    while (offset <= maxoffset)
                    {
                        for (scan = last; (needle[scan] == haystack[scan + offset]); scan--)
                        {
                            if (scan == 0)
                            { //Match found
                                return offset;
                            }
                        }
                        offset += badShift[(int)haystack[offset + last]];
                    }
                    return -1;
                }




               


                Stopwatch stopwatch = new Stopwatch();//timer



                    for (int k = 0; k < Irepeat; k++)
                {
               

                    stopwatch.Start();
                    char[] SearchChar = SSsearch.ToCharArray();
                    char[] daneChar = dane.ToCharArray();
                    bmResult = BoyerMoore(SSsearch, dane);
                   



                }
                    stopwatch.Stop();

                TEXT_time_BM.Text = "" + stopwatch.ElapsedMilliseconds;
                MessageBox.Show("znalezniono " + bmResult);


            }
           

        }


        private void btn_start_RK_Click(object sender, RoutedEventArgs e)
        {



            Hmany = 0;
            if (String.IsNullOrEmpty(SearchInput_RK.Text))
            {
                MessageBox.Show("Uzupełnij pole z szukaną!");
            }
            else
            {




                Hmany = 0;
                Stopwatch stopwatch = new Stopwatch();//timer
                stopwatch.Start();


                for (int k = 0; k < Irepeat; k++)
                {

                }






                    stopwatch.Stop();

                TEXT_time_RK.Text = "" + stopwatch.ElapsedMilliseconds;
                MessageBox.Show("znalenizono:" + Hmany + " razy");

            }




        }

        
    }
}

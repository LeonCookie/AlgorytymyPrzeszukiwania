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
        int Hmany = 0;



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
                string[] STable = Lista.ToArray();//MAKE TABLE TO LISt
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

                stopwatch.Start();
                //sorting(brutalforce)
                SSsearch = SearchInput.Text;
                stringholder.ItemsSource = Lista;










                stopwatch.Stop();


                TEXT_time_BF.Text = "" + stopwatch.ElapsedMilliseconds;
            }


            /*
             * MZTQIUMCCF
AEUCUQQZXM
LXZMDRFRTH
SATGEUZMRS
PTGYVVLEZY
QJKIWZQILM
PDWMMXVZLU
JXJXXERDSL
QVSCCYWESR
MIUJKMQORA
KQJSHHCQOJ
WPDVUORLXP
NQSRIMAXHM
ZSWPBLWIRZ
XYAPDRYABP
LVEJHUQBAS
ZXCBHTLTPT
WGJTQZRAIU
QOPUTPLVPU
HYDZDYOWRR
ZNPLYXWBFP
UKVIVHLFAO
OAIZBFOPZQ
MNAYWCOMUZ
THYQVMAIDE
FUDLLSTBVD
IKOV */
        }

        private void btn_start_kmp_Click(object sender, RoutedEventArgs e)
        {


            if (String.IsNullOrEmpty(SearchInput_KMP.Text))
            {
                MessageBox.Show("Uzupełnij pole z szukaną!");
            }
            else
            {
                Stopwatch stopwatch = new Stopwatch();//timer

                stopwatch.Start();
                //sorting(brute force)
               

                /*
                pp = b = 0;
                for (i = 0; i < N; i++)
                {
                    while ((b > -1) && (p[b] != s[i])) b = KMPNext[b];
                    if (++b == M)
                    {
                        while (pp < i - b + 1)
                        {
                            cout << " "; pp++;
                        }
                        cout << "^"; pp++;
                        b = KMPNext[b];
                    }
                }
                */








                stopwatch.Stop();


                TEXT_time_KMF.Text = "" + stopwatch.ElapsedMilliseconds;

            }
        }
    }
}

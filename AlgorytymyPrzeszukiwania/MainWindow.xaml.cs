﻿using Microsoft.Win32;
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
        
        string[] sTable;




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
                        Lista.Add(s);  
                }
                stringholder.ItemsSource = Lista;
                Lista.ForEach(x => Debug.WriteLine(x));// write Lista in Debug window for check
                sTable = Lista.ToArray();// change list to array
                Debug.WriteLine("===========================");
                for (int i = 0; i < sTable.Length; i++)
                {
                    Debug.WriteLine(sTable[i]);
                }// write sTable in Debug window


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
                Debug.WriteLine("LIsta:");
              




                stopwatch.Stop();


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
                stringholder.ItemsSource = Lista;

                string lancuch = String.Join("", Lista.ToArray());
                Debug.WriteLine(lancuch);

               
                int Nsearch = SSsearch.Length; // lenght of searched
                int Mlist = sTable.Length; //lenght of table

                int Mlista1 = Mlist + 1;


                Stopwatch stopwatch = new Stopwatch();//timer

                stopwatch.Start();

                Debug.WriteLine(Nsearch);
                Debug.WriteLine(Mlist);

      
               










                stopwatch.Stop();

                
                TEXT_time_KMF.Text = "" + stopwatch.ElapsedMilliseconds;

            }
        }


        private void btn_start_BM_Click(object sender, RoutedEventArgs e)
        {
            //https://www.programmingalgorithms.com/algorithm/boyer–moore-string-search-algorithm/
        }

        private void btn_start_RK_Click(object sender, RoutedEventArgs e)
        {
            int sum = 0;

            int[] SearchString(string A, string B)
            {
                sum = 0;
                List<int> retVal = new List<int>();
                ulong siga = 0;
                ulong sigb = 0;
                ulong Q = 100007;
                ulong D = 256;

                for (int i = 0; i < B.Length; ++i)
                {
                    siga = (siga * D + (ulong)A[i]) % Q;
                    sigb = (sigb * D + (ulong)B[i]) % Q;
                }

                if (siga == sigb)
                    retVal.Add(0);

                ulong pow = 1;

                for (int k = 1; k <= B.Length - 1; ++k)
                    pow = (pow * D) % Q;

                for (int j = 1; j <= A.Length - B.Length; ++j)
                {
                    siga = (siga + Q - pow * (ulong)A[j - 1] % Q) % Q;
                    siga = (siga * D + (ulong)A[j + B.Length - 1]) % Q;

                    if (siga == sigb)
                        if (A.Substring(j, B.Length) == B)
                            retVal.Add(j);
                    sum += 1;

                }

                Debug.WriteLine(retVal);
                return retVal.ToArray();
            }
            
            Stopwatch stopwatch = new Stopwatch();//timer

            string lancuch = String.Join("", Lista.ToArray());

            SSsearch = SearchInput_RK.Text;
            stopwatch.Start();
          

            for (int i=1; Irepeat > 0; i++)
            {
                
                int[] value = SearchString(lancuch, SSsearch);
                
            }
            stopwatch.Stop();

            TEXT_time_RK.Text = "" + stopwatch.ElapsedMilliseconds;
            Debug.WriteLine(sum);
            MessageBox.Show("znalenizono:" + sum.ToString() + " razy");
















        }
        

        
    }
}

using HumanClass;
using System;
using System.Collections.Generic;
using System.IO;
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
using SchoolchildClass;
using WorkerClass;
using UndergradClass;
using StudentClass;
using System.Collections.Immutable;
using System.Windows.Media.TextFormatting;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Human[] humans = new Human[15];
        public MainWindow()
        {
            
            InitializeComponent();
            using (StreamReader reader = new StreamReader("humans.txt"))
            {
                int i = 0;
                string? line;
                int[] numbers = new int[15];
                while ((line = reader.ReadLine()) != null)
                {
                    string[] person = line.Split(' ');
                    int year = DateTime.Today.Year;
                        switch (year - int.Parse(person[1]))
                    {
                        case < 18:
                            numbers = CreateNumArr(5, person.Length, person);
                            humans[i] = new Schoolchild(person[0], Convert.ToInt32(person[1]), person[2], person[3], Convert.ToInt32(person[4]), numbers);
                            break;
                        case > 22:
                            numbers = CreateNumArr(4, person.Length, person);
                            humans[i] = new Worker(person[0], Convert.ToInt32(person[1]), person[2], person[3], numbers);
                            break;
                        default:
                            numbers = CreateNumArr(5, person.Length, person);
                            humans[i] = new Undergrad(person[0], Convert.ToInt32(person[1]), person[2], person[3], person[4], numbers);
                            break;

                    }
                    i++;
                }
            }
        }

        static int[] CreateNumArr(int ind, int len, string[] strArr)
        {
            int[] arr = new int[12];
            int i = 0;
            for (int j = ind; j < len; j++)
            {
                if (int.TryParse(strArr[j], out arr[i]))
                {
                    i++;
                }
                else
                {
                    break;
                }
            }
            return arr;
        }

        private void allInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            infoLabel.Content = "";
            while (humans[i] != null)
            {
                infoLabel.Content += humans[i].GetInfo() + '\n';
                i++;
            }
        }

        private void workerInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            infoLabel.Content = "";
            Worker[] workers = new Worker[15];
            int j = 0;
            for(int i = 0; i < humans.Length; i++)
            {
                if (humans[i] == null)
                {
                    break;
                }
                else if (DateTime.Today.Year - humans[i].birthYear > 21)
                {
                    workers[j] = (Worker)humans[i];
                    j++;
                }
            }
            Array.Sort(workers);
            int k = 0;
            while (k<workers.Length)
            {
                if(workers[k] == null)
                {
                    k++;
                    continue;
                }
                infoLabel.Content += workers[k].GetInfo() + '\n';
                k++;
            }
        }

        private void badStudentsBtn_Click(object sender, RoutedEventArgs e)
        {
            infoLabel.Content = "";
            for (int i = 0; i < humans.Length; i++)
            {
                if (humans[i] == null)
                {
                    break;
                }
                int age = DateTime.Today.Year - humans[i].birthYear;
                if (age <= 21 && age >= 18)
                {
                    if (humans[i].Intelligence() <= 2)
                    {
                        Undergrad tmp = (Undergrad)humans[i];
                        infoLabel.Content += $"{tmp.surname} {tmp.groupName} {tmp.status}\n";
                    }
                }
            }
            if ((string)infoLabel.Content == "")
            {
                infoLabel.Content = "No student is a loser";
            }
        }

        private void badSchoolchildBtn_Click(object sender, RoutedEventArgs e)
        {
            infoLabel.Content = "";
            for (int i = 0; i < humans.Length; i++)
            {
                if (humans[i] == null)
                {
                    break;
                }
                int age = DateTime.Today.Year - humans[i].birthYear;
                if (age < 18)
                {
                    Schoolchild tmp = (Schoolchild)humans[i];
                    if (tmp.isHaveTwos())
                    {
                        infoLabel.Content += tmp.GetInfo() + '\n';
                    }
                }
            }
            if ((string)infoLabel.Content == "")
            {
                infoLabel.Content = "No student has more than 1 deuce";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using ZeleznicaSrbije.API.Services;

namespace ZeleznicaSrbije
{
    /// <summary>
    /// Interaction logic for TrainsPage.xaml
    /// </summary>
    public partial class TrainsPage : Page, INotifyPropertyChanged
    {
        TrainsService trainsService;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }


        public TrainsPage()
        {
            trainsService = new TrainsService();
            InitializeComponent();
            Trains.ItemsSource = trainsService.getAllTrains();
        }

        

        public void DeleteTrainBtn_Click(object sender, RoutedEventArgs e)
        {
            var selected = Trains.SelectedItem;
            ConfirmTrainDeletePopUp deletePopUp = new ConfirmTrainDeletePopUp(Trains.SelectedItem, "train");

            deletePopUp.Show();
            
        }
    }
}

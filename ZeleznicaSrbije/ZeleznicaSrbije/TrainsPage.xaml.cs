using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ZeleznicaSrbije.API.Models;
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
        ObservableCollection<Train> TrainsCollection { get; set; }

        private ICollectionView _View;
        public ICollectionView View
        {
            get
            {
                return _View;
            }
            set
            {
                _View = value;
                OnPropertyChanged("View");
            }
        }


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
            
            TrainsCollection = new ObservableCollection<Train> (trainsService.getAllTrains());
            TrainsData.ItemsSource = TrainsCollection;
        } 
        


        public void DeleteTrainBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmTrainDeletePopUp deletePopUp = new ConfirmTrainDeletePopUp("Da li sigurno da zelite da obrisete voz " + ((Train)TrainsData.SelectedItem).TrainNumber + " ?");
            deletePopUp.yesClicked += PopUpClicked;
            deletePopUp.Show();
            //TrainsCollection = new ObservableCollection<Train> (trainsService.getAllTrains());
            //View = CollectionViewSource.GetDefaultView(TrainsCollection);


    
        }

        public void PopUpClicked(bool yes)
        {
            if (yes)
            {
                trainsService.deleteTrain(((Train)TrainsData.SelectedItem).TrainNumber);
                TrainsCollection.Remove((Train)TrainsData.SelectedItem);
            }
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.API.Services;

namespace ZeleznicaSrbije.ManagerPages
{
    /// <summary>
    /// Interaction logic for AddNewTrainLine.xaml
    /// </summary>
    public partial class AddNewTrainLine : Window
    {
        Point startPoint = new Point();

        PlaceService _placeService;
        Place startingPlacePopped;
        Place endingPlacePopped;

        List<Place> _startingPlaces = new List<Place>();
        List<Place> _endingPlaces = new List<Place>();

        public Action<TrainLine> addNewTrainLineClicked;

        public TrainLine newTrainLine = new TrainLine();

        public ObservableCollection<Place> PlacesCollection
        {
            get;
            set;
        }

        public ObservableCollection<Place> Studenti
        {
            get;
            set;
        }

        public ObservableCollection<Place> Studenti2
        {
            get;
            set;
        }

        public AddNewTrainLine()
        {
            _placeService = new PlaceService();
            _startingPlaces = _placeService.getOnlyNamedPlaces();
            _endingPlaces = _placeService.getOnlyNamedPlaces();
            InitializeComponent();

            PlacesCollection = new ObservableCollection<Place>();
            createPlacesCollection();
            StartingPlaces.ItemsSource = _startingPlaces;
            EndingPlaces.ItemsSource = _endingPlaces;

            
            this.DataContext = this;
            List<Place> l = new List<Place>();
            //l.Add(new Student { Ime = "Petar", Prezime = "Petrovic", Indeks = "SW 1\\2061", Email = "ppetrovic@gmail.com", Upisan = true });
            //l.Add(new Student { Ime = "Milica", Prezime = "Milicevic", Indeks = "SW 2\\2061", Email = "mmilicevic@gmail.com", Upisan = false });
            //l.Add(new Student { Ime = "Zoran", Prezime = "Zoranovic", Indeks = "SW 3\\2061", Email = "zzoranovic@gmail.com", Upisan = true });
            //l.Add(new Student { Ime = "Suzana", Prezime = "Suzanic", Indeks = "SW 4\\2061", Email = "ssuzanic@gmail.com", Upisan = false });
            //l.Add(new Student { Ime = "Goran", Prezime = "Goranski", Indeks = "SW 5\\2061", Email = "awesomeadressxxXXxx1996@gmail.com", Upisan = true });
            l = _placeService.getOnlyNamedPlaces();
            Studenti = new ObservableCollection<Place>(_startingPlaces);
            Studenti2 = new ObservableCollection<Place>();
        }

        private void StartPlace_Picked(object sender, SelectionChangedEventArgs e)
        {
            if (startingPlacePopped != null) { 
                Studenti.Add(startingPlacePopped);
                _endingPlaces.Add(startingPlacePopped);
                startingPlacePopped = (Place)StartingPlaces.SelectedItem; }

            foreach (Place place in _endingPlaces)
            {
                if (place.PlaceName == ((Place)StartingPlaces.SelectedItem).PlaceName)
                {
                    _endingPlaces.Remove(place);
                    break;
                }
            }
            startingPlacePopped = (Place)StartingPlaces.SelectedItem;
            EndingPlaces.ItemsSource = _endingPlaces;
            EndingPlaces.IsEnabled = true;

            Studenti.Remove(Studenti.Where(i => i.PlaceName == ((Place)StartingPlaces.SelectedItem).PlaceName).Single());
            //TrainlinesData.SelectedItem = TrainLineCollection;

            StartingPlaces.ItemsSource = _startingPlaces;
            EndingPlaces.ItemsSource = _endingPlaces;
        }

        private void EndPlace_Picked(object sender, SelectionChangedEventArgs e)
        {
            if (endingPlacePopped != null)
            {
                Studenti.Add(endingPlacePopped);
                _startingPlaces.Remove((Place)EndingPlaces.SelectedItem);
                endingPlacePopped = (Place)EndingPlaces.SelectedItem;
            }
            List<Place> possibleMiddleStations = _placeService.getPossibleMiddleStations((Place)StartingPlaces.SelectedItem, (Place)EndingPlaces.SelectedItem);
            Studenti = new ObservableCollection<Place>(possibleMiddleStations);
            

            //foreach (Place place in _endingPlaces)
            //{
            //    if (place.PlaceName == ((Place)StartingPlaces.SelectedItem).PlaceName)
            //    {
            //        _endingPlaces.Remove(place);
            //        break;
            //    }
            //}
            //EndingPlaces.ItemsSource = _endingPlaces;
            //EndingPlaces.IsEnabled = true;
            _startingPlaces.Remove((Place)EndingPlaces.SelectedItem);
            endingPlacePopped = (Place)EndingPlaces.SelectedItem;
            //Studenti.Remove(Studenti.Where(i => i.PlaceName == ((Place)EndingPlaces.SelectedItem).PlaceName).Single());
            StartingPlaces.ItemsSource = _startingPlaces;
            EndingPlaces.ItemsSource = _endingPlaces;
            //

        }

        private void createPlacesCollection()
        {
            foreach(Place place in _startingPlaces)
            {
                PlacesCollection.Add(place);
            }
        }

        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                // Find the data behind the ListViewItem
                Place student = (Place)listView.ItemContainerGenerator.
                    ItemFromContainer(listViewItem);

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myFormat", student);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Place student = e.Data.GetData("myFormat") as Place;
                Studenti.Remove(student);
                Studenti2.Add(student);
            }
        }

        private List<string> getMiddlePlaces()
        {
            List<string> result = new List<string>();
            foreach(var s2 in Studenti2)
            {
                result.Add(s2.PlaceName);
            }
            return result;
        }

        private void addNewLineButton_Click(object sender, RoutedEventArgs e)
        {
            newTrainLine = new TrainLine { MiddlePlaces = getMiddlePlaces(),
                PlaceStart = ((Place)StartingPlaces.SelectedItem).PlaceName,
                PlaceEnd = ((Place)EndingPlaces.SelectedItem).PlaceName,
                
        };
            addNewTrainLineClicked?.Invoke(newTrainLine);
            this.Close();
        }
    }
}

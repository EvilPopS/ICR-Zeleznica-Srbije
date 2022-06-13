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
using System.Windows.Shapes;
using ZeleznicaSrbije.API.DTOs;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.API.Services;

namespace ZeleznicaSrbije.ManagerPages
{
    /// <summary>
    /// Interaction logic for AddNewRide.xaml
    /// </summary>
    public partial class AddNewRide : Window
    {
        public Action<Timetable> addNewRideClicked;
        TrainLineService _trainlineService;
        TrainsService _trainsService;
        StationsService _stationsService;

        Timetable newRide;

        List<TrainLine> trainLines;
        List<Train> trains;

        bool hoursPicked;


        public AddNewRide()
        {
            _trainlineService = new TrainLineService();
            _trainsService = new TrainsService();
            _stationsService = new StationsService();
            trainLines = _trainlineService.getTrainLines();
            trains = _trainsService.GetAllTrains();
            InitializeComponent();
            StartHours.ItemsSource = createHoursAndMinutesList(24);
            StartMinutes.ItemsSource = createHoursAndMinutesList(60);
            Relations.ItemsSource = getPossibleRelations();
            TrainNumber.ItemsSource = _trainsService.GetAllTrains();

            newRide = new Timetable();
        }

        private List<string> createHoursAndMinutesList(int N)
        {
            List<string> hours = new List<string>();
            for (int i = 0; i < N; i++)
            {
                if (i <= 9)
                {
                    hours.Add("0" + i.ToString());
                }
                else { hours.Add(i.ToString()); }
            }

            return hours;
        }

        //private List<string> getTrainNumbers()
        //{
        //    List<string> trainNumbers = new List<string>();
        //    foreach(var t in trains)
        //    {
        //        trainNumbers.Add(t.TrainNumber);
        //    }

        //    return trainNumbers;
        //}

        private List<RelationDTO> getPossibleRelations()
        {
            List<RelationDTO> relations = new List<RelationDTO>();
            foreach(var tl in trainLines)
            {
                RelationDTO newRel = new RelationDTO
                {
                    Relation = tl.PlaceStart + " - " + tl.PlaceEnd,
                    TrainLineId = tl.Id
                };
                if (!relationAlreadyAdded(relations, newRel))
                {
                    relations.Add(newRel);
                }
                
            }
            return relations;
        }

        private bool relationAlreadyAdded(List<RelationDTO> relations, RelationDTO newRel)
        {
            foreach(var rel in relations)
            {
                if (rel.Relation == newRel.Relation)
                {
                    return true;
                }
            }
            return false;
        }

        private void Relation_Picked(object sender, SelectionChangedEventArgs e)
        {
            // popuni medjustanice
            RelationDTO rel = (RelationDTO)Relations.SelectedItem;
            List<string> midleStationsList = new List<string>() ;
            foreach (var tl in trainLines)
            {
                if (tl.PlaceStart == rel.Relation.Split('-')[0].Trim() && tl.PlaceEnd == rel.Relation.Split('-')[1].Trim())
                {
                    if (tl.MidlePlaces.Count == 0)
                    {
                        midleStationsList.Add("Bez medjustanica");
                    }
                    else
                    {
                        midleStationsList.Add(String.Join(",", tl.MidlePlaces));
                    }

                }
            }
            Midlestations.ItemsSource = midleStationsList;
            Midlestations.IsEnabled = true;

        }

        private void Midlestations_Picked(object sender, SelectionChangedEventArgs e)
        {
            List<string> selectedMidlestations = Midlestations.SelectedItem.ToString().Split(',').ToList();
            newRide.TrainServiceId = _trainlineService.getTrainLineByMidleStations(selectedMidlestations).Id;
            StartHours.IsEnabled = true;

            ;


        }

        private void Hours_Picked(object sender, SelectionChangedEventArgs e)
        {
            this.hoursPicked = true;
            StartMinutes.IsEnabled = true;
        }
        private void Minutes_Picked(object sender, SelectionChangedEventArgs e)
        {
            var selectedMinutes = StartMinutes.SelectedItem;
            if (hoursPicked)
            {
                newRide.Start = TimeSpan.Parse(StartHours.SelectedItem + ":" + selectedMinutes);
            }
            RelationDTO rdto = (RelationDTO)Relations.SelectedItem;
            string startPoint = rdto.Relation.Split('-')[0].Trim();
            string endPoint = rdto.Relation.Split('-')[1].Trim();
            List<string> ms = Midlestations.SelectedItem.ToString().Split(',').ToList();
            TimeSpan endTime = _stationsService.calculateEndTime(newRide.Start,
                ms,
                startPoint, endPoint);
            newRide.End = endTime;

            EndTime.Text = endTime.ToString(@"hh\:mm");
            TrainNumber.IsEnabled = true;


        }

        private void TrainNumber_Picked(object sender, SelectionChangedEventArgs e)
        {
            newRide.TrainId = ((Train)TrainNumber.SelectedItem).Id;
            
        }







        private void addNewRide_Click(object sender, RoutedEventArgs e)
        {
            //Train newTrain = new Train
            //{
            //    TrainNumber = newTrainNumber.Text,
            //    Capacity = Int32.Parse(newTrainNoCols.Text) * Int32.Parse(newTrainNoRows.Text),
            //    IsDeleted = false,
            //    NoCols = Int32.Parse(newTrainNoCols.Text),
            //    NoRows = Int32.Parse(newTrainNoRows.Text),
            //};
            addNewRideClicked?.Invoke(newRide);
            this.Close();
        }
    }
}

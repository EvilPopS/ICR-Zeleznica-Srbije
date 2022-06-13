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
    /// Interaction logic for EditRideWindow.xaml
    /// </summary>
    public partial class EditRideWindow : Window
    {
        public event Action<Timetable> saveButtonClicked;
        ManagerTimetableDTO selTimetable;

        TrainLineService _trainLineService;
        StationsService _stationsService;
        TimetableService _timetableService;
        TrainsService _trainsService;

        List<TrainLine> trainLines;
        List<RelationDTO> relationsDTOs;

        bool middlestationsAccessedFromRelation;

        public EditRideWindow(ManagerTimetableDTO selectedTimetable, List<string> hoursToPick, List<string> minutesToPick, List<RelationDTO> relationsToPick, List<Train> trainsToPick)
        {
            _trainLineService = new TrainLineService();
            _stationsService = new StationsService();
            _timetableService = new TimetableService();
            _trainsService = new TrainsService();
            trainLines = _trainLineService.getTrainLines();
            relationsDTOs = relationsToPick;

            InitializeComponent();
            //this.DataContext = selectedTimetable;
            StartHours.ItemsSource = hoursToPick;
            StartMinutes.ItemsSource = minutesToPick;
            Relations.ItemsSource = relationsToPick;
            TrainNumber.ItemsSource = trainsToPick;


            selTimetable = selectedTimetable;

            Relations.Text = getRelation(_trainLineService.getTrainLineByMidleStations(selectedTimetable.MidleStations.Split(',').ToList()).Id);
            StartHours.Text = selectedTimetable.StartTime.Split(':')[0];
            StartMinutes.Text = selectedTimetable.StartTime.Split(':')[1];
            Midlestations.Text = selectedTimetable.MidleStations;
            TrainNumber.Text = selectedTimetable.TrainNumber;

            
        }

        private string getRelation(int trainLineId)
        {
            foreach (var rel in relationsDTOs)
            {
                if (rel.TrainLineId == trainLineId)
                {
                    return rel.Relation;
                }
            }
            return null;
        }

        private void Relation_Picked(object sender, SelectionChangedEventArgs e)
        {
            // popuni medjustanice
            RelationDTO rel = (RelationDTO)Relations.SelectedItem;
            List<string> midleStationsList = new List<string>();
            foreach (var tl in trainLines)
            {
                if (tl.PlaceStart == rel.Relation.Split('-')[0].Trim() && tl.PlaceEnd == rel.Relation.Split('-')[1].Trim())
                {
                    if (tl.MiddlePlaces.Count == 0)
                    {
                        midleStationsList.Add("Bez medjustanica");
                    }
                    else
                    {
                        midleStationsList.Add(String.Join(",", tl.MiddlePlaces));
                    }

                }
            }
            selTimetable.From = rel.Relation.Split('-')[0].Trim();
            selTimetable.To = rel.Relation.Split('-')[1].Trim();

            middlestationsAccessedFromRelation = true;
            Midlestations.ItemsSource = midleStationsList;
            Midlestations.IsEnabled = true;
            

        }

        private void Hours_Changed(object sender, SelectionChangedEventArgs e)
        {
            RelationDTO rdto = (RelationDTO)Relations.SelectedItem;
            string startPoint = rdto.Relation.Split('-')[0].Trim();
            string endPoint = rdto.Relation.Split('-')[1].Trim();
            List<string> ms = selTimetable.MidleStations.Split(',').ToList();
            string minutes = (StartMinutes.SelectedItem != null) ?  StartMinutes.SelectedItem.ToString() : selTimetable.StartTime.Split(':')[1];
            
            TimeSpan endTime = _stationsService.calculateEndTime(
                TimeSpan.Parse(StartHours.SelectedItem + ":" + minutes),
                ms,
                startPoint, endPoint);
            selTimetable.EndTime = endTime.ToString(@"hh\:mm");
            selTimetable.StartTime = StartHours.SelectedItem + ":" + minutes;

            EndTime.Text = endTime.ToString(@"hh\:mm");
            TrainNumber.IsEnabled = true;
        }

        private void Minutes_Changed(object sender, SelectionChangedEventArgs e)
        {
            RelationDTO rdto = (RelationDTO)Relations.SelectedItem;
            string startPoint = rdto.Relation.Split('-')[0].Trim();
            string endPoint = rdto.Relation.Split('-')[1].Trim();
            List<string> ms = selTimetable.MidleStations.Split(',').ToList();
            string hours = (StartMinutes.SelectedItem != null) ? StartHours.SelectedItem.ToString() : selTimetable.StartTime.Split(':')[0];

            TimeSpan endTime = _stationsService.calculateEndTime(
                TimeSpan.Parse(hours + ":" + StartMinutes.SelectedItem),
                ms,
                startPoint, endPoint);

            selTimetable.EndTime = endTime.ToString(@"hh\:mm");
            selTimetable.StartTime = hours + ":" + StartMinutes.SelectedItem;


            EndTime.Text = endTime.ToString(@"hh\:mm");
            TrainNumber.IsEnabled = true;
        }

        private void Train_Changed(object sender, SelectionChangedEventArgs e)
        {
            selTimetable.TrainNumber = ((Train)TrainNumber.SelectedItem).TrainNumber;
        }

        private void SaveChangesButton_Clicked(object sender, RoutedEventArgs e)
        {
            Timetable editedTimetable = _timetableService.GetTimetableById(selTimetable.TimetableId);
            editedTimetable.TrainServiceId = _trainLineService.getTrainLineByMidleStations(selTimetable.MidleStations.Split(',').ToList()).Id;
            editedTimetable.TrainId = _trainsService.getTrainByTrainNumber(selTimetable.TrainNumber).Id;
            editedTimetable.Start = TimeSpan.Parse(selTimetable.StartTime);
            editedTimetable.End = TimeSpan.Parse(selTimetable.EndTime);

            saveButtonClicked?.Invoke(editedTimetable);
            this.Close();
        }

        private void Midlestations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            selTimetable.MidleStations = Midlestations.SelectedItem?.ToString();
            if (!middlestationsAccessedFromRelation)
            {
                RelationDTO rdto = (RelationDTO)Relations.SelectedItem;
                string startPoint = rdto.Relation.Split('-')[0].Trim();
                string endPoint = rdto.Relation.Split('-')[1].Trim();
                List<string> ms = selTimetable.MidleStations.Split(',').ToList();
                string hours = (StartMinutes.SelectedItem != null) ? StartHours.SelectedItem.ToString() : selTimetable.StartTime.Split(':')[0];
                string minutes = (StartMinutes.SelectedItem != null) ? StartMinutes.SelectedItem.ToString() : selTimetable.StartTime.Split(':')[1];

                TimeSpan endTime = _stationsService.calculateEndTime(
                    TimeSpan.Parse(hours + ":" + minutes),
                    ms,
                    startPoint, endPoint);

                selTimetable.EndTime = endTime.ToString(@"hh\:mm");
                selTimetable.StartTime = hours + ":" + minutes;


                EndTime.Text = endTime.ToString(@"hh\:mm");
                TrainNumber.IsEnabled = true;
                middlestationsAccessedFromRelation = false;
            }
            else
            {
                middlestationsAccessedFromRelation = false;
            }
            

        }
    }
}

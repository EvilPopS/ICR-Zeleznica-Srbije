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
        List<TrainLine> trainLines;
        List<RelationDTO> relationsDTOs;
        public EditRideWindow(ManagerTimetableDTO selectedTimetable, List<string> hoursToPick, List<string> minutesToPick, List<RelationDTO> relationsToPick, List<Train> trainsToPick)
        {
            _trainLineService = new TrainLineService();
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
            Midlestations.ItemsSource = midleStationsList;
            Midlestations.IsEnabled = true;

        }
    }
}

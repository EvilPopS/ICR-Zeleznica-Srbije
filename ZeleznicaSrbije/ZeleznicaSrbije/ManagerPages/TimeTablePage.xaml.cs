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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZeleznicaSrbije.API.DTOs;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.API.Services;
using ZeleznicaSrbije.MainWindowPages;

namespace ZeleznicaSrbije.ManagerPages
{
    /// <summary>
    /// Interaction logic for TimetablePage.xaml
    /// </summary>
    public partial class TimetablePage : Page
    {
        TrainsService _trainsService;
        TrainLineService _trainLineService;
        TimetableService _timetableService;

        ObservableCollection<ManagerTimetableDTO> TimetableCollection { get; set; }
        List<Timetable> timetables;
        List<TrainLine> trainLines;

        public TimetablePage()
        {
            _trainsService = new TrainsService();
            _trainLineService = new TrainLineService();
            _timetableService = new TimetableService();
            trainLines = _trainLineService.getTrainLines();
            InitializeComponent();

            TimetableCollection = new ObservableCollection<ManagerTimetableDTO>();
            timetables = _timetableService.getTimetable();
            createTimetableDTOCollection();
            TimetableData.ItemsSource = TimetableCollection;

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


        private List<RelationDTO> getPossibleRelations()
        {
            List<RelationDTO> relations = new List<RelationDTO>();
            foreach (var tl in trainLines)
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
            foreach (var rel in relations)
            {
                if (rel.Relation == newRel.Relation)
                {
                    return true;
                }
            }
            return false;
        }

        private ManagerTimetableDTO createTimetableDTO(Timetable timetable)
        {
            ManagerTimetableDTO timetableDTO = new ManagerTimetableDTO
            {
                TimetableId = timetable.Id,
                From = _trainLineService.getTrainLineById(timetable.TrainServiceId).PlaceStart,
                To = _trainLineService.getTrainLineById(timetable.TrainServiceId).PlaceEnd,
                StartTime = timetable.Start.ToString(@"hh\:mm"),
                EndTime = timetable.End.ToString(@"hh\:mm"),
                TrainNumber = _trainsService.getTrainById(timetable.TrainId).TrainNumber,
                MidleStations = (String.Join(",", _trainLineService.getTrainLineById(timetable.TrainServiceId).MiddlePlaces))
            };
            return timetableDTO;
        }

        private void createTimetableDTOCollection()
        {
            foreach(var timetable in timetables)
            {
                TimetableCollection.Add(createTimetableDTO(timetable));
            }
        }

        private void addNewRideButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewRide addRideWindow = new AddNewRide();
            addRideWindow.addNewRideClicked += createNewRide;
            addRideWindow.ShowDialog();
        }

        private void createNewRide(Timetable newRide)
        {
            TimetableCollection.Add(createTimetableDTO(newRide));
            _timetableService.addNewRideToTimetable(newRide);
        }

        private void EditRideButton_Clicked(object sender, RoutedEventArgs e)
        {
            ManagerTimetableDTO selTimetable = (ManagerTimetableDTO)TimetableData.SelectedItem;
            EditRideWindow editRideWindow = new EditRideWindow(selTimetable, createHoursAndMinutesList(24), createHoursAndMinutesList(60), getPossibleRelations(), _trainsService.GetAllTrains());
            editRideWindow.saveButtonClicked += editRide;
            editRideWindow.ShowDialog();

        }

        private void updateTimetableCollection(Timetable succEditedRide)
        {
            for (int i = 0; i < TimetableCollection.Count; i++)
            {
                if (succEditedRide.Id == TimetableCollection[i].TimetableId)
                {
                    TimetableCollection[i] = createTimetableDTO(succEditedRide);
                    break;
                }
            }
        }

        private void editRide(Timetable editedRide)
        {
            Timetable successfullyEditedRide = _timetableService.updateRide(editedRide);
            updateTimetableCollection(successfullyEditedRide);

            InformPopUp popUp = new InformPopUp("Uspešno ste izmenili vožnju.", false);
            popUp.ShowDialog();
        }

        private void deleteRideButton_Click(object sender, RoutedEventArgs e)
        {
            ConfirmTrainDeletePopUp deletePopUp = new ConfirmTrainDeletePopUp("Da li sigurno želite da obrišete ovu vožnju?");
            deletePopUp.YesClicked += PopUpClicked;
            deletePopUp.ShowDialog();
        }

        private void PopUpClicked(bool yes)
        {
            if (yes)
            {
                Timetable selRide = _timetableService.GetTimetableById(((ManagerTimetableDTO)TimetableData.SelectedItem).TimetableId);
                _timetableService.DeleteRide(selRide.Id);
                //bool isDeleted = TimetableCollection.Remove(createTimetableDTO(selRide));
                TimetableCollection.Remove(TimetableCollection.Where(i => i.TimetableId == selRide.Id).Single());
                TimetableData.ItemsSource = TimetableCollection;

                InformPopUp popUp = new InformPopUp("Uspešno ste obrisali vožnju.", false);
                popUp.ShowDialog();
            }
        }
    }
}

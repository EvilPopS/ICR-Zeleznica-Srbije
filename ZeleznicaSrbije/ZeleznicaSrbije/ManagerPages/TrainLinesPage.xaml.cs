﻿using System;
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

namespace ZeleznicaSrbije.ManagerPages
{
    /// <summary>
    /// Interaction logic for TrainLinesPage.xaml
    /// </summary>
    public partial class TrainLinesPage : Page
    {

        TrainLineService _trainLineService;
        PlaceService _placeService;

        ObservableCollection<ManagerTrainLineDTO> TrainLineCollection { get; set; }

        List<TrainLine> _trainLines;

        public TrainLinesPage()
        {
            _trainLineService = new TrainLineService();
            _placeService = new PlaceService();
            _trainLines = _trainLineService.getTrainLines();
            InitializeComponent();

            TrainLineCollection = new ObservableCollection<ManagerTrainLineDTO>();
            createTrainLineCollection();
            TrainlinesData.ItemsSource = TrainLineCollection;
        }

        private void createTrainLineCollection()
        {
            foreach(var tl in _trainLines)
            {
                TrainLineCollection.Add(createTrainLineDTO(tl));
            }
        }

        private List<int> getPlacesIds(List<string> placeNames)
        {
            List<int> noNamePlaceIds = new List<int>();
            List<int> placeIds = new List<int>();
            foreach(string placeName in placeNames)
            {
                placeIds.Add(_placeService.getPlaceByName(placeName).Id);
            }

            foreach(Place noNamePlace in _placeService.getNoNamePlaces())
            {
                placeIds.Add(noNamePlace.Id);
            }

            return placeIds;
        }

        private ManagerTrainLineDTO createTrainLineDTO(TrainLine tl)
        {
            List<string> placeNames = tl.MiddlePlaces;
            placeNames.Add(tl.PlaceStart);
            placeNames.Add(tl.PlaceEnd);

            return new ManagerTrainLineDTO
            {
                TrainLineId = tl.Id,
                PlaceStart = tl.PlaceStart,
                PlaceEnd = tl.PlaceEnd,
                MiddleStations = tl.MiddlePlaces.Count == 0 ? "Na ovoj liniji nema međustanica." : String.Join(",", tl.MiddlePlaces),
                AllPlacesIds = _placeService.getAllIds(), // sva mesta
                PlaceNames = placeNames
            };
        }

        private void deleteTrainLineButton_Click(object sender, RoutedEventArgs e)
        {
            ConfirmTrainDeletePopUp deletePopup = new ConfirmTrainDeletePopUp("Da li sigurno želite da obrišete ovu voznu liniju?");
            deletePopup.YesClicked += PopUpClicked;
            deletePopup.ShowDialog();
        }

        private void PopUpClicked(bool yes)
        {
            if (yes)
            {
                TrainLine selTrainLine = _trainLineService.getTrainLineById(((ManagerTrainLineDTO)TrainlinesData.SelectedItem).TrainLineId);
                _trainLineService.DeleteTrainLine(selTrainLine.Id);

                TrainLineCollection.Remove(TrainLineCollection.Where(i => i.TrainLineId == selTrainLine.Id).Single());
                TrainlinesData.SelectedItem = TrainLineCollection;

                OkPopUp okPopUp = new OkPopUp("Uspešno ste obrisali voznu liniju.");
                okPopUp.ShowDialog();


            }
        }

        private void VisualizeLinesButton_Clicked(object sender, RoutedEventArgs e)
        {
            VisualizedTrainLines visualizedTrainLines = new VisualizedTrainLines((ManagerTrainLineDTO)TrainlinesData.SelectedItem);
            visualizedTrainLines.ShowDialog();
        }
    }
}

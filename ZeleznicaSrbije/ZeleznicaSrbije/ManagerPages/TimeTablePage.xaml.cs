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
    /// Interaction logic for TimetablePage.xaml
    /// </summary>
    public partial class TimetablePage : Page
    {
        TrainsService _trainsService;
        TrainLineService _trainLineService;
        TimetableService _timetableService;

        ObservableCollection<ManagerTimetableDTO> TimetableCollection { get; set; }
        List<Timetable> timetables;

        public TimetablePage()
        {
            _trainsService = new TrainsService();
            _trainLineService = new TrainLineService();
            _timetableService = new TimetableService();
            InitializeComponent();

            TimetableCollection = new ObservableCollection<ManagerTimetableDTO>();
            timetables = _timetableService.getTimetable();
            createTimetableDTOCollection();
            TimetableData.ItemsSource = TimetableCollection;

        }

        private ManagerTimetableDTO createTimetableDTO(Timetable timetable)
        {
            ManagerTimetableDTO timetableDTO = new ManagerTimetableDTO
            {
                From = _trainLineService.getTrainLineById(timetable.TrainServiceId).PlaceStart,
                To = _trainLineService.getTrainLineById(timetable.TrainServiceId).PlaceEnd,
                StartTime = timetable.Start.ToString(@"hh\:mm"),
                EndTime = timetable.End.ToString(@"hh\:mm"),
                TrainNumber = _trainsService.getTrainById(timetable.TrainServiceId).TrainNumber,
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
    }
}
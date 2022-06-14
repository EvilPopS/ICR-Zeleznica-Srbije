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
    /// Interaction logic for VisualizedTrainLines.xaml
    /// </summary>
    /// 
    class draw
    {
        public static void circle(double x, double y, int width, int height, Canvas cv)
        {

            Ellipse circle = new Ellipse()
            {
                Width = width,
                Height = height,
                Stroke = Brushes.Black,
                StrokeThickness = 6
            };

            cv.Children.Add(circle);

            circle.SetValue(Canvas.LeftProperty, x);
            circle.SetValue(Canvas.TopProperty, y);
        }
    }
    public partial class VisualizedTrainLines : Window
    {
        ManagerTrainLineDTO trainLineDTO;
        PlaceService _placeService;

        List<Place> allPlaces;
        public VisualizedTrainLines(ManagerTrainLineDTO ManagerTrainLineDTO)
        {
            // petrov - bg -------indjija
            _placeService = new PlaceService();
            trainLineDTO = ManagerTrainLineDTO;
            allPlaces = _placeService.getAllPlaces();
            InitializeComponent();

            canvas.Children.Clear();
            //int x_inc = 150;
            
            //Point[] points = new Point[8]
            //{

            //new Point(x_inc + 15, 25)  ,//15, 25),  
            //new Point(x_inc + 35 , 45)  ,//25 , 35),
            //new Point(x_inc + 75, 55)  ,//45, 40),
            //new Point(x_inc + 95, 145)  ,//55, 85 ),
            //new Point(x_inc + 155, 165)  ,//85, 95),
            //new Point(x_inc + 225, 205),//120, 115),
            //new Point(x_inc + 265, 245),//140, 135),
            //new Point(x_inc + 335, 265),//175, 145)

            //};
            
            //DrawLine2(points);

            drawPoints();

            drawCircles();

            //draw.circle(points[0].X, points[0].Y, 5, 5, canvas);
            //draw.circle(points[1].X, points[1].Y, 5, 5, canvas);
            //draw.circle(points[2].X, points[2].Y, 5, 5, canvas);
            //draw.circle(points[3].X, points[3].Y, 5, 5, canvas);
            //draw.circle(points[4].X, points[4].Y, 5, 5, canvas);
            //draw.circle(points[5].X, points[5].Y, 5, 5, canvas);
            //draw.circle(points[6].X, points[6].Y, 5, 5, canvas);
            //draw.circle(points[7].X, points[7].Y, 5, 5, canvas);
            drawText();
            //Text(points[0].X, points[0].Y - 15, "Novi Sad", Color.FromRgb(2, 5, 7));
            //Text(points[1].X, points[1].Y - 15, "", Color.FromRgb(2, 5, 7));
            //Text(points[2].X, points[2].Y - 15, "Petrovaradin", Color.FromRgb(2, 5, 7));
            //Text(points[3].X, points[3].Y - 15, "", Color.FromRgb(2, 5, 7));
            //Text(points[4].X, points[4].Y - 15, "Inđija", Color.FromRgb(2, 5, 7));
            //Text(points[5].X, points[5].Y - 15, "", Color.FromRgb(2, 5, 7));
            //Text(points[6].X, points[6].Y - 15, "Zemun", Color.FromRgb(2, 5, 7));
            //Text(points[7].X, points[7].Y - 15, "Beograd", Color.FromRgb(2, 5, 7));

        }

        private void drawCircles()
        {
            foreach(string placeName in trainLineDTO.PlaceNames)
            {
                draw.circle(_placeService.getPlaceByName(placeName).X, _placeService.getPlaceByName(placeName).Y, 5, 5, canvas);
            }
        }

        private void drawText()
        {
            foreach (string placeName in trainLineDTO.PlaceNames)
            {
                Text(_placeService.getPlaceByName(placeName).X, _placeService.getPlaceByName(placeName).Y - 15, placeName, Color.FromRgb(2, 5, 7));
            }
        }

        private void drawPoints()
        {
            Point[] points = new Point[trainLineDTO.AllPlacesIds.Count];
            Place place = null;
            for (int i = 0; i < points.Length; i++)
            {
                place = _placeService.getPlaceById(trainLineDTO.AllPlacesIds[i]);
                points[i] = new Point(place.X, place.Y);
            }

            Point[] sortedPoints = points.OrderBy(x=>x.X).ThenBy(x=>x.Y).ToArray();

            DrawLine2(sortedPoints);


        }

        private void Text(double x, double y, string text, Color color)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Foreground = new SolidColorBrush(color);
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            canvas.Children.Add(textBlock);
        }


        private void DrawLine2(Point[] points)
        {
            Polyline line = new Polyline();
            PointCollection collection = new PointCollection();
            foreach (Point p in points)
            {
                collection.Add(p);
            }
            line.Points = collection;
            line.Stroke = new SolidColorBrush(Colors.Black);
            line.StrokeThickness = 1;
            canvas.Children.Add(line);
        }
    }
}

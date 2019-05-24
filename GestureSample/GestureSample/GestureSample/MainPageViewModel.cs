using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Linq;
using Xamarin.Forms;

namespace GestureSample
{
    public class MainPageViewModel : BindableObject
    {
        public SKPath Path { get; set; }
        public SKCanvasView CanvasView { get; set; }
        //public SKCanvas canvas { get; set; }
        public Board Board { get; set; }
        public Game Game { get; set; }
        MainPage mainPage;
        private readonly INavigation navigation;

        public double PanX { get; set; }
        public double PanY { get; set; }

        public MainPageViewModel(INavigation navigation, MainPage mainPage)
        {
            this.navigation = navigation;
            this.mainPage = mainPage;
        }

        public Command<Point> PanCommand => new Command<Point>(point =>
        {
            PanX = point.X;
            PanY = point.Y;
            OnPropertyChanged(nameof(PanX));
            OnPropertyChanged(nameof(PanY));
        });

        public Command<Point> TapCommand => new Command<Point>(point =>
        {
            SKPoint sKPoint = ConvertToPixel(point);

            PanX = sKPoint.X;
            PanY = sKPoint.Y;
            OnPropertyChanged(nameof(PanX));
            OnPropertyChanged(nameof(PanY));

           
            if (Game.PlacePath)
            {
                CheckPath();
            }
            else if (Game.Turn < 2 && Game.VillagesCache.Count == 0)
            {
                CheckVillage();              
            }
            else if (Game.PlaceVillage)
            {
                CheckVillage();
            }
            else if (Game.PlaceTown)
            { 
                CheckTown();
            }
            else if (Game.PlaceThief)
            {
                CheckThief();
            }
        }
        );

        private void CheckThief()
        {
            for (int i = 0; i < 19; i++)
            {
                if (Board.Tiles[i].HexPath.Contains((float)PanX, (float)PanY))
                {
                    Game.ThiefHexagon.SetNumber(Game.ThiefHexagon.Id);
                    Game.ThiefHexagon.UnsetThief();
                    Board.Tiles[i].SetThief();
                    Game.ThiefHexagon = Board.Tiles[i];
                    CanvasView.InvalidateSurface();
                    
                }
            }
            Game.PlaceThief = false;
        }

        private void CheckTown()
        {
            foreach (Vertex village in Game.CurrentPlayer.Villages.ToList())
            {
                if (village.Path.Contains((float)PanX, (float)PanY))
                {
                    village.Path = new Star(village.Point, 2 * village.Radius).StarPath;
                    Game.CurrentPlayer.Towns.Add(village);
                    Game.CurrentPlayer.Villages.Remove(village);
                    Game.PlaceTown = false;
                    mainPage.Switch = true;
                    CanvasView.InvalidateSurface();
                }
            }
        }

        private void CheckVillage()
        {
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (Board.Tiles[i].Vertices[j].Path.Contains((float)PanX, (float)PanY))
                    {
                        this.Game.CurrentPlayer.Villages.Add(Board.Tiles[i].Vertices[j]);
                        Game.VillagesCache.Add(Board.Tiles[i].Vertices[j]);
                        if (Game.Turn == 1)
                        {
                            Game.CurrentPlayer.AddResource(Board.Tiles[i].Vertices[j].resourceType, 1);
                        }
                        if (Game.Turn < 2) Game.PlacePath = true;
                        mainPage.Switch = true;
                        Game.PlaceVillage = false;                    
                        CanvasView.InvalidateSurface();
                        //break;
                    }
                }
            }
        }

        private void CheckPath()
        {
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (Board.Tiles[i].Edges[j].Contains((float)PanX, (float)PanY))
                    {
                        this.Game.CurrentPlayer.Paths.Add(Board.Tiles[i].Edges[j]);
                        Game.PathsCache.Add(Board.Tiles[i].Edges[j]);
                        mainPage.Switch = true;
                        Game.PlacePath = false;
                        if (Game.PathBuilder)
                        {
                            Game.PathBuilder = false;
                            Game.PlacePath = true;
                        }
                        CanvasView.InvalidateSurface();
                        //break;
                    }
                }
            }
        }

        SKPoint ConvertToPixel(Point pt)
        {
            return new SKPoint((float)(CanvasView.CanvasSize.Width * pt.X / CanvasView.Width),
                               (float)(CanvasView.CanvasSize.Height * pt.Y / CanvasView.Height));
        }


    }
}
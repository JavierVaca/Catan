using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GestureSample
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel pageModel;
        public bool Switch = false;
        //public List<SKPath> PaintedPaths; 
        SKImageInfo info;
        SKSurface surface;
        SKCanvas canvas;
        //public List<SKPath> PaintedTowns;
        public Game Game { get; set; }
        public Board Board { get; set; }
        public bool onFirstLoad;

        public MainPage()
        {
            InitializeComponent();
            pageModel = new MainPageViewModel(Navigation, this);
            BindingContext = pageModel;
            //PaintedPaths = new List<SKPath>();
            //PaintedTowns = new List<SKPath>();
            Game = new Game(new List<Player>()
            {
                new Player("Carin", new SKColor(255,65,237)){Rock =1, Sheep = 1, Wheat = 1 },
                new Player("Paquito", new SKColor(127,255,64)),
                new Player("Kung Fu", new SKColor(167,31,225)),
                //new Player("Donatello", SKColors.Yellow),
            });
            pageModel.Game = this.Game;
            DiceImage1.Source = ImageSource.FromFile("dice1");
            DiceImage2.Source = ImageSource.FromFile("dice2");
            onFirstLoad = true;
            SetLabels();
            SetName();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetLabels();
        }

        private void SetName()
        {
            PLayerName.Text = Game.CurrentPlayer.Name;
            PLayerName.TextColor = Game.CurrentPlayer.Color.Color.ToFormsColor();
            PLayerName.FontSize = 36;
        }

        private void SetLabels()
        {
            wheatLabel.Text = "Wheat: " + Game.CurrentPlayer.Wheat.ToString();
            rockLabel.Text = "Rock: " + Game.CurrentPlayer.Rock.ToString();
            woodLabel.Text = "Wood: " + Game.CurrentPlayer.Wood.ToString();
            sheepLabel.Text = "Sheep: " + Game.CurrentPlayer.Sheep.ToString();
            brickLabel.Text = "Brick: " + Game.CurrentPlayer.Brick.ToString();
        }

        public void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            info = args.Info;
            surface = args.Surface;
            canvas = surface.Canvas;

            SetLabels();

            canvas.Clear();

            if (onFirstLoad)
            {
                Board = new Board(info.Width, info.Height);
                pageModel.Board = Board;
                pageModel.CanvasView = canvasView;
                Game.ThiefHexagon = Board.Desert;
                onFirstLoad = false;
            }

            if (Switch)
            {

                foreach (Player player in Game.Players)
                {
                    foreach (SKPath path in player.Paths)
                    {
                        canvas.DrawPath(path, player.Color);
                    }
                }
            }

            for (int i = 0; i < 19; i++)
            {
                var Tile = this.Board.Tiles[i];
                canvas.DrawPath(Tile.HexPath, Tile.HexPaint);
                if (Tile.GetNumber() != "7")
                {
                    canvas.DrawPath(Tile.NumberCircle, Tile.CenterPaint);
                    canvas.DrawText(Tile.GetNumber(), 
                        new SKPoint(Tile.Center_x - info.Width * 0.01f, Tile.Center_y + info.Height * 0.01f),
                        Tile.TextPaint);
                }
            }
            for (int i = 0; i < 18; i++)
            {
                var SeaTile = Board.SeaTiles[i];
                canvas.DrawPath(SeaTile.HexPath, new SKPaint() { Color = SKColors.LightSkyBlue});
            }

            if (Switch)
            {
                foreach (Player player in Game.Players)
                {
                    foreach (Vertex path in player.Villages)
                    {
                        canvas.DrawPath(path.Path, player.Color);
                    }
                    foreach (Vertex path in player.Towns)
                    {
                        canvas.DrawPath(path.Path, player.Color);
                    }

                }
            }
        }

        private void RollButton_Clicked(object sender, EventArgs e)
        {
            Random random = new Random();
            int diceNumber1 = random.Next(1, 7);
            int diceNumber2 = random.Next(1, 7);
            DiceImage1.Source = ImageSource.FromFile("dice" + diceNumber1.ToString());
            DiceImage2.Source = ImageSource.FromFile("dice" + diceNumber2.ToString());
            if (diceNumber1 + diceNumber2 == 7)
            {
                Game.PlaceThief = true;
                Navigation.PushModalAsync(new ThiefPage(Game));
            }
            else
            {
                Game.HandleDiceRoll(diceNumber1 + diceNumber2);
            }
            rollButton.IsEnabled = false;
            SetLabels();
        }

        private void TurnButton_Clicked(object sender, EventArgs e)
        {
            if (Game.Turn == 1)
            {
                Game.ReversedNextPlayer();
            }
            else
            {
                Game.GetNextPlayer();
            }
            Game.PathsCache = new List<SKPath>();
            Game.VillagesCache = new List<Vertex>();
            rollButton.IsEnabled = true;
            SetLabels();
            SetName();
        }

        private void MarketButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MarketPage(Game));
        }

        private void BuildButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BuildPage(Game.CurrentPlayer, Game));
        }

        private void CardButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CardPage(Game.CurrentPlayer));
        }

        private void Undo_Clicked(object sender, EventArgs e)
        {
            try
            {
                Vertex vertex = Game.VillagesCache[Game.VillagesCache.Count - 1];
                Game.CurrentPlayer.Villages.Remove(vertex);
                Game.VillagesCache.Remove(vertex);
            }
            catch
            {
                
            }
            try
            {
                SKPath edge = Game.PathsCache[Game.PathsCache.Count - 1];
                Game.CurrentPlayer.Paths.Remove(edge);
                Game.PathsCache.Remove(edge);
            }
            catch { }
            
            canvasView.InvalidateSurface();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestureSample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MarketPage : ContentPage
	{
        public Game Game { get; set; }
        public int Wheat { get; set; }
        public int Sheep { get; set; }
        public int Rock { get; set; }
        public int Brick { get; set; }
        public int Wood { get; set; }
        public int Wheat2 { get; set; }
        public int Sheep2 { get; set; }
        public int Rock2 { get; set; }
        public int Brick2 { get; set; }
        public int Wood2 { get; set; }

        public MarketPage(Game game)
        {
            Game = game;
            InitializeComponent();
            Game.Players.Add(new Player("Ports", SkiaSharp.SKColors.Black)
            {
                Rock = 100,
                Wheat = 100,
                Wood = 100,
                Brick = 100,
                Sheep = 100
            });
            playerList.ItemsSource = Game.Players;
            currentPlayer.Text = "Current Player: " + Game.CurrentPlayer.Name;
            currentPlayer.TextColor = Game.CurrentPlayer.XamColor;
            playerList.SelectedItem = Game.Players[0];
            Game = game;
            ResetLabels();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Game.Players.RemoveAt(3);
        }

        private void ResetLabels()
        {
            Wheat = 0;
            Sheep = 0;
            Rock = 0;
            Brick = 0;
            Wood = 0;
            Wheat2 = 0;
            Sheep2 = 0;
            Rock2 = 0;
            Brick2 = 0;
            Wood2 = 0;
            wheatLabel.Text = "Wheat: " + Wheat;
            sheepLabel.Text = "Sheep: " + Sheep;
            woodLabel.Text = "Wood: " + Wood;
            brickLabel.Text = "Brick: " + Brick;
            rockLabel.Text = "Rock: " + Rock;
            wheatLabel2.Text = "Wheat: " + Wheat2;
            sheepLabel2.Text = "Sheep: " + Sheep2;
            woodLabel2.Text = "Wood: " + Wood2;
            brickLabel2.Text = "Brick: " + Brick2;
            rockLabel2.Text = "Rock: " + Rock2;
        }

        private void playerList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Player selectedPlayer = (Player)e.SelectedItem;
            Wheat2 = 0;
            Sheep2 = 0;
            Rock2 = 0;
            Brick2 = 0;
            Wood2 = 0;
        }

        private void TradeButton_Clicked(object sender, EventArgs e)
        {
            Game.CurrentPlayer.Rock -= Rock;
            Game.CurrentPlayer.Wheat -= Wheat;
            Game.CurrentPlayer.Wood -= Wood;
            Game.CurrentPlayer.Brick -= Brick;
            Game.CurrentPlayer.Sheep -= Sheep;
            Game.CurrentPlayer.Rock += Rock2;
            Game.CurrentPlayer.Wheat += Wheat2;
            Game.CurrentPlayer.Wood += Wood2;
            Game.CurrentPlayer.Brick += Brick2;
            Game.CurrentPlayer.Sheep += Sheep2;

            Player selectedPlayer = (Player)playerList.SelectedItem;

            selectedPlayer.Rock -= Rock2;
            selectedPlayer.Sheep -= Sheep2;
            selectedPlayer.Brick -= Brick2;
            selectedPlayer.Wheat -= Wheat2;
            selectedPlayer.Wood -= Wood2;
            selectedPlayer.Rock += Rock;
            selectedPlayer.Sheep += Sheep;
            selectedPlayer.Brick += Brick;
            selectedPlayer.Wheat += Wheat;
            selectedPlayer.Wood += Wood;

            ResetLabels();
        }

       

        private void RemoveWheatButton_Clicked(object sender, EventArgs e)
        {
            if(Wheat > 0) Wheat -= 1;
            wheatLabel.Text = "Wheat: " + Wheat;

        }

        private void AddWheatButton_Clicked(object sender, EventArgs e)
        {
            if (Game.CurrentPlayer.Wheat > 0 && Game.CurrentPlayer.Wheat > Wheat)
            {
                Wheat += 1;
                wheatLabel.Text = "Wheat: " + Wheat;
            }
        }

        private void RemoveSheepButton_Clicked(object sender, EventArgs e)
        {
            if (Sheep > 0) Sheep -= 1;
            sheepLabel.Text = "Sheep: " + Sheep;
        }

        private void AddSheepButton_Clicked(object sender, EventArgs e)
        {
            if (Game.CurrentPlayer.Sheep > 0 && Game.CurrentPlayer.Sheep > Sheep)
            {
                Sheep += 1;
                sheepLabel.Text = "Sheep: " + Sheep;
            }
        }

        private void RemoveWoodButton_Clicked(object sender, EventArgs e)
        {
            if (Wood > 0) Wood -= 1;
            woodLabel.Text = "Wood: " + Wood;
        }

        private void AddWoodButton_Clicked(object sender, EventArgs e)
        {
            if (Game.CurrentPlayer.Wood > 0 && Game.CurrentPlayer.Wood > Wood)
            {
                Wood += 1;
                woodLabel.Text = "Wood: " + Wood;
            }
        }

        private void RemoveBrickButton_Clicked(object sender, EventArgs e)
        {
            if (Brick > 0) Brick -= 1;
            brickLabel.Text = "Brick: " + Brick;
        }

        private void AddBrickButton_Clicked(object sender, EventArgs e)
        {
            if (Game.CurrentPlayer.Brick > 0 && Game.CurrentPlayer.Brick > Brick)
            {
                Brick += 1;
                brickLabel.Text = "Brick: " + Brick;
            }
        }

        private void AddRockButton_Clicked(object sender, EventArgs e)
        {
            if (Game.CurrentPlayer.Rock > 0 && Game.CurrentPlayer.Rock > Rock)
            {
                Rock += 1;
                rockLabel.Text = "Rock: " + Rock;
            }
        }

        private void RemoveRockButton_Clicked(object sender, EventArgs e)
        {
            if (Rock > 0) Rock -= 1;
            rockLabel.Text = "Rock: " + Rock;
        }

        private void AddWheatButton2_Clicked(object sender, EventArgs e)
        {
            Player selectedPlayer = (Player)playerList.SelectedItem;
            if (selectedPlayer.Wheat > 0 && selectedPlayer.Wheat > Wheat2)
            {
                Wheat2 += 1;
                wheatLabel2.Text = "Wheat: " + Wheat2;
            }
        }

        private void RemoveWheatButton2_Clicked(object sender, EventArgs e)
        {
            if (Wheat2 > 0) Wheat2 -= 1;
            wheatLabel2.Text = "Wheat: " + Wheat2;
        }

        private void AddSheepButton2_Clicked(object sender, EventArgs e)
        {
            Player selectedPlayer = (Player)playerList.SelectedItem;
            if (selectedPlayer.Sheep > 0 && selectedPlayer.Sheep > Sheep2)
            {
                Sheep2 += 1;
                sheepLabel2.Text = "Sheep: " + Sheep2;
            }
        }

        private void RemoveSheepButton2_Clicked(object sender, EventArgs e)
        {
            if (Sheep > 0) Sheep -= 1;
            sheepLabel2.Text = "Sheep: " + Sheep;
        }

        private void AddWoodButton2_Clicked(object sender, EventArgs e)
        {
            Player selectedPlayer = (Player)playerList.SelectedItem;
            if (selectedPlayer.Wood > 0 && selectedPlayer.Wood > Wood2)
            {
                Wood2 += 1;
                woodLabel2.Text = "Wood: " + Wood2;
            }
        }

        private void RemoveWoodButton2_Clicked(object sender, EventArgs e)
        {
            if (Wood2 > 0) Wood2 -= 1;
            woodLabel2.Text = "Wood: " + Wood2;
        }

        private void AddBrickButton2_Clicked(object sender, EventArgs e)
        {
            Player selectedPlayer = (Player)playerList.SelectedItem;
            if (selectedPlayer.Brick > 0 && selectedPlayer.Brick > Brick2)
            {
                Brick2 += 1;
                brickLabel2.Text = "Brick: " + Brick2;
            }
        }

        private void RemoveBrickButton2_Clicked(object sender, EventArgs e)
        {
            if (Brick2 > 0) Brick2 -= 1;
            brickLabel2.Text = "Brick: " + Brick2;
        }

        private void AddRockButton2_Clicked(object sender, EventArgs e)
        {
            Player selectedPlayer = (Player)playerList.SelectedItem;
            if (selectedPlayer.Rock > 0 && selectedPlayer.Rock > Rock2)
            {
                Rock2 += 1;
                rockLabel2.Text = "Rock: " + Rock2;
            }
        }

        private void RemoveRockButton2_Clicked(object sender, EventArgs e)
        {
            if (Rock2 > 0) Rock2 -= 1;
            rockLabel2.Text = "Rock: " + Rock2;
        }
    }
}
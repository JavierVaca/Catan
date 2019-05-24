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
	public partial class ThiefPage : ContentPage
	{
        public Game Game { get; set; }

        public ThiefPage (Game game)
		{
            Game = game;
			InitializeComponent ();
            playerList.ItemsSource = Game.Players;
		}

        private void playerList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Player selectedPlayer = (Player)e.SelectedItem;
            SetLabels(selectedPlayer);
        }

        private void SetLabels(Player selectedPlayer)
        {
            wheatLabel.Text = "Wheat: " + selectedPlayer.Wheat;
            woodLabel.Text = "Wood: " + selectedPlayer.Wood;
            rockLabel.Text = "Rock: " + selectedPlayer.Rock;
            sheepLabel.Text = "Sheep: " + selectedPlayer.Sheep;
            brickLabel.Text = "Brick: " + selectedPlayer.Brick;
        }

        private void RockButton_Clicked(object sender, EventArgs e)
        {
            Player selectedPlayer = (Player)playerList.SelectedItem;
            if (selectedPlayer.Rock > 0) selectedPlayer.Rock -= 1;
            SetLabels(selectedPlayer);
        }

        private void BrickButton_Clicked(object sender, EventArgs e)
        {
            Player selectedPlayer = (Player)playerList.SelectedItem;
            if (selectedPlayer.Brick > 0) selectedPlayer.Brick -= 1;
            SetLabels(selectedPlayer);
        }

        private void WheatButton_Clicked(object sender, EventArgs e)
        {
            Player selectedPlayer = (Player)playerList.SelectedItem;
            if (selectedPlayer.Wheat > 0) selectedPlayer.Wheat -= 1;
            SetLabels(selectedPlayer);
        }

        private void WoodButton_Clicked(object sender, EventArgs e)
        {
            Player selectedPlayer = (Player)playerList.SelectedItem;
            if(selectedPlayer.Wood > 0) selectedPlayer.Wood -= 1;
            SetLabels(selectedPlayer);
        }

        private void SheepButton_Clicked(object sender, EventArgs e)
        {
            Player selectedPlayer = (Player)playerList.SelectedItem;
            if (selectedPlayer.Sheep > 0) selectedPlayer.Sheep -= 1;
            SetLabels(selectedPlayer);
        }
    }
}
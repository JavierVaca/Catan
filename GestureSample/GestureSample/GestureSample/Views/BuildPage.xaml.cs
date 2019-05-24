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
	public partial class BuildPage : ContentPage
	{
        public Player Player { get; set; }
        public Game Game { get; set; }

        public BuildPage (Player player, Game game)
		{
			InitializeComponent ();
            Player = player;
            Game = game;
            CheckAffordability();
		}

        private void CheckAffordability()
        {
            if (Player.Wood >= 1 && Player.Brick >= 1)
            {
                PathButton.IsEnabled = true;
                PathButton.BackgroundColor = Color.DodgerBlue;
            }

            if (Player.Sheep >= 1 && Player.Wood >= 1 && Player.Brick >= 1 && Player.Wheat >= 1)
            {
                VillageButton.IsEnabled = true;
                VillageButton.BackgroundColor = Color.DodgerBlue;
            }

            if (Player.Rock >= 3 && Player.Wheat >= 2)
            {
                TownButton.IsEnabled = true;
                TownButton.BackgroundColor = Color.DodgerBlue;
            }

            if (Player.Wheat >= 1 && Player.Rock >= 1 && Player.Sheep >= 1)
            {
                DevelopmentButton.IsEnabled = true;
                DevelopmentButton.BackgroundColor = Color.DodgerBlue;
            }
        }

        private void PathButton_Clicked(object sender, EventArgs e)
        {
            Game.PlacePath = true;
            Player.Wood -= 1;
            Player.Brick -= 1;
            Navigation.PopAsync();
        }

        private void VillageButton_Clicked(object sender, EventArgs e)
        {
            Game.PlaceVillage = true;
            Player.Wood -= 1;
            Player.Brick -= 1;
            Player.Wheat -= 1;
            Player.Sheep -= 1;
            Navigation.PopAsync();
        }

        private void TownButton_Clicked(object sender, EventArgs e)
        {
            Game.PlaceTown = true;
            Player.Rock -= 3;
            Player.Wheat -= 2;
            Navigation.PopAsync();
        }

        private void DevelopmentButton_Clicked(object sender, EventArgs e)
        {
            Random random = new Random();
            int index = random.Next(0, Game.Cards.Count);
            if (Game.Cards.Count != 0)
            {
                Card card = Game.Cards[index];
                Game.CurrentPlayer.Cards.Add(card);
                Game.Cards.RemoveAt(index);
            }
            Player.Sheep -= 1;
            Player.Rock -= 1;
            Player.Wheat -= 1;
            Navigation.PopAsync();
        }
    }
}
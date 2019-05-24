using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
	public partial class MonopolyPopUp : PopupPage
	{
        private TileType tileTypes { get; set; }
        public Game Game { get; set; }

        public MonopolyPopUp(Game game)
        {
            Game = game;
            InitializeComponent();
            BrickButton.BackgroundColor = Color.OrangeRed;
            RockButton.BackgroundColor = Color.Gray;
            WheatButton.BackgroundColor = Color.FromRgb(233, 207, 39);
            WoodButton.BackgroundColor = Color.DarkGreen;
            SheepButton.BackgroundColor = Color.WhiteSmoke;
            SelectButton.Clicked += SelectButton_ClickedAsync;
            tileTypes = TileType.Desert;
        }

        private async void SelectButton_ClickedAsync(object sender, EventArgs e)
        {
            if (tileTypes == TileType.Desert)
            {
                MessageLabel.Text = "Please select a resource";
            }

            else
            {
                int resource = 0;
                foreach (Player player in Game.Players)
                {
                    if (tileTypes == TileType.Brick)
                    {
                        resource += player.Brick;
                        player.Brick = 0;
                    }
                    else if (tileTypes == TileType.Rock)
                    {
                        resource += player.Rock;
                        player.Rock = 0;
                    }
                    else if (tileTypes == TileType.Wheat)
                    {
                        resource += player.Wheat;
                        player.Wheat = 0;
                    }
                    else if (tileTypes == TileType.Sheep)
                    {
                        resource += player.Sheep;
                        player.Sheep = 0;
                    }
                    else if (tileTypes == TileType.Wood)
                    {
                        resource += player.Wood;
                        player.Wood = 0;
                    }             
                }
                Game.CurrentPlayer.AddResource(tileTypes, resource);
                await PopupNavigation.Instance.PopAsync();
            }

        }

        private void SetBordersToWhite()
        {
            WheatButton.BorderWidth = 0;
            RockButton.BorderWidth = 0;
            WoodButton.BorderWidth = 0;
            BrickButton.BorderWidth = 0;
            SheepButton.BorderWidth = 0;
        }

        private void WheatButton_Clicked(object sender, EventArgs e)
        {
            tileTypes = TileType.Wheat;
            SetBordersToWhite();
            WheatButton.BorderColor = Color.Black;
            WheatButton.BorderWidth = 5;
        }

        private void WoodButton_Clicked(object sender, EventArgs e)
        {
            tileTypes = TileType.Wood;
            SetBordersToWhite();
            WoodButton.BorderColor = Color.Black;
           WoodButton.BorderWidth = 5;
        }

        private void RockButton_Clicked(object sender, EventArgs e)
        {
            tileTypes = TileType.Rock;
            SetBordersToWhite();
            RockButton.BorderColor = Color.Black;
            RockButton.BorderWidth = 5;
        }

        private void SheepButton_Clicked(object sender, EventArgs e)
        {
            tileTypes = TileType.Sheep;
            SetBordersToWhite();
            SheepButton.BorderColor = Color.Black;
            SheepButton.BorderWidth = 5;
        }

        private void BrickButton_Clicked(object sender, EventArgs e)
        {
            tileTypes = TileType.Brick;
            SetBordersToWhite();
            BrickButton.BorderColor = Color.Black;
            BrickButton.BorderWidth = 5;
        }
    }
}
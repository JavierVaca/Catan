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
	public partial class DiscoveryPopUp : PopupPage
	{
        private List<TileType> cardTypes;
        public Player Player { get; set; }

        public DiscoveryPopUp (Player player)
		{
            Player = player;
			InitializeComponent ();
            BrickButton.BackgroundColor = Color.OrangeRed;
            RockButton.BackgroundColor = Color.Gray;
            WheatButton.BackgroundColor = Color.FromRgb(233, 207, 39);
            WoodButton.BackgroundColor = Color.DarkGreen;
            SheepButton.BackgroundColor = Color.WhiteSmoke;
            cardTypes = new List<TileType>();
            SelectButton.Clicked += SelectButton_ClickedAsync;
		}

        private async void SelectButton_ClickedAsync(object sender, EventArgs e)
        {
            if (cardTypes.Count == 2)
            {
                Player.AddResource(cardTypes[0], 1);
                Player.AddResource(cardTypes[1], 1);
                await PopupNavigation.Instance.PopAsync();
            }
            else if (cardTypes.Count == 1)
            {
                Player.AddResource(cardTypes[0], 2);
                await PopupNavigation.Instance.PopAsync();
            }
            else
            {
                MessageLabel.Text = "Please select a resource";
            }
           
        }

        private void WheatButton_Clicked(object sender, EventArgs e)
        {
            if(cardTypes.Count < 2)
            {
                cardTypes.Add(TileType.Wheat);
                WheatButton.BorderColor = Color.Black;
                WheatButton.BorderWidth = 5;
            }
            
        }

        private void WoodButton_Clicked(object sender, EventArgs e)
        {
            if (cardTypes.Count < 2)
            {
                cardTypes.Add(TileType.Wood);
                WoodButton.BorderColor = Color.Black;
                WoodButton.BorderWidth = 5;
            }
        }

        private void RockButton_Clicked(object sender, EventArgs e)
        {
            if (cardTypes.Count < 2)
            {
                cardTypes.Add(TileType.Rock);
                RockButton.BorderColor = Color.Black;
                RockButton.BorderWidth = 5;
            }
        }

        private void SheepButton_Clicked(object sender, EventArgs e)
        {
            if (cardTypes.Count < 2)
            {
                cardTypes.Add(TileType.Sheep);
                SheepButton.BorderColor = Color.Black;
                SheepButton.BorderWidth = 5;
            }
        }

        private void BrickButton_Clicked(object sender, EventArgs e)
        {
            if (cardTypes.Count < 2)
            {
                cardTypes.Add(TileType.Brick);
                BrickButton.BorderColor = Color.Black;
                BrickButton.BorderWidth = 5;
            }
        }
    }
}
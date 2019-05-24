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
	public partial class CardPage : ContentPage
	{
		public CardPage (Player player)
		{
			InitializeComponent ();
            double cardnumber = Math.Sqrt(player.Cards.Count);
            for (double i = 0; i < Math.Round(cardnumber); i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition() {Width = GridLength.Auto });
            }
            for (double i = 0; i < Math.Ceiling(cardnumber); i++)
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            }

            int x = 0;
            int j = 0;
            foreach (Card card in player.Cards)
            {
                if (x == Math.Floor(cardnumber))
                {
                    j++;
                    x = 0;
                };
                grid.Children.Add(card, x, j);
                if (j == Math.Ceiling(cardnumber)) j = 0;
                x++;
            }

        }
	}
}
using Xamarin;
using Xamarin.Forms;
using System;
using Rg.Plugins.Popup.Services;

namespace GestureSample
{
    public class Card : Image
    {
        public CardType type { get; set; }
        public TapGestureRecognizer tap { get; set; }
        public Game Game { get; set; }
        public bool Active { get; set; }

        public Card(ImageSource picture, CardType type, Game game)
        {
            Source = picture;
            this.type = type;
            Game = game;
            tap = new TapGestureRecognizer();
            tap.Tapped += GetEventHandler(type);
            GestureRecognizers.Add(tap);
            Active = true;

        }

        private EventHandler GetEventHandler(CardType type)
        {
            if (type == CardType.PathBuilder)
            {
                return (s, e) =>
                {
                    if (Active)
                    {
                        Game.PathBuilder = true;
                        Game.PlacePath = true;
                        Navigation.PopAsync();
                        Active = false;
                    }
                };
            }
            else if (type == CardType.Monopoly)
            {
                return async (s, e) => 
                {
                    if (Active)
                    {
                        await PopupNavigation.Instance.PushAsync(new MonopolyPopUp(Game));
                        Active = false;
                    }       
                };
            }
            else if (type == CardType.Knight)
            {
                return (s, e) => 
                {
                    if (Active)
                    {
                        Game.PlaceThief = true;
                        Navigation.PopAsync();
                        Active = false;
                    }
                };
            }
            else if (type == CardType.Discovery)
            {
                return async (s, e) => 
                {
                    if (Active)
                    {
                        await PopupNavigation.Instance.PushAsync(new DiscoveryPopUp(Game.CurrentPlayer));
                        Active = false;
                    }
                };
            }
            else
            {
                return (s, e) => {};
            }
        }
    }
}
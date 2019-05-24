using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GestureSample
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public Player CurrentPlayer { get; set; }
        public Hexagon ThiefHexagon { get; set; }
        public bool PlacePath { get; set; }
        public bool PlaceTown { get; set; }
        public bool PlaceVillage { get; set; }
        public bool PlaceThief { get; set; }
        private int playerIndex;
        public int Turn { get; set; }
        public List<Vertex> VillagesCache { get; set; }
        public List<SkiaSharp.SKPath> PathsCache { get; set; }
        public List<Card> Cards { get; set; }
        public bool PathBuilder { get; internal set; }

        public Game(List<Player> players)
        {
            Players = players;
            CurrentPlayer = Players[0];
            playerIndex = 0;
            VillagesCache = new List<Vertex>();
            PathsCache = new List<SkiaSharp.SKPath>();
            Cards = GetCards();
            PlacePath = false;
            PlaceTown = false;
            PlaceVillage = true;
            PlaceThief = false;
            Turn = 0;
        }

        private List<Card> GetCards()
        {
            List<Card> result = new List<Card>()
            {
                new Card(
                   ImageSource.FromFile("Biblioteca.png"),
                    CardType.VictoryPoint, this),
                new Card(
                    
                    ImageSource.FromFile("Ayuntamiento.png"),
                    CardType.VictoryPoint, this),
                new Card(
                    
                    ImageSource.FromFile("Universidad.png"),
                    CardType.VictoryPoint, this),
                new Card(
                    
                    ImageSource.FromFile("Mercado.png"),
                    CardType.VictoryPoint, this),
                new Card(
                    
                    ImageSource.FromFile("Iglesia.png"),
                    CardType.VictoryPoint, this),
                new Card(
                    
                    ImageSource.FromFile("ConstruyeCarretera.png"),
                    CardType.PathBuilder, this),
                 new Card(
                    
                    ImageSource.FromFile("ConstruyeCarretera.png"),
                    CardType.PathBuilder, this),
                  new Card(
                    
                    ImageSource.FromFile("Monopolio.png"),
                    CardType.Monopoly, this), new Card(
                    
                    ImageSource.FromFile("Monopolio.png"),
                    CardType.Monopoly, this),
                   new Card(
                    
                    ImageSource.FromFile("Descubrimiento.png"),
                    CardType.Discovery, this),
                    new Card(
                    
                    ImageSource.FromFile("Descubrimiento.png"),
                    CardType.Discovery, this),
            };
            for (int i = 0; i < 18; i++)
            {
                result.Add(new Card(
                   ImageSource.FromFile("Caballero.png"),
                    CardType.Knight, this));
            }
            return result;
        }

        public void HandleDiceRoll(int dice)
        {
            if (dice == 7)
            {
                PlaceThief = true;
            }
            else
            {
                foreach (Player player in Players)
                {
                    player.DiceRoll(dice);
                }
            }
        }

        public void GetNextPlayer()
        {
            if (playerIndex == Players.Count - 1)
            {
                Turn += 1;
            }
            if (Turn == 1 && playerIndex == Players.Count - 1)
            {
                playerIndex = Players.Count - 1;
                CurrentPlayer = Players[playerIndex];
            }
            else
            {
                playerIndex = (playerIndex + 1) % Players.Count;
                CurrentPlayer = Players[playerIndex];
            }
        }

        public void ReversedNextPlayer()
        {
            if (playerIndex == 0)
            {
                Turn += 1;
            }
            playerIndex = (playerIndex - 1);
            if (playerIndex < 0)
            {
                playerIndex = 0;
            }
            CurrentPlayer = Players[playerIndex];
        }
    }
}

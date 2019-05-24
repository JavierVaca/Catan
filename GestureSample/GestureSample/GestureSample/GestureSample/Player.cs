using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestureSample
{
    public class Player
    {
        public string Name { get; set; }
        public SKPaint Color { get; set; }
        public Xamarin.Forms.Color XamColor { get; set; }
        public List<SKPath> Paths { get; set; }
        public List<Vertex> Towns { get; set; }
        public List<Vertex> Villages { get; set; }
        public List<Card> Cards { get; set; }
        public int Wood { get; set; }
        public int Brick { get; set; }
        public int Wheat { get; set; }
        public int Rock { get; set; }
        public int Sheep { get; set; }
        public int Score { get; internal set; }

        public Player(string name, SKColor color)
        {
            Name = name;
            Color = new SKPaint { Color = color};
            XamColor = Color.Color.ToFormsColor();
            Paths = new List<SKPath>();
            Towns = new List<Vertex>();
            Villages = new List<Vertex>();
            Cards = new List<Card>();
        }

        internal void DiceRoll(int dice)
        {
            foreach (Vertex village in Villages)
            {
                if (village.ID == dice && !village.Thief)
                {
                    AddResource(village.resourceType, 1);
                }
            }

            foreach (Vertex town in Towns)
            {
                if (town.ID == dice)
                {
                    AddResource(town.resourceType, 2);
                }
            }
        }

        public void AddResource(TileType resourceType, int i)
        {
            if (resourceType == TileType.Wood)
            {
                Wood += i;
            }
            else if (resourceType == TileType.Wheat)
            {
                Wheat += i;
            }
            else if (resourceType == TileType.Brick)
            {
                Brick += i;
            }
            else if (resourceType == TileType.Rock)
            {
                Rock += i;
            }
            else if (resourceType == TileType.Sheep)
            {
                Sheep += i;
            }
        }
    }
}

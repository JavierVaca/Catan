using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestureSample
{
    public class Board
    {
        public Hexagon[] Tiles { get; set; }
        public Vertex[] Paths { get; set; }
        public Edge[] Towns { get; set; }
        public Hexagon Desert { get; set; }
        public Hexagon[] SeaTiles { get; set; }

        public Board(float screenWidth, float screenHeight)
        {
            Tiles = new Hexagon[19];
            SeaTiles = new Hexagon[18];
            SetTiles(screenWidth, screenHeight);
            SetSeaTiles(screenWidth, screenHeight);
            GetRandomNumbers();
            GetTileType();
        }

        private void SetTiles(float screenWidth, float screenHeight)
        {
            float hexWidth = 1f / 6f * screenWidth;
            float hexVertexLength = 2f * (hexWidth / (2 * (float)Math.Sin(2.0944))) * (float)Math.Sin(0.523599);
            float xCenter = 0.5f * screenWidth;
            float xLeft = 0.5f * screenWidth + hexWidth + 0.01f * screenWidth;
            float xRight = 0.5f * screenWidth - hexWidth - 0.01f * screenWidth;
            
            // Define the board
            Tiles[7] = new Hexagon(0.5f * screenWidth + 2f * hexWidth + 0.02f * screenWidth, 0.5f * screenHeight, hexVertexLength);
            Tiles[8] = new Hexagon(xLeft, 0.5f * screenHeight, hexVertexLength);
            Tiles[9] = new Hexagon(xCenter, 0.5f * screenHeight, hexVertexLength);
            Tiles[10] = new Hexagon(xRight, 0.5f * screenHeight, hexVertexLength);
            Tiles[11] = new Hexagon(0.5f * screenWidth - 2f * hexWidth - 0.02f * screenWidth, 0.5f * screenHeight, hexVertexLength);

            Tiles[3] = new Hexagon(xLeft + hexWidth / 2f + 0.005f * screenWidth, 0.5f * screenHeight + hexWidth - 0.01f * screenHeight, hexVertexLength);
            Tiles[4] = new Hexagon(xCenter + hexWidth / 2f + 0.005f * screenWidth, 0.5f * screenHeight + hexWidth - 0.01f * screenHeight, hexVertexLength);
            Tiles[5] = new Hexagon(xCenter - hexWidth / 2f - 0.005f * screenWidth, 0.5f * screenHeight + hexWidth - 0.01f * screenHeight, hexVertexLength);
            Tiles[6] = new Hexagon(xRight - hexWidth / 2f - 0.005f * screenWidth, 0.5f * screenHeight + hexWidth - 0.01f * screenHeight, hexVertexLength);

            Tiles[0] = new Hexagon(xLeft, 0.5f * screenHeight + hexWidth * 2 - 0.02f * screenHeight, hexVertexLength);
            Tiles[1] = new Hexagon(xCenter, 0.5f * screenHeight + hexWidth * 2 - 0.02f * screenHeight, hexVertexLength);
            Tiles[2] = new Hexagon(xRight, 0.5f * screenHeight + hexWidth * 2 - 0.02f * screenHeight, hexVertexLength);

            Tiles[12] = new Hexagon(xLeft + hexWidth / 2f + 0.005f * screenWidth, 0.5f * screenHeight - hexWidth + 0.01f * screenHeight, hexVertexLength);
            Tiles[13] = new Hexagon(xCenter + hexWidth / 2f + 0.005f * screenWidth, 0.5f * screenHeight - hexWidth + 0.01f * screenHeight, hexVertexLength);
            Tiles[14] = new Hexagon(xCenter - hexWidth / 2f - 0.005f * screenWidth, 0.5f * screenHeight - hexWidth + 0.01f * screenHeight, hexVertexLength);
            Tiles[15] = new Hexagon(xRight - hexWidth / 2f - 0.005f * screenWidth, 0.5f * screenHeight - hexWidth + 0.01f * screenHeight, hexVertexLength);

            Tiles[16] = new Hexagon(xLeft, 0.5f * screenHeight - (hexWidth * 2) + 0.02f * screenHeight, hexVertexLength);
            Tiles[17] = new Hexagon(xCenter, 0.5f * screenHeight - (hexWidth * 2) + 0.02f * screenHeight, hexVertexLength);
            Tiles[18] = new Hexagon(xRight, 0.5f * screenHeight - (hexWidth * 2) + 0.02f * screenHeight, hexVertexLength);
        }

        private void SetSeaTiles(float screenWidth, float screenHeight)
        {
            float hexWidth = 1f / 6f * screenWidth;
            float hexVertexLength = 2f * (hexWidth / (2 * (float)Math.Sin(2.0944))) * (float)Math.Sin(0.523599);
            float xCenter = 0.5f * screenWidth;
            float xLeft = 0.5f * screenWidth + hexWidth + 0.01f * screenWidth;
            float xRight = 0.5f * screenWidth - hexWidth - 0.01f * screenWidth;

            SeaTiles[0] = new Hexagon(xLeft + hexWidth / 2f + 0.005f * screenWidth, 0.5f * screenHeight - (hexWidth * 3) + 0.03f * screenHeight, hexVertexLength);
            SeaTiles[1] = new Hexagon(xCenter + hexWidth / 2f + 0.005f * screenWidth, 0.5f * screenHeight - (hexWidth * 3) + 0.03f * screenHeight, hexVertexLength);
            SeaTiles[2] = new Hexagon(xCenter - hexWidth / 2f - 0.005f * screenWidth, 0.5f * screenHeight - (hexWidth * 3) + 0.03f * screenHeight, hexVertexLength);
            SeaTiles[3] = new Hexagon(xRight - hexWidth / 2f - 0.005f * screenWidth, 0.5f * screenHeight - (hexWidth * 3) + 0.03f * screenHeight, hexVertexLength);

            SeaTiles[4] = new Hexagon(0.5f * screenWidth + 2f * hexWidth + 0.02f * screenWidth, 0.5f * screenHeight - (hexWidth * 2) + 0.02f * screenHeight, hexVertexLength);
            SeaTiles[5] = new Hexagon(0.5f * screenWidth - 2f * hexWidth - 0.02f * screenWidth, 0.5f * screenHeight - (hexWidth * 2) + 0.02f * screenHeight, hexVertexLength);

            SeaTiles[6] = new Hexagon(xRight - 3f * (hexWidth / 2f + 0.005f * screenWidth), 0.5f * screenHeight - hexWidth + 0.01f * screenHeight, hexVertexLength);
            SeaTiles[7] = new Hexagon(xLeft + 3f * (hexWidth / 2f + 0.005f * screenWidth), 0.5f * screenHeight - hexWidth + 0.01f * screenHeight, hexVertexLength);

            SeaTiles[8] = new Hexagon(0.5f * screenWidth + 3f * hexWidth + 0.03f * screenWidth, 0.5f * screenHeight, hexVertexLength);
            SeaTiles[9] = new Hexagon(0.5f * screenWidth - 3f * hexWidth - 0.03f * screenWidth, 0.5f * screenHeight, hexVertexLength);

            SeaTiles[10] = new Hexagon(xRight - 3f * ((hexWidth / 2f ) + 0.005f * screenWidth), 0.5f * screenHeight + hexWidth - 0.01f * screenHeight, hexVertexLength);
            SeaTiles[11] = new Hexagon(xLeft + 3f * ((hexWidth / 2f) + 0.005f * screenWidth), 0.5f * screenHeight + hexWidth - 0.01f * screenHeight, hexVertexLength);

            SeaTiles[12] = new Hexagon(0.5f * screenWidth - 2f * hexWidth - 0.02f * screenWidth, 0.5f * screenHeight + hexWidth * 2 - 0.02f * screenHeight, hexVertexLength);
            SeaTiles[13] = new Hexagon(0.5f * screenWidth + 2f * hexWidth + 0.02f * screenWidth, 0.5f * screenHeight + hexWidth * 2 - 0.02f * screenHeight, hexVertexLength);

            SeaTiles[14] = new Hexagon(xLeft + hexWidth / 2f + 0.005f * screenWidth, 0.5f * screenHeight + (hexWidth * 3) - 0.03f * screenHeight, hexVertexLength);
            SeaTiles[15] = new Hexagon(xCenter + hexWidth / 2f + 0.005f * screenWidth, 0.5f * screenHeight + (hexWidth * 3) - 0.03f * screenHeight, hexVertexLength);
            SeaTiles[16] = new Hexagon(xCenter - hexWidth / 2f - 0.005f * screenWidth, 0.5f * screenHeight + (hexWidth * 3) - 0.03f * screenHeight, hexVertexLength);
            SeaTiles[17] = new Hexagon(xRight - hexWidth / 2f - 0.005f * screenWidth, 0.5f * screenHeight + (hexWidth * 3) - 0.03f * screenHeight, hexVertexLength);
        }

        private void GetTileType()
        {
            Random random = new Random();

            SKPaint[] colors = new SKPaint[6]
            {
                new SKPaint() {Color = SKColors.WhiteSmoke},
                new SKPaint() {Color = SKColors.Gray},
                new SKPaint() {Color = new SKColor(233, 207, 39) },
                new SKPaint() {Color = SKColors.OrangeRed},
                new SKPaint() {Color = SKColors.DarkGreen}, 
                new SKPaint() {Color = SKColors.Wheat},
            };

            List<TileType> tileTypes = new List<TileType>
            {
                TileType.Brick,
                TileType.Brick,
                TileType.Brick,
                TileType.Wood,
                TileType.Wood,
                TileType.Wood,
                TileType.Wood,
                TileType.Wheat,
                TileType.Wheat,
                TileType.Wheat,
                TileType.Wheat,
                TileType.Sheep,
                TileType.Sheep,
                TileType.Sheep,
                TileType.Sheep,
                TileType.Rock,
                TileType.Rock,
                TileType.Rock,
            };
            Shuffle(tileTypes, random);

            for (int i = 0; i < 19; i++)
            {
                if (Tiles[i].GetNumber() == "7")
                {
                    Tiles[i].SetTileType(TileType.Desert);
                    Tiles[i].HexPaint = colors[5];
                    Desert = Tiles[i];
                    if (i != 18)
                    {
                        tileTypes.Add(tileTypes[i]);
                    }
                }
                else
                {
                    var currentTileType = tileTypes[i];
                    Tiles[i].SetTileType(currentTileType);
                    int index = (int)currentTileType;
                    Tiles[i].HexPaint = colors[index];
                }
            }
        }

        private void GetRandomNumbers()
        {
            Random random = new Random();

            List<string> numbers = new List<string>{"2","3","3","4","4","5",
                "5","6","6","8","8","9","9","10","10","11","11","12", "7" };
            Shuffle(numbers, random);
            for (int i = 0; i  < 19; i++)
            {
                Tiles[i].SetNumber(numbers[i]);
            }
        }

        //Shuffle using Fisher-Yates algorithm
        public static void Shuffle<T>(IList<T> list, Random rnd)
        {
            for (var i = 0; i < list.Count; i++)
                Swap(list, i, rnd.Next(i, list.Count));
        }

        public static void Swap<T>(IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}

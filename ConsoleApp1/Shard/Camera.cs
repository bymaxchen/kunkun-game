using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Shard
{
    public class Camera
    {
        public float X { get; set; }

        public float Y { get; set; }
        public int Width { get; }
        public int Height { get; }

        public Camera(int width, int height)
        {
            Width = width;
            Height = height;
            X = 0;
            Y = 0;
        }

        public void Update(Vector2 playerPosition, int characterWidth, int levelWidth, int levelHeight)
        {
            // Center the camera on the player, but don't go out of the level bounds
            X = Math.Max(0, Math.Min(levelWidth - Width, playerPosition.X - (Width / 2) + characterWidth / 2));
            Y = Math.Max(0, Math.Min(levelHeight - Height, playerPosition.Y - (Height / 2)));
        }
    }
}

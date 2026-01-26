using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace FriendsPoint.GameObjects {
    public class Map : SquareHBoxObj {                                                          // Класс карты, наследует класс GameObject
        public Map(Vector2 position, int width, int height) {
            Width = width;
            Height = height;
            Layer = 0f;
            ScreenPosition = position;
            Position = position;
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Xml.Linq;

public class Map : GameObject {                                                          // Класс карты, наследует класс GameObject
    public Map(Vector2 position, int width, int height) {
        Width = width;
        Height = height;
        Layer = 0.5f;
        Scale = 1.0f;
        ScreenPosition = position;
        Position = position;
    }
    public override void Draw(SpriteBatch render, Rectangle? sourceRectangle = null) {   // Отрисовка карты, здесь я переопределяю функцию draw() из GameObject. Если в него нужно передать какой нибудь Rectangle, то надо писать такую конструкцию, если не нужно, то функцию можно не переопределять

        Rectangle Rect = new Rectangle((int)ScreenPosition.X, (int)ScreenPosition.Y, Width, Height);
        base.Draw(render, Rect);
    }

}
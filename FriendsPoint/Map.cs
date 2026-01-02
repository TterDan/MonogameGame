using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class Map {
    public Vector2 Position;    // Смещение карты
    public int Width;           // Ширина карты
    public int Height;          // Высота карты
    public Texture2D Texture;   // Текстура карты
    public Texture2D BlackTexture;     // Пиксель
    public float Rotation = 0;

    public Map(Vector2 position, int width, int height) {
        Position = position;
        Width = width;
        Height = height;
    }

    // Метод для отрисовки карты
    public void Draw(SpriteBatch render) {
        Rectangle Rect = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        render.Draw(
            BlackTexture, 
            Position, 
            Rect, 
            Color.Black * 0.5f, 
            0.0f,
            new Vector2(Height, Width) * 0.5f,
            0.35f,  
            SpriteEffects.None,
            0.0f);
    }

}
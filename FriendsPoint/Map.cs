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
    public Texture2D Pixel;     // Пиксель
    public float Rotation = 0;

    public Map(Vector2 position, int width, int height) {
        Position = position;
        Width = width;
        Height = height;
    }

    // Метод для отрисовки карты
    public void Draw(SpriteBatch spriteBatch) {
        if (Texture != null) {
            Rectangle Rect = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

            spriteBatch.Draw(
                Texture, 
                Position, // Положение 
                null, // Прямоугольник
                Color.Blue, // Цвет
                Rotation, // Вращение
                new Vector2(Texture.Width * 0.5f, Texture.Height * 0.5f), // Центр объекта, вокруг которого происходит вращение и тд.
                0.35f, // Масштабирование
                SpriteEffects.None, // Отражение по горизонтали и вертикали
                0.0f // Глубина
                );

            spriteBatch.Draw(
                Pixel, 
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

}
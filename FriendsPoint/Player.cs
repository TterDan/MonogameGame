using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class Player {
    public Vector2 Position;    // Позиция игрока
    public int Width = 170;     // Ширина прямоугольника
    public int Height = 170;    // Высота прямоугольника
    public Texture2D Texture;   // Текстура игрока
    public Texture2D Pixel; // Пиксель
    public float Rotation = 0;
    public Player(Vector2 startPosition) {
        Position = startPosition;
    }

    public void direction(Point mousePosition)
    {
        Vector2 mousedirection = new Vector2(mousePosition.X - Position.X, mousePosition.Y - Position.Y);
        Rotation = (float)Math.Atan2(mousedirection.Y, mousedirection.X) + MathHelper.PiOver2;
    }

    // Метод для отрисовки игрока
    public void Draw(SpriteBatch spriteBatch) {
        if (Texture != null) {
            Rectangle Rect = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

            spriteBatch.Draw(
                Texture, 
                Position, // Положение 
                null, // Прямоугольник
                Color.White, // Цвет
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
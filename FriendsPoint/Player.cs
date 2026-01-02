using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class Player {
    public Vector2 Position;    // Позиция игрока
    public Vector2 PlayerScreenPos;    // Положение игрока на экране (в центре)
    public int Width;     // Ширина хитбокса игрока
    public int Height;    // Высота хитбокса игрока
    public float MoveSpeed;
    public Texture2D Texture;   // Текстура игрока
    public Texture2D BlackTexture; // 
    public float Rotation = 0;

    public Player(Vector2 startPosition, int width, int height, float moveSpeed, Vector2 playerScreenPos) {
        Position = startPosition;
        Width = width;
        Height = height;
        MoveSpeed = moveSpeed;
        PlayerScreenPos = playerScreenPos;
    }

    public void rotate(Point mousePosition)
    {
        Vector2 mousedirection = new Vector2(mousePosition.X - PlayerScreenPos.X, mousePosition.Y - PlayerScreenPos.Y);
        Rotation = (float)Math.Atan2(mousedirection.Y, mousedirection.X) + MathHelper.PiOver2;
    }
    public void move(Vector2 moveDirection, Map map, SomeObject obj, List<GameObject> objects) // функция перемещения всех обьектов на карте, также добавляет к игроку значения к координате для удобства, про List<GameObject> писал в Main.cs
    {
        Position += moveDirection * MoveSpeed;
        map.Position -= moveDirection * MoveSpeed;
        obj.Position -= moveDirection * MoveSpeed;
    }

    // Метод для отрисовки игрока
    public void Draw(SpriteBatch render) {
        if (Texture != null) {
            Rectangle Rect = new Rectangle((int)PlayerScreenPos.X, (int)PlayerScreenPos.Y, Width, Height);

            render.Draw(
                Texture, 
                PlayerScreenPos, // Положение 
                null, // Прямоугольник
                Color.White, // Цвет
                Rotation, // Вращение
                new Vector2(Texture.Width * 0.5f, Texture.Height * 0.5f), // Центр объекта, вокруг которого происходит вращение и тд.
                0.35f, // Масштабирование
                SpriteEffects.None, // Отражение по горизонтали и вертикали
                0.0f // Глубина
                );

            render.Draw(
                BlackTexture, 
                PlayerScreenPos, 
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
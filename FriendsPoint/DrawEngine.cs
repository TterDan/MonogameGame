using FriendsPoint.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
public class DrawEngine {                                                          // Статический класс камеры
    static public GraphicsDevice GraphicsDevice;
    static public SpriteBatch SpriteBatch;
    static public float GameScale = 1.7f;
    static public SpriteFont GameFont;
    static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Rectangle drawRectangle, Vector2 centerPosition, Color? nullableColor, float rotation = 0f, float scale = 1f, float layer = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {
        scale *= GameScale;
        Color color = nullableColor ?? Color.Black;

        Texture2D texture = new Texture2D(GraphicsDevice, 1, 1);
        texture.SetData(new[] { Color.Black });

        spriteBatch.Draw(
            texture,                //Текстура
            position,               // Положение 
            drawRectangle,          // Область текстуры для отрисовки
            color,                  // Цвет
            rotation,               // Вращение
            centerPosition,         // Центр объекта, вокруг которого происходит вращение и тд
            scale * GameScale,      // Масштабирование
            spriteEffect,     // Отражение по горизонтали и вертикали
            layer                   // Слой
        );
    }
    static public void DrawCircle(SpriteBatch spriteBatch, Vector2 position, Rectangle? nullableDrawRectangle, Vector2? nullableCenterPosition, int radius, Color? nullableColor, float rotation = 0f, float scale = 1f, float layer = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {

        int diameter = radius * 2;

        Rectangle drawRectangle = nullableDrawRectangle ?? new Rectangle(0, 0, diameter, diameter);
        Vector2 centerPosition = nullableCenterPosition ?? new Vector2(radius, radius);
        Color color = nullableColor ?? Color.Black;

        Texture2D texture = new Texture2D(GraphicsDevice, diameter, diameter);
        Color[] data = new Color[diameter * diameter];
        Vector2 center = new Vector2(radius);
        for (int y = 0; y < diameter; y++) {
            for (int x = 0; x < diameter; x++) {
                int index = y * diameter + x;
                Vector2 pos = new Vector2(x, y);

                if (Vector2.Distance(pos, center) <= radius)
                    data[index] = color;
                else
                    data[index] = Color.Transparent;
            }
        }

        texture.SetData(data);

        spriteBatch.Draw(
            texture,                //Текстура
            position,               // Положение 
            drawRectangle,          // Область текстуры для отрисовки
            color,                  // Цвет
            rotation,               // Вращение
            centerPosition,         // Центр объекта, вокруг которого происходит вращение и тд
            scale * GameScale,      // Масштабирование
            SpriteEffects.None,     // Отражение по горизонтали и вертикали
            layer                   // Слой
        );
    }
    static public void DrawLine(SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color? nullableColor, float thickness = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {

        Color color = nullableColor ?? Color.Black;
        Texture2D lineTexture = new Texture2D(GraphicsDevice, 1, 1);
        lineTexture.SetData(new[] { Color.White });

        Vector2 delta = end - start;
        float length = delta.Length();
        float angle = MathF.Atan2(delta.Y, delta.X);

        spriteBatch.Draw(
            lineTexture,
            start,
            null,
            color,
            angle,
            Vector2.Zero,
            new Vector2(length, thickness),
            SpriteEffects.None,
            0f
        );
    }

    static public void DrawTexture(SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Rectangle? nullableDrawRectangle, Color? nullableColor, float rotation = 0f, float scale = 1f, float layer = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {
        if (texture == null) {
            System.Diagnostics.Debug.WriteLine("Error");
            return;
        }

        Color color = nullableColor ?? Color.White;
        Rectangle drawRectangle;

        if (nullableDrawRectangle == null) {
            drawRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        } else {
            drawRectangle = nullableDrawRectangle.Value;
        }
        Vector2 centerPosition = new Vector2(drawRectangle.Width / 2, drawRectangle.Height / 2);

        spriteBatch.Draw(
            texture,                //Текстура
            position,               // Положение 
            drawRectangle,          // Область текстуры для отрисовки
            color,                  // Цвет
            rotation,               // Вращение
            centerPosition,         // Центр объекта, вокруг которого происходит вращение и тд
            scale * GameScale,      // Масштабирование
            SpriteEffects.None,     // Отражение по горизонтали и вертикали
            layer                   // Слой
        );
    }
    
    static public void DrawText(SpriteBatch spriteBatch, Vector2 position, Vector2? nullableCenterPosition, string message, Color? nullableColor, float rotation = 0f, float scale = 1f, float layer = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {
        
        Vector2 centerPosition = nullableCenterPosition ?? Vector2.Zero;
        Color color = nullableColor ?? Color.Black;

        spriteBatch.DrawString(GameFont, message, position, color, rotation, centerPosition, scale, SpriteEffects.None, layer);
    }
}
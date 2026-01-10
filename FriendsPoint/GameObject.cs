using FriendsPoint;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

abstract public class GameObject        // Абстрактный класс для всех игровых объектов, нужен чтобы не писать каждый раз в объектах функции отрисовки и базовые поля.
{
    public Vector2 ScreenPosition; // Соответственно базовые поля
    public Vector2 Position;
    public int Width;
    public int Height;
    public float Layer;
    public Texture2D Texture;
    public float Scale = 0.35f;
    public float Rotation = 0f;
    public Microsoft.Xna.Framework.Color TextureColor = Color.White;

    public virtual void Draw(SpriteBatch render, Rectangle? sourceRectangle = null) {       // Соответственно функция отрисовки, передаю сюда SpriteBatch и sourceRectangle, если вдруг не было передано sourceRectangle, то оно заменится на null и не вызовет ошибку
        if (Texture != null) {      // Если у объекта нет текстуры, то вызовет ошибку, поэтому прерываю действие здесь
            render.Draw(
            Texture,                //Текстура
            ScreenPosition,         // Положение 
                sourceRectangle,    // Область текстуры для отрисовки
                TextureColor,       // Цвет
                Rotation,           // Вращение
                new Vector2(Texture.Width, Texture.Height) * 0.5f, // Центр объекта, вокруг которого происходит вращение и тд
                Scale,              // Масштабирование
                SpriteEffects.None, // Отражение по горизонтали и вертикали
                Layer               // Слой
                );
        }
        OtherDraw(render);          // Функция, если вдруг для объекта нужно отрисовать что-то ещё
    }

    public virtual void OtherDraw(SpriteBatch render) {         // Функция конкретно здесь пустая, потому что не у всех объектов есть что-то ещё для отрисовки, а если и есть, то ОБЯЗАТЕЛЬНО функцию нужно переопределять.
        
    }
}
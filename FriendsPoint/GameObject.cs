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

    public float TextureLayer = 0.9f;
    public float Layer = 0.8f;

    public Texture2D Texture;
    public Texture2D HitboxTexture;

    public float HitboxOpacity = 1.0f;
    public float TextureOpacity = 1.0f;

    public float TextureScale = 1.4f;
    public float Scale = 1.4f;

    public float Rotation = 0f;

    public Rectangle? DrawRect = null;

    public Microsoft.Xna.Framework.Color TextureColor = Color.White;
    public Microsoft.Xna.Framework.Color HitboxTextureColor = Color.White;

    public virtual void Draw(SpriteBatch render) {       // Соответственно функция отрисовки, передаю сюда SpriteBatch и sourceRectangle, если вдруг не было передано sourceRectangle, то оно заменится на null и не вызовет ошибку
        if (Texture != null) {      // Если у объекта нет текстуры, то вызовет ошибку, поэтому прерываю действие здесь
            render.Draw(
            Texture,                //Текстура
            ScreenPosition,         // Положение 
                null,    // Область текстуры для отрисовки
                TextureColor * TextureOpacity,       // Цвет
                Rotation,           // Вращение
                new Vector2(Texture.Width, Texture.Height) / 2, // Центр объекта, вокруг которого происходит вращение и тд
                TextureScale,              // Масштабирование
                SpriteEffects.None, // Отражение по горизонтали и вертикали
                Layer               // Слой
                );
        }
        if (HitboxTexture != null) {      // Если у объекта нет текстуры, то вызовет ошибку, поэтому прерываю действие здесь
            render.Draw(
            HitboxTexture,                //Текстура
            ScreenPosition,         // Положение 
                DrawRect,    // Область текстуры для отрисовки
                HitboxTextureColor * HitboxOpacity,       // Цвет
                Rotation,           // Вращение
                DrawRect == null ? new Vector2(Texture.Width, Texture.Height) / 2 : new Vector2(DrawRect.Value.Width, DrawRect.Value.Height) / 2, // Центр объекта, вокруг которого происходит вращение и тд
                Scale,              // Масштабирование
                SpriteEffects.None, // Отражение по горизонтали и вертикали
                Layer - 0.1f               // Слой
                );
        }
        OtherDraw(render);          // Функция, если вдруг для объекта нужно отрисовать что-то ещё
    }

    public virtual void OtherDraw(SpriteBatch render) {         // Функция конкретно здесь пустая, потому что не у всех объектов есть что-то ещё для отрисовки, а если и есть, то ОБЯЗАТЕЛЬНО функцию нужно переопределять.
        
    }
}
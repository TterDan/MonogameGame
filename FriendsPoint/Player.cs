using FriendsPoint;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

public class Player : GameObject {          // Класс игрока, наследует класс GameObject
    public float MoveSpeed;
    static public Texture2D BlackTexture;
    public string Weapon;                   // Текущее оружие игрока
    public bool flag;
    public Player(Vector2 startPosition, int width, int height, float moveSpeed, Vector2 playerScreenPos, string weapon) {
        Position = startPosition;
        Width = width;
        Height = height;
        MoveSpeed = moveSpeed;
        ScreenPosition = playerScreenPos;
        Weapon = weapon;
        Layer = 0.9f;
    }
    public void shot() {    // Функции на будущее

    }
    public void takeWeapon() {

    }
    public void throwWeapon() {

    }
    public void shiftLook() {

    }
    public void rotate(Point mousePosition) {                           // Функция поворота игрока в сторону мыши
        Vector2 mousedirection = new Vector2(mousePosition.X - ScreenPosition.X, mousePosition.Y - ScreenPosition.Y);
        Rotation = (float)Math.Atan2(mousedirection.Y, mousedirection.X) + MathHelper.PiOver2;
    }
    public void move(Vector2 moveDirection, List<GameObject> objects)   // Функция перемещения всех обьектов на карте
    {
        Position += moveDirection * MoveSpeed;                          // Изменение координат игрока
        for (int i = 0; i < objects.Count; i++) {
            if (objects[i] is Player) {
                continue;
            }
            objects[i].ScreenPosition = ScreenPosition + (objects[i].Position - Position); // Арифметика для перемещения объектов по экрану игрока (их реальная позиция в мире не меняется)
        }
    }
    public override void OtherDraw(SpriteBatch render) {                // Переопределяю функцию OtherDraw() из GameObject, чтобы отрисовать что-то еще помимо базовой отрисовки
        Rectangle Rect = new Rectangle((int)ScreenPosition.X, (int)ScreenPosition.Y, Width, Height);
        render.Draw(                                                    // Отрисовка хитбокса игрока
            BlackTexture,
            ScreenPosition,
            Rect,
            Color.Black * 0.5f,
            0.0f,
            new Vector2(Height, Width) * 0.5f,
            Scale,
            SpriteEffects.None,
            0.0f
        );

        if (Weapon != "hand")                                           // Отрисовка оружия в руке игрока
        {
            Rectangle weaponRect = new Rectangle((int)ScreenPosition.X, (int)ScreenPosition.Y, 50, 50);
            Vector2 WeaponOffset = new Vector2(20, 40);                 // Координаты для смещения оружия от игрока в его руке
            Vector2 WeaponPos = new Vector2((MathF.Cos(Rotation) * WeaponOffset.X) + (MathF.Cos(Rotation) * WeaponOffset.Y), (MathF.Sin(Rotation) * WeaponOffset.X) + (MathF.Sin(Rotation) * WeaponOffset.Y));      // Математика для определения смещения оружия от игрока в его руке
            render.Draw(
                BlackTexture,
                new Vector2(ScreenPosition.X + WeaponPos.X, ScreenPosition.Y + WeaponPos.Y),
                weaponRect,
                Color.Black,
                Rotation,
                new Vector2(Texture.Width, Texture.Height) * 0.5f,
                Scale,
                SpriteEffects.None,
                1.0f);
        }
    }
}
using FriendsPoint;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;

public class Player : GameObject {          // Класс игрока, наследует класс GameObject
    public float MoveSpeed;
    Vector2 CurrentSpeed = Vector2.Zero;
    public Vector2 ScreenCenter;
    static public Texture2D BlackTexture;
    public Weapon currentWeapon;            // Текущее оружие игрока
    public Rectangle Rect;
    public Player(Vector2 startPosition, int width, int height, float moveSpeed, Vector2 playerScreenPos, Weapon weapon) {
        Position = startPosition;
        Width = width;
        Height = height;
        MoveSpeed = moveSpeed;
        ScreenPosition = playerScreenPos;
        ScreenCenter = playerScreenPos;
        currentWeapon = weapon;
        Layer = 0.9f;
    }
    public void Shot() {    // Функции на будущее
        //  Если здесь попал во врага, то вызывается
        //  if (enemy.TakeDamage(Weapon.Damage) == true) {
        //      objects.RemoveAt(enemyIndex);
        //  }
    }
    public bool TakeWeapon(List<GameObject> objects) {
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i] is Weapon weapon)
            {
                if (Rect.Intersects(weapon.Rect))
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.E) && currentWeapon.Name == "hand")
                    {
                        currentWeapon = weapon;
                        objects.RemoveAt(i);
                        i--;
                    }
                    return true;
                }
            }
        }
        return false;
    }
    public Weapon ThrowWeapon(Texture2D blacktxtr) {
        Weapon wpn = new Weapon(blacktxtr, currentWeapon.Name, Position, currentWeapon.Width, currentWeapon.Width);
        currentWeapon.Name = "hand";
        return wpn;
    }
    public void ShiftLook(bool ShiftPressed, Point mousePosition) {
        Vector2 mouseDirectionForCamera;
        if (ShiftPressed) {
            mouseDirectionForCamera = new Vector2(mousePosition.X - ScreenCenter.X, mousePosition.Y - ScreenCenter.Y);
            mouseDirectionForCamera.Normalize();
        } else {
            mouseDirectionForCamera = Vector2.Zero;
        }
        Camera.ChangeShiftOffset(mouseDirectionForCamera);
    }
    public void rotate(Point mousePosition) {                           // Функция поворота игрока в сторону мыши
        Vector2 mouseDirection = new Vector2(mousePosition.X - ScreenPosition.X, mousePosition.Y - ScreenPosition.Y);
        Vector2 mouseDirectionNormalized = mouseDirection;
        mouseDirectionNormalized.Normalize();
        mouseDirectionNormalized *= 500f;
        Vector2 mouseDirectionForCamera = new Vector2(mousePosition.X - ScreenCenter.X, mousePosition.Y - ScreenCenter.Y) + mouseDirectionNormalized;
        Camera.ChangeMouseOffset(mouseDirectionForCamera);
        Rotation = (float)Math.Atan2(mouseDirection.Y, mouseDirection.X) + MathHelper.PiOver2;
    }

    public void move(Vector2 moveDirection, List<GameObject> objects)   // Функция перемещения всех обьектов на карте
    {
        if (moveDirection == Vector2.Zero) {
            CurrentSpeed = Vector2.Lerp(CurrentSpeed, Vector2.Zero, 0.3f);
        } else {
            Vector2 targetVelocity = moveDirection * MoveSpeed;
            CurrentSpeed = Vector2.Lerp(CurrentSpeed, targetVelocity, 0.3f);
        }
        Camera.ChangeWalkOffset(moveDirection);
        Position += CurrentSpeed;                         // Изменение координат игрока
        for (int i = 0; i < objects.Count; i++) {
            Vector2 normVectorSpeed = CurrentSpeed;
            normVectorSpeed.Normalize();
            if (objects[i] is Player) {
                ScreenPosition = ScreenCenter - Camera.CameraOffset;
                continue;
            }
            objects[i].ScreenPosition = ScreenPosition + (objects[i].Position - Position); // Арифметика для перемещения объектов по экрану игрока (их реальная позиция в мире не меняется)
        }
    }
    public override void OtherDraw(SpriteBatch render) {                // Переопределяю функцию OtherDraw() из GameObject, чтобы отрисовать что-то еще помимо базовой отрисовки
        Rect = new Rectangle((int)ScreenPosition.X - Width / 2, (int)ScreenPosition.Y - Height / 2, Width, Height);
        render.Draw(                                                    // Отрисовка хитбокса игрока
            BlackTexture,
            ScreenPosition,
            Rect,
            Color.Black * 0.5f,
            0.0f,
            new Vector2(Height, Width) * 0.5f,
            1.0f,
            SpriteEffects.None,
            0.8f
        );

        if (currentWeapon.Name != "hand")                                           // Отрисовка оружия в руке игрока
        {
            Rectangle weaponRect = new Rectangle((int)ScreenPosition.X, (int)ScreenPosition.Y, currentWeapon.Width, currentWeapon.Height);
            Vector2 WeaponOffset = new Vector2(20, 40);                              // Координаты для смещения оружия от игрока в его руке
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
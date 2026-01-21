using FriendsPoint;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading;

public class Player : CircleHBoxObj {          // Класс игрока, наследует класс GameObject

    public float MoveSpeed;
    Vector2 CurrentSpeed = Vector2.Zero;
    public Vector2 ScreenCenter;
    public Weapon currentWeapon;            // Текущее оружие игрока
    public Vector2 mouseDirection;
    public float wpnDifference;
    public Vector2 mousePos;
    public Vector2 ray;
    public bool isray;
    public double length;
    public Rectangle Rect;
    public double vectorsCorner;
    public Vector2 enemyDirection;
    public bool isdropped;
    public Weapon droppedWeapon;
    public Vector2 droppedDirection;
    public Player(GraphicsDevice GraphicsDevice, Vector2 startPosition, int radius, float moveSpeed, Vector2 playerScreenPos, Weapon weapon) {
        Position = startPosition;
        MoveSpeed = moveSpeed;
        ScreenPosition = playerScreenPos;
        ScreenCenter = playerScreenPos;
        currentWeapon = weapon;
        isray = false;
        Radius = radius;
        HitboxTexture = CreateCircleTexture(GraphicsDevice, Radius, Color.Black);
        TextureScale = Scale * 0.35f;
        DrawRect = new Rectangle(0, 0, Radius * 2, Radius * 2);
        HitboxOpacity = 0.5f;
    }

    public void Shot(List<GameObject> objects) {
        Vector2 direction = mousePos - ScreenPosition;
        ray = direction;
        Vector2.Normalize(ray);
        ray /= 10000;
        ray += ScreenPosition;
        for (int j = 0; j < objects.Count; j++)
        {
            if (objects[j] is Enemy enemy)
            {
                enemyDirection = enemy.ScreenPosition - ScreenPosition;
                Vector2 enemyRay = enemyDirection;
                Vector2.Normalize(enemyRay);
                double AB = direction.X * enemyDirection.X + direction.Y * enemyDirection.Y;
                double moduleA = Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);
                double moduleB = Math.Sqrt(enemyDirection.X * enemyDirection.X + enemyDirection.Y * enemyDirection.Y);
                double corner = AB / (moduleA * moduleB);
                float diffEnemy = (enemy.ScreenPosition - ray).Length();
                float diffPlayer = (enemy.ScreenPosition - ScreenPosition).Length();
                vectorsCorner = Math.Acos(corner);
                length = moduleB * Math.Sin(vectorsCorner);
                Rectangle RectEnemy = new Rectangle((int)enemy.ScreenPosition.X - enemy.Radius, (int)enemy.ScreenPosition.Y - enemy.Radius, enemy.Radius * 2, enemy.Radius * 2);
                if (length < enemy.Radius && diffEnemy < diffPlayer)
                {
                    objects.RemoveAt(j);
                    break;
                }
            }
        }
    }

    public bool TakeWeapon(List<GameObject> objects) {
        for (int i = 0; i < objects.Count; i++)
        {
            Rectangle RectPlayer = new Rectangle((int)Position.X - Radius, (int)Position.Y - Radius, Radius * 2, Radius * 2);
            if (objects[i] is Weapon weapon)
            {

                Rectangle RectWeapon = new Rectangle((int)weapon.Position.X - weapon.Radius, (int)weapon.Position.Y - weapon.Radius, weapon.Radius * 2, weapon.Radius * 2);

                if (RectPlayer.Intersects(RectWeapon))
                {
                    WeaponDegress(weapon.Position);
                    if (Keyboard.GetState().IsKeyDown(Keys.E) && currentWeapon.Name == "hand" && wpnDifference < 0.4 && wpnDifference > -0.4 && !weapon.isflying)
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

    public void WeaponDegress(Vector2 position)
    {
        Vector2 weaponDirection = new Vector2(position.X - Position.X, position.Y - Position.Y);
        float weaponRotate = (float)Math.Atan2(weaponDirection.Y, weaponDirection.X) + MathHelper.PiOver2;
        if(weaponRotate < 0 && Rotation < 0)
            wpnDifference = Math.Abs(weaponRotate) - Math.Abs(Rotation);
        else
           wpnDifference = Math.Abs(weaponRotate) - Rotation;
    }

    public Weapon ThrowWeapon()
    {
        droppedWeapon = currentWeapon;
        droppedDirection = mouseDirection;
        isdropped = true;
        return currentWeapon;
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
        mousePos = new Vector2(mousePosition.X, mousePosition.Y);
        mouseDirection = new Vector2(mousePosition.X - ScreenPosition.X, mousePosition.Y - ScreenPosition.Y);
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
            if (objects[i] is Player) {
                ScreenPosition = ScreenCenter - Camera.CameraOffset;
                continue;
            }
            objects[i].ScreenPosition = ScreenPosition + (objects[i].Position - Position); // Арифметика для перемещения объектов по экрану игрока (их реальная позиция в мире не меняется)
        }
    }
    public override void OtherDraw(SpriteBatch render) {                // Переопределяю функцию OtherDraw() из GameObject, чтобы отрисовать что-то еще помимо базовой отрисовки
        System.Diagnostics.Debug.WriteLine(ScreenCenter);

        if (currentWeapon.Name != "hand")                                           // Отрисовка оружия в руке игрока
        {
            Rectangle weaponRect = new Rectangle((int)ScreenPosition.X, (int)ScreenPosition.Y, currentWeapon.Radius*2, currentWeapon.Radius*2);
            Vector2 WeaponOffset = -new Vector2(40, 55);                              // Координаты для смещения оружия от игрока в его руке
            float fixedRotation = Rotation + 90 * MathF.PI / 180;
            float cosRotation = MathF.Cos(fixedRotation);
            float sinRotation = MathF.Sin(fixedRotation);
            Vector2 WeaponPos = new Vector2(cosRotation * WeaponOffset.X - sinRotation * WeaponOffset.Y, sinRotation * WeaponOffset.X + cosRotation * WeaponOffset.Y);      // Математика для определения смещения оружия от игрока в его руке
            currentWeapon.Position = Position;

            render.Draw(
                currentWeapon.HitboxTexture,
                new Vector2(ScreenPosition.X + WeaponPos.X, ScreenPosition.Y + WeaponPos.Y),
                currentWeapon.DrawRect,
                Color.Black,
                fixedRotation,
                new Vector2(currentWeapon.DrawRect.Value.Width, currentWeapon.DrawRect.Value.Height) / 2,
                Scale,
                SpriteEffects.None,
                1.0f
            );
        }
        //render.Draw(
        //    HitboxTexture,
        //    ScreenPosition,
        //    DrawRect,
        //    Color.Black,
        //    0,
        //    new Vector2(DrawRect.Value.Width, DrawRect.Value.Height) / 2,
        //    Scale,
        //    SpriteEffects.None,
        //    1.0f
        //);
    }
}
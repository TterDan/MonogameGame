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
    public Vector2 mousePosition;
    public Rectangle Rect;
    public bool isdropped;
    public Weapon droppedWeapon;
    public Vector2 droppedDirection;
    public float Health = 100f;

    public int AdditionalHitboxRadius;          // Дополнительный хитбокс, нужный для оценки расстояния подбора оружия, движения врагов
    public Texture2D AdditionalHitboxTexture;

    public Player(GraphicsDevice GraphicsDevice, Vector2 startPosition, int radius, int additionalHitboxRadius, float moveSpeed, Vector2 playerScreenPos, Weapon weapon) {
        Position = startPosition;
        MoveSpeed = moveSpeed;
        ScreenPosition = playerScreenPos;
        ScreenCenter = playerScreenPos;
        currentWeapon = weapon;
        Radius = radius;
        AdditionalHitboxRadius = additionalHitboxRadius;
        HitboxTexture = CreateCircleTexture(GraphicsDevice, Radius, Color.Black);
        AdditionalHitboxTexture = CreateCircleTexture(GraphicsDevice, AdditionalHitboxRadius, Color.Black);
        TextureScale = Scale * 0.35f;
        DrawRect = new Rectangle(0, 0, Radius * 2, Radius * 2);
        HitboxOpacity = 0.5f;
    }

    public void UseWeapon(List<GameObject> objects) {
        Vector2 direction = mousePosition - ScreenPosition;
        if (currentWeapon.Type == "Melee") {
            Beat(objects);
        }
        if (currentWeapon.Type == "Throwing") {

        }
        if (currentWeapon.Type == "Gun") {
            Shot(objects, direction);
        }
    }
    public void Beat(List<GameObject> objects) {
        List<int> IndexesOfNearestObjects = new List<int> { };
        for (int j = 0; j < objects.Count; j++) {
            if (objects[j] is Enemy enemy) {
                float enemyDifference = WeaponDegress(enemy.Position);
                if (AdditionalHitboxRadius + enemy.Radius * 2 >= (ScreenPosition - enemy.ScreenPosition).Length() && enemyDifference < 0.4 && enemyDifference > -0.4) {
                    Vector2 normalizedDirection = (ScreenPosition - enemy.ScreenPosition);
                    normalizedDirection.Normalize();
                    normalizedDirection *= 10.0f;
                    enemy.currentSpeed = normalizedDirection;

                    enemy.Health -= currentWeapon.Damage;
                    if (enemy.Health <= 0) {
                        objects.RemoveAt(j);
                    }
                }
            }
            if (objects[j] is Weapon weapon) {
                float enemyDifference = WeaponDegress(weapon.Position);
                if (AdditionalHitboxRadius + weapon.Radius * 2 >= (ScreenPosition - weapon.ScreenPosition).Length() && enemyDifference < 0.4 && enemyDifference > -0.4) {
                    Vector2 normalizedDirection = (ScreenPosition - weapon.ScreenPosition);
                    normalizedDirection.Normalize();
                    normalizedDirection *= 25.0f;
                    weapon.currentSpeed = normalizedDirection;
                }
            }
        }
    }
    public void Shot(List<GameObject> objects, Vector2 direction) {
        for (int j = 0; j < objects.Count; j++) {
            if (objects[j] is Enemy enemy) {
                Vector2 enemyDirection = enemy.ScreenPosition - ScreenPosition;
                float AB = direction.X * enemyDirection.X + direction.Y * enemyDirection.Y;
                float moduleA = MathF.Sqrt(direction.X * direction.X + direction.Y * direction.Y);
                float moduleB = MathF.Sqrt(enemyDirection.X * enemyDirection.X + enemyDirection.Y * enemyDirection.Y);
                float CosAngle = AB / (moduleA * moduleB);
                float Angle = MathF.Acos(CosAngle);
                float LengthBetweenDirectionAndEnemy = moduleB * MathF.Sin(Angle);
                Rectangle RectEnemy = new Rectangle((int)enemy.ScreenPosition.X - enemy.Radius, (int)enemy.ScreenPosition.Y - enemy.Radius, enemy.Radius * 2, enemy.Radius * 2);
                if (LengthBetweenDirectionAndEnemy < enemy.Radius && CosAngle > 0) {
                    enemy.Health -= currentWeapon.Damage;
                    if (enemy.Health <= 0) {
                        objects.RemoveAt(j);
                    }
                }
            }
        }
    }
    public bool TakeWeapon(List<GameObject> objects) {
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i] is Weapon weapon)
            {
                //System.Diagnostics.Debug.WriteLine((ScreenPosition - weapon.ScreenPosition).Length());
                //System.Diagnostics.Debug.WriteLine(AdditionalHitboxRadius + weapon.Radius * 2);
                if (AdditionalHitboxRadius + weapon.Radius * 2 >= (ScreenPosition - weapon.ScreenPosition).Length())
                {
                    float wpnDifference = WeaponDegress(weapon.Position);
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

    public float WeaponDegress(Vector2 position)
    {
        Vector2 weaponDirection = new Vector2(position.X - Position.X, position.Y - Position.Y);
        float weaponRotate = (float)MathF.Atan2(weaponDirection.Y, weaponDirection.X) + MathHelper.PiOver2;
        float wpnDifference;
        if (weaponRotate < 0 && Rotation < 0)
            wpnDifference = MathF.Abs(weaponRotate) - MathF.Abs(Rotation);
        else
           wpnDifference = MathF.Abs(weaponRotate) - Rotation;
        return wpnDifference;
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
    public void rotate(Point mousePositionPoint) {                           // Функция поворота игрока в сторону мыши
        mousePosition = new Vector2(mousePositionPoint.X, mousePositionPoint.Y);
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
        //System.Diagnostics.Debug.WriteLine(ScreenCenter);

        render.Draw(
            AdditionalHitboxTexture,                //Текстура
            ScreenPosition,         // Положение 
            new Rectangle(0,0, AdditionalHitboxRadius*2, AdditionalHitboxRadius*2),    // Область текстуры для отрисовки
            Color.Black * 0.2f,       // Цвет
            Rotation,           // Вращение
            new Vector2(AdditionalHitboxRadius, AdditionalHitboxRadius), // Центр объекта, вокруг которого происходит вращение и тд
            Scale,              // Масштабирование
            SpriteEffects.None, // Отражение по горизонтали и вертикали
            Layer               // Слой
        );

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
    }
}
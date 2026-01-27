using FriendsPoint;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace FriendsPoint.GameObjects {
    public class Player : CircleHBoxObj {          // Класс игрока, наследует класс GameObject

        public float MoveSpeed;
        Vector2 CurrentSpeed = Vector2.Zero;
        public Vector2 ScreenCenter;
        public Weapon currentWeapon;            // Текущее оружие игрока
        public Vector2 mouseDirection;
        public Vector2 mousePosition;
        public Rectangle Rect;
        public Vector2 droppedDirection;
        public float Health = 100f;

        public int AdditionalHitboxRadius;          // Дополнительный хитбокс, нужный для оценки расстояния подбора оружия, движения врагов
        public Texture2D AdditionalHitboxTexture;
        public Texture2D lineTexture;
        public Texture2D blackTexture;
        public SpriteBatch render;

        public double currentFireTime = 0;
        public double ShotDrawTimer = 70;
        public int currentShotDrawTime = 70;

        public Weapon viewWeapon;

        public SpriteFont font;

        public Player(GraphicsDevice GraphicsDevice, Vector2 startPosition, int radius, int additionalHitboxRadius, float moveSpeed, Vector2 playerScreenPos, Weapon weapon, SpriteFont Font) {
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
            font = Font;
        }

        public void UseWeapon(List<GameObject> objects) {
            Vector2 direction = mousePosition - ScreenPosition;
            if (currentFireTime > currentWeapon.fireRate) {
                currentFireTime = 0;
                if (currentWeapon.Type == "Melee") {
                    Beat(objects);
                }
                if (currentWeapon.Type == "Throwing") {
                    Throw(objects);
                }
                if (currentWeapon.Type == "Gun") {
                    Shot(objects, direction);
                }
                if (currentWeapon.Type == "Placing") {

                }
            }
        }
        public void Throw(List<GameObject> objects) {

        }
        public void Beat(List<GameObject> objects) {
            for (int j = 0; j < objects.Count; j++) {
                if (objects[j] is Enemy enemy) {
                    float enemyDifference = WeaponDegress(enemy.Position);
                    if (AdditionalHitboxRadius + enemy.Radius * 2 >= (ScreenPosition - enemy.ScreenPosition).Length() && enemyDifference < 0.4 && enemyDifference > -0.4) {
                        Vector2 normalizedDirection = (ScreenPosition - enemy.ScreenPosition);
                        normalizedDirection.Normalize();
                        normalizedDirection *= 10.0f;
                        enemy.currentSpeed += normalizedDirection;

                        enemy.TakeDamage(currentWeapon.Damage, objects, j);
                    }
                }
                if (objects[j] is Weapon weapon) {
                    float enemyDifference = WeaponDegress(weapon.Position);
                    if (AdditionalHitboxRadius + weapon.Radius * 2 >= (ScreenPosition - weapon.ScreenPosition).Length() && enemyDifference < 0.4 && enemyDifference > -0.4) {
                        Vector2 normalizedDirection = (ScreenPosition - weapon.ScreenPosition);
                        normalizedDirection.Normalize();
                        normalizedDirection *= 25.0f;
                        weapon.currentSpeed += normalizedDirection;
                    }
                }
            }
        }
        public void Shot(List<GameObject> objects, Vector2 direction) {
            for (int j = 0; j < objects.Count; j++) {
                if (objects[j] is Enemy enemy) {
                    Vector2 enemyDirection = enemy.ScreenPosition - ScreenPosition;
                    float AB = direction.X * enemyDirection.X + direction.Y * enemyDirection.Y;
                    float moduleA = direction.Length();
                    float moduleB = enemyDirection.Length();
                    float CosAngle = AB / (moduleA * moduleB);
                    float Angle = MathF.Acos(CosAngle);
                    float LengthBetweenDirectionAndEnemy = moduleB * MathF.Sin(Angle);
                    Rectangle RectEnemy = new Rectangle((int)enemy.ScreenPosition.X - enemy.Radius, (int)enemy.ScreenPosition.Y - enemy.Radius, enemy.Radius * 2, enemy.Radius * 2);
                    if (LengthBetweenDirectionAndEnemy < enemy.Radius && CosAngle > 0) {
                        enemy.TakeDamage(currentWeapon.Damage, objects, j);
                    }
                }
            }
            ShotDrawTimer = 0;
        }
        public bool TakeWeapon(List<GameObject> objects) {
            for (int i = 0; i < objects.Count; i++) {
                if (objects[i] is Weapon weapon) {
                    //System.Diagnostics.Debug.WriteLine((ScreenPosition - weapon.ScreenPosition).Length());
                    if (AdditionalHitboxRadius + weapon.AdditionRadius >= (weapon.Position - Position).Length() / Scale) {
                        float wpnDifference = WeaponDegress(weapon.Position);
                        if (Keyboard.GetState().IsKeyDown(Keys.E) && currentWeapon.Name == "Fist" && wpnDifference < 0.4 && wpnDifference > -0.4 && !weapon.isflying) {
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

        public float WeaponDegress(Vector2 position) {
            Vector2 weaponDirection = new Vector2(position.X - Position.X, position.Y - Position.Y);
            float weaponRotate = (float)MathF.Atan2(weaponDirection.Y, weaponDirection.X) + MathHelper.PiOver2;
            float wpnDifference;
            if (weaponRotate < 0 && Rotation < 0)
                wpnDifference = MathF.Abs(weaponRotate) - MathF.Abs(Rotation);
            else
                wpnDifference = MathF.Abs(weaponRotate) - Rotation;
            return wpnDifference;
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
        public void rotate(Point mousePositionPoint, List<GameObject> objects) {                           // Функция поворота игрока в сторону мыши
            mousePosition = new Vector2(mousePositionPoint.X, mousePositionPoint.Y);
            mouseDirection = new Vector2(mousePosition.X - ScreenPosition.X, mousePosition.Y - ScreenPosition.Y);
            Vector2 mouseDirectionNormalized = mouseDirection;
            mouseDirectionNormalized.Normalize();
            mouseDirectionNormalized *= 500f;
            Vector2 mouseDirectionForCamera = new Vector2(mousePosition.X - ScreenCenter.X, mousePosition.Y - ScreenCenter.Y) + mouseDirectionNormalized;
            Camera.ChangeMouseOffset(mouseDirectionForCamera);
            Rotation = (float)Math.Atan2(mouseDirection.Y, mouseDirection.X) + MathHelper.PiOver2;

            for (int i = 0; i < objects.Count; i++) {
                if (objects[i] is Weapon weapon) {
                    if ((weapon.ScreenPosition - mousePosition).Length() <= weapon.AdditionRadius) {
                        viewWeapon = weapon;
                        return;
                    }
                }
            }
            viewWeapon = null;
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
            System.Diagnostics.Debug.WriteLine(ShotDrawTimer);
            if (currentShotDrawTime >= ShotDrawTimer) {
                Vector2 secondPoint1 = (mousePosition - ScreenPosition);
                secondPoint1.Normalize();
                secondPoint1 *= ScreenCenter.X * 2;
                DrawLine(render, ScreenPosition, ScreenPosition + secondPoint1, Color.Red, 6f);
            }

            if (viewWeapon != null) {
                float minCord = MathF.Abs(mouseDirection.X) > MathF.Abs(mouseDirection.Y) ? mouseDirection.Y : mouseDirection.X;
                minCord = MathF.Abs(minCord);

                Vector2 firstPoint = ScreenPosition;
                Vector2 secondPoint = firstPoint + new Vector2(minCord * mouseDirection.X / Math.Abs(mouseDirection.X), minCord * mouseDirection.Y / Math.Abs(mouseDirection.Y));
                Vector2 thirdPoint = secondPoint + (mousePosition - secondPoint);

                DrawLine(render, firstPoint, secondPoint, Color.Black, 6f);
                DrawLine(render, secondPoint, thirdPoint, Color.Black, 6f);

                render.Draw(
                    blackTexture,                //Текстура
                    thirdPoint,         // Положение 
                    new Rectangle(0, 0, 120, 20),    // Область текстуры для отрисовки
                    Color.Black,       // Цвет
                    0,           // Вращение
                    new Vector2(120, 20) / 2, // Центр объекта, вокруг которого происходит вращение и тд
                    Scale,              // Масштабирование
                    SpriteEffects.None, // Отражение по горизонтали и вертикали
                    Layer - 0.1f               // Слой
                );

                render.DrawString(font, $"Take {viewWeapon.Name}", thirdPoint - new Vector2(60, 0), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1.0f);
            }


            render.Draw(
                AdditionalHitboxTexture,                //Текстура
                ScreenPosition,         // Положение 
                new Rectangle(0, 0, AdditionalHitboxRadius * 2, AdditionalHitboxRadius * 2),    // Область текстуры для отрисовки
                Color.Black * 0.2f,       // Цвет
                Rotation,           // Вращение
                new Vector2(AdditionalHitboxRadius, AdditionalHitboxRadius), // Центр объекта, вокруг которого происходит вращение и тд
                Scale,              // Масштабирование
                SpriteEffects.None, // Отражение по горизонтали и вертикали
                Layer               // Слой
            );

            if (currentWeapon.Name != "Fist")                                           // Отрисовка оружия в руке игрока
            {
                Rectangle weaponRect = new Rectangle((int)ScreenPosition.X, (int)ScreenPosition.Y, currentWeapon.Radius * 2, currentWeapon.Radius * 2);
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
                render.Draw(
                    currentWeapon.Texture,                //Текстура
                    new Vector2(ScreenPosition.X + WeaponPos.X, ScreenPosition.Y + WeaponPos.Y),         // Положение 
                    null,    // Область текстуры для отрисовки
                    currentWeapon.TextureColor,       // Цвет
                    fixedRotation,           // Вращение
                    new Vector2(Texture.Width, Texture.Height) / 2, // Центр объекта, вокруг которого происходит вращение и тд
                    currentWeapon.TextureScale,              // Масштабирование
                    SpriteEffects.None, // Отражение по горизонтали и вертикали
                    currentWeapon.Layer               // Слой
                );
            }
        }


        void DrawLine(SpriteBatch spriteBatch,
              Vector2 start,
              Vector2 end,
              Color color,
              float thickness = 1f) {
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
    }
}
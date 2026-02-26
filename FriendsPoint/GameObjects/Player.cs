
using System;

namespace FriendsPoint.GameObjects {
    public class Player : CircleHBoxObj {          // Класс игрока, наследует класс GameObject

        public Weapon Fist;
        public float MoveSpeed;
        Vector2 CurrentSpeed = Vector2.Zero;
        public Vector2 ScreenCenter;
        public Weapon currentWeapon;            // Текущее оружие игрока
        public Vector2 mouseDirection;
        public Vector2 mousePosition;

        public float Health = 100f;

        public SpriteBatch spriteBatch;
        public bool isShooting;
        public Vector2 currentOffset;
        public Vector2 recoilOffset;
        public int shotcount;
        public double currentFireTime = 0;
        public double ShotDrawTimer = 70;
        public int currentShotDrawTime = 70;
        public Vector2 bulletLine;
        public float coolDown;
        public Weapon viewWeapon;
        public SpriteFont font;
        public Vector2 mouseDirectionForCamera;
        public List<Vector2> bullets;
        public bool CanToTakeWeapon = false;


        public Player(GraphicsDevice GraphicsDevice, Vector2 startPosition, int radius, int additionRadius, float moveSpeed, Vector2 playerScreenPos, Weapon weapon, SpriteFont Font) {
            Position = startPosition;
            MoveSpeed = moveSpeed;
            ScreenPosition = playerScreenPos;
            ScreenCenter = playerScreenPos;
            currentWeapon = weapon;
            Radius = radius;
            AdditionRadius = additionRadius;
            TextureScale = Scale * 0.35f;
            DrawRect = new Rectangle(0, 0, Radius * 2, Radius * 2);
            HitboxOpacity = 0.5f;
            font = Font;
            bullets = new List<Vector2>();
        }
        public void UseWeapon(List<GameObject> enemies, List<GameObject> weapons) {
            Vector2 direction = mousePosition - ScreenPosition;
            if (currentFireTime > currentWeapon.fireRate) {
                if (currentWeapon.Type == "Melee") {
                    Beat(enemies, weapons);
                } else
                if (currentWeapon.Type == "Throwing") {
                    Throw(weapons);
                } else
                if (currentWeapon.Name == "Shotgun") {
                    for (int i = 0; i < 5; i++)
                        Shot(enemies, Vector2.Normalize(direction));
                } else
                if (currentWeapon.Type == "Semi-automatic" || currentWeapon.Type == "Automatic") {
                    Shot(enemies, Vector2.Normalize(direction));
                } else
                if (currentWeapon.Type == "Placing") {

                }
                currentFireTime = 0;
            }
        }
        public void Place() {

        }
        public void Throw(List<GameObject> objects) {

        }
        public void Beat(List<GameObject> enemies, List<GameObject> weapons) {
            for (int j = 0; j < enemies.Count; j++) {
                Enemy enemy = (Enemy)enemies[j];
                float enemyDifference = CalculateDegrees(enemy.Position);
                if (AdditionRadius + enemy.Radius >= (Position - enemy.Position).Length() && enemyDifference < 0.4 && enemyDifference > -0.4) {
                    Vector2 normalizedDirection = (ScreenPosition - enemy.ScreenPosition);
                    normalizedDirection.Normalize();
                    normalizedDirection *= 10.0f;
                    enemy.BeatForceVelocity += normalizedDirection;
                    enemy.TakeDamage(currentWeapon.Damage, enemies, j);
                }
            }
            for (int j = 0; j < weapons.Count; j++) {
                Weapon weapon = (Weapon)weapons[j];
                if (AdditionRadius + weapon.Radius >= (Position - weapon.Position).Length()) {
                    Vector2 mouseDirection = (mousePosition - ScreenPosition);
                    Vector2 weaponDirection = weapon.ScreenPosition - ScreenPosition;
                    float AB = mouseDirection.X * weaponDirection.X + mouseDirection.Y * weaponDirection.Y;
                    float moduleA = mouseDirection.Length();
                    float moduleB = weaponDirection.Length();
                    float CosAngle = AB / (moduleA * moduleB);
                    float Angle = MathF.Acos(CosAngle);
                    float LengthBetweenDirectionAndWeapon = moduleB * MathF.Sin(Angle);
                    if (LengthBetweenDirectionAndWeapon < weapon.AdditionRadius && CosAngle > 0) {
                        Vector2 force = Vector2.Normalize(weaponDirection);
                        force *= 20f;
                        weapon.currentSpeed -= force;
                    }
                }
            }
        }
        public Vector2 GetTrunkOffset() //в теории можно переделать под все оффсеты, например, для рукояток и тд, просто чтобы не было дублирования кода 
        {
            Vector2 OffsetX = -new Vector2(currentWeapon.TrunkOffset.X, currentWeapon.TrunkOffset.Y);                              // Координаты для смещения оружия от игрока в его руке
            Vector2 OffsetY = -new Vector2(currentWeapon.TrunkOffset.X, -currentWeapon.TrunkOffset.Y);
            float fixedRotation = Rotation + MathF.PI / 2;
            float cosRotation = MathF.Cos(fixedRotation);
            float sinRotation = MathF.Sin(fixedRotation);
            Vector2 trunkPos = new Vector2(cosRotation * OffsetX.X - sinRotation * OffsetY.Y, sinRotation * OffsetX.X + cosRotation * OffsetY.Y);
            return trunkPos;
        }
        public void Shot(List<GameObject> enemies, Vector2 direction) {
            shotcount += 1;
            Camera.ShotOffset(-mouseDirectionForCamera, currentWeapon.RecoilStrengthForCamera);
            Vector2 recoilTarget = new Vector2(currentWeapon.RecoilStrength, 0f);
            recoilOffset = Vector2.Lerp(recoilOffset, recoilTarget, 0.2f);
            Vector2 spread = pattern.getPattern(currentWeapon.PatternIndex, shotcount, CurrentSpeed);
            Vector2 finalDirection = new Vector2(direction.X + spread.X, direction.Y + spread.Y);
            for (int j = 0; j < enemies.Count; j++) {
                Enemy enemy = (Enemy)enemies[j];
                Vector2 enemyDirection = enemy.ScreenPosition - (ScreenPosition + GetTrunkOffset());
                float AB = finalDirection.X * enemyDirection.X + finalDirection.Y * enemyDirection.Y;
                float moduleA = finalDirection.Length();
                float moduleB = enemyDirection.Length();
                float CosAngle = AB / (moduleA * moduleB);
                float Angle = MathF.Acos(CosAngle);
                float LengthBetweenDirectionAndEnemy = moduleB * MathF.Sin(Angle);
                if (LengthBetweenDirectionAndEnemy < enemy.Radius && CosAngle > 0) {
                    enemy.TakeDamage(currentWeapon.Damage, enemies, j);
                }
                isShooting = false;
            }
            bullets.Add(finalDirection);
            ShotDrawTimer = 0;
        }
        public void TakeWeapon(List<GameObject> weapons, List<(Weapon, Vector2)> droppedWeapons) {
            if (CanToTakeWeapon == false || viewWeapon == null) {
                return;
            }
            int index = weapons.IndexOf(viewWeapon);
            if (currentWeapon.Name != "Fist") {
                weapons.Add(currentWeapon);
                droppedWeapons.Add((currentWeapon, Vector2.Normalize(mouseDirection)));
                Console.Log("Weapon dropped");
            }
            foreach (var weaponDrop in droppedWeapons) {
                if (weaponDrop.Item1 == viewWeapon) {
                    droppedWeapons.Remove(weaponDrop);
                    break;
                }
            }
            currentWeapon = viewWeapon;
            weapons.RemoveAt(index);
            return;
        }
        public void DropWeapon(List<GameObject> objects, List<(Weapon, Vector2)> droppedWeapons) {
            currentWeapon.Speed = currentWeapon.DropSpeed;
            currentWeapon.Position = Position;
            currentWeapon.Speed = 10f;
            objects.Add(currentWeapon);
            droppedWeapons.Add((currentWeapon, Vector2.Normalize(mouseDirection)));
            currentWeapon = Fist;
        }
        public float CalculateDegrees(Vector2 position) {
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
        public void rotate(Point mousePositionPoint, List<GameObject> weapons) {                           // Функция поворота игрока в сторону мыши
            mousePosition = new Vector2(mousePositionPoint.X, mousePositionPoint.Y);
            mouseDirection = new Vector2(mousePosition.X - ScreenPosition.X, mousePosition.Y - ScreenPosition.Y);
            Vector2 mouseDirectionNormalized = mouseDirection;
            mouseDirectionNormalized.Normalize();
            mouseDirectionNormalized *= 500f;
            mouseDirectionForCamera = new Vector2(mousePosition.X - ScreenCenter.X, mousePosition.Y - ScreenCenter.Y) + mouseDirectionNormalized;
            Camera.ChangeMouseOffset(mouseDirectionForCamera);
            Rotation = (float)Math.Atan2(mouseDirection.Y, mouseDirection.X) + MathHelper.PiOver2;
            for (int i = 0; i < weapons.Count; i++) {
                Weapon weapon = (Weapon)weapons[i];
                if (weapon.Radius >= (weapon.ScreenPosition - mousePosition).Length()) {
                    viewWeapon = weapon;
                    return;
                }
            }
            viewWeapon = null;
        }
        public void move(Vector2 moveDirection, List<GameObject> players, List<GameObject> weapons, List<GameObject> enemies, List<GameObject> otherGameObjects)   // Функция перемещения всех обьектов на карте
        {
            Vector2 targetVelocity = moveDirection * MoveSpeed;
            CurrentSpeed = Vector2.Lerp(CurrentSpeed, targetVelocity, 0.3f);
            Camera.ChangeWalkOffset(moveDirection);
            Position += CurrentSpeed;
        }
        public override void Draw(SpriteBatch spriteBatch) {
            DrawEngine.Circle(spriteBatch, CircleTexture, ScreenPosition, Radius, Color.Black, 0.34f, 0f, 1f / (300 / Radius));
            DrawEngine.Circle(spriteBatch, CircleTexture, ScreenPosition, AdditionRadius, Color.Black * 0.65f, 0.05f, 0f, 1f / (300 / AdditionRadius));
            DrawEngine.Texture(spriteBatch, Texture, ScreenPosition, 0.42f, Rotation, 0.7f);
            DrawEngine.RectFigure(spriteBatch, ScreenPosition, new Rectangle(0, 0, 20, 20), new Vector2(0, 0), Color.Yellow, 0f, 1f, 0.43f);

            if (!isShooting) {
                recoilOffset = Vector2.Lerp(recoilOffset, Vector2.Zero, 0.05f);
            }
            currentOffset = currentWeapon.handleOffset + recoilOffset;
            Rectangle weaponRect = new Rectangle((int)ScreenPosition.X, (int)ScreenPosition.Y, currentWeapon.Radius * 2, currentWeapon.Radius * 2);
            Vector2 WeaponOffset1 = -new Vector2(currentOffset.X, currentOffset.Y);                              // Координаты для смещения оружия от игрока в его руке
            Vector2 WeaponOffset2 = -new Vector2(currentOffset.X, -currentOffset.Y);
            float fixedRotation = Rotation + MathF.PI / 2;
            float cosRotation = MathF.Cos(fixedRotation);
            float sinRotation = MathF.Sin(fixedRotation);
            Vector2 WeaponPos1 = new Vector2(cosRotation * WeaponOffset1.X - sinRotation * WeaponOffset1.Y, sinRotation * WeaponOffset1.X + cosRotation * WeaponOffset1.Y);      // Математика для определения смещения оружия от игрока в его руке
            Vector2 WeaponPos2 = new Vector2(cosRotation * WeaponOffset2.X - sinRotation * WeaponOffset2.Y, sinRotation * WeaponOffset2.X + cosRotation * WeaponOffset2.Y);      // Математика для определения смещения оружия от игрока в его руке

            if (currentWeapon.Name == "Fist") {
                DrawEngine.Texture(spriteBatch, currentWeapon.Texture, ScreenPosition + WeaponPos1, 0.35f, Rotation);
                DrawEngine.Texture(spriteBatch, currentWeapon.Texture, ScreenPosition + WeaponPos2, 0.35f, Rotation);
            } else {
              DrawEngine.Texture(spriteBatch, currentWeapon.Texture, ScreenPosition + WeaponPos1, 0.35f, (Rotation) - MathF.PI / 2);
            }
            if (currentShotDrawTime >= ShotDrawTimer) {
                if(bullets.Count >= 0)
                {
                    for (int i = 0; i < bullets.Count; i++)
                    {
                        bullets[i].Normalize();
                        bullets[i] *= ScreenCenter.X * 2;
                        DrawEngine.Line(spriteBatch, ScreenPosition + GetTrunkOffset(), ScreenPosition + bullets[i], Color.Black, 6f, 1f);
                        bullets.RemoveAt(i);
                        i--;
                    }
                }
            }
            if (viewWeapon != null) {
                float minCord = MathF.Abs(mouseDirection.X) > MathF.Abs(mouseDirection.Y) ? mouseDirection.Y : mouseDirection.X;
                minCord = MathF.Abs(minCord);
                Vector2 firstPoint = ScreenPosition;
                Vector2 secondPoint = firstPoint + new Vector2(minCord * mouseDirection.X / Math.Abs(mouseDirection.X), minCord * mouseDirection.Y / Math.Abs(mouseDirection.Y));
                Vector2 thirdPoint = secondPoint + (mousePosition - secondPoint);

                if (AdditionRadius + viewWeapon.Radius >= (viewWeapon.Position - Position).Length()) {
                    CanToTakeWeapon = true;
                    Main.ViewWeaponUI(spriteBatch, firstPoint, secondPoint, thirdPoint, viewWeapon.Name, Color.White);
                } else {
                    Main.ViewWeaponUI(spriteBatch, firstPoint, secondPoint, thirdPoint, viewWeapon.Name, Color.Gray);
                    CanToTakeWeapon = false;
                }
            } else {
                Main.CursorUI(spriteBatch, new Vector2(mousePosition.X - 33, mousePosition.Y - 26));
            }
        }
    }
}
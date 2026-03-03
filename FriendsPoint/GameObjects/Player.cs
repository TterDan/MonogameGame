
using Microsoft.Xna.Framework.Input;
using System;
using System.Reflection;

namespace FriendsPoint.GameObjects {
    public class Player : CircleHBoxObj {          // Класс игрока, наследует класс GameObject

        public Weapon Fist;
        public float MoveSpeed;
        Vector2 CurrentSpeed = Vector2.Zero;
        public Vector2 ScreenCenter;
        public Weapon currentWeapon;            // Текущее оружие игрока
        public Vector2 mouseDirection;
        public Vector2 mousePosition;
        public Random rnd;
        public float Health = 100f;

        public SpriteBatch spriteBatch;
        public bool isShooting;
        public Vector2 currentOffset;
        public Vector2 recoilOffset;
        public int shotcount;
        public double currentFireTime = 200;
        public double ShotDrawTimer = 0;
        public double currentShotDrawTime = 50;
        public Vector2 bulletLine;
        public Weapon viewWeapon;
        public SpriteFont font;
        public Vector2 mouseDirectionForCamera;
        public List<Vector2> bullets;
        public bool CanToTakeWeapon = false;
        float deltaTimeForRecoil;
        public bool isReloading = false;
        public bool isCoolDown = false;
        public float oldShotCount = 0;
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
            rnd = new Random();
        }
        public void setConstants(float deltaTime) {
            currentShotDrawTime *= 200 * deltaTime;
            currentFireTime *= 150 * deltaTime;
        }
        public void UseWeapon(List<GameObject> enemies, List<GameObject> weapons, float deltaTime) {
            Vector2 direction = mousePosition - ScreenPosition;
            deltaTimeForRecoil = deltaTime;
            if (!isCoolDown)
            {
                if (currentFireTime > currentWeapon.FireRate)
                {
                    bullets.Clear();
                    if (currentWeapon.Type == "Melee")
                    {
                        Beat(enemies, weapons);
                    }
                    else

                    if (currentWeapon.CartrigesInMagazine > 0)
                    {
                        currentWeapon.CartrigesInMagazine--;
                        if (currentWeapon.Type == "Throwing")
                        {
                            Throw(weapons);
                        }
                        else
                        if (currentWeapon.Name == "Shotgun")
                        {
                            for (int i = 0; i < 5; i++)
                                Shot(enemies, Vector2.Normalize(direction), deltaTime);
                        }
                        else
                        if (currentWeapon.Type == "Semi-automatic" || currentWeapon.Type == "Automatic")
                        {
                            Shot(enemies, Vector2.Normalize(direction), deltaTime);
                        }
                        else
                        if (currentWeapon.Type == "Placing")
                        {

                        }
                    }
                    else
                        Reload();
                    currentFireTime = 0;
                }
            }
        }
        
        public void Reload()
        {
             isReloading = true;
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
                    Vector2 normalizedDirection = Vector2.Normalize(enemy.ScreenPosition - ScreenPosition);
                    enemy.AddForce(normalizedDirection);
                    if (enemy.TakeDamage(currentWeapon.Damage, enemies, j) == true) {
                        j--;
                    }
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
                        Vector2 normalizedDirection = Vector2.Normalize(weaponDirection);
                        weapon.AddForce(normalizedDirection);
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
        public void Shot(List<GameObject> enemies, Vector2 direction, float deltaTime) {
            isShooting = true;
            shotcount++;
            Camera.ShotOffset(-mouseDirectionForCamera, currentWeapon.RecoilStrengthForCamera);
            Vector2 spread = pattern.getPattern(currentWeapon.PatternIndex, shotcount, (CurrentSpeed * deltaTime) * 10);
            Vector2 finalDirection = new Vector2(direction.X + spread.X, direction.Y + spread.Y);
            for (int j = 0; j < enemies.Count; j++)
            {
                Enemy enemy = (Enemy)enemies[j];
                Vector2 enemyDirection = enemy.ScreenPosition - (ScreenPosition + GetTrunkOffset());
                float AB = finalDirection.X * enemyDirection.X + finalDirection.Y * enemyDirection.Y;
                float moduleA = finalDirection.Length();
                float moduleB = enemyDirection.Length();
                float CosAngle = AB / (moduleA * moduleB);
                float Angle = MathF.Acos(CosAngle);
                float LengthBetweenDirectionAndEnemy = moduleB * MathF.Sin(Angle);
                if (LengthBetweenDirectionAndEnemy < enemy.Radius && CosAngle > 0)
                {
                    if (enemy.TakeDamage(currentWeapon.Damage, enemies, j) == true)
                    {
                        j--;
                    }
                }
            }
            bullets.Add(Vector2.Normalize(finalDirection) * 10000f);
            ShotDrawTimer = 0;
        }
        
        public void TakeWeapon(List<GameObject> weapons, List<(Weapon, Vector2)> droppedWeapons) {
            if (CanToTakeWeapon == false || viewWeapon == null) {
                return;
            }
            int index = weapons.IndexOf(viewWeapon);
            if (viewWeapon.Type == "Ammunition")
            {
                if (currentWeapon.ReloadCount != 0 && currentWeapon.TotalCartriges <= 0)
                {
                    weapons.RemoveAt(index);
                    currentWeapon.TotalCartriges += rnd.Next(1, (int)currentWeapon.ReloadCount);
                    return;
                }
                return;
            }
            if (currentWeapon.Name != "Fist") {
                DropWeapon(weapons, droppedWeapons);
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
        public void DropWeapon(List<GameObject> weapons, List<(Weapon, Vector2)> droppedWeapons) {
            currentWeapon.FlyVelocity = currentWeapon.HitForceVelocity;
            currentWeapon.Position = Position;
            weapons.Add(currentWeapon);
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
        public void Rotate(Point mousePositionPoint, List<GameObject> weapons) {                           // Функция поворота игрока в сторону мыши
            mousePosition = new Vector2(mousePositionPoint.X, mousePositionPoint.Y);
            mouseDirection = new Vector2(mousePosition.X - ScreenPosition.X, mousePosition.Y - ScreenPosition.Y);
            Vector2 mouseDirectionNormalized = Vector2.Normalize(mouseDirection) * 500f;
            mouseDirectionForCamera = new Vector2(mousePosition.X - ScreenCenter.X, mousePosition.Y - ScreenCenter.Y) + mouseDirectionNormalized;
            Camera.ChangeMouseOffset(mouseDirectionForCamera);
            Rotation = (float)Math.Atan2(mouseDirection.Y, mouseDirection.X) + MathHelper.PiOver2;
            for (int i = 0; i < weapons.Count; i++)
            {
                Weapon weapon = (Weapon)weapons[i];
                if (weapon.Radius >= (weapon.ScreenPosition - mousePosition).Length())
                {
                    viewWeapon = weapon;
                    return;
                }
            }
            viewWeapon = null;
        }
        public void Move(Vector2 moveDirection, List<GameObject> players, List<GameObject> weapons, List<GameObject> enemies, List<GameObject> otherGameObjects, float deltaTime)   // Функция перемещения всех обьектов на карте
        {
            Vector2 targetVelocity = moveDirection * MoveSpeed;
            CurrentSpeed = Vector2.Lerp(CurrentSpeed, targetVelocity, 2f * deltaTime);
            Camera.ChangeWalkOffset(moveDirection);
            Position += CurrentSpeed * deltaTime;
        }
        public override void Draw(SpriteBatch spriteBatch) {
            DrawEngine.Circle(spriteBatch, CircleTexture, ScreenPosition, Radius, Color.Black, 0.34f, 0f, 1f / (300 / Radius));
            DrawEngine.Circle(spriteBatch, CircleTexture, ScreenPosition, AdditionRadius, Color.Black * 0.65f, 0.05f, 0f, 1f / (300 / AdditionRadius));

            DrawEngine.DrawTexture(spriteBatch, ScreenPosition, Texture, Rotation, 0.7f, 0.42f);
            DrawEngine.RectFigure(spriteBatch, ScreenPosition, new Rectangle(0, 0, 20, 20), new Vector2(0, 0), Color.Yellow, 0f, 1f, 0.43f);
            if (isShooting)
            {
                Vector2 recoilTarget = new Vector2(currentWeapon.RecoilStrength, 0f);
                recoilOffset = Vector2.Lerp(recoilOffset, recoilTarget, 1.5f * deltaTimeForRecoil);
            }
            if(!isShooting)
                recoilOffset = Vector2.Lerp(recoilOffset, Vector2.Zero, 0.3f * deltaTimeForRecoil);
            currentOffset = currentWeapon.HandleOffset + recoilOffset;
            Rectangle weaponRect = new Rectangle((int)ScreenPosition.X, (int)ScreenPosition.Y, currentWeapon.Radius * 2, currentWeapon.Radius * 2);
            Vector2 WeaponOffset1 = -new Vector2(currentOffset.X, currentOffset.Y);                              // Координаты для смещения оружия от игрока в его руке
            Vector2 WeaponOffset2 = -new Vector2(currentOffset.X, -currentOffset.Y);
            float fixedRotation = Rotation + MathF.PI / 2;
            float cosRotation = MathF.Cos(fixedRotation);
            float sinRotation = MathF.Sin(fixedRotation);
            Vector2 WeaponPos1 = new Vector2(cosRotation * WeaponOffset1.X - sinRotation * WeaponOffset1.Y, sinRotation * WeaponOffset1.X + cosRotation * WeaponOffset1.Y);      // Математика для определения смещения оружия от игрока в его руке
            Vector2 WeaponPos2 = new Vector2(cosRotation * WeaponOffset2.X - sinRotation * WeaponOffset2.Y, sinRotation * WeaponOffset2.X + cosRotation * WeaponOffset2.Y);      // Математика для определения смещения оружия от игрока в его руке

            if (currentWeapon.Name == "Fist") {
                DrawEngine.DrawTexture(spriteBatch, ScreenPosition + WeaponPos1, currentWeapon.Texture, Rotation, 1f, 0.35f);
                DrawEngine.DrawTexture(spriteBatch, ScreenPosition + WeaponPos2, currentWeapon.Texture, Rotation, 1f, 0.35f);
            } else {
              DrawEngine.DrawTexture(spriteBatch, ScreenPosition + WeaponPos1, currentWeapon.Texture, (Rotation) - MathF.PI / 2, 1f, 0.35f);
            }
            if (ShotDrawTimer <= currentShotDrawTime) {
                for (int i = 0; i < bullets.Count; i++)
                {
                    DrawEngine.Line(spriteBatch, ScreenPosition + GetTrunkOffset(), ScreenPosition + bullets[i], Color.Yellow, 1f, 6f);
                    Console.Log("1", "1");
                }
            }
            Console.Log(currentShotDrawTime, "5959");
            Console.Log(ShotDrawTimer, "59159");
            if(currentWeapon.Type != "Melee")
                Main.CartrigesInMagazineUI(spriteBatch,currentWeapon.CartrigesInMagazine, currentWeapon.TotalCartriges);
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
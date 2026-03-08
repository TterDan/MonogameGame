namespace FriendsPoint.GameObjects.Player {
    public partial class Player : CircleHBoxObj {          // Класс игрока, наследует класс GameObject
        public void UseWeapon(List<GameObject> enemies, List<GameObject> weapons, float deltaTime) {
            anim1.Play();
            timer1.Play();
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
            float rand = rnd.Next(90, 110) * 0.01f;
            Console.Log(rand, "random");
            currentWeapon.FlyVelocity = dropStrength * rand;
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
    }
}
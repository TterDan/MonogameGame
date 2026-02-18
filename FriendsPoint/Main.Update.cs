
namespace FriendsPoint
{
    public partial class Main                                   // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
        public double Timer1 = 0;
        int FramesPerSecond;
        int FrameCounter;
        double ElapsedTime;
        protected override void Update(GameTime gameTime) {
            Input();
            weaponMove();
            semiCheck(gameTime);
            enemySpawn();
            FPSCounter(gameTime);
            Camera.ChangeOffset();
            player.currentFireTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            player.ShotDrawTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            base.Update(gameTime);
            ListCheck();


        }

        protected void ListCheck() {
            Vector2 PScreenPosition = ScreenCenter - Camera.CameraOffset;
            Vector2 PPosition = player.Position;
            player.ScreenPosition = PScreenPosition;
            for (int i = 1; i < Players.Count; i++) {
                Player player = (Player)Players[i];
                player.ScreenPosition = PScreenPosition + (player.Position - PPosition);
            }
            for (int i = 0; i < Weapons.Count; i++) {
                Weapon weapon = (Weapon)Weapons[i];
                weapon.ScreenPosition = PScreenPosition + (weapon.Position - PPosition);
                weapon.move();
            }
            for (int i = 0; i < Enemies.Count; i++) {
                Enemy enemy = (Enemy)Enemies[i];
                enemy.ScreenPosition = PScreenPosition + (enemy.Position - PPosition);
                enemy.move(player.Position - enemy.Position, player.Radius + enemy.Radius);
            }
            for (int i = 0; i < OtherGameObjects.Count; i++) {
                GameObject gameObj = (GameObject)OtherGameObjects[i];
                gameObj.ScreenPosition = PScreenPosition + (gameObj.Position - PPosition);
            }
        }
        protected void FPSCounter(GameTime gameTime) {
            ElapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            FrameCounter++;
            if (ElapsedTime >= 0.4) {
                FramesPerSecond = (int)(FrameCounter * 2.5);
                FrameCounter = 0;
                ElapsedTime = 0;
            }
        }
        protected void semiCheck(GameTime gameTime)
        {
            if (player.shotcount > 0)
            {
                if (!player.isShooting)
                    Timer1 += gameTime.ElapsedGameTime.TotalSeconds;
                else
                    Timer1 = 0f;

                if (Timer1 >= 1.0f)
                {
                    player.shotcount = 0;
                    Timer1 = 0f;
                }
            }
        }
        protected void weaponMove() {
            for (int i = 0; i < droppedWeapons.Count; i++) {
                var (weapon, dir) = droppedWeapons[i];
                weapon.Speed -= 0.5f;
                weapon.Position += dir * weapon.Speed;
                weapon.Rotation += weapon.Speed * 0.01f;
                for (int j = 0; j < Enemies.Count; j++) {
                    Enemy enemy = (Enemy)Enemies[i];
                    if (enemy.Radius + weapon.Radius * 2 >= (enemy.ScreenPosition - weapon.ScreenPosition).Length()) {
                        float calculatedDamage = (weapon.HitDamage * weapon.Speed / weapon.DropSpeed);
                        weapon.Speed = 0;
                        enemy.TakeDamage(calculatedDamage, Enemies, j);
                    }
                }
                if (weapon.Speed <= 0) {
                    droppedWeapons.RemoveAt(i);
                }
            }
        }
        public void enemySpawn()
        {
            DrawEngine.GraphicsDevice = GraphicsDevice;
            int enemyExist = Enemies.Count;
            if (enemyExist < 3)
            {
                for (int i = 0; i < 3 - enemyExist; i++)
                {
                    Enemy enemy = new Enemy(
                        GraphicsDevice,
                        new Vector2(200 + i * 100, 200),
                        60,
                        3f
                    );
                    Enemies.Add(enemy);
                }
            }
        }
    }
}
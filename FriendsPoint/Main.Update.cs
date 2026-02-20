
namespace FriendsPoint
{
    public partial class Main                                   // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
        public double Timer1 = 0;
        int FramesPerSecond;
        int FrameCounter;
        double ElapsedTime;
        double timer = 0;
        long delta;
        long lastAllocated = 0;
        float deltaTime = 0;
        protected override void Update(GameTime gameTime) {
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds * 10;
            Camera.deltaTime = deltaTime;
            timer += gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= 0.25) {
                long allocated = GC.GetAllocatedBytesForCurrentThread();
                delta = allocated - lastAllocated;

                lastAllocated = allocated;
                timer = 0;
            }
            Console.Log(GC.GetTotalMemory(false), "Total GC memory");
            Console.Log(delta, "GC memory adding bytes per second");

            Input();
            weaponMove();
            semiCheck(gameTime);
            enemySpawn();
            FPSCounter(gameTime);
            Camera.ChangeOffset();
            player.currentFireTime += 1;
            player.ShotDrawTimer += 1;
            ListForCycles();
            base.Update(gameTime);
        }

        protected void ListForCycles() {                                    // Здесь перебираются массивы игровых объектов
            Vector2 PScreenPosition = ScreenCenter - Camera.CameraOffset;
            Vector2 PPosition = player.Position;
            player.ScreenPosition = PScreenPosition;
            for (int i = 1; i < Players.Count; i++) {
                Player player = (Player)Players[i];
                player.ScreenPosition = PScreenPosition + (player.Position - PPosition);
                player.setConstants(deltaTime);
            }
            for (int i = 0; i < Weapons.Count; i++) {
                Weapon weapon = (Weapon)Weapons[i];
                weapon.Move(deltaTime);
                weapon.ScreenPosition = PScreenPosition + (weapon.Position - PPosition);
            }
            for (int i = 0; i < Enemies.Count; i++) {
                Enemy enemy = (Enemy)Enemies[i];
                enemy.Move(player.Position - enemy.Position, player.Radius + enemy.Radius, deltaTime);
                enemy.ScreenPosition = PScreenPosition + (enemy.Position - PPosition);
            }
            for (int i = 0; i < OtherGameObjects.Count; i++) {
                GameObject gameObj = (GameObject)OtherGameObjects[i];
                gameObj.ScreenPosition = PScreenPosition + (gameObj.Position - PPosition);
            }
        }
        protected void weaponMove() {
            for (int i = 0; i < droppedWeapons.Count; i++) {
                var (weapon, dir) = droppedWeapons[i];
                weapon.FlyVelocity -= weapon.FlyDeceleraion * deltaTime;
                weapon.Position += dir * weapon.FlyVelocity * deltaTime;
                weapon.Rotation += weapon.FlyVelocity * deltaTime * 0.02f;
                Console.Log(dir, "113");
                for (int j = 0; j < Enemies.Count; j++) {
                    Enemy enemy = (Enemy)Enemies[j];
                    if (enemy.Radius + weapon.Radius * 2 >= (enemy.ScreenPosition - weapon.ScreenPosition).Length()) {
                        float calculatedDamage = (weapon.HitDamage * weapon.FlyVelocity / weapon.HitForceVelocity);
                        weapon.FlyVelocity = 0;
                        enemy.TakeDamage(calculatedDamage, Enemies, j);
                    }
                }
                if (weapon.FlyVelocity <= 0) {
                    droppedWeapons.RemoveAt(i);
                }
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
        public void enemySpawn()
        {
            DrawEngine.GraphicsDevice = GraphicsDevice;
            int enemyExist = Enemies.Count;

            if (enemyExist < 3) {
                for (int i = 0; i < 3 - enemyExist; i++) {
                    Enemy enemy = new Enemy(
                        GraphicsDevice,
                        new Vector2(200 + i * 100, 200),
                        60,
                        35f,
                        0
                    );
                    Enemies.Add(enemy);
                }
                for (int i = 0; i < enemyExist; i++) {
                    Enemies[i].Layer = 0.2f + (0.1f / enemyExist * i);
                }
            }
        }
    }
}
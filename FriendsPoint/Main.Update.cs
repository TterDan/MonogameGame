
namespace FriendsPoint
{
    public partial class Main                                   // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
        // Код обновлений
        protected override void Update(GameTime gameTime)
        {
            Input();
            weaponMove();

            for (int i = 0; i < objects.Count; i++) {
                if (objects[i] is Enemy enemy) {
                    enemy.move(player.Position - enemy.Position, player.Radius + enemy.Radius);
                }
                if (objects[i] is Weapon weapon) {
                    weapon.move();
                }
            }
            Camera.ChangeOffset();
            player.currentFireTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            player.ShotDrawTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            base.Update(gameTime);
        }
        protected void weaponMove() {
            for (int i = 0; i < droppedWeapons.Count; i++) {
                var (weapon, dir) = droppedWeapons[i];
                weapon.Speed -= 0.5f;
                weapon.Position += dir * weapon.Speed;
                weapon.Rotation += (weapon.Speed * 0.2f) * 0.1f;
                weapon.isflying = true;
                for (int j = 0; j < objects.Count; j++) {
                    if (objects[j] is Enemy enemy) {
                        if (enemy.Radius + weapon.Radius * 2 >= (enemy.ScreenPosition - weapon.ScreenPosition).Length() && weapon.isflying) {
                            weapon.isflying = false;
                            float calculatedDamage = (weapon.HitDamage * weapon.Speed / weapon.DropSpeed);
                            weapon.Speed = 0;
                            enemy.TakeDamage(calculatedDamage, objects, j);
                        }
                    }
                }
                if (weapon.Speed <= 0) {
                    weapon.isflying = false;
                    droppedWeapons.RemoveAt(i);
                }

            }
        }
    }
}
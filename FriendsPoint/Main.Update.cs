using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using FriendsPoint.GameObjects;

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
                    enemy.move(player.Position - enemy.Position);
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
            if (droppedWeapons.Count > 0) {
                for (int i = 0; i < droppedWeapons.Count; i++) {
                    var (weapon, dir) = droppedWeapons[i];
                    weapon.Speed -= 0.1f;
                    weapon.Position += Vector2.Normalize(dir) * weapon.Speed;
                    weapon.Rotation += 0.1f;
                    weapon.isflying = true;
                    for (int j = 0; j < objects.Count; j++) {
                        if (objects[j] is Enemy enemy) {
                            if (enemy.Radius + weapon.Radius * 2 >= (enemy.ScreenPosition - weapon.ScreenPosition).Length() && weapon.isflying) {
                                enemy.Health -= weapon.HitDamage;
                                weapon.isflying = false;
                                weapon.Speed = 0;
                                if (enemy.Health <= 0)
                                    objects.RemoveAt(j);
                            }
                        }
                    }
                    if (weapon.Speed <= 0) {
                        weapon.isflying = false;
                        weapon.Speed = 10f;
                        droppedWeapons.RemoveAt(i);
                    }

                }
            }
        }
    }
}
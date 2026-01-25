using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace FriendsPoint
{
    public partial class Main                                   // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
        // Код обновлений
        protected override void Update(GameTime gameTime)
        {
            Input();
            player.WeaponFly(objects, droppedWeapons);

            for (int i = 0; i < objects.Count; i++) {
                if (objects[i] is Enemy enemy) {
                    enemy.move(player.Position - enemy.Position);
                }
                if (objects[i] is Weapon weapon) {
                    weapon.move();
                }
            }
            Camera.ChangeOffset();
            base.Update(gameTime);
        }

    }
}
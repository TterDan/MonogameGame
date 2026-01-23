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
        int index;
        protected override void Update(GameTime gameTime)
        {
            Input();
            if (player.isdropped)  // Условие для дропа
            {
                index = objects.IndexOf(player.droppedWeapon);
                if (objects[index].Speed >= 0f)
                {
                    objects[index].Speed -= 0.3f;
                    objects[index].Position += Vector2.Normalize(player.droppedDirection) * objects[index].Speed;
                    objects[index].isflying = true;
                }
                if(objects[index].Speed <= 0)
                {
                    player.isdropped = false;
                    objects[index].isflying = false;
                    objects[index].Speed = 10f;
                }
            }

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
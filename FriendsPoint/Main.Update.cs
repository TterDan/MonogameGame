using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
            if(player.flag == false)
            {
                player.Weapon = "glock";
            }
            for (int i = 0; i < objects.Count; i++) {
                if (objects[i] is Enemy enemy) {
                    enemy.moveTowardsPlayer(player.Position);
                }
            }
                takeWeapon();
            Camera.ChangeOffset();
            base.Update(gameTime);
        }

        public void takeWeapon()                                // ДЖАС вот этот код лучше переместить в метод takeWeapon() у игрока
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i] is Weapon) {
                    Vector2 playerCenter = player.ScreenPosition + new Vector2(player.Width / 2f, player.Height / 2f);
                    Vector2 wpnCenter = objects[i].ScreenPosition + new Vector2(objects[i].Width / 2f, objects[i].Height / 2f);

                    float distance = Vector2.Distance(playerCenter, wpnCenter);
                    if (distance < 110 && player.Weapon == "hand" && Keyboard.GetState().IsKeyDown(Keys.E)) {
                        player.Weapon = "bat";
                        objects.RemoveAt(i);
                        return;
                    }
                }
            }
        }
    }
}
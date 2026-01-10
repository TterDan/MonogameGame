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
            for (int i = 0; i < objects.Count; i++) {
                if (objects[i] is Enemy enemy) {
                    enemy.moveTowardsPlayer(player.Position);
                }
            }
            Camera.ChangeOffset();
            base.Update(gameTime);
        }

    }
}
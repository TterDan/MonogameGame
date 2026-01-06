using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace FriendsPoint
{
    public partial class Main
    {
        // Код обновлений
        protected override void Update(GameTime gameTime)
        {
            Input();
            if(player.flag == false)
            {
                player.Weapon = "glock";
            }
            takeWeapon();
            base.Update(gameTime);
        }

        public void takeWeapon()
        {
            for (int i = 0; i < renderlist.Count; i++)
            {
                Vector2 playerCenter = player.PlayerScreenPos + new Vector2(player.Width / 2f, player.Height / 2f);
                Vector2 wpnCenter = renderlist[i].Position + new Vector2(renderlist[i].Width / 2f, renderlist[i].Height / 2f);

                float distance = Vector2.Distance(playerCenter, wpnCenter);
                if (distance < 110 && player.Weapon == "hand" && Keyboard.GetState().IsKeyDown(Keys.E))
                {
                    player.Weapon = "bat";
                    renderlist.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace FriendsPoint
{
    public partial class Main
    {
        // Код обновлений
        protected override void Update(GameTime gameTime)
        {
            Input();
            player.Weapon = "bat";
            base.Update(gameTime);
        }
    }
}
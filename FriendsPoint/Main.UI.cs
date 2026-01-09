using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace FriendsPoint
{
    public partial class Main 
    {
        public virtual void DrawUI(SpriteBatch render, Rectangle? sourceRectangle = null)
        {
            if(player.TakeWeapon(objects))
                    render.DrawString(font, "Press E to take weapon", new Vector2((windowSize.X / 2f) - (150 / 2f), 50), Color.Black);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using FriendsPoint.GameObjects;
namespace FriendsPoint
{
    public partial class Main 
    {
        public virtual void DrawUI(SpriteBatch render, Rectangle? sourceRectangle = null)
        {
            for (int j = 0; j < objects.Count; j++) {
                if (objects[j] is Enemy enemy) {
                    render.DrawString(font, $"HP: {enemy.Health}", new Vector2(enemy.ScreenPosition.X, enemy.ScreenPosition.Y), Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1.0f);
                }
            }
        }
    }
}

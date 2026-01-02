using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace FriendsPoint
{
    public partial class Main
    {
        // Код обновлений
        protected void Input()
        {
            player.rotate(getMouse().Position);
            player.move(getKeyboard(), map);
        }
        protected MouseState getMouse()
        {
            MouseState mouse = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            return mouse;
        }
        protected Vector2 getKeyboard()
        {
            KeyboardState keyboard = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (keyboard.IsKeyDown(Keys.W))
                direction.Y = -1;

            if (keyboard.IsKeyDown(Keys.S))
                direction.Y = 1;

            if (keyboard.IsKeyDown(Keys.A))
                direction.X = -1;

            if (keyboard.IsKeyDown(Keys.D))
                direction.X = 1;
            
            if (direction != Vector2.Zero)
                direction.Normalize();
            return direction;
        }
    }
}
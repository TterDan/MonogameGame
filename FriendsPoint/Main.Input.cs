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
            player.rotate(getMouse().Position); // В метод дай ввод с мыши
            player.move(getKeyboard(), map, obj, objects);   // В метод даю ввод с клавиатуры и все обьекты на карте, чтобы их смещать
        }
        protected MouseState getMouse()  // Получение ввода с мыши
        {
            MouseState mouse = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            return mouse;
        }
        protected Vector2 getKeyboard() // Получение ввода с клавиатуры
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
                direction.Normalize();          // ВАЖНАЯ ДЕТАЛЬ, нормализую вектор, т.е. делаю так, чтобы игрок не был быстрее, когда двигается по горизонтали
            return direction;
        }
    }
}
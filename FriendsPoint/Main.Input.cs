using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace FriendsPoint
{
    public partial class Main                       // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
        // Код обновлений
        protected MouseState mouse;
        protected void Input()
        {
            player.rotate(getMouse().Position);     // В метод даю ввод с мыши
            player.move(getKeyboard(), objects);    // В метод даю ввод с клавиатуры и все обьекты на карте, чтобы их смещать
        }
        protected MouseState getMouse()             // Получение ввода с мыши
        {
            mouse = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            return mouse;
        }
        protected Vector2 getKeyboard()             // Получение ввода с клавиатуры
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

            if (direction != Vector2.Zero) {
                direction.Normalize();              // Нормализую вектор, т.е. делаю так, чтобы игрок не был быстрее, когда двигается по горизонтали
            }
            if (keyboard.IsKeyDown(Keys.LeftShift)) {
                player.ShiftLook(true, mouse.Position);
            } else {
                player.ShiftLook(false, Point.Zero);
            }
            if (keyboard.IsKeyDown(Keys.G) && player.Weapon != "hand")                      // ДЖАС Вот этот код лучше поместить в метод throwWeapon() у игрока
            {
                Weapon wpn = new Weapon(blackTxtr, player.Weapon, player.Position, 50, 50);
                player.flag = true;                 // Флажок для теста просто, потом уберу
                objects.Add(wpn);
                player.Weapon = "hand";
            }

            return direction;
        }
    }
}
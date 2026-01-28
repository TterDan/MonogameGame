using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using FriendsPoint.GameObjects;
namespace FriendsPoint
{
    public partial class Main                       // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
        // Код обновлений
        protected MouseState mouse;
        protected bool mouseState = false;
        public bool isOemTildePressed = false;
        protected void Input()
        {
            player.rotate(getMouse().Position, objects);     // В метод даю ввод с мыши
            player.move(getKeyboard(), objects);    // В метод даю ввод с клавиатуры и все обьекты на карте, чтобы их смещать
        }
        protected MouseState getMouse()             // Получение ввода с мыши
        {
            mouse = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (mouse.LeftButton == ButtonState.Pressed && mouseState == false)
                player.UseWeapon(objects);
                mouseState = true;

            if (mouse.LeftButton == ButtonState.Released)
                mouseState = false;
            //System.Diagnostics.Debug.WriteLine(mouse.Position);
            return mouse;
        }
        protected Vector2 getKeyboard()             // Получение ввода с клавиатуры
        {
            KeyboardState keyboard = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;

            if (keyboard.IsKeyDown(Keys.OemTilde)) {
                if (isOemTildePressed == false) {
                    Console.IsConsoleOpen = (Console.IsConsoleOpen == true) ? false : true;
                    Console.Log("Console gets opened/closed");
                    isOemTildePressed = true;
                }
            }
            if (keyboard.IsKeyUp(Keys.OemTilde)) {
                isOemTildePressed = false;
            }
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
            if (keyboard.IsKeyDown(Keys.G) && player.currentWeapon.Name != "Fist")
            {
                objects.Add(player.currentWeapon);
                droppedWeapons.Add((player.currentWeapon, player.mouseDirection));
                player.currentWeapon = fist;
            }
            return direction;
        }
    }
}

namespace FriendsPoint
{
    public partial class Main                       // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
        protected MouseState mouse;
        protected bool mouseState = false;
        public bool isOemTildePressed = false;
        public bool isEPressed = false;
        protected void Input()
        {
            player.rotate(getMouse().Position, Weapons);     // В метод даю ввод с мыши
            player.move(getKeyboard(), Players, Weapons, Enemies, OtherGameObjects);    // В метод даю ввод с клавиатуры и все обьекты на карте, чтобы их смещать
        }
        protected MouseState getMouse()             // Получение ввода с мыши
        {
            mouse = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (mouse.LeftButton == ButtonState.Pressed && mouseState == false)
            {
                player.isShooting = false;
                player.UseWeapon(Enemies, Weapons);
                mouseState = true;
            }
            if(mouseState == true && player.currentWeapon.Type == "Automatic")
                player.UseWeapon(Enemies, Weapons);

            if (mouse.LeftButton == ButtonState.Released)
            {
                mouseState = false;
            }
            return mouse;
        }
        protected Vector2 getKeyboard()             // Получение ввода с клавиатуры
        {
            KeyboardState keyboard = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (keyboard.IsKeyDown(Keys.OemTilde)) {
                if (isOemTildePressed == false) {
                    Console.IsConsoleOpen = (Console.IsConsoleOpen == true) ? false : true;
                    isOemTildePressed = true;
                }
            }
            if (keyboard.IsKeyUp(Keys.OemTilde)) {
                isOemTildePressed = false;
            }
            if (keyboard.IsKeyDown(Keys.W))
                direction.Y = -1;
            else
            if (keyboard.IsKeyDown(Keys.S))
                direction.Y = 1;
            if (keyboard.IsKeyDown(Keys.A))
                direction.X = -1;
            else
            if (keyboard.IsKeyDown(Keys.D))
                direction.X = 1;
            if (keyboard.IsKeyDown(Keys.E)) {
                if (isEPressed == false) {
                    player.TakeWeapon(Weapons, droppedWeapons);
                }
                isEPressed = true;
            }
            if (keyboard.IsKeyUp(Keys.E)) {
                isEPressed = false;
            }
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
                player.DropWeapon(Weapons, droppedWeapons);
                mouseState = false;
                player.shotcount = 0;
            }
            return direction;
        }
    }
}
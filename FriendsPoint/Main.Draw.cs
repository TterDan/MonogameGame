
namespace FriendsPoint
{
    public partial class Main       // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
        // Отрисовка всего кадра
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);
            render.Begin(
                SpriteSortMode.FrontToBack
            );

            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Draw(render); // Отрисовываются все обьекты в списке
            }
            if (Console.IsConsoleOpen == true) {
                Console.DrawConsole(render);
            }
            DrawUI(render); // Отрисовка интерфейса
            base.Draw(gameTime);
            render.End();
        }
    }
}
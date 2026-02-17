
namespace FriendsPoint
{
    public partial class Main 
    {
        public List<Button> Buttons = new List<Button>(); 
        public virtual void DrawUI(SpriteBatch render, Rectangle? sourceRectangle = null)
        {
            CursorUI();
            for (int j = 0; j < Enemies.Count; j++) {
                Enemy enemy = (Enemy)Enemies[j];
                render.DrawString(font, $"HP: {enemy.Health}", new Vector2(enemy.ScreenPosition.X, enemy.ScreenPosition.Y), Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1.0f);
            }
        }
        public void CursorUI() // Думаю удобно будет для каждого элемента интерфейса делать свой метод, в котором с ним будет удобно взаимодействовать, чтобы не засирать Draw.     Нет, arishem, всем все равно
        {
            render.Draw(Cursor, new Vector2(player.mousePosition.X - 33, player.mousePosition.Y - 26), null, Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.9f);
            DrawEngine.Text(render, new Vector2(10, 10), $"FPS: {FramesPerSecond}");
        }
    }
}


using System.Text;

namespace FriendsPoint
{
    public partial class Main 
    {
        public List<Button> Buttons = new List<Button>();
        static public StringBuilder ViewWeaponTextBuffer = new StringBuilder(32);
        public virtual void DrawUI(SpriteBatch render, Rectangle? sourceRectangle = null)
        {
            for (int j = 0; j < Enemies.Count; j++) {
                Enemy enemy = (Enemy)Enemies[j];

                DrawEngine.DrawText(render, new Vector2(enemy.ScreenPosition.X, enemy.ScreenPosition.Y), "HP:", Color.White, 0.301f);
                DrawEngine.DrawText(render, new Vector2(enemy.ScreenPosition.X + 30, enemy.ScreenPosition.Y), enemy.Health, Color.White, 0.301f);
            }

            DrawEngine.DrawText(render, new Vector2(10, 10), "FPS:", Color.Black, 0.65f);
            DrawEngine.DrawText(render, new Vector2(50, 10), FramesPerSecond, Color.Black, 0.65f);
        }
        static public void ViewWeaponUI(SpriteBatch spriteBatch, Vector2 firstPoint, Vector2 secondPoint, Vector2 thirdPoint, string name, Color color) {
            ViewWeaponTextBuffer.Clear();
            ViewWeaponTextBuffer.Append("Take ");
            ViewWeaponTextBuffer.Append(name);

            DrawEngine.Line(spriteBatch, firstPoint, secondPoint, Color.Black, 0.52f, 6f);
            DrawEngine.Line(spriteBatch, secondPoint, thirdPoint, Color.Black, 0.52f, 6f);
            DrawEngine.RectFigure(spriteBatch, thirdPoint, new Rectangle(0, 0, ViewWeaponTextBuffer.Length * 12 + 25, 40), new Vector2(150, 20) / 2, Color.Black, 0.521f);

            DrawEngine.DrawText(spriteBatch, thirdPoint + new Vector2(-65, -4), "Take", color, 0.522f, 1.3f);
            DrawEngine.DrawText(spriteBatch, thirdPoint + new Vector2(-05, -4), name, color, 0.522f, 1.3f);
        }
        static public void CursorUI(SpriteBatch spriteBatch, Vector2 position) // Думаю удобно будет для каждого элемента интерфейса делать свой метод, в котором с ним будет удобно взаимодействовать, чтобы не засирать Draw.     Нет, arishem, всем все равно
        {
            spriteBatch.Draw(Cursor, position, null, Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.53f);
        }
    }
}

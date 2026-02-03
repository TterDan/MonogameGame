
namespace FriendsPoint
{
    public partial class Main 
    {
        public List<Button> Buttons = new List<Button>(); 
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

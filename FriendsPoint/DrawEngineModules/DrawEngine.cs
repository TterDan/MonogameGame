
namespace FriendsPoint.DrawEngineModules {
    public partial class DrawEngine {
        static public GraphicsDevice GraphicsDevice;
        static public float GameScale = 1.0f;
        static public SpriteFont GameFont;

        static public void DrawRect(SpriteBatch spriteBatch, Vector2 Position, BasicStyle basicStyle, FillStyle fillStyle, StrokeStyle strokeStyle) {
            Vector2 size = new Vector2(basicStyle.Size.X, basicStyle.Size.Y);

            DrawEngine.RectFigure(spriteBatch, Position, new Rectangle(0, 0, (int)size.X, (int)size.Y), basicStyle.CenterPosition, fillStyle.Color, 0.999f);

            //DrawEngine.RectFigure(spriteBatch, Position, new Rectangle(0, 0, (int)size.X, (int)size.Y), basicStyle.CenterPosition, strokeStyle.Color, 1f);
            DrawEngine.RectFigure(spriteBatch, Position - new Vector2(-150, strokeStyle.Width), new Rectangle(0, 0, (int)(size.X), (int)strokeStyle.Width), basicStyle.CenterPosition, strokeStyle.Color);
        }
        static public void DrawRect(SpriteBatch spriteBatch, Vector2 Position, BasicStyle basicStyle, FillStyle fillStyle) {
            Vector2 size = new Vector2(basicStyle.Size.X, basicStyle.Size.Y);

            DrawEngine.RectFigure(spriteBatch, Position, new Rectangle(0, 0, (int)size.X, (int)size.Y), basicStyle.CenterPosition, fillStyle.Color, 0.999f);

        }
        static public void DrawRect(SpriteBatch spriteBatch, Vector2 Position, BasicStyle basicStyle, StrokeStyle strokeStyle) {
            Vector2 size = new Vector2(basicStyle.Size.X, basicStyle.Size.Y);


        }
    }
}
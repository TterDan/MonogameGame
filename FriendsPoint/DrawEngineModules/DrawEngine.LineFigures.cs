
namespace FriendsPoint.DrawEngineModules {
    public partial class DrawEngine {                                                          // Статический класс камеры
        static public void DrawLine(SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color color, float layer = 1f, float thickness = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {
            Texture2D lineTexture = new Texture2D(GraphicsDevice, 1, 1);
            lineTexture.SetData(new[] { Color.White });
            Vector2 delta = end - start;
            float length = delta.Length();
            float angle = MathF.Atan2(delta.Y, delta.X);

            spriteBatch.Draw(
                lineTexture,
                start,
                null,
                color,
                angle,
                Vector2.Zero,
                new Vector2(length, thickness),
                SpriteEffects.None,
                layer
            );
        }
        static public void DrawLine(SpriteBatch spriteBatch, Vector2 start, Vector2 end, float layer = 1f, float thickness = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {
            Color color = Color.Black;
            Texture2D lineTexture = new Texture2D(GraphicsDevice, 1, 1);
            lineTexture.SetData(new[] { Color.White });
            Vector2 delta = end - start;
            float length = delta.Length();
            float angle = MathF.Atan2(delta.Y, delta.X);

            spriteBatch.Draw(
                lineTexture,
                start,
                null,
                color,
                angle,
                Vector2.Zero,
                new Vector2(length, thickness),
                SpriteEffects.None,
                layer
            );
        }
    }
}
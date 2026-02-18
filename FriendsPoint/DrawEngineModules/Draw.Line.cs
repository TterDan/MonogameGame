
namespace FriendsPoint.DrawEngineModules {
    public partial class DrawEngine {
        static public void Line(SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color color, float layer = 1f, float thickness = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {
            Vector2 delta = end - start;
            float length = delta.Length();
            float angle = MathF.Atan2(delta.Y, delta.X);

            spriteBatch.Draw(
                TexturePixel,
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
        static public void Line(SpriteBatch spriteBatch, Vector2 start, Vector2 end, float layer = 1f, float thickness = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {
            Color color = Color.Black;
            Vector2 delta = end - start;
            float length = delta.Length();
            float angle = MathF.Atan2(delta.Y, delta.X);

            spriteBatch.Draw(
                TexturePixel,
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
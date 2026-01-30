
namespace FriendsPoint.DrawEngineModules {
    public partial class DrawEngine {                                                          // Статический класс камеры
        static public void DrawText(SpriteBatch spriteBatch, Vector2 position, string message, Vector2 centerPosition, Color color, float layer = 1f, float rotation = 0f, float scale = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {
            
            spriteBatch.DrawString(GameFont, message, position, color, rotation, centerPosition, scale, SpriteEffects.None, layer);

        }
        static public void DrawText(SpriteBatch spriteBatch, Vector2 position, string message, float layer = 1f, float rotation = 0f, float scale = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {

            Vector2 centerPosition = Vector2.Zero;
            Color color = Color.Black;

            spriteBatch.DrawString(GameFont, message, position, color, rotation, centerPosition, scale, SpriteEffects.None, layer);
        }
    }
}
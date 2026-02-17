
namespace FriendsPoint.DrawEngineModules {
    public partial class DrawEngine {
        //static public void Circle(SpriteBatch spriteBatch, Texture2D circleTexture, Vector2 position, int radius, Color color, float layer = 1f, float rotation = 0f, float scale = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {

        //    spriteBatch.Draw(circleTexture, position, new Rectangle(0, 0, 600, 600), color, rotation, new Vector2(300, 300), scale, SpriteEffects.None, layer);
        //}
        static public void Circle(SpriteBatch spriteBatch, Texture2D circleTexture, Vector2 position, int radius, float layer = 1f, float rotation = 0f, float scale = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {

            spriteBatch.Draw(circleTexture, position, new Rectangle(0, 0, 600, 600), Color.Red, rotation, new Vector2(300, 300), scale, SpriteEffects.None, layer);
        }
    }
}
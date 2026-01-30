
namespace FriendsPoint.DrawEngineModules {
    public partial class DrawEngine {                                                          // Статический класс камеры
        static public void DrawCircle(SpriteBatch spriteBatch, Vector2 position, int radius, Rectangle drawRectangle, Vector2 centerPosition, Color color, float layer = 1f, float rotation = 0f, float scale = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {

            int diameter = radius * 2;

            Texture2D texture = new Texture2D(GraphicsDevice, diameter, diameter);
            Color[] data = new Color[diameter * diameter];
            Vector2 center = new Vector2(radius);
            for (int y = 0; y < diameter; y++) {
                for (int x = 0; x < diameter; x++) {
                    int index = y * diameter + x;
                    Vector2 pos = new Vector2(x, y);

                    if (Vector2.Distance(pos, center) <= radius)
                        data[index] = color;
                    else
                        data[index] = Color.Transparent;
                }
            }

            texture.SetData(data);
            spriteBatch.Draw(texture, position, drawRectangle, color, rotation, centerPosition, scale * GameScale, SpriteEffects.None, layer);
        }
        static public void DrawCircle(SpriteBatch spriteBatch, Vector2 position, int radius, Color color, float layer = 1f, float rotation = 0f, float scale = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {

            int diameter = radius * 2;

            Rectangle drawRectangle = new Rectangle(0, 0, diameter, diameter);
            Vector2 centerPosition = new Vector2(radius, radius);

            Texture2D texture = new Texture2D(GraphicsDevice, diameter, diameter);
            Color[] data = new Color[diameter * diameter];
            Vector2 center = new Vector2(radius);
            for (int y = 0; y < diameter; y++) {
                for (int x = 0; x < diameter; x++) {
                    int index = y * diameter + x;
                    Vector2 pos = new Vector2(x, y);

                    if (Vector2.Distance(pos, center) <= radius)
                        data[index] = color;
                    else
                        data[index] = Color.Transparent;
                }
            }

            texture.SetData(data);

            spriteBatch.Draw(texture, position, drawRectangle, color, rotation, centerPosition, scale * GameScale, SpriteEffects.None, layer);
        }
    }
}
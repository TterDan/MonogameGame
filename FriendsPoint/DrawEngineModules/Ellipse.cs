
namespace FriendsPoint.DrawEngineModules {
    public partial class DrawEngine {
        static public void Circle(SpriteBatch spriteBatch, Texture2D circleTexture, Vector2 position, int radius, Color color, float layer = 1f, float rotation = 0f, float scale = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {

            spriteBatch.Draw(circleTexture, position, new Rectangle(0, 0, 600, 600), color, rotation, new Vector2(300, 300), scale, SpriteEffects.None, layer);
        }














        public static Texture2D CreateCircleTexture(int radius, GraphicsDevice GraphicsDevice) {
            int diameter = radius * 2;
            Texture2D texture = new Texture2D(GraphicsDevice, diameter, diameter);
            Color[] data = new Color[diameter * diameter];
            Vector2 center = new Vector2(radius);
            for (int y = 0; y < diameter; y++) {
                for (int x = 0; x < diameter; x++) {
                    int index = y * diameter + x;
                    Vector2 pos = new Vector2(x, y);
                    if (Vector2.Distance(pos, center) <= radius)
                        data[index] = Color.White;
                    else
                        data[index] = Color.Transparent;
                }
            }
            texture.SetData(data);
            return texture;
        }
        public static Texture2D CreateHalfCircleTexture(int radius, GraphicsDevice GraphicsDevice) {
            int diameter = radius * 2;
            Texture2D texture = new Texture2D(GraphicsDevice, diameter, radius);
            Color[] data = new Color[diameter * radius];
            Vector2 center = new Vector2(radius);
            for (int y = 0; y < radius; y++) {
                for (int x = 0; x < diameter; x++) {
                    int index = y * diameter + x;
                    Vector2 pos = new Vector2(x, y);
                    if (Vector2.Distance(pos, center) <= radius)
                        data[index] = Color.White;
                    else
                        data[index] = Color.Transparent;
                }
            }
            texture.SetData(data);
            return texture;
        }

        public static Texture2D CreateQuarterCircleTexture(int radius, GraphicsDevice GraphicsDevice) {
            Texture2D texture = new Texture2D(GraphicsDevice, radius, radius);
            Color[] data = new Color[radius * radius];
            Vector2 center = new Vector2(radius);
            for (int y = 0; y < radius; y++) {
                for (int x = 0; x < radius; x++) {
                    int index = y * radius + x;
                    Vector2 pos = new Vector2(x, y);
                    if (Vector2.Distance(pos, center) <= radius)
                        data[index] = Color.White;
                    else
                        data[index] = Color.Transparent;
                }
            }
            texture.SetData(data);
            return texture;
        }



        public static Texture2D CreateQuarterCircleTextureTransparent(int radius, GraphicsDevice GraphicsDevice) {
            Texture2D texture = new Texture2D(GraphicsDevice, radius, radius);
            Color[] data = new Color[radius * radius];
            Vector2 center = new Vector2(radius);
            for (int y = 0; y < radius; y++) {
                for (int x = 0; x < radius; x++) {
                    int index = y * radius + x;
                    Vector2 pos = new Vector2(x, y);
                    if (Vector2.Distance(pos, center) <= radius)
                        data[index] = Color.Transparent;
                    else
                        data[index] = Color.White;
                }
            }
            texture.SetData(data);
            return texture;
        }

    }
}
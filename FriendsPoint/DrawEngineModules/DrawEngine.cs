
namespace FriendsPoint.DrawEngineModules {
    public partial class DrawEngine {
        static public GraphicsDevice GraphicsDevice;
        static public float GameScale = 1.0f;
        static public SpriteFont GameFont;
        static public Texture2D TexturePixel;
        static public void Init(SpriteFont font, GraphicsDevice graphicsDevice) {
            GameFont = font;
            GraphicsDevice = graphicsDevice;
            TexturePixel = new Texture2D(GraphicsDevice, 1, 1);
            TexturePixel.SetData(new[] { Color.White });
        }
    }
}

namespace FriendsPoint
{
    public partial class Main : Game
    {
        // Стили, здесь создавайте стили рисования, а затем применяйте в отрисовке элемента;
        public FillStyle BasicFillStyle = new FillStyle(Color.Yellow);
        public StrokeStyle BasicStrokeStyle = new StrokeStyle(Color.Black, 6f, 0f, "3", new Vector2(0f, 0f), new Vector2(0f, 0f));

        public Texture2D Circle(int radius, Color color) {
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
            return texture;
        }
        public Texture2D BasicBlackCircleTexture;
        public Texture2D BasicHalfBlackCircleTexture;
        public Texture2D BasicRedCircleTexture;
    }
}

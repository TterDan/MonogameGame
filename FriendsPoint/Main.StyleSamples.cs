
namespace FriendsPoint
{
    public partial class Main : Game
    {
        // Стили, здесь создавайте стили рисования, а затем применяйте в отрисовке элемента;
        public FillStyle BasicFillStyle = new FillStyle(Color.Blue);
        public StrokeStyle BasicStrokeStyleOn = new StrokeStyle(Color.Black, 5f, "on");
        public StrokeStyle BasicStrokeStyleIn = new StrokeStyle(Color.Black, 15f, "in");
        public StrokeStyle BasicStrokeStyleOut = new StrokeStyle(Color.Black, 15f, "out");
        public LineStyle BasicLineStyleSolid = new LineStyle("solid", 0f);
        public LineStyle BasicLineStyleWavy = new LineStyle("wavy", 3f, 25f, false, 0f, 0f);
        public LineStyle BasicLineStyleDashed = new LineStyle("dashed", 25f, 5, 0f);
        public LineStyle BasicLineStyleDashedSpacing = new LineStyle("dashed", 7f, 14f, 0f, 0f);
        public LineStyle BasicLineStyleDotted = new LineStyle("dashed", 15f, 5, 0f);
        public LineStyle BasicLineStyleDouble = new LineStyle("double", 10f, "in", 0f);

        public Texture2D CreateCircleTexture1(int radius) {
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
        public Texture2D CreateQuarterCircleTexture(int radius) {
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
        public Texture2D CreateCircleTexture(int radius) {
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
        public Texture2D CircleTexture;
        public Texture2D HalfCircleTexture;
        public Texture2D QuarterCircleTexture;
    }
}

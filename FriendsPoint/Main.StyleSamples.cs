
namespace FriendsPoint
{
    public partial class Main : Game
    {
        // Стили, здесь создавайте стили рисования, а затем применяйте в отрисовке элемента;
        public FillStyle BasicFillStyle = new FillStyle(Color.Blue);
        public StrokeStyle BasicStrokeStyleOn = new StrokeStyle(Color.Black, 15f, "on");
        public StrokeStyle BasicStrokeStyleIn = new StrokeStyle(Color.Black, 15f, "in");
        public StrokeStyle BasicStrokeStyleOut = new StrokeStyle(Color.Black, 15f, "out");
        public LineStyle BasicLineStyleSolid = new LineStyle("solid", 0f);
        public LineStyle BasicLineStyleWavy = new LineStyle("wavy", 5f, 0.1f, false, 0f);
        public LineStyle BasicLineStyleDashed = new LineStyle("dashed", 25f, 5, 0f);
        public LineStyle BasicLineStyleDotted = new LineStyle("dashed", 15f, 5, 0f);
        public LineStyle BasicLineStyleDouble = new LineStyle("double", 10f, 0f);

        public Texture2D Circle(int radius) {
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
                        data[index] = Color.White;
                    else
                        data[index] = Color.Transparent;
                }
            }
            texture.SetData(data);
            return texture;
        }
        public Texture2D CircleTexture;
    }
}

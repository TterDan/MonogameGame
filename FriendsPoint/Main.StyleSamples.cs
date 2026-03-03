
namespace FriendsPoint
{
    public partial class Main : Game
    {
        // Стили, здесь создавайте стили рисования, а затем применяйте в отрисовке элемента;
        public StrokeStyle BasicStrokeStyleOn = new StrokeStyle(Color.Black, 5f, "on");
        public StrokeStyle BasicStrokeStyleIn = new StrokeStyle(Color.Black, 15f, "in");
        public StrokeStyle BasicStrokeStyleOut = new StrokeStyle(Color.Black, 15f, "out");
        public LineStyle BasicLineStyleSolid = new LineStyle("solid", 0f);
        public LineStyle BasicLineStyleWavy = new LineStyle("wavy", 3f, 25f, false, 0f, 0f);
        public LineStyle BasicLineStyleDashed = new LineStyle("dashed", 25f, 5, 0f);
        public LineStyle BasicLineStyleDashedSpacing = new LineStyle("dashed", 7f, 14f, 0f, 0f);
        public LineStyle BasicLineStyleDotted = new LineStyle("dashed", 15f, 5, 0f);
        public LineStyle BasicLineStyleDouble = new LineStyle("double", 10f, "in", 0f);


        public Texture2D CircleTexture;
        public Texture2D HalfCircleTexture;
        public Texture2D QuarterCircleTexture;
    }
}

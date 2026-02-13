public class DrawStyle {
    public string DrawingType;


    public float Blur = 0;                      // Уровень размытия

    public float ShadowBlur = 0;                // Размытие тени
    public Vector2 ShadowOffset = Vector2.Zero; // Смещение тени
    public float ShadowTransparency = 1.0f;     // Прозрачность тени
    public Color ShadowColor = Color.White;     // Цвет тени

    public float GlowBlur = 0;                  // Размытие свечения
    public float GlowSize = 1.0f;               // Размер свечения
    public float GlowTransparency = 1.0f;       // Прозрачность свечения
    public Color GlowColor = Color.White;       // Цвет свечения

    public Color FillColor = Color.Gray;        // Цвет заливки
    public float FillTransparency = 1.0f;       // Прозрачность заливки

    public Color StrokeColor = Color.Black;     // Цвет обводки
    public float StrokeTransparency = 1.0f;     // Прозрачность обводки
    public float StrokeWidth = 2.0f;            // Ширина обводки
    public float StrokeRound = 0;               // Скругление обводки. Работает только для нескругленных фигур 
    public string StrokePositionVariant = "onBorder";  // 1 - onFiguresBorder, 2 - outOfTheFigure, 3 - inTheFigure;   1 - Обводка на границе фигуры, 2 - обводка за границей фигуры, 3 - обводка в пределах границы вигуры
    public Vector2 StrokeOffsetX = Vector2.Zero;        // Смещение левой границы фигуры от самой фигуры, и смещение правой границы фигуры от самой фигуры
    public Vector2 StrokeOffsetY = Vector2.Zero;        // Смещение верхней границы фигуры от самой фигуры, и смещение нижней границы фигуры от самой фигуры

    public string StrokeStyle = "solid"; // 1 - solid, 2 - double, 3 - dotted, 4 - dashed, 5 - wavy";     1 - сплошная линия, 2 - двойная линия, 3 - точечная линия, 4 - пунктирная линия, 5 - волнистая линия

    public float StrokeStyleWidth = 0.5f;                      // Ширина линии
    public float StrokeStyleLinesDistance = 0.3f;               // Расстояние между линиями двойной линии
    public float StrokeStyleDashesWidth = 0.1f;         // Ширина пунктиров пунктирной линии
    public float StrokeStyleDashesDistance = 0.1f;      // Расстояние между пунктирами пунктирной линии

    public float StrokeStyleFold = 1.0f;            // Сила сгиба волнистой линии
    public bool StrokeStyleIsSharp = false;         // Является ли волнистая линия зигзагообразной

}
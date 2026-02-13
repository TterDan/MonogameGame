
public class GlowStyle {
    public float GlowSize;                  // Размер свечения
    public Color GlowColor;                 // Цвет свечения
    public float GlowBlur;                  // Размытие свечения
    public GlowStyle(float glowSize, Color glowColor, float glowBlur) {
        GlowSize = glowSize;
        GlowColor = glowColor;
        GlowBlur = glowBlur;
    }
}
public class ShadowStyle {
    public Vector2 ShadowOffset;            // Смещение тени
    public Color ShadowColor;               // Цвет тени
    public float ShadowBlur;                // Размытие тени
    public ShadowStyle(Vector2 shadowOffset, Color shadowColor, float shadowBlur) {
        ShadowOffset = shadowOffset;
        ShadowColor = shadowColor;
        ShadowBlur = shadowBlur;
    }
}
public class PostProcessing {
    public float Blur;                      // Уровень размытия
    public PostProcessing(float blur) {
        Blur = blur;
    }
}
public class StrokeStyle {
    public Color StrokeColor;               // Цвет заливки
    public float StrokeWidth;               // Ширина обводки
    public float StrokeRound;               // Скругление обводки. Работает только для нескругленных фигур 
    public string StrokePositionVariant;    // 1 - onFiguresBorder, 2 - outOfTheFigure, 3 - inTheFigure;   1 - Обводка на границе фигуры, 2 - обводка за границей фигуры, 3 - обводка в пределах границы вигуры
    public Vector2 StrokeOffsetX;           // Смещение левой границы фигуры от самой фигуры, и смещение правой границы фигуры от самой фигуры
    public Vector2 StrokeOffsetY;           // Смещение верхней границы фигуры от самой фигуры, и смещение нижней границы фигуры от самой фигуры
}
public class FillStyle {
    public Color FillColor;                 // Цвет обводки
    public FillStyle(Color fillColor) {
        FillColor = fillColor;
    }
}

public class BasicStyle {
    public Vector2 Position;                // Позиция
    public Vector2 Size;                    // Размеры
    public Vector2 CenterPosition;          // Центр отрисовки
    public float Round;                     // Скругление углов
    public BasicStyle(Vector2 position, Vector2 size, Vector2 centerPosition, float round) {
        Position = position;
        Size = size;
        CenterPosition = centerPosition;
        Round = round;
    }
}

public class TextStyle {
    public string FontFamily;               // Шрифт
    public string FontSize;                 // Размер шрифта
    public string LetterSpacing;            // Междубуквенный интервал
    public string LineSpacing;              // Междустрочный интервал
    public string TextPositioning;          // 1 - start, 2 - center, 3 - end;          1 - Текст держится левой стороны, 2 - Текст центрируется, 3 - Текст держится правой стороны
    public bool IsHaveLine;
    public TextStyle (string fontFamily, string fontSize, string letterSpacing, string lineSpacing, string textPositioning) {
        FontFamily = fontFamily;
        FontSize = fontSize;
        LetterSpacing = letterSpacing;
        LineSpacing = lineSpacing;
        TextPositioning = textPositioning;
    }
}

public class LineStyle {
    public string LineType;                      // 1 - solid, 2 - double, 3 - dotted, 4 - dashed, 5 - wavy";     1 - сплошная линия, 2 - двойная линия, 3 - точечная линия, 4 - пунктирная линия, 5 - волнистая линия
    public string LinePositionStyle;                // 1 - underline, 2 - inline, 3 - overline;         1 - подчеркивание, 2 - перечеркивание, 3 - надчеркивание

    public float StrokeStyleWidth;                  // Ширина линии
    public float StrokeStyleLinesDistance;          // Расстояние между линиями двойной линии
    public float StrokeStyleDashesWidth;            // Ширина пунктиров пунктирной линии
    public float StrokeStyleDashesDistance;         // Расстояние между пунктирами пунктирной линии

    public float StrokeStyleFold;                   // Сила сгиба волнистой линии
    public bool StrokeStyleIsSharp;                 // Является ли волнистая линия зигзагообразной
    public LineStyle(string lineType, string linePositionStyle, float strokeStyleWidth, float strokeStyleFold, bool strokeStyleIsSharp) {
        LineType = lineType;
        LinePositionStyle = linePositionStyle;
        StrokeStyleWidth = strokeStyleWidth;

        StrokeStyleFold = strokeStyleFold;
        StrokeStyleIsSharp = strokeStyleIsSharp;
    }
    public LineStyle(string lineType, string linePositionStyle, float strokeStyleWidth, float strokeStyleLinesDistance, float strokeStyleDashesWidth, float strokeStyleDashesDistance) {
        LineType = lineType;
        LinePositionStyle = linePositionStyle;
        StrokeStyleWidth = strokeStyleWidth;

        StrokeStyleLinesDistance = strokeStyleLinesDistance;
        StrokeStyleDashesWidth = strokeStyleDashesWidth;
        StrokeStyleDashesDistance = strokeStyleDashesDistance;
    }
    public LineStyle(string lineType, string linePositionStyle, float strokeStyleWidth) {
        LineType = lineType;
        LinePositionStyle = linePositionStyle;
        StrokeStyleWidth = strokeStyleWidth;
    }
}
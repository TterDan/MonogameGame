

public class Style {

}
public class GlowStyle : Style {
    public float Size;                  // Размер свечения
    public Color Color;                 // Цвет свечения
    public float Blur;                  // Размытие свечения
    public GlowStyle(float glowSize, Color glowColor, float glowBlur) {
        Size = glowSize;
        Color = glowColor;
        Blur = glowBlur;
    }
}
public class ShadowStyle : Style {
    public Vector2 Offset;            // Смещение тени
    public Color Color;               // Цвет тени
    public float Blur;                // Размытие тени
    public ShadowStyle(Vector2 shadowOffset, Color shadowColor, float shadowBlur) {
        Offset = shadowOffset;
        Color = shadowColor;
        Blur = shadowBlur;
    }
}
public class PostProcessing : Style {
    public float Blur;                      // Уровень размытия
    public PostProcessing(float blur) {
        Blur = blur;
    }
}
public class StrokeStyle : Style {
    public Color Color;               // Цвет заливки
    public float Width;               // Ширина обводки
    public float Round;               // Скругление обводки. Работает только для нескругленных фигур 
    public string PositionVariant;    // 1 - onFiguresBorder, 2 - outOfTheFigure, 3 - inTheFigure;   1 - Обводка на границе фигуры, 2 - обводка за границей фигуры, 3 - обводка в пределах границы вигуры
    public Vector2 OffsetX;           // Смещение левой границы фигуры от самой фигуры, и смещение правой границы фигуры от самой фигуры
    public Vector2 OffsetY;           // Смещение верхней границы фигуры от самой фигуры, и смещение нижней границы фигуры от самой фигуры
    public StrokeStyle(Color strokeColor, float strokeWidth, float strokeRound, string strokePositionVariant, Vector2 strokeOffsetX, Vector2 strokeOffsetY) {
        Color = strokeColor;
        Width = strokeWidth;
        Round = strokeRound;
        PositionVariant = strokePositionVariant;
        OffsetX = strokeOffsetX;
        OffsetY = strokeOffsetY;
    }
}
public class FillStyle : Style {
    public Color Color;                 // Цвет обводки
    public FillStyle(Color fillColor) {
        Color = fillColor;
    }
}

public class BasicStyle : Style {
    public Vector2 Position;                // Позиция
    public Vector2 Size;                    // Размеры
    public float Scale;                     // Масштабирование
    public Vector2 CenterPosition;          // Центр отрисовки
    public float Round;                     // Скругление углов
    public BasicStyle(Vector2 position, Vector2 size, Vector2 centerPosition, float round) {
        Position = position;
        Size = size;
        CenterPosition = centerPosition;
        Round = round;
    }
}

public class TextStyle : Style {
    public string FontFamily;               // Шрифт
    public string FontSize;                 // Размер шрифта
    public string LetterSpacing;            // Междубуквенный интервал
    public string LinesSpacing;              // Междустрочный интервал
    public string TextPositioning;          // 1 - start, 2 - center, 3 - end;          1 - Текст держится левой стороны, 2 - Текст центрируется, 3 - Текст держится правой стороны
    public bool IsHaveLine;
    public TextStyle (string fontFamily, string fontSize, string letterSpacing, string lineSpacing, string textPositioning) {
        FontFamily = fontFamily;
        FontSize = fontSize;
        LetterSpacing = letterSpacing;
        LinesSpacing = lineSpacing;
        TextPositioning = textPositioning;
    }
}

public class LineStyle : Style {
    public string Type;                         // 1 - solid, 2 - double, 3 - dotted, 4 - dashed, 5 - wavy";     1 - сплошная линия, 2 - двойная линия, 3 - точечная линия, 4 - пунктирная линия, 5 - волнистая линия
    public string PositionVariant;              // 1 - underline, 2 - inline, 3 - overline;         1 - подчеркивание, 2 - перечеркивание, 3 - надчеркивание

    public float Width;                         // Ширина линии
    public float LinesDistance;                 // Расстояние между линиями двойной линии
    public float DashesWidth;                   // Ширина пунктиров пунктирной линии
    public float DashesDistance;                // Расстояние между пунктирами пунктирной линии

    public float Fold;                          // Сила сгиба волнистой линии
    public bool Sharp;                          // Является ли волнистая линия зигзагообразной
    public LineStyle(string lineType, string linePositionStyle, float strokeStyleWidth, float strokeStyleFold, bool strokeStyleIsSharp) {
        Type = lineType;
        PositionVariant = linePositionStyle;
        Width = strokeStyleWidth;

        Fold = strokeStyleFold;
        Sharp = strokeStyleIsSharp;
    }
    public LineStyle(string lineType, string linePositionStyle, float strokeStyleWidth, float strokeStyleLinesDistance, float strokeStyleDashesWidth, float strokeStyleDashesDistance) {
        Type = lineType;
        PositionVariant = linePositionStyle;
        Width = strokeStyleWidth;

        LinesDistance = strokeStyleLinesDistance;
        DashesWidth = strokeStyleDashesWidth;
        DashesDistance = strokeStyleDashesDistance;
    }

    public LineStyle(string lineType, string linePositionStyle, float strokeStyleWidth) {
        Type = lineType;
        PositionVariant = linePositionStyle;
        Width = strokeStyleWidth;
    }
}


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
    public string PositionVariant;    // 1 - on, 2 - out, 3 - in;   1 - Обводка на границе фигуры, 2 - обводка за границей фигуры, 3 - обводка в пределах границы вигуры
    public Vector2 OffsetX;           // Смещение левой границы фигуры от самой фигуры, и смещение правой границы фигуры от самой фигуры
    public Vector2 OffsetY;           // Смещение верхней границы фигуры от самой фигуры, и смещение нижней границы фигуры от самой фигуры
    public StrokeStyle(Color strokeColor, float strokeWidth, string strokePositionVariant, float strokeRound, Vector2 strokeOffsetX, Vector2 strokeOffsetY) {
        Color = strokeColor;
        Width = strokeWidth;
        Round = strokeRound;
        PositionVariant = strokePositionVariant;
        OffsetX = strokeOffsetX;
        OffsetY = strokeOffsetY;
    }
    public StrokeStyle(Color strokeColor, float strokeWidth, string strokePositionVariant, Vector2 strokeOffsetX, Vector2 strokeOffsetY) {
        Color = strokeColor;
        Width = strokeWidth;
        Round = 0f;
        PositionVariant = strokePositionVariant;
        OffsetX = strokeOffsetX;
        OffsetY = strokeOffsetY;
    }
    public StrokeStyle(Color strokeColor, float strokeWidth, string strokePositionVariant, float strokeRound) {
        Color = strokeColor;
        Width = strokeWidth;
        Round = strokeRound;
        PositionVariant = strokePositionVariant;
        OffsetX = Vector2.Zero;
        OffsetY = Vector2.Zero;
    }
    public StrokeStyle(Color strokeColor, float strokeWidth, string strokePositionVariant) {
        Color = strokeColor;
        Width = strokeWidth;
        Round = 0f;
        PositionVariant = strokePositionVariant;
        OffsetX = Vector2.Zero;
        OffsetY = Vector2.Zero;
    }
}
public class FillStyle : Style {
    public Color Color;                 // Цвет обводки
    public FillStyle(Color fillColor) {
        Color = fillColor;
    }
}

//public class BasicStyle : Style {
//    public Vector2 Position;                // Позиция
//    public Vector2 Size;                    // Размеры
//    public float Scale;                     // Масштабирование
//    public Vector2 CenterPosition;          // Центр отрисовки
//    public float Round;                     // Скругление углов
//    public BasicStyle(Vector2 position, Vector2 size, Vector2 centerPosition, float round) {
//        Position = position;
//        Size = size;
//        CenterPosition = centerPosition;
//        Round = round;
//    }
//}

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
    //public string PositionVariant;              // 1 - underline, 2 - inline, 3 - overline;         1 - подчеркивание, 2 - перечеркивание, 3 - надчеркивание
    public float Round;

    public float LinesDistance;                 // Расстояние между линиями двойной линии

    public int DotsNum;

    public float DashesWidth;                   // Ширина пунктиров пунктирной линии
    public float DashesSpacing;                // Расстояние между пунктирами пунктирной линии
    public int DashesNum;                     // Количество пунктиров
    public string DashedLineType;                 // Тип пунктирной линии: 1 - num, 2 - spacing ;            1 - Линия строится учитывая количество пунктиров, 2 - Линия строится учитывая расстояние между пунктирами


    public float WaveAmplitude;                     // Сила сгиба волнистой линии
    public bool isZigZag;                           // Является ли волнистая линия зигзагообразной
    public float WaveFrequency;                     // Частота волнистой линии

    public float Offset;                        // Сдвиг рисовки линии пунктирной / волнистой

    public LineStyle(string lineType, float lineRound) {
        Type = lineType;
        Round = lineRound;
    }

    public LineStyle(string lineType, float strokeStyleDashesWidth, float strokeStyleDashesSpacing, float lineRound) {
        Type = lineType;
        Round = lineRound;

        DashedLineType = "spacing";

        DashesWidth = strokeStyleDashesWidth;
        DashesSpacing = strokeStyleDashesSpacing;
    }
    public LineStyle(string lineType, float strokeStyleDashesWidth, int dashesNum, float lineRound) {
        Type = lineType;
        Round = lineRound;

        DashedLineType = "num";

        DashesWidth = strokeStyleDashesWidth;
        DashesNum = dashesNum;
    }

    public LineStyle(string lineType, float strokeStyleLinesDistance, float lineRound) {
        Type = lineType;
        Round = lineRound;

        LinesDistance = strokeStyleLinesDistance;
    }
    public LineStyle(string lineType, float waveAmplitude, float waveFrequency, bool strokeStyleIsZigZag, float lineRound) {
        Type = lineType;
        Round = lineRound;

        WaveAmplitude = waveAmplitude;
        WaveFrequency = waveFrequency;
        isZigZag = strokeStyleIsZigZag;
    }
}
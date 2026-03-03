

public class Style {

}
public class ShadowStyle : Style {
    public Vector2 Offset;            // Смещение тени
    public Vector2 ShadowSize; //   Размер тени
    public Color Color;               // Цвет тени
    public float Blur;                // Размытие тени

    public ShadowStyle(Vector2 shadowOffset, Vector2 shadowSize, Color shadowColor, float shadowBlur) {
        Offset = shadowOffset;
        Color = shadowColor;
        Blur = shadowBlur;
        ShadowSize = shadowSize;
    }
}
public class PostProcessingStyle : Style {
    public float Blur;                      // Уровень размытия
    public PostProcessingStyle(float blur) {
        Blur = blur;
    }
}
public class StrokeStyle : Style {
    public Color Color;               // Цвет заливки
    public float Width;               // Ширина обводки
    public float Round;               // Скругление обводки по углам. Работает только для нескругленных фигур 
    public string PositionVariant;    // 1 - on, 2 - out, 3 - in;   1 - Обводка на границе фигуры, 2 - обводка за границей фигуры, 3 - обводка в пределах границы вигуры

    public StrokeStyle(Color strokeColor, float strokeWidth, string strokePositionVariant, float strokeRound) {
        Color = strokeColor;
        Width = strokeWidth;
        Round = strokeRound;
        PositionVariant = strokePositionVariant;
    }
    public StrokeStyle(Color strokeColor, float strokeWidth, string strokePositionVariant) {
        Color = strokeColor;
        Width = strokeWidth;
        Round = 0f;
        PositionVariant = strokePositionVariant;
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
    public float Round;

    public float LinesDistance;                 // Расстояние между линиями двойной линии
    public string SecondLinePosition;                 // Позиция второй линии    1 - out, 2 - in;        1 - снаружи, 2 - внутри

    public float DashesWidth;                   // Ширина пунктиров пунктирной линии
    public float DashesSpacing;                // Расстояние между пунктирами пунктирной линии
    public int DashesNum;                     // Количество пунктиров
    public string DashedLineType;                 // Тип пунктирной линии: 1 - num, 2 - spacing ;            1 - Линия строится учитывая количество пунктиров, 2 - Линия строится учитывая расстояние между пунктирами

    public float WaveAmplitude;                     // Сила сгиба волнистой линии
    public bool isZigZag;                           // Является ли волнистая линия зигзагообразной
    public float WaveFrequency;                     // Частота волнистой линии

    public float Phase;                             // Фаза пунктирной / зигзагообразной / волнистой линии
    public LineStyle(string lineType, float lineRound) {
        Type = lineType;
        Round = lineRound;
    }

    public LineStyle(string lineType, float strokeStyleDashesWidth, float strokeStyleDashesSpacing, float phase, float lineRound) {
        Type = lineType;
        Round = lineRound;

        DashedLineType = "spacing";

        DashesWidth = strokeStyleDashesWidth;
        DashesSpacing = strokeStyleDashesSpacing;

        Phase = phase;
    }
    public LineStyle(string lineType, float strokeStyleDashesWidth, int dashesNum, float lineRound) {
        Type = lineType;
        Round = lineRound;

        DashedLineType = "num";

        DashesWidth = strokeStyleDashesWidth;
        DashesNum = dashesNum;
    }

    public LineStyle(string lineType, float strokeStyleLinesDistance, string secondLinePosition, float lineRound) {
        Type = lineType;
        Round = lineRound;

        SecondLinePosition = secondLinePosition;
        LinesDistance = strokeStyleLinesDistance;
    }
    public LineStyle(string lineType, float waveAmplitude, float waveFrequency, bool strokeStyleIsZigZag, float phase, float lineRound) {
        Type = lineType;
        Round = lineRound;

        WaveAmplitude = waveAmplitude;
        WaveFrequency = waveFrequency;
        isZigZag = strokeStyleIsZigZag;
        Phase = phase;
    }
}
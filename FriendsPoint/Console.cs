using System.Text;
public class Log {
    public StringBuilder Message = new StringBuilder(64);
    public StringBuilder DateTime = new StringBuilder(8);
    public string Key;
    public Color Color;
    public Log() {
        Key = "";
        Color = Color.White;
    }
    public void DoLog(StringBuilder message, string key, DateTime dateTime, Color color) {
        Message.Clear();
        Message.Append(message);
        DateTime.Clear();
        int h = dateTime.Hour;
        int m = dateTime.Minute;
        int s = dateTime.Second;

        AppendTwoDigits(DateTime, h);
        DateTime.Append(':');
        AppendTwoDigits(DateTime, m);
        DateTime.Append(':');
        AppendTwoDigits(DateTime, s);


        Key = key;
        Color = color;
    }
    private void AppendTwoDigits(StringBuilder stringBuilder, int value) {
        stringBuilder.Append((char)('0' + value / 10));
        stringBuilder.Append((char)('0' + value % 10));
    }
    public void CopyFrom(Log other) {
        Message.Clear();
        Message.Append(other.Message);

        DateTime.Clear();
        DateTime.Append(other.DateTime);

        Key = other.Key;
        Color = other.Color;
    }
}
static public class Console {                                                          // Статический класс консоли
    static public Vector2 WindowSize;
    static public bool IsConsoleOpen = false;
    static public float oneX;
    static public float oneY;
    static private readonly Log[] LogsPool = new Log[21];
    static private int CountOfRepeatLogs = 0;
    static public void Init(Vector2 windowSize) {
        WindowSize = windowSize;
        oneX = windowSize.X / 100;
        oneY = windowSize.Y / 100;
        for (int i = 0; i < LogsPool.Length; i++)
            LogsPool[i] = new Log();
    }
    static public StringBuilder TextBuffer = new StringBuilder(64);

    static public void BeforeLog(StringBuilder message, string key, Color? colorNullable) {
        Color color = (colorNullable == null ? Color.White : colorNullable.Value);
        if (key == "Log") {
            for (int i = LogsPool.Length - 2; i >= CountOfRepeatLogs; i--) {
                LogsPool[i + 1].CopyFrom(LogsPool[i]);
            }
            LogsPool[CountOfRepeatLogs].DoLog(message, key, DateTime.Now, color);
        } else {
            for (int i = 0; i < CountOfRepeatLogs; i++) {
                if (LogsPool[i].Key == key) {
                    LogsPool[i].DoLog(message, key, DateTime.Now, color);
                    return;
                }
            }
            for (int i = LogsPool.Length - 2; i >= CountOfRepeatLogs; i--) {
                LogsPool[i + 1].CopyFrom(LogsPool[i]);
            }
            LogsPool[CountOfRepeatLogs].DoLog(message, key, DateTime.Now, color);
            if (CountOfRepeatLogs < LogsPool.Length - 1)
                CountOfRepeatLogs++;
        }
    }
    static public void Log(string message, string key = "Log", Color? color = null) {
        TextBuffer.Clear().Append(message);
        BeforeLog(TextBuffer, key, color);
    }
    static public void Log(int message, string key = "Log", Color? color = null) {
        TextBuffer.Clear().Append(message);
        BeforeLog(TextBuffer, key, color);
    }
    static public void Log(float message, string key = "Log", Color? color = null) {
        TextBuffer.Clear().Append(message);
        BeforeLog(TextBuffer, key, color);
    }
    static public void Log(double message, string key = "Log", Color? color = null) {
        TextBuffer.Clear().Append(message);
        BeforeLog(TextBuffer, key, color);
    }
    static public void Log(long message, string key = "Log", Color? color = null) {
        TextBuffer.Clear().Append(message);
        BeforeLog(TextBuffer, key, color);
    }
    static public void Log(char message, string key = "Log", Color? color = null) {
        TextBuffer.Clear().Append(message);
        BeforeLog(TextBuffer, key, color);
    }
    static public void Log(Rectangle message, string key = "Log", Color? color = null) {
        TextBuffer.Clear().Append(message);
        BeforeLog(TextBuffer, key, color);
    }
    static public void Log(Vector2 message, string key = "Log", Color? color = null) {
        TextBuffer.Clear().Append(message);
        BeforeLog(TextBuffer, key, color);
    }
    static public void DrawConsole(SpriteBatch spriteBatch) {
        DrawEngine.RectFigure(
            spriteBatch,
            new Vector2(oneX, oneY),
            new Rectangle(0, 0, (int)oneX * 50, (int)(oneY * 35)),
            Vector2.Zero,
            Color.Black * 0.8f,
            0.7f
        );

        DrawEngine.DrawText(spriteBatch, new Vector2(oneX * 2, oneY), "Console", Color.White, 0.71f);

        float y = oneY * 3;

        for (int i = 0; i < LogsPool.Length; i++) {
            DrawLogLine(spriteBatch, LogsPool[i], y);
            y += oneY * 1.5f;
        }
    }
    static void DrawLogLine(SpriteBatch spriteBatch, Log log, float y) {
        Vector2 pos = new Vector2(oneX * 2, y);

        spriteBatch.DrawString(DrawEngine.GameFont, log.DateTime, pos, log.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.71f);
        pos.X += 160;

        spriteBatch.DrawString(DrawEngine.GameFont, "|", pos, log.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.71f);
        pos.X += 10;

        spriteBatch.DrawString(DrawEngine.GameFont, log.Key, pos, log.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.71f);
        pos.X += 300;

        spriteBatch.DrawString(DrawEngine.GameFont, ":", pos, log.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.71f);
        pos.X += 10;

        spriteBatch.DrawString(DrawEngine.GameFont, log.Message, pos, log.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.71f);
    }
}
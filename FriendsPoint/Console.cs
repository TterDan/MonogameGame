using System.Reflection.Emit;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

public class Log {
    public StringBuilder Message = new StringBuilder(128);
    public StringBuilder DateTime = new StringBuilder(8);
    public string Key;
    public Color Color;
    public Log() {
        Key = "";
        Color = Color.White;
    }
    public void DoLog(string message, string key, DateTime dateTime, Color color) {
        Message.Clear();
        Message.Append(message);
        DateTime.Clear();
        DateTime.Append(dateTime);
        Key = key;
        Color = color;
    }
    public void DoLog(int message, string key, DateTime dateTime, Color color) {
        Message.Clear();
        Message.Append(message);
        DateTime.Clear();
        DateTime.Append(dateTime);
        Key = key;
        Color = color;
    }
    public void DoLog(float message, string key, DateTime dateTime, Color color) {
        Message.Clear();
        Message.Append(message);
        DateTime.Clear();
        DateTime.Append(dateTime);
        Key = key;
        Color = color;
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
    static Console() {
        for (int i = 0; i < LogsPool.Length; i++)
            LogsPool[i] = new Log();
    }
    static public void Log(string message, string key = "Log", Color? color = null) {
        if (key == "Log") {
            for (int i = LogsPool.Length - 2; i >= CountOfRepeatLogs; i--) {
                LogsPool[i + 1].CopyFrom(LogsPool[i]);
            }
            LogsPool[CountOfRepeatLogs].DoLog(message, key, DateTime.Now, (color == null ? Color.White : color).Value);
        } else {
            for (int i = 0; i < CountOfRepeatLogs; i++) {
                if (LogsPool[i].Key == key) {
                    LogsPool[i].DoLog(message, key, DateTime.Now, (color == null ? Color.White : color).Value);
                    return;
                }
            }
            for (int i = LogsPool.Length - 2; i >= CountOfRepeatLogs; i--) {
                LogsPool[i + 1].CopyFrom(LogsPool[i]);
            }
            LogsPool[CountOfRepeatLogs].DoLog(message, key, DateTime.Now, (color == null ? Color.White : color).Value);
            if (CountOfRepeatLogs < LogsPool.Length - 1)
                CountOfRepeatLogs++;
        }
    }
    static public void Log(int message, string key = "Log", Color? color = null) {
        if (key == "Log") {
            for (int i = LogsPool.Length - 2; i >= CountOfRepeatLogs; i--) {
                LogsPool[i + 1].CopyFrom(LogsPool[i]);
            }
            LogsPool[CountOfRepeatLogs].DoLog(message, key, DateTime.Now, (color == null ? Color.White : color).Value);
        } else {
            for (int i = 0; i < CountOfRepeatLogs; i++) {
                if (LogsPool[i].Key == key) {
                    LogsPool[i].DoLog(message, key, DateTime.Now, (color == null ? Color.White : color).Value);
                    return;
                }
            }
            for (int i = LogsPool.Length - 2; i >= CountOfRepeatLogs; i--) {
                LogsPool[i + 1].CopyFrom(LogsPool[i]);
            }
            LogsPool[CountOfRepeatLogs].DoLog(message, key, DateTime.Now, (color == null ? Color.White : color).Value);
            if (CountOfRepeatLogs < LogsPool.Length - 1)
                CountOfRepeatLogs++;
        }
    }
    static public void Log(float message, string key = "Log", Color? color = null) {
        if (key == "Log") {
            for (int i = LogsPool.Length - 2; i >= CountOfRepeatLogs; i--) {
                LogsPool[i + 1].CopyFrom(LogsPool[i]);
            }
            LogsPool[CountOfRepeatLogs].DoLog(message, key, DateTime.Now, (color == null ? Color.White : color).Value);
        } else {
            for (int i = 0; i < CountOfRepeatLogs; i++) {
                if (LogsPool[i].Key == key) {
                    LogsPool[i].DoLog(message, key, DateTime.Now, (color == null ? Color.White : color).Value);
                    return;
                }
            }
            for (int i = LogsPool.Length - 2; i >= CountOfRepeatLogs; i--) {
                LogsPool[i + 1].CopyFrom(LogsPool[i]);
            }
            LogsPool[CountOfRepeatLogs].DoLog(message, key, DateTime.Now, (color == null ? Color.White : color).Value);
            if (CountOfRepeatLogs < LogsPool.Length - 1)
                CountOfRepeatLogs++;
        }
    }
    static public void DrawConsole(SpriteBatch spriteBatch) {
        DrawEngine.RectFigure(
            spriteBatch,
            new Vector2(oneX, oneY),
            new Rectangle(0, 0, (int)oneX * 50, (int)(oneY * 35)),
            Vector2.Zero,
            Color.Black * 0.8f,
            0.95f
        );

        DrawEngine.Text(spriteBatch, new Vector2(oneX * 2, oneY), "Console", Vector2.Zero, Color.White);

        float y = oneY * 3;

        for (int i = 0; i < LogsPool.Length; i++) {
            DrawLogLine(spriteBatch, LogsPool[i], y);
            y += oneY * 1.5f;
        }
    }
    static void DrawLogLine(SpriteBatch spriteBatch, Log log, float y) {
        Vector2 pos = new Vector2(oneX * 2, y);

        spriteBatch.DrawString(DrawEngine.GameFont, log.DateTime, pos, log.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.99f);
        pos.X += 160;

        spriteBatch.DrawString(DrawEngine.GameFont, "|", pos, log.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.99f);
        pos.X += 10;

        spriteBatch.DrawString(DrawEngine.GameFont, log.Key, pos, log.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.99f);
        pos.X += 80;

        spriteBatch.DrawString(DrawEngine.GameFont, ":", pos, log.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.99f);
        pos.X += 10;

        spriteBatch.DrawString(DrawEngine.GameFont, log.Message, pos, log.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.99f);
    }
}
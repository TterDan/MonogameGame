
public class Log {
    public string Message;
    public string DateTime;
    public string Key;
    public Color MesColor;
    public Log(string message, string dateTime, string key, Color mesColor) {
        Message = message;
        DateTime = dateTime;
        Key = key;
        MesColor = mesColor;
    }
}
static public class Console {                                                          // Статический класс консоли
    static public List<Log> NonRepeatLogs = new List<Log> { };
    static public List<Log> RepeatLogs = new List<Log> { };
    static public Vector2 WindowSize;
    static public bool IsConsoleOpen = false;
    static public void Log(string message, Color color, string type = "non-repeat", string key = "Log") {
        DoLog(message, color, type, key);
    }
    static public void Log(string message, string type = "non-repeat", string key = "Log") {
        DoLog(message, Color.White, type, key);
    }
    static public void DoLog(string message, Color color, string type, string key) {
        if (type == "non-repeat") {
            string dateTime = DateTime.Now.ToString("HH:mm:ss");
            Log log = new Log(message, dateTime, key, color);
            NonRepeatLogs.Add(log);
        } else if (type == "repeat") {
            bool isThereKey = false;
            for (int i = 0; i < RepeatLogs.Count; i++) {
                if (RepeatLogs[i].Key == key) {
                    RepeatLogs[i].Message = message;
                    RepeatLogs[i].DateTime = DateTime.Now.ToString("HH:mm:ss");
                    isThereKey = true;
                    break;
                }
            }
            if (isThereKey == false) {
                string dateTime = DateTime.Now.ToString("HH:mm:ss");
                Log log = new Log(message, dateTime, key, color);
                RepeatLogs.Add(log);
            }
        }
        if (RepeatLogs.Count + NonRepeatLogs.Count > 24) {
            if (NonRepeatLogs.Count > 0) {
                NonRepeatLogs.RemoveAt(0);
            } else {
                RepeatLogs.RemoveAt(0);
            }
        }
    }
    static public void ClerConsole() {
        RepeatLogs.Clear();
        NonRepeatLogs.Clear();
    }
    static public void DrawConsole(SpriteBatch SpriteBatch) {
        float oneX = WindowSize.X / 100;
        float oneY = WindowSize.Y / 100;
        DrawEngine.DrawRect(SpriteBatch, new Vector2(oneX, oneY), new Rectangle(0, 0, (int)oneX * 20, (int)(oneY * 14.5)), Vector2.Zero, Color.DarkGray * 0.6f, 0.95f);
        DrawEngine.DrawText(SpriteBatch, new Vector2(oneX*2, oneY*4/3), "Console", Vector2.Zero, Color.White);
        for (int i = 0; i < RepeatLogs.Count; i++) {
            string message = $"{RepeatLogs[i].DateTime} | {RepeatLogs[i].Key} : {RepeatLogs[i].Message}";
            DrawEngine.DrawText(SpriteBatch, new Vector2(oneX*2, (float)(oneY*(3 + i*1.5))), message, Vector2.Zero, RepeatLogs[i].MesColor);
        }
        for (int i = 0; i < NonRepeatLogs.Count; i++) {
            string message = $"{NonRepeatLogs[i].DateTime} | {NonRepeatLogs[i].Key} : {NonRepeatLogs[i].Message}";
            DrawEngine.DrawText(SpriteBatch, new Vector2(oneX * 2, (float)(oneY * (3 + (i + RepeatLogs.Count) * 1.5))), message, Vector2.Zero, NonRepeatLogs[i].MesColor);
        }
    }
}
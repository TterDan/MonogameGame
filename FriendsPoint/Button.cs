
public class Button {
    public Vector2 Position;
    public Vector2 Size;
    public Color Color;
    public Color TextColor = Color.Black;
    public string Type = "button";
    public string Text = "";
    public bool state = false;
    public Button(Vector2 position, Vector2 size, Color color, string text, Color textColor, string type) {
        Position = position;
        Size = size;
        Color = color;
        Text = text;
        TextColor = textColor;
        Type = type;
    }
    public Button(Vector2 position, Vector2 size, Color color, string type) {
        Position = position;
        Size = size;
        Color = color;
        Type = type;
    }
    public Button(Vector2 position, Vector2 size, Color color) {
        Position = position;
        Size = size;
        Color = color;
    }
    public void Use() {

    }
    public void Click() {
        if (Type == "Button") {
            Use();
        } else if (Type == "Checkbox") {
            state = (state == true) ? false : true;
        }
    }
    public void Draw(SpriteBatch spriteBatch) {
        DrawEngine.DrawRect(spriteBatch, Position, new Rectangle(0, 0, (int)Size.X, (int)Size.Y), Color.DarkGray);
    }
}
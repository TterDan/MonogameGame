using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
public class Weapon : GameObject {                                                          // Класс оружия, наследует класс GameObject
    public string Name;
    public Weapon(Texture2D texture, string name, Vector2 position, int width, int height) {
        Texture = texture;
        Name = name;
        Position = position;
        System.Diagnostics.Debug.WriteLine("GIM");
        System.Diagnostics.Debug.WriteLine(position);
        System.Diagnostics.Debug.WriteLine(ScreenPosition);
        Width = width;
        Height = height;
        Layer = 1.0f;
    }
    public override void Draw(SpriteBatch render, Rectangle? sourceRectangle = null) {      // Отрисовка оружия, здесь я переопределяю функцию draw() из GameObject. Если в него нужно передать какой нибудь Rectangle, то надо писать такую конструкцию, если не нужно, то функцию можно не переопределять

        Rectangle Rect = new Rectangle((int)ScreenPosition.X, (int)ScreenPosition.Y, Width, Height);
        base.Draw(render, Rect);
    }
}


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
public class Weapon : GameObject {                                                          // Класс оружия, наследует класс GameObject
    public string Name;
    public Rectangle Rect; 
    public Weapon(Texture2D texture, string name, Vector2 position, int width, int height) {
        Texture = texture;
        Name = name;
        Position = position;
        Width = width;
        Height = height;
        Layer = 1.0f;
    }
    public override void Draw(SpriteBatch render, Rectangle? sourceRectangle = null) {      // Отрисовка оружия, здесь я переопределяю функцию draw() из GameObject. Если в него нужно передать какой нибудь Rectangle, то надо писать такую конструкцию, если не нужно, то функцию можно не переопределять
        //Rect = new Rectangle((int)ScreenPosition.X - Width / 2, (int)ScreenPosition.Y - Height / 2, Width, Height);
        Rect = new Rectangle((int)ScreenPosition.X - Width / 2, (int)ScreenPosition.Y - Height / 2,
        (int)(Width * Scale), (int)(Height * Scale));
        render.Draw(Texture, Rect, Color.Black);
    }
}


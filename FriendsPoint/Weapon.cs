using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
public class Weapon : CircleHBoxObj {                                                          // Класс оружия, наследует класс GameObject
    public string Name;
    public Rectangle Rect;
    public Weapon(GraphicsDevice GraphicsDevice, string name, Vector2 position, int radius) {
        Name = name;
        Position = position;
        Layer = 1.0f;
        Radius = radius;
        HitboxTexture = CreateCircleTexture(GraphicsDevice, Radius, Color.Black);
        DrawRect = new Rectangle(0, 0, Radius * 2, Radius * 2);
    }
}


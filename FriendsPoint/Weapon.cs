using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Weapon
{
    public string Name;
    public Vector2 Position;
    public Texture2D Texture;
    public Texture2D BlackTexture;
    public int Width;
    public int Height;

    public Weapon(string name, Vector2 position, int width, int height)
    {
        Name = name;
        Position = position;
        Width = width;
        Height = height;
    }
    
    public void Draw(SpriteBatch render)
    {
        Rectangle Rect = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        render.Draw(
        BlackTexture,
        Position,
        Rect,
        Color.Black,
        0.0f,
        new Vector2(Height, Width) * 0.5f,
        0.35f,
        SpriteEffects.None,
        1.0f);
    }
}


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Player {
    public Vector2 Position;       // позиция игрока
    public int Width = 50;         // ширина прямоугольника
    public int Height = 80;        // высота прямоугольника
    public Texture2D Texture;      // текстура игрока

    public Player(Vector2 startPosition) {
        Position = startPosition;
    }

    // Метод для отрисовки игрока
    public void Draw(SpriteBatch spriteBatch) {
        if (Texture != null) {
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), Color.Black);
        }
    }
}
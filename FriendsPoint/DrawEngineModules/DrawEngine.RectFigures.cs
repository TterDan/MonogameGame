
namespace FriendsPoint.DrawEngineModules {
    public partial class DrawEngine {                                                          // Статический класс камеры
        static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Rectangle drawRectangle, Vector2 centerPosition, Color color, float layer = 1f, float rotation = 0f, float scale = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {
            scale *= GameScale;
            Texture2D texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.Black });

            spriteBatch.Draw(
                texture,                //Текстура
                position,               // Положение 
                drawRectangle,          // Область текстуры для отрисовки
                color,                  // Цвет
                rotation,               // Вращение
                centerPosition,         // Центр объекта, вокруг которого происходит вращение и тд
                scale * GameScale,      // Масштабирование
                spriteEffect,     // Отражение по горизонтали и вертикали
                layer                   // Слой
            );
        }
        static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Rectangle drawRectangle, Color color, float layer = 1f, float rotation = 0f, float scale = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {
            scale *= GameScale;
            Vector2 centerPosition = new(drawRectangle.Width / 2, drawRectangle.Height / 2);
            Texture2D texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.Black });

            spriteBatch.Draw(
                texture,                //Текстура
                position,               // Положение 
                drawRectangle,          // Область текстуры для отрисовки
                color,                  // Цвет
                rotation,               // Вращение
                centerPosition,         // Центр объекта, вокруг которого происходит вращение и тд
                scale * GameScale,      // Масштабирование
                spriteEffect,     // Отражение по горизонтали и вертикали
                layer                   // Слой
            );
        }
        static public void DrawTexture(SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Rectangle? nullableDrawRectangle, Color? nullableColor, float layer = 1f, float rotation = 0f, float scale = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {
            if (texture == null) {
                System.Diagnostics.Debug.WriteLine("Error");
                return;
            }
            Color color = nullableColor ?? Color.White;
            Rectangle drawRectangle;
            if (nullableDrawRectangle == null) {
                drawRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            } else {
                drawRectangle = nullableDrawRectangle.Value;
            }
            Vector2 centerPosition = new Vector2(drawRectangle.Width / 2, drawRectangle.Height / 2);

            spriteBatch.Draw(
                texture,                //Текстура
                position,               // Положение 
                drawRectangle,          // Область текстуры для отрисовки
                color,                  // Цвет
                rotation,               // Вращение
                centerPosition,         // Центр объекта, вокруг которого происходит вращение и тд
                scale * GameScale,      // Масштабирование
                SpriteEffects.None,     // Отражение по горизонтали и вертикали
                layer                   // Слой
            );
        }
    }
}
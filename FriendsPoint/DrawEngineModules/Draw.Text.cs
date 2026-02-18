
using System.Text;

namespace FriendsPoint.DrawEngineModules {
    public partial class DrawEngine {
        static public StringBuilder TextBuffer = new StringBuilder(128);

        static public void DrawText(SpriteBatch spriteBatch, Vector2 position, string message, Color? color = null, float layer = 1f, float scale = 1f, float rotation = 0) {
            color = (color == null ? Color.Black : color);
            TextBuffer.Clear();
            TextBuffer.Append(message);
            spriteBatch.DrawString(GameFont, TextBuffer, position, color.Value, rotation, Vector2.Zero, scale, SpriteEffects.None, layer);
        }
        static public void DrawText(SpriteBatch spriteBatch, Vector2 position, int message, Color? color = null, float layer = 1f, float scale = 1f, float rotation = 0) {
            color = (color == null ? Color.Black : color);
            TextBuffer.Clear();
            TextBuffer.Append(message);
            spriteBatch.DrawString(GameFont, TextBuffer, position, color.Value, rotation, Vector2.Zero, scale, SpriteEffects.None, layer);
        }
        static public void DrawText(SpriteBatch spriteBatch, Vector2 position, float message, Color? color = null, float layer = 1f, float scale = 1f, float rotation = 0) {
            color = (color == null ? Color.Black : color);
            TextBuffer.Clear();
            TextBuffer.Append(message);
            spriteBatch.DrawString(GameFont, TextBuffer, position, color.Value, rotation, Vector2.Zero, scale, SpriteEffects.None, layer);
        }
    }
}
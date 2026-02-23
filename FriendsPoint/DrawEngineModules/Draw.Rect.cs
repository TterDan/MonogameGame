

namespace FriendsPoint.DrawEngineModules {
    public partial class DrawEngine {
        static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, FillStyle fillStyle, StrokeStyle strokeStyle, LineStyle lineStyle, float layer) {
            Vector2 centerPosition = size / 2;
            FillRect(spriteBatch, position, centerPosition, size, fillStyle.Color, layer - 0.00001f);
            StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, layer);
        }
        static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, FillStyle fillStyle, float layer) {
            Vector2 centerPosition = size / 2;

            FillRect(spriteBatch, position, centerPosition, size, fillStyle.Color, layer - 0.00001f);

        }
        static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, StrokeStyle strokeStyle, LineStyle lineStyle, float layer) {
            Vector2 centerPosition = size / 2;

            StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, layer);
        }
        static public void FillRect(SpriteBatch spriteBatch, Vector2 position, Vector2 centerPosition, Vector2 size, Color fillColor, float layer) {
            DrawEngine.RectFigure(spriteBatch, position, new Rectangle(0, 0, (int)size.X, (int)size.Y), centerPosition, fillColor, layer);
        }
        static public void StrokeRect(SpriteBatch spriteBatch, LineStyle lineStyle, Vector2 position, Vector2 centerPosition, Vector2 size, string positionVariant, float strokeWidth, Color strokeColor, float layer) {
            Vector2 centerPositionNormal = new Vector2(-centerPosition.Y, centerPosition.X);
            Vector2 WidthVector = new Vector2(strokeWidth, strokeWidth);
            Vector2 WidthNormal = new Vector2(-WidthVector.Y, WidthVector.X);
            Vector2 pos1 = position - centerPosition;
            Vector2 pos2 = position - centerPositionNormal;
            Vector2 pos3 = position + centerPosition;
            Vector2 pos4 = position + centerPositionNormal;
            if (positionVariant == "on") {
                pos1 -= WidthVector / 2;
                pos2 -= WidthNormal / 2;
                pos3 += WidthVector / 2;
                pos4 += WidthNormal / 2;
                DrawEngine.LinePathRect(spriteBatch, pos1, pos2 - new Vector2(strokeWidth, 0), strokeWidth, strokeColor, lineStyle, strokeWidth, layer);
                DrawEngine.LinePathRect(spriteBatch, pos2, pos3 - new Vector2(0, strokeWidth), strokeWidth, strokeColor, lineStyle, strokeWidth, layer);
                DrawEngine.LinePathRect(spriteBatch, pos3, pos4 + new Vector2(strokeWidth, 0), strokeWidth, strokeColor, lineStyle, strokeWidth, layer);
                DrawEngine.LinePathRect(spriteBatch, pos4, pos1 + new Vector2(0, strokeWidth), strokeWidth, strokeColor, lineStyle, strokeWidth, layer);
            } else if (positionVariant == "out") {
                pos1 -= WidthVector;
                pos2 -= WidthNormal;
                pos3 += WidthVector;
                pos4 += WidthNormal;
                DrawEngine.LinePathRect(spriteBatch, pos1, pos2 - new Vector2(strokeWidth, 0), strokeWidth, strokeColor, lineStyle, strokeWidth, layer);
                DrawEngine.LinePathRect(spriteBatch, pos2, pos3 - new Vector2(0, strokeWidth), strokeWidth, strokeColor, lineStyle, strokeWidth, layer);
                DrawEngine.LinePathRect(spriteBatch, pos3, pos4 + new Vector2(strokeWidth, 0), strokeWidth, strokeColor, lineStyle, strokeWidth, layer);
                DrawEngine.LinePathRect(spriteBatch, pos4, pos1 + new Vector2(0, strokeWidth), strokeWidth, strokeColor, lineStyle, strokeWidth, layer);
            } else if (positionVariant == "in") {
                DrawEngine.LinePathRect(spriteBatch, pos1, pos2 - new Vector2(strokeWidth, 0), strokeWidth, strokeColor, lineStyle, strokeWidth, layer);
                DrawEngine.LinePathRect(spriteBatch, pos2, pos3 - new Vector2(0, strokeWidth), strokeWidth, strokeColor, lineStyle, strokeWidth, layer);
                DrawEngine.LinePathRect(spriteBatch, pos3, pos4 + new Vector2(strokeWidth, 0), strokeWidth, strokeColor, lineStyle, strokeWidth, layer);
                DrawEngine.LinePathRect(spriteBatch, pos4, pos1 + new Vector2(0, strokeWidth), strokeWidth, strokeColor, lineStyle, strokeWidth, layer);
            }
        }

        static public void LinePathRect(SpriteBatch spriteBatch, Vector2 start, Vector2 end, float width, Color color, LineStyle lineStyle, float strokeWidth, float layer) {
            if (lineStyle.Type == "solid") {
                DrawEngine.DrawSolidLine(spriteBatch, start, end, width, color, lineStyle, layer);
            } else if (lineStyle.Type == "double") {
                Vector2 direction = Vector2.Normalize(end - start);                                 // Направление линии
                Vector2 normal = new Vector2(-direction.Y, direction.X);                            // Нормаль линии
                Vector2 directionDistanceVector = direction * (lineStyle.LinesDistance + width);    // Расстояние от центров линий
                Vector2 normalDistanceVector = normal * (lineStyle.LinesDistance + width);          // Увеличение длины линий

                DrawEngine.DrawSolidLine(spriteBatch, start, end, width, color, lineStyle, layer);
                DrawEngine.DrawSolidLine(spriteBatch, start - directionDistanceVector - normalDistanceVector, end + directionDistanceVector - normalDistanceVector, width, color, lineStyle, layer);
            } else if (lineStyle.Type == "dashed") {

                Vector2 direction = end - start;
                direction += Vector2.Normalize(direction) * strokeWidth;
                DrawEngine.DrawDashedLine(spriteBatch, start, start + direction, width, color, lineStyle, layer);

            } else if (lineStyle.Type == "wavy") {
                if (lineStyle.isZigZag == false) {
                    DrawEngine.DrawSineLine(spriteBatch, start, end, width, color, layer, lineStyle.WaveAmplitude, lineStyle.WaveFrequency, 0, 5);
                } else {

                }
            }
        }


























        static public void RectFigure(SpriteBatch spriteBatch, Vector2 position, Rectangle drawRectangle, Vector2 centerPosition, Color color, float layer = 1f, float rotation = 0f, float scale = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {
            scale *= GameScale;

            spriteBatch.Draw(
                TexturePixel,                //Текстура
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

        static public void Texture(SpriteBatch spriteBatch, Texture2D texture, Vector2 position, float layer = 1f, float rotation = 0f, float scale = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {
            Color color = Color.White;
            Rectangle drawRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
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
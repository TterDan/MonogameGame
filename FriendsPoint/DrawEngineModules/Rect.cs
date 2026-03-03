
namespace FriendsPoint.DrawEngineModules {
    public partial class DrawEngine {
        static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, Vector2 centerPosition, float rotation, float scale, float layer, Color fillColor, StrokeStyle strokeStyle, LineStyle lineStyle) {
            FillRect(spriteBatch, position, centerPosition, size, fillColor, rotation, scale, layer - 0.00001f);
            StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
        } static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, Vector2 centerPosition, float rotation, float scale, float layer, Color fillColor) {
            FillRect(spriteBatch, position, centerPosition, size, fillColor, rotation, scale, layer - 0.00001f);
        } static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, Vector2 centerPosition, float rotation, float scale, float layer, StrokeStyle strokeStyle, LineStyle lineStyle) {
            StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
        }
        static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, Vector2 centerPosition, float rotation, float scale, float layer, Color fillColor, StrokeStyle strokeStyle, LineStyle lineStyle, ShadowStyle shadowStyle) {
            FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, rotation, scale, layer - 0.00002f);
            FillRect(spriteBatch, position, centerPosition, size, fillColor, scale, rotation, layer - 0.00001f);
            StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
        } static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, Vector2 centerPosition, float rotation, float scale, float layer, Color fillColor, ShadowStyle shadowStyle) {
            FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, rotation, scale, layer - 0.00002f);
            FillRect(spriteBatch, position, centerPosition, size, fillColor, rotation, scale, layer - 0.00001f);
        } static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, Vector2 centerPosition, float rotation, float scale, float layer, StrokeStyle strokeStyle, LineStyle lineStyle, ShadowStyle shadowStyle) {
            FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, rotation, scale, layer - 0.00002f);
            StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
        }



        static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float rotation, float scale, float layer, Color fillColor, StrokeStyle strokeStyle, LineStyle lineStyle) {
            Vector2 centerPosition = size / 2;
            FillRect(spriteBatch, position, centerPosition, size, fillColor, rotation, scale, layer - 0.00001f);
            StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
        }
        static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float rotation, float scale, float layer, Color fillColor) {
            Vector2 centerPosition = size / 2;
            FillRect(spriteBatch, position, centerPosition, size, fillColor, rotation, scale, layer - 0.00001f);
        }
        static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float rotation, float scale, float layer, StrokeStyle strokeStyle, LineStyle lineStyle) {
            Vector2 centerPosition = size / 2;
            StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
        }
        static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float rotation, float scale, float layer, Color fillColor, StrokeStyle strokeStyle, LineStyle lineStyle, ShadowStyle shadowStyle) {
            Vector2 centerPosition = size / 2;
            FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, rotation, scale, layer - 0.00002f);
            FillRect(spriteBatch, position, centerPosition, size, fillColor, scale, rotation, layer - 0.00001f);
            StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
        }
        static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float rotation, float scale, float layer, Color fillColor, ShadowStyle shadowStyle) {
            Vector2 centerPosition = size / 2;
            FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, rotation, scale, layer - 0.00002f);
            FillRect(spriteBatch, position, centerPosition, size, fillColor, rotation, scale, layer - 0.00001f);
        }
        static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float rotation, float scale, float layer, StrokeStyle strokeStyle, LineStyle lineStyle, ShadowStyle shadowStyle) {
            Vector2 centerPosition = size / 2;
            FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, rotation, scale, layer - 0.00002f);
            StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
        }




        static public void DrawTexture(SpriteBatch spriteBatch, Vector2 position, Vector2 centerPosition, Texture2D texture, float rotation, float scale, float layer, StrokeStyle strokeStyle, LineStyle lineStyle) {
            Vector2 size = new Vector2(texture.Width, texture.Height);
            RectTexture(spriteBatch, texture, position, centerPosition, rotation, scale, layer - 0.00001f);
            StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
        }
        static public void DrawTexture(SpriteBatch spriteBatch, Vector2 position, Vector2 centerPosition, Texture2D texture, float rotation, float scale, float layer) {
            RectTexture(spriteBatch, texture, position, centerPosition, rotation, scale, layer - 0.000001f);
        }
        static public void DrawTexture(SpriteBatch spriteBatch, Vector2 position, Vector2 centerPosition, Texture2D texture, float rotation, float scale, float layer, StrokeStyle strokeStyle, LineStyle lineStyle, ShadowStyle shadowStyle) {
            Vector2 size = new Vector2(texture.Width, texture.Height);
            FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, rotation, scale, layer - 0.00002f);
            RectTexture(spriteBatch, texture, position, centerPosition, rotation, scale, layer - 0.00001f);
            StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
        }
        static public void DrawTexture(SpriteBatch spriteBatch, Vector2 position, Vector2 centerPosition, Texture2D texture, float rotation, float scale, float layer, ShadowStyle shadowStyle) {
            Vector2 size = new Vector2(texture.Width, texture.Height);
            FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, rotation, scale, layer - 0.00002f);
            RectTexture(spriteBatch, texture, position, centerPosition, rotation, scale, layer - 0.00001f);
        }



        static public void DrawTexture(SpriteBatch spriteBatch, Vector2 position, Texture2D texture, float rotation, float scale, float layer, StrokeStyle strokeStyle, LineStyle lineStyle) {
            Vector2 size = new Vector2(texture.Width, texture.Height);
            Vector2 centerPosition = size / 2;
            RectTexture(spriteBatch, texture, position, centerPosition, rotation, scale, layer - 0.00001f);
            StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
        }
        static public void DrawTexture(SpriteBatch spriteBatch, Vector2 position, Texture2D texture, float rotation, float scale, float layer) {
            Vector2 size = new Vector2(texture.Width, texture.Height);
            Vector2 centerPosition = size / 2;
            RectTexture(spriteBatch, texture, position, centerPosition, rotation, scale, layer - 0.000001f);
        }
        static public void DrawTexture(SpriteBatch spriteBatch, Vector2 position, Texture2D texture, float rotation, float scale, float layer, StrokeStyle strokeStyle, LineStyle lineStyle, ShadowStyle shadowStyle) {
            Vector2 size = new Vector2(texture.Width, texture.Height);
            Vector2 centerPosition = size / 2;
            FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, rotation, scale, layer - 0.00002f);
            RectTexture(spriteBatch, texture, position, centerPosition, rotation, scale, layer - 0.00001f);
            StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
        }
        static public void DrawTexture(SpriteBatch spriteBatch, Vector2 position, Texture2D texture, float rotation, float scale, float layer, ShadowStyle shadowStyle) {
            Vector2 size = new Vector2(texture.Width, texture.Height);
            Vector2 centerPosition = size / 2;
            FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, rotation, scale, layer - 0.00002f);
            RectTexture(spriteBatch, texture, position, centerPosition, rotation, scale, layer - 0.00001f);
        }









        static public void FillRect(SpriteBatch spriteBatch, Vector2 position, Vector2 centerPosition, Vector2 size, Color fillColor, float rotation, float scale, float layer) {
            DrawEngine.RectFigure(spriteBatch, position, new Rectangle(0, 0, (int)size.X, (int)size.Y), centerPosition, fillColor, rotation, scale, layer);
        }
        static public void StrokeRect(SpriteBatch spriteBatch, LineStyle lineStyle, Vector2 position, Vector2 cntrPos, Vector2 size, string positionVariant, float strokeWidth, Color strokeColor, float rotation, float scale, float layer) {
            Vector2 centerPosition = size / 2;
            centerPosition *= scale;
            strokeWidth *= scale;
            Vector2 centerPositionNormal = new Vector2(-centerPosition.X, centerPosition.Y);
            DrawEngine.RectFigure(spriteBatch, position, new Rectangle(0, 0, 20, 20), new Vector2(10, 10), Color.Yellow, 0f, 1f, 1f);
            Vector2 WidthVector = new Vector2(strokeWidth, strokeWidth);
            Vector2 WidthNormal = new Vector2(-WidthVector.Y, WidthVector.X);

            Matrix rot = Matrix.CreateRotationZ(rotation);
            Vector2 difference = centerPosition - cntrPos;
            Vector2 pos1 = position - Vector2.Transform(centerPosition - difference, rot);
            Vector2 pos2 = position - Vector2.Transform(centerPositionNormal - difference, rot);
            Vector2 pos3 = position + Vector2.Transform(centerPosition + difference, rot);
            Vector2 pos4 = position + Vector2.Transform(centerPositionNormal + difference, rot);

            Vector2 XstrokeWidthVector = Vector2.Transform(new Vector2(strokeWidth, 0), rot);
            Vector2 YstrokeWidthVector = Vector2.Transform(new Vector2(0, strokeWidth), rot);

            if (positionVariant == "on") {
                pos1 -= WidthVector / 2;
                pos2 -= WidthNormal / 2;
                pos3 += WidthVector / 2;
                pos4 += WidthNormal / 2;
                float offset = 0;
                offset += DrawEngine.LinePathRect(spriteBatch, pos1, pos2 - new Vector2(strokeWidth, 0), strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
                offset += DrawEngine.LinePathRect(spriteBatch, pos2, pos3 - YstrokeWidthVector, strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
                offset += DrawEngine.LinePathRect(spriteBatch, pos3, pos4 + new Vector2(strokeWidth, 0), strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
                offset += DrawEngine.LinePathRect(spriteBatch, pos4, pos1 + YstrokeWidthVector, strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
            } else if (positionVariant == "out") {
                pos1 -= WidthVector;
                pos2 -= WidthNormal;
                pos3 += WidthVector;
                pos4 += WidthNormal;
                float offset = 0;
                offset += DrawEngine.LinePathRect(spriteBatch, pos1, pos2 - XstrokeWidthVector, strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
                offset += DrawEngine.LinePathRect(spriteBatch, pos2, pos3 - YstrokeWidthVector, strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
                offset += DrawEngine.LinePathRect(spriteBatch, pos3, pos4 + XstrokeWidthVector, strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
                offset += DrawEngine.LinePathRect(spriteBatch, pos4, pos1 + YstrokeWidthVector, strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
            } else if (positionVariant == "in") {
                float offset = 0;
                offset += DrawEngine.LinePathRect(spriteBatch, pos1, pos2 - XstrokeWidthVector, strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
                offset += DrawEngine.LinePathRect(spriteBatch, pos2, pos3 - YstrokeWidthVector, strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
                offset += DrawEngine.LinePathRect(spriteBatch, pos3, pos4 + XstrokeWidthVector, strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
                offset += DrawEngine.LinePathRect(spriteBatch, pos4, pos1 + YstrokeWidthVector, strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
            }
        }

        static public float LinePathRect(SpriteBatch spriteBatch, Vector2 start, Vector2 end, float width, Color color, LineStyle lineStyle, float strokeWidth, float layer, float offset) {
            if (lineStyle.Type == "solid") {
                DrawEngine.DrawSolidLine(spriteBatch, start, end, width, color, lineStyle, layer);
            } else if (lineStyle.Type == "double") {
                if (lineStyle.SecondLinePosition == "in") {
                    Vector2 direction = Vector2.Normalize(end - start);                                 // Направление линии
                    Vector2 normal = -new Vector2(-direction.Y, direction.X);                            // Нормаль линии
                    Vector2 directionDistanceVector = direction * (lineStyle.LinesDistance + width);    // Расстояние от центров линий
                    Vector2 normalDistanceVector = normal * (lineStyle.LinesDistance + width);          // Увеличение длины линий

                    DrawEngine.DrawSolidLine(spriteBatch, start, end, width, color, lineStyle, layer);
                    DrawEngine.DrawSolidLine(spriteBatch, start + directionDistanceVector - normalDistanceVector, end - directionDistanceVector - normalDistanceVector, width, color, lineStyle, layer);
                } else {
                    Vector2 direction = Vector2.Normalize(end - start);                                 // Направление линии
                    Vector2 normal = new Vector2(-direction.Y, direction.X);                            // Нормаль линии
                    Vector2 directionDistanceVector = direction * (lineStyle.LinesDistance + width);    // Расстояние от центров линий
                    Vector2 normalDistanceVector = normal * (lineStyle.LinesDistance + width);          // Увеличение длины линий

                    DrawEngine.DrawSolidLine(spriteBatch, start, end, width, color, lineStyle, layer);
                    DrawEngine.DrawSolidLine(spriteBatch, start - directionDistanceVector - normalDistanceVector, end + directionDistanceVector - normalDistanceVector, width, color, lineStyle, layer);
                }
            } else if (lineStyle.Type == "dashed") {

                Vector2 direction = end - start;
                direction += Vector2.Normalize(direction) * strokeWidth;
                float offsetNew = DrawEngine.DrawDashedLine(spriteBatch, start, start + direction, width, color, lineStyle, layer, offset);

                return offsetNew;
            } else if (lineStyle.Type == "wavy") {
                if (lineStyle.isZigZag == false) {
                    DrawEngine.DrawWavyLine(spriteBatch, start, end, width, color, layer, lineStyle.WaveAmplitude, lineStyle.WaveFrequency, lineStyle.Phase, 5);
                } else {
                    DrawEngine.DrawZigZagLine(spriteBatch, start, end, width, color, layer, lineStyle.WaveAmplitude, lineStyle.WaveFrequency, lineStyle.Phase, 5);
                }
            }
            return 0f;
        }


























        static public void RectFigure(SpriteBatch spriteBatch, Vector2 position, Rectangle drawRectangle, Vector2 centerPosition, Color color, float rotation = 0f, float scale = 1f, float layer = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {
            
            spriteBatch.Draw(
                TexturePixel,                //Текстура
                position,               // Положение 
                drawRectangle,          // Область текстуры для отрисовки
                color,                  // Цвет
                rotation,               // Вращение
                centerPosition,         // Центр объекта, вокруг которого происходит вращение и тд
                scale,      // Масштабирование
                spriteEffect,     // Отражение по горизонтали и вертикали
                layer                   // Слой
            );
        }

        static public void RectTexture(SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Vector2 centerPosition, float rotation = 0f, float scale = 1f, float layer = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {
            Color color = Color.White;
            Rectangle drawRectangle = new Rectangle(0, 0, texture.Width, texture.Height);

            spriteBatch.Draw(
                texture,                //Текстура
                position,               // Положение 
                drawRectangle,          // Область текстуры для отрисовки
                color,                  // Цвет
                rotation,               // Вращение
                centerPosition,         // Центр объекта, вокруг которого происходит вращение и тд
                scale,      // Масштабирование
                SpriteEffects.None,     // Отражение по горизонтали и вертикали
                layer                   // Слой
            );
        }
        static public void RectTexture(SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Vector2 centerPosition, Color color, float rotation = 0f, float scale = 1f, float layer = 1f, SpriteEffects spriteEffect = SpriteEffects.None) {
            Rectangle drawRectangle = new Rectangle(0, 0, texture.Width, texture.Height);

            spriteBatch.Draw(
                texture,                //Текстура
                position,               // Положение 
                drawRectangle,          // Область текстуры для отрисовки
                color,                  // Цвет
                rotation,               // Вращение
                centerPosition,         // Центр объекта, вокруг которого происходит вращение и тд
                scale,      // Масштабирование
                SpriteEffects.None,     // Отражение по горизонтали и вертикали
                layer                   // Слой
            );
        }
    }
}
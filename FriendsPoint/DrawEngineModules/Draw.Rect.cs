

namespace FriendsPoint.DrawEngineModules {
    public partial class DrawEngine {
        static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float layer, FillStyle fillStyle, StrokeStyle strokeStyle, LineStyle lineStyle) {
            Vector2 centerPosition = size / 2;
            FillRect(spriteBatch, position, centerPosition, size, fillStyle.Color, layer - 0.00001f);
            StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, layer);
        } static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float layer, FillStyle fillStyle) {
            Vector2 centerPosition = size / 2;

            FillRect(spriteBatch, position, centerPosition, size, fillStyle.Color, layer - 0.00001f);

        } static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float layer, StrokeStyle strokeStyle, LineStyle lineStyle) {
            Vector2 centerPosition = size / 2;

            StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, layer);
        }


        static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float layer, FillStyle fillStyle, StrokeStyle strokeStyle, LineStyle lineStyle, ShadowStyle shadowStyle) {
            Vector2 centerPosition = size / 2;
            FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, layer - 0.00002f);
            FillRect(spriteBatch, position, centerPosition, size, fillStyle.Color, layer - 0.00001f);
            StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, layer);


        } static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float layer, FillStyle fillStyle, ShadowStyle shadowStyle) {
            Vector2 centerPosition = size / 2;

            FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, layer - 0.00002f);
            FillRect(spriteBatch, position, centerPosition, size, fillStyle.Color, layer - 0.00001f);

        } static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float layer, StrokeStyle strokeStyle, LineStyle lineStyle, ShadowStyle shadowStyle) {
            Vector2 centerPosition = size / 2;

            FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, layer - 0.00002f);
            StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, layer);
        }





        //static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float layer, FillStyle fillStyle, StrokeStyle strokeStyle, LineStyle lineStyle, PostProcessingStyle postProcessingStyle) {
        //    Vector2 centerPosition = size / 2;

        //    FillRect(spriteBatch, position, centerPosition, size, fillStyle.Color, layer - 0.00001f);
        //    StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, layer);
        //} static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float layer, FillStyle fillStyle, PostProcessingStyle postProcessingStyle) {
        //    Vector2 centerPosition = size / 2;

        //    FillRect(spriteBatch, position, centerPosition, size, fillStyle.Color, layer - 0.00001f);

        //} static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float layer, StrokeStyle strokeStyle, LineStyle lineStyle, PostProcessingStyle postProcessingStyle) {
        //    Vector2 centerPosition = size / 2;

        //    StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, layer);
        //}


        //static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float layer, FillStyle fillStyle, StrokeStyle strokeStyle, LineStyle lineStyle, ShadowStyle shadowStyle, PostProcessingStyle postProcessingStyle) {
        //    Vector2 centerPosition = size / 2;
        //    FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, layer - 0.00002f);
        //    FillRect(spriteBatch, position, centerPosition, size, fillStyle.Color, layer - 0.00001f);
        //    StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, layer);
        //} static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float layer, FillStyle fillStyle, ShadowStyle shadowStyle, PostProcessingStyle postProcessingStyle) {
        //    Vector2 centerPosition = size / 2;

        //    FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, layer - 0.00002f);
        //    FillRect(spriteBatch, position, centerPosition, size, fillStyle.Color, layer - 0.00001f);

        //} static public void DrawRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float layer, StrokeStyle strokeStyle, LineStyle lineStyle, ShadowStyle shadowStyle, PostProcessingStyle postProcessingStyle) {
        //    Vector2 centerPosition = size / 2;

        //    FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, layer - 0.00002f);
        //    StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, layer);
        //}












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
                float offset = 0;
                offset += DrawEngine.LinePathRect(spriteBatch, pos1, pos2 - new Vector2(strokeWidth, 0), strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
                offset += DrawEngine.LinePathRect(spriteBatch, pos2, pos3 - new Vector2(0, strokeWidth), strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
                offset += DrawEngine.LinePathRect(spriteBatch, pos3, pos4 + new Vector2(strokeWidth, 0), strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
                offset += DrawEngine.LinePathRect(spriteBatch, pos4, pos1 + new Vector2(0, strokeWidth), strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
            } else if (positionVariant == "out") {
                pos1 -= WidthVector;
                pos2 -= WidthNormal;
                pos3 += WidthVector;
                pos4 += WidthNormal;
                float offset = 0;
                offset += DrawEngine.LinePathRect(spriteBatch, pos1, pos2 - new Vector2(strokeWidth, 0), strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
                offset += DrawEngine.LinePathRect(spriteBatch, pos2, pos3 - new Vector2(0, strokeWidth), strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
                offset += DrawEngine.LinePathRect(spriteBatch, pos3, pos4 + new Vector2(strokeWidth, 0), strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
                offset += DrawEngine.LinePathRect(spriteBatch, pos4, pos1 + new Vector2(0, strokeWidth), strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
            } else if (positionVariant == "in") {
                float offset = 0;
                offset += DrawEngine.LinePathRect(spriteBatch, pos1, pos2 - new Vector2(strokeWidth, 0), strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
                offset += DrawEngine.LinePathRect(spriteBatch, pos2, pos3 - new Vector2(0, strokeWidth), strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
                offset += DrawEngine.LinePathRect(spriteBatch, pos3, pos4 + new Vector2(strokeWidth, 0), strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
                offset += DrawEngine.LinePathRect(spriteBatch, pos4, pos1 + new Vector2(0, strokeWidth), strokeWidth, strokeColor, lineStyle, strokeWidth, layer, offset);
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
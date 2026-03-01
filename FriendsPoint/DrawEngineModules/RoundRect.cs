

using System.Reflection.Emit;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace FriendsPoint.DrawEngineModules {
    public partial class DrawEngine {
        static public void DrawRoundRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, Vector2 centerPosition, float round, float rotation, float scale, float layer, Color fillColor, StrokeStyle strokeStyle, LineStyle lineStyle) {
            FillRoundRect(spriteBatch, position, centerPosition, size, round, rotation, scale, layer, fillColor);
            //StrokeRoundRect(spriteBatch, lineStyle, position, size / 2, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
        }
        static public void DrawRoundRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, Vector2 centerPosition, float round, float rotation, float scale, float layer, Color fillColor) {
            FillRoundRect(spriteBatch, position, centerPosition, size, round, rotation, scale, layer, fillColor);
        }

        static public void DrawRoundRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float round, float rotation, float scale, float layer, Color fillColor, StrokeStyle strokeStyle, LineStyle lineStyle) {
            Vector2 centerPosition = size / 2;
            FillRoundRect(spriteBatch, position, centerPosition, size, round, rotation, scale, layer, fillColor);
            //StrokeRoundRect(spriteBatch, lineStyle, position, size / 2, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
        }
        static public void DrawRoundRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float round, float rotation, float scale, float layer, Color fillColor) {
            Vector2 centerPosition = size / 2;
            FillRoundRect(spriteBatch, position, centerPosition, size, round, rotation, scale, layer, fillColor);
        }
        //static public void DrawRoundRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float rotation, float scale, float layer, StrokeStyle strokeStyle, LineStyle lineStyle) {
        //    Vector2 centerPosition = size / 2;
        //    StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
        //}
        //static public void DrawRoundRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float rotation, float scale, float layer, Color fillColor, StrokeStyle strokeStyle, LineStyle lineStyle, ShadowStyle shadowStyle) {
        //    Vector2 centerPosition = size / 2;
        //    FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, rotation, scale, layer - 0.00002f);
        //    FillRect(spriteBatch, position, centerPosition, size, fillColor, scale, rotation, layer - 0.00001f);
        //    StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
        //}
        //static public void DrawRoundRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float rotation, float scale, float layer, Color fillColor, ShadowStyle shadowStyle) {
        //    Vector2 centerPosition = size / 2;
        //    FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, rotation, scale, layer - 0.00002f);
        //    FillRect(spriteBatch, position, centerPosition, size, fillColor, rotation, scale, layer - 0.00001f);
        //}
        //static public void DrawRoundRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float rotation, float scale, float layer, StrokeStyle strokeStyle, LineStyle lineStyle, ShadowStyle shadowStyle) {
        //    Vector2 centerPosition = size / 2;
        //    FillRect(spriteBatch, position + shadowStyle.Offset, centerPosition, shadowStyle.ShadowSize, shadowStyle.Color, rotation, scale, layer - 0.00002f);
        //    StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
        //}


        static public void FillRoundRect(SpriteBatch spriteBatch, Vector2 position, Vector2 cntrPosition, Vector2 size, float round, float rotation, float scale, float layer, Color color) {
            Vector2 centerPosition = size / 2;
            DrawEngine.RectFigure(spriteBatch, position, new Rectangle(0, 0, 20, 20), new Vector2(0, 0), Color.Yellow, 0f, 1f, 1f);
            //position += size / 2 + cntrPosition;
            Vector2 sum = centerPosition + cntrPosition;
            Vector2 normalCenterPosition = new Vector2(centerPosition.Y, centerPosition.X);
            Vector2 normalCntrPosition = new Vector2(cntrPosition.Y, -cntrPosition.X);

            Vector2 centerBlockPosition = position + new Vector2(round, 0);
            Vector2 centerBlockSize = size - new Vector2(round * 2, 0);
            Vector2 centerBlockCenterPosition = centerBlockSize / 2;
            Vector2 sideBlockSize = new Vector2(round, size.Y - round * 2) + new Vector2(1, 1) / 2;
            Vector2 leftBlockCenterPosition = new Vector2(centerBlockCenterPosition.X + round, sideBlockSize.Y / 2);
            Vector2 rightBlockCenterPosition = -new Vector2(centerBlockCenterPosition.X, -sideBlockSize.Y / 2);

            FillRect(spriteBatch, position, centerBlockCenterPosition - centerPosition + cntrPosition, centerBlockSize + new Vector2(1, 1) / 2, color, rotation, scale, layer - 0.00001f);
            FillRect(spriteBatch, position, leftBlockCenterPosition - centerPosition + cntrPosition, sideBlockSize, color, rotation, scale, layer - 0.00001f);
            FillRect(spriteBatch, position, rightBlockCenterPosition - centerPosition + cntrPosition, sideBlockSize, color, rotation, scale, layer - 0.00001f);

            float ninetyDegRot = MathF.PI / 2;
            RectTexture(spriteBatch, QuarterCircleTexture, position, (cntrPosition) * (300 / round), color, rotation, scale / (300 / round), layer - 0.00001f);
            RectTexture(spriteBatch, QuarterCircleTexture, position, (normalCntrPosition + new Vector2(0, size.Y)) * (300 / round), color, rotation + ninetyDegRot, scale / (300 / round), layer - 0.00001f);
            RectTexture(spriteBatch, QuarterCircleTexture, position, (centerPosition * 2 - cntrPosition) * (300 / round), color, rotation + ninetyDegRot * 2, scale / (300 / round), layer - 0.00001f);
            RectTexture(spriteBatch, QuarterCircleTexture, position, (-normalCntrPosition + new Vector2(size.X, 0)) * (300 / round), color, rotation + ninetyDegRot * 3, scale / (300 / round), layer - 0.00001f);
        }

        static public void StrokeRoundRect(SpriteBatch spriteBatch, LineStyle lineStyle, Vector2 position, Vector2 cntrPos, Vector2 size, string positionVariant, float strokeWidth, Color strokeColor, float rotation, float scale, float layer) {
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
    }
}


using System.Reflection.Emit;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace FriendsPoint.DrawEngineModules {
    public partial class DrawEngine {
        static public void DrawRoundRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float round, float rotation, float scale, float layer, Color fillColor, StrokeStyle strokeStyle, LineStyle lineStyle) {
            FillRoundRect(spriteBatch, position, size, round, rotation, scale, layer, fillColor);
            //StrokeRect(spriteBatch, lineStyle, position, centerPosition, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
        }

        //static public void DrawRoundRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float rotation, float scale, float layer, Color fillColor) {
        //    Vector2 centerPosition = size / 2;
        //    FillRect(spriteBatch, position, centerPosition, size, fillColor, rotation, scale, layer - 0.00001f);
        //}
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


        static public void FillRoundRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, float round, float rotation, float scale, float layer, Color color) {
            Vector2 centerPosition = size / 2;
            Vector2 normalCenterPosition = new Vector2(centerPosition.Y, centerPosition.X);

            Vector2 centerBlockPosition = position + new Vector2(round, 0);
            Vector2 centerBlockSize = size - new Vector2(round * 2, 0);
            Vector2 centerBlockCenterPosition = centerBlockSize / 2;


            Vector2 sideBlockSize = new Vector2(round, size.Y - round * 2) + new Vector2(1, 1) / 2;
            Vector2 leftBlockCenterPosition = new Vector2(centerBlockCenterPosition.X + round, sideBlockSize.Y / 2);
            Vector2 rightBlockCenterPosition = -new Vector2(centerBlockCenterPosition.X, -sideBlockSize.Y / 2);

            FillRect(spriteBatch, position, centerBlockCenterPosition, centerBlockSize + new Vector2(1, 1) / 2, color, rotation, scale, layer - 0.00001f);
            FillRect(spriteBatch, position, leftBlockCenterPosition, sideBlockSize, color, rotation, scale, layer - 0.00001f);
            FillRect(spriteBatch, position, rightBlockCenterPosition, sideBlockSize, color, rotation, scale, layer - 0.00001f);


            float ninetyDegRot = MathF.PI / 2;


            RectTexture(spriteBatch, QuarterCircleTexture, position, centerPosition * (300 / round), color, rotation, scale / (300 / round), layer - 0.00001f);
            RectTexture(spriteBatch, QuarterCircleTexture, position, normalCenterPosition * (300 / round), color, rotation + ninetyDegRot, scale / (300 / round), layer - 0.00001f);
            RectTexture(spriteBatch, QuarterCircleTexture, position, centerPosition * (300 / round), color, rotation + ninetyDegRot * 2, scale / (300 / round), layer - 0.00001f);
            RectTexture(spriteBatch, QuarterCircleTexture, position, normalCenterPosition * (300 / round), color, rotation + ninetyDegRot * 3, scale / (300 / round), layer - 0.00001f);

        }
    }
}
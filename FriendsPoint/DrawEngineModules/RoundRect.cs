

using System.Reflection.Emit;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace FriendsPoint.DrawEngineModules {
    public partial class DrawEngine {
        static public void DrawRoundRect(SpriteBatch spriteBatch, Vector2 position, Vector2 size, Vector2 centerPosition, float round, float rotation, float scale, float layer, Color fillColor, StrokeStyle strokeStyle, LineStyle lineStyle) {
            FillRoundRect(spriteBatch, position, centerPosition, size, round, rotation, scale, layer, fillColor);
            StrokeRoundRect(spriteBatch, lineStyle, position, size / 2, size, strokeStyle.PositionVariant, strokeStyle.Width, strokeStyle.Color, rotation, scale, layer);
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
            //DrawEngine.RectFigure(spriteBatch, position, new Rectangle(0, 0, 20, 20), new Vector2(0, 0), Color.Yellow, 0f, 1f, 1f);
            Vector2 sum = centerPosition + cntrPosition;
            Vector2 normalCenterPosition = new Vector2(centerPosition.Y, centerPosition.X);
            Vector2 normalCntrPosition = new Vector2(cntrPosition.Y, -cntrPosition.X);

            Vector2 centerBlockPosition = position + new Vector2(round, 0);
            Vector2 centerBlockSize = size - new Vector2(round * 2, 0);
            Vector2 centerBlockCenterPosition = centerBlockSize / 2;
            Vector2 sideBlockSize = new Vector2(round, size.Y - round * 2);
            Vector2 leftBlockCenterPosition = new Vector2(centerBlockCenterPosition.X + round, sideBlockSize.Y / 2);
            Vector2 rightBlockCenterPosition = -new Vector2(centerBlockCenterPosition.X, -sideBlockSize.Y / 2);

            FillRect(spriteBatch, position, centerBlockCenterPosition - centerPosition + cntrPosition, centerBlockSize, color, rotation, scale, layer - 0.00001f);
            FillRect(spriteBatch, position, leftBlockCenterPosition - centerPosition + cntrPosition, sideBlockSize, color, rotation, scale, layer - 0.00001f);
            FillRect(spriteBatch, position, rightBlockCenterPosition - centerPosition + cntrPosition, sideBlockSize, color, rotation, scale, layer - 0.00001f);

            float ninetyDegRot = MathF.PI / 2;
            RectTexture(spriteBatch, QuarterCircleTexture, position, (cntrPosition) * (300 / round), color, rotation, scale / (300 / round), layer - 0.00001f);
            RectTexture(spriteBatch, QuarterCircleTexture, position, (normalCntrPosition + new Vector2(0, size.Y)) * (300 / round), color, rotation + ninetyDegRot, scale / (300 / round), layer - 0.00001f);
            RectTexture(spriteBatch, QuarterCircleTexture, position, (centerPosition * 2 - cntrPosition) * (300 / round), color, rotation + ninetyDegRot * 2, scale / (300 / round), layer - 0.00001f);
            RectTexture(spriteBatch, QuarterCircleTexture, position, (-normalCntrPosition + new Vector2(size.X, 0)) * (300 / round), color, rotation + ninetyDegRot * 3, scale / (300 / round), layer - 0.00001f);
        }

        static public void StrokeRoundRect(SpriteBatch spriteBatch, LineStyle lineStyle, Vector2 position, Vector2 cntrPos, Vector2 size, string positionVariant, float strokeWidth, Color strokeColor, float rotation, float scale, float layer) {
            //Texture2D fisrt = Main.CreateQuarterCircleTexture(300, GraphicsDevice);
            //Texture2D second = Main.CreateQuarterCircleTexture(300, GraphicsDevice);
            //float offset = 50;
            //Vector2 offsetVector = new Vector2(offset, offset);


            //Vector2 offsetUV = offsetVector / new Vector2(second.Width, second.Height);

            //Main.multiplyEffect.Parameters["TextureA"].SetValue(fisrt);
            //Main.multiplyEffect.Parameters["TextureB"].SetValue(second);
            //Main.multiplyEffect.Parameters["Offset"].SetValue(offsetUV);

            //RectTexture(spriteBatch, fisrt, new Vector2(100, 100), Vector2.Zero);

        }
    }
}
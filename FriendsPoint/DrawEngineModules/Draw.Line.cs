
using System.Collections;
using System.Reflection.Emit;

namespace FriendsPoint.DrawEngineModules {
    public partial class DrawEngine {
        static public void DrawSolidLine(SpriteBatch spriteBatch, Vector2 start, Vector2 end, float width, Color color, LineStyle lineStyle, float layer = 1f) {
            Line(spriteBatch, start, end, color, width, layer);
        }
        static public float DrawDashedLine(SpriteBatch spriteBatch, Vector2 start, Vector2 end, float width, Color color, LineStyle lineStyle, float layer = 1f, float offset = 0f) {
            if (lineStyle.DashedLineType == "num") {
                int dashesNum = lineStyle.DashesNum;
                Vector2 direction = end - start;
                float lineLength = direction.Length() - lineStyle.DashesWidth;
                float step = lineLength / (dashesNum - 1);
                direction.Normalize();

                for (float i = 0; i <= lineLength; i += step) {
                    Vector2 startForDash = start + i * direction;
                    Vector2 endForDash = startForDash + direction * lineStyle.DashesWidth;
                    Line(spriteBatch, startForDash, endForDash, color, width, layer);
                }
                return 0f;
            } else {
                Vector2 direction = end - start;
                Vector2 normalizedDirection = Vector2.Normalize(direction);
                float step = lineStyle.DashesSpacing;
                Console.Log(start - end, "End");
                Vector2 startForDash = Vector2.Zero;
                float Phase = offset + lineStyle.Phase;
                Phase = Phase % lineStyle.DashesSpacing;
                for (float i = -lineStyle.DashesWidth + Phase + width; i <= direction.Length() - width; i += step) {
                    startForDash = start + i * normalizedDirection;
                    Vector2 endForDash = startForDash + normalizedDirection * lineStyle.DashesWidth;
                    if ((start - endForDash).Length() > (start - end).Length()) {
                        endForDash -= normalizedDirection * (end - endForDash).Length();
                    }
                    if (i < 0) {
                        startForDash -= normalizedDirection * i;
                    }
                    Line(spriteBatch, startForDash, endForDash, color, width, layer);
                }
                Console.Log((startForDash - end).Length() - width, "StartForDash");
                return direction.Length() % step;
            }
        }
        static public void DrawWavyLine(
            SpriteBatch spriteBatch,
            Vector2 start,
            Vector2 end,
            float width,
            Color color,
            float layer,
            float amplitude,
            float frequency,
            float phase = 0f,
            float step = 0.01f) {
            Vector2 dir = end - start;
            float length = dir.Length();
            dir.Normalize();

            Vector2 normal = new Vector2(-dir.Y, dir.X);

            Vector2 prev = start + normal * width / 2;
            for (float x = 0; x <= length; x += step) {
                float y = MathF.Sin(x * frequency + phase) * amplitude;
                Vector2 cur = prev + dir * step + normal * y;
                Line(spriteBatch, prev, cur, color, width, layer, true);
                prev = cur;
            }
        }
        static public void DrawZigZagLine(SpriteBatch spriteBatch,
            Vector2 start,
            Vector2 end,
            float width,
            Color color,
            float layer,
            float amplitude,
            float frequency,
            float phase = 0f,
            float step = 0.01f) {
            Vector2 dir = end - start;
            float length = dir.Length();
            dir.Normalize();

            Vector2 normal = new Vector2(-dir.Y, dir.X);

            float zigStep = MathF.PI / frequency;
            float sign = MathF.Sin(phase) >= 0 ? 1f : -1f;

            Vector2 prev = start + normal * sign * amplitude;

            for (float x = zigStep; x <= length; x += zigStep) {
                sign = -sign; // чередуем вверх / вниз
                Vector2 cur = start + dir * x + normal * sign * amplitude;
                Line(spriteBatch, prev, cur, color, width, layer, true);
                prev = cur;
            }
        }

        static public void Line(SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color color, float width, float layer = 1f, bool isCentered = false, SpriteEffects spriteEffect = SpriteEffects.None) {
            Vector2 delta = end - start;
            float length = delta.Length();
            float angle = MathF.Atan2(delta.Y, delta.X);
            if (isCentered) {
                Vector2 normal = Vector2.Normalize(new Vector2(-delta.Y, delta.X));
                start -= normal * width / 2;
            }
            spriteBatch.Draw(
                TexturePixel,
                start,
                null,
                color,
                angle,
                Vector2.Zero,
                new Vector2(length, width),
                SpriteEffects.None,
                layer
            );
        }
        static public void BezierLine(
            SpriteBatch spriteBatch,
            Vector2 p0,
            Vector2 p1,
            Vector2 p2,
            Vector2 p3,
            float width,
            Color color,
            float layer = 1f,
            int segments = 32) {
                Vector2 prev = p0;

                for (int i = 1; i <= segments; i++) {
                    float t = i / (float)segments;
                    Vector2 current = BezierPoint(p0, p1, p2, p3, t);

                    Line(spriteBatch, prev, current, color, width, layer);
                    prev = current;
                }
        }


        public static Vector2 BezierPoint(
            Vector2 p0,
            Vector2 p1,
            Vector2 p2,
            Vector2 p3,
            float t) {
            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;
            float uuu = uu * u;
            float ttt = tt * t;

            return
                uuu * p0 +
                3 * uu * t * p1 +
                3 * u * tt * p2 +
                ttt * p3;
        }
    }
}
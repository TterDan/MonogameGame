using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendsPoint.GameObjects {
    public class CircleHBoxObj : GameObject {                                                          // Класс оружия, наследует класс GameObject
        public int Radius;
        public Texture2D CreateCircleTexture(GraphicsDevice graphicsDevice, int radius, Color color) {
            int diameter = radius * 2;
            Texture2D texture = new Texture2D(graphicsDevice, diameter, diameter);
            Color[] data = new Color[diameter * diameter];

            Vector2 center = new Vector2(radius);

            for (int y = 0; y < diameter; y++) {
                for (int x = 0; x < diameter; x++) {
                    int index = y * diameter + x;
                    Vector2 pos = new Vector2(x, y);

                    if (Vector2.Distance(pos, center) <= radius)
                        data[index] = color;
                    else
                        data[index] = Color.Transparent;
                }
            }

            texture.SetData(data);
            return texture;
        }
    }
}

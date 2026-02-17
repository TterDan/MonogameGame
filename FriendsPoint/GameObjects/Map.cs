
namespace FriendsPoint.GameObjects {
    public class Map : SquareHBoxObj {                                                          // Класс карты, наследует класс GameObject
        public Map(Vector2 position, int width, int height) {
            Width = width;
            Height = height;
            Layer = 0f;
            ScreenPosition = position;
            Position = position;
        }
        public override void Draw(SpriteBatch render) {
            DrawEngine.Texture(render, Texture, ScreenPosition);
        }
    }
}

namespace FriendsPoint.GameObjects {
    public class Enemy : CircleHBoxObj {                                                          // Класс врага, наследует класс GameObject
        public float Health = 100f;
        public float MoveSpeed;
        public Vector2 currentSpeed = Vector2.Zero;
        public Rectangle Rect;
        public Enemy(GraphicsDevice GraphicsDevice, Vector2 position, int radius, float moveSpeed) {
            Layer = 0.5f;
            ScreenPosition = position;
            Position = position;
            MoveSpeed = moveSpeed;
            Radius = radius;
            //Texture = CreateCircleTexture(GraphicsDevice, Radius, Color.Red);
            DrawRect = new Rectangle(0, 0, Radius * 2, Radius * 2);
        }

        public void hit() {

        }

        public void Die(List<GameObject> objects, int objectIndex) {
            objects.RemoveAt(objectIndex);
            // Код при смерти во врага
        }

        public void TakeDamage(float damage, List<GameObject> objects, int objectIndex) {
            Health -= damage;
            if (Health <= 0) {
                 Die(objects, objectIndex);
            }
            Console.Log("Enemy gets punched", "non-repeat", "Ouch!");
            // Код при попадании во врага

        }

        public void move(Vector2 moveDirection, float length) {
            if (moveDirection.Length() > length * DrawEngine.GameScale) {
                moveDirection.Normalize();
                moveDirection -= currentSpeed;
                currentSpeed = Vector2.Lerp(currentSpeed, Vector2.Zero, 0.1f);
                Position += moveDirection * MoveSpeed;
                ScreenPosition += moveDirection * MoveSpeed;
            }
        }

        public override void Draw(SpriteBatch render) {
            DrawEngine.DrawCircle(render, ScreenPosition, Radius, DrawRect, new Vector2(DrawRect.Width / 2, DrawRect.Height / 2), Color.Red, 0);
        }
    }
}
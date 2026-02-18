
namespace FriendsPoint.GameObjects {
    public class Enemy : CircleHBoxObj {                                                          // Класс врага, наследует класс GameObject
        public float Health = 100f;
        public float MoveSpeed;
        public Vector2 BeatForceVelocity = Vector2.Zero;
        public Rectangle Rect;

        public Enemy(GraphicsDevice GraphicsDevice, Vector2 position, int radius, float moveSpeed) {
            Layer = 0.5f;
            ScreenPosition = position;
            Position = position;
            MoveSpeed = moveSpeed;
            Radius = radius;
            DrawRect = new Rectangle(0, 0, Radius * 2, Radius * 2);
        }
        public void Hit() {

        }
        public void Die(List<GameObject> enemies, int objectIndex) {
            enemies.RemoveAt(objectIndex);
            // Код при смерти врага
        }
        public void TakeDamage(float damage, List<GameObject> enemies, int objectIndex) {
            Health -= damage;
            if (Health <= 0) {
                 Die(enemies, objectIndex);
            }
            Console.Log("Enemy gets punched", "Ouch!");
            // Код при попадании во врага
        }
        public void move(Vector2 moveDirection, float length) {
            if (moveDirection.Length() < length) {
                moveDirection = Vector2.Zero;
            } else {
                moveDirection.Normalize();
            }
            moveDirection -= BeatForceVelocity;
            BeatForceVelocity = Vector2.Lerp(BeatForceVelocity, Vector2.Zero, 0.1f);
            Position += moveDirection * MoveSpeed;
            ScreenPosition += moveDirection * MoveSpeed;
        }
        public override void Draw(SpriteBatch render) {
            DrawEngine.Circle(render, HitboxTexture, ScreenPosition, Radius, 0, 0f, 1f / (300 / Radius));
        }
    }
}
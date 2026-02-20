
namespace FriendsPoint.GameObjects {
    public class Enemy : CircleHBoxObj {                                                          // Класс врага, наследует класс GameObject
        private float Health = 100f;
        private float MoveSpeed;
        private Vector2 HitForce = Vector2.Zero;
        private float HitForceVelocity = 200f;
        private float AdditionForceDeceleraion = 1f;
        private int IsMove = 0;

        public Enemy(GraphicsDevice GraphicsDevice, Vector2 position, int radius, float moveSpeed, int isMove) {
            Layer = 0.2f;
            ScreenPosition = position;
            Position = position;
            MoveSpeed = moveSpeed;
            Radius = radius;
            IsMove = 0;
        }
        public float GetHealth() {
            return Health;
        }
        public bool TakeDamage(float damage, List<GameObject> enemies, int objectIndex) {
            Health -= damage;
            if (Health <= 0) {
                enemies.RemoveAt(objectIndex);
                return true;
            }
            return false;
        }
        public void AddForce(Vector2 forceVector) {
            HitForce += forceVector * HitForceVelocity;
        }
        public void Move(Vector2 vectorToPlayer, float sumOfRadiuses, float deltaTime) {
            Vector2 forceToPlayer = (vectorToPlayer.Length() >= sumOfRadiuses ? Vector2.Normalize(vectorToPlayer) * MoveSpeed : Vector2.Zero) * IsMove;
            Position += (HitForce + forceToPlayer) * deltaTime;
            HitForce = Vector2.Lerp(HitForce, Vector2.Zero, AdditionForceDeceleraion * deltaTime);
        }
        public override void Draw(SpriteBatch render) {
            DrawEngine.Circle(render, CircleTexture, ScreenPosition, Radius, Color.Red, Layer, 0f, 1f / (300 / Radius));
        }
    }
}
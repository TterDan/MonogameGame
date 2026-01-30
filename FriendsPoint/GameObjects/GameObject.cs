using FriendsPoint;
using Microsoft.Xna.Framework;

namespace FriendsPoint.GameObjects {
    abstract public class GameObject        // Абстрактный класс для всех игровых объектов, нужен чтобы не писать каждый раз в объектах функции отрисовки и базовые поля.
    {
        public Vector2 ScreenPosition; // Соответственно базовые поля
        public Vector2 Position;

        public float TextureLayer = 0.9f;
        public float Layer = 0.8f;

        public Texture2D Texture;
        public Texture2D HitboxTexture;

        public float HitboxOpacity = 1.0f;
        public float TextureOpacity = 1.0f;

        public float TextureScale = 1.7f;
        public float Scale = 1f;

        public float Rotation = 0f;
        public float Speed = 7f;

        public bool isflying = false;

        public Rectangle DrawRect;

        public Microsoft.Xna.Framework.Color TextureColor = Color.White;
        public Microsoft.Xna.Framework.Color HitboxTextureColor = Color.White;

        public virtual void Draw(SpriteBatch spriteBatch) {

        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Xml.Linq;

public class Enemy : GameObject {                                                          // Класс врага, наследует класс GameObject
    public int Health = 100;
    public float MoveSpeed;
    public Enemy(Texture2D texture, Vector2 position, int width, int height, float moveSpeed) {
        Width = width;
        Height = height;
        Layer = 0.5f;
        Scale = 1.0f;
        ScreenPosition = position;
        Position = position;
        MoveSpeed = moveSpeed;
        Texture = texture;
    }
    public void hit() {

    }
    public bool TakeDamage(int damage, int objectIndex) {
        Health -= damage;
        if (Health <= 0) {
            return die(objectIndex);
        }
        // Код при попадании во врага
        return false;
    }
    public bool die(int objectIndex) {
        // Код при смерти врага
        return true;
    }
    public void moveTowardsPlayer(Vector2 playerPosition) {
        Vector2 direction = playerPosition - Position;
        if (direction != Vector2.Zero) {
            direction.Normalize();
            Position += direction * MoveSpeed;
            ScreenPosition += direction * MoveSpeed;
        }
    }
    public override void Draw(SpriteBatch render, Rectangle? sourceRectangle = null) {   // Отрисовка врага, здесь я переопределяю функцию draw() из GameObject. Если в него нужно передать какой нибудь Rectangle, то надо писать такую конструкцию, если не нужно, то функцию можно не переопределять

        Rectangle Rect = new Rectangle((int)ScreenPosition.X, (int)ScreenPosition.Y, Width, Height);
        base.Draw(render, Rect);
    }
}
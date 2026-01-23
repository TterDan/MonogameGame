using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        Texture = CreateCircleTexture(GraphicsDevice, Radius, Color.Red);
        DrawRect = new Rectangle(0, 0, Radius * 2, Radius * 2);
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

    public void move(Vector2 moveDirection) {
        System.Diagnostics.Debug.WriteLine(moveDirection);
        moveDirection.Normalize();
        moveDirection -= currentSpeed;
        currentSpeed = Vector2.Lerp(currentSpeed, Vector2.Zero, 0.1f);
        Position += moveDirection * MoveSpeed;
        ScreenPosition += moveDirection * MoveSpeed;
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class SomeObject {
    public Vector2 Position;
    public int Width;
    public int Height;
    public Texture2D BlackTexture;

    public SomeObject() {
        Position = new Vector2(100, 100);
        Width = 50;
        Height = 50;
    }

    public void Draw(SpriteBatch render) {
        Rectangle Rect = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        //render.Draw(
        //    BlackTexture, 
        //    Position, 
        //    Rect, 
        //    Color.Black, 
        //    0.0f,
        //    new Vector2(Height, Width) * 0.5f,
        //    0.35f,  
        //    SpriteEffects.None,
        //    0.0f);
    }

}
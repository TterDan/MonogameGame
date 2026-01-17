using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Xml.Linq;

static public class Camera {                                                          // —татический класс камеры
    static public float MaxShiftOffset = 180f;
    static public Vector2 ShiftOffset = Vector2.Zero;
    static public float ShiftOffsetSpeed = 0.15f;

    static public float MaxMouseOffset = 0.1f;
    static public Vector2 MouseOffset = Vector2.Zero;
    static public float MouseOffsetSpeed = 0.4f;

    static public float MaxWalkOffset = 30f;
    static public Vector2 WalkOffset = Vector2.Zero;
    static public float WalkOffsetSpeed = 0.15f;

    static public Vector2 CameraOffset = Vector2.Zero;

    static public float Zoom = 0f;                                        // ≈сли вдруг когда нибудь € смогу реализовать зум камеры, то будет кайф, в данный момент € хз как просто добавил поле дл€ зума (точнее € могу на изи узнать как это сделать но мне лень (точнее не узнать а разобратьс€ самому))

    static public void ChangeShiftOffset(Vector2 direction) {
        ShiftOffset = Vector2.Lerp(ShiftOffset, MaxShiftOffset * direction, ShiftOffsetSpeed);
        System.Diagnostics.Debug.WriteLine(ShiftOffset);
    }
    static public void ChangeMouseOffset(Vector2 direction) {
        MouseOffset = Vector2.Lerp(MouseOffset, MaxMouseOffset * direction, MouseOffsetSpeed);
    }
    static public void ChangeWalkOffset(Vector2 direction) {
        WalkOffset = Vector2.Lerp(WalkOffset, MaxWalkOffset * direction, WalkOffsetSpeed);
    }
    static public void ChangeOffset() {
        CameraOffset = -WalkOffset + MouseOffset + ShiftOffset;
    }

}
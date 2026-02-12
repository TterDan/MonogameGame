
static public class Camera {                                                          // Статический класс камеры
    static public float MaxShiftOffset = 180f;
    static public Vector2 ShiftOffset = Vector2.Zero;
    static public float ShiftOffsetSpeed = 0.15f;

    static public float MaxMouseOffset = 0.1f;
    static public Vector2 MouseOffset = Vector2.Zero;
    static public float MouseOffsetSpeed = 0.4f;

    static public float MaxWalkOffset = 50f;
    static public Vector2 WalkOffset = Vector2.Zero;
    static public float WalkOffsetSpeed = 0.10f;

    static public Vector2 CameraOffset = Vector2.Zero;
    static public float Zoom = 0f;
    static public void ChangeShiftOffset(Vector2 direction) {
        ShiftOffset = Vector2.Lerp(ShiftOffset, MaxShiftOffset * direction, ShiftOffsetSpeed);
    }
    static public void ChangeMouseOffset(Vector2 direction) {
        MouseOffset = Vector2.Lerp(MouseOffset, MaxMouseOffset * direction, MouseOffsetSpeed);
    }
    static public void ShotOffset(Vector2 direction, float recoilStrengthForCamera)
    {
        MouseOffset = Vector2.Lerp(MouseOffset, recoilStrengthForCamera * -direction, 0.05f);
    }
    static public void ChangeWalkOffset(Vector2 direction) {
        WalkOffset = Vector2.Lerp(WalkOffset, MaxWalkOffset * direction, WalkOffsetSpeed);
    }
    static public void ChangeOffset() {
        CameraOffset = -WalkOffset + MouseOffset + ShiftOffset;
    }
}
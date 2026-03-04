
using FriendsPoint;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;
public class Animation {
    public float Value;
    public float End;
    public int TimerIndex;
    public string Function;
    public string FunctionType;
    public float Modifier;
    public bool IsActive;
    public void SetTimer(float _Value, float _End, float _Step, int _TimerIndex, string _Function, string _FunctionType, float _Modifier) {
        IsActive = true;
        Value = _Value;
        End = _End;
        TimerIndex = _TimerIndex;
        Modifier = _Modifier;
        Function = _Function;                           // 1 - linear, 2 - circle, 3 - expo, 4 - back, 5 - elastic, 6 - bounce 
        FunctionType = _FunctionType;                   // 1 - easeIn, 2 - easeOut, 3 - easeInOut
    }
}
public partial class AnimEngine {

    static public void Animate(ref int var, float animTime) {

    }
    static public void UpdateAnim(GameTime gameTime) {

    }
    private int GetTimerIndex(string key) {
        return TimerEngine.GetTimerIndex(key);
    }
    private float GetTimer(int index) {
        return TimerEngine.GetTimer(index);
    }
    private void AddTimer(float _Value, float _End, float _Step, string _Key, string _StepType) {
        TimerEngine.AddTimer(_Value, _End, _Step, _Key, _StepType);
    }
}



public static class Functions {
    static public float easeInSine(float x) {
        return 1 - MathF.Cos((x* MathF.PI) / 2);
    }
    static public float easeOutSine(float x) {
        return MathF.Sin((x * MathF.PI) / 2);
    }
    static public float easeInOutSine(float x) {
        return -(MathF.Cos(MathF.PI * x) - 1) / 2;
    }



    static public float easeInCirc(float x) {
            return 1 - MathF.Sqrt(1 - MathF.Pow(x, 2));
    }
    static public float easeOutCirc(float x) {
        return MathF.Sqrt(1 - MathF.Pow(x - 1, 2));
    }
    static public float easeInOutCirc(float x) {
        return x < 0.5
        ? (1 - MathF.Sqrt(1 - MathF.Pow(2 * x, 2))) / 2
        : (MathF.Sqrt(1 - MathF.Pow(-2 * x + 2, 2)) + 1) / 2;
    }



    static public float easeInExpo(float x) {
        return x == 0 ? 0 : MathF.Pow(2, 10 * x - 10);
    }
    static public float easeOutExpo(float x) {
        return x == 1 ? 1 : 1 - MathF.Pow(2, -10 * x);
    }
    static public float easeInOutExpo(float x) {
        return x == 0
          ? 0
          : x == 1
          ? 1
          : x < 0.5 ? MathF.Pow(2, 20 * x - 10) / 2
          : (2 - MathF.Pow(2, -20 * x + 10)) / 2;
    }



    static public float easeInBack(float x) {
        float c1 = 1.70158f;
        float c3 = c1 + 1;

        return c3* x *x * x - c1 * x * x;
    }
    static public float easeOutBack(float x) {
        float c1 = 1.70158f;
        float c3 = c1 + 1;

        return 1 + c3 * MathF.Pow(x - 1, 3) + c1 * MathF.Pow(x - 1, 2);
    }
    static public float easeInOutBack(float x) {
        float c1 = 1.70158f;
        float c2 = c1 * 1.525f;

        return x < 0.5
          ? (MathF.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2)) / 2
          : (MathF.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
    }



    static public float easeInElastic(float x) {
        float c4 = (2 * MathF.PI) / 3;
        return x == 0
            ? 0
            : x == 1
            ? 1
            : -MathF.Pow(2, 10 * x - 10) * MathF.Sin((x* 10 - 10.75f) * c4);
    }
    static public float easeOutElastic(float x) {
        float c4 = (2 * MathF.PI) / 3;
        return x == 0
            ? 0
            : x == 1
            ? 1
            : MathF.Pow(2, -10 * x) * MathF.Sin((x* 10 - 0.75f) * c4) + 1;
    }
    static public float easeInOutElastic(float x) {
        float c5 = (2 * MathF.PI) / 4.5f;
        return x == 0
          ? 0
          : x == 1
          ? 1
          : x< 0.5
          ? -(MathF.Pow(2, 20 * x - 10) * MathF.Sin((20 * x - 11.125f) * c5)) / 2
          : (MathF.Pow(2, -20 * x + 10) * MathF.Sin((20 * x - 11.125f) * c5)) / 2 + 1;
    }



    static public float easeInBounce(float x) {
        return 1 - easeOutBounce(1 - x);
    }
    static public float easeOutBounce(float x) {
        float n1 = 7.5625f;
        float d1 = 2.75f;
        if (x < 1 / d1) {
            return n1 * x * x;
        } else if (x < 2 / d1) {
            return n1 * (x -= 1.5f / d1) * x + 0.75f;
        } else if (x < 2.5 / d1) {
            return n1 * (x -= 2.25f / d1) * x + 0.9375f;
        } else {
            return n1 * (x -= 2.625f / d1) * x + 0.984375f;
        }
    }
    static public float easeInOutBounce(float x) {
        return x < 0.5
          ? (1 - easeOutBounce(1 - 2 * x)) / 2
          : (1 + easeOutBounce(2 * x - 1)) / 2;
    }

}
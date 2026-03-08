
using FriendsPoint;
using static System.Runtime.InteropServices.JavaScript.JSType;
public class Animation {
    private Func<float, float> Function;
    public float Animtime;
    public float CurrentAnimtime = 0f;
    private float[] Keyframes;
    private int CurrentKeyFrame = 0;
    private int NumOfColumns;
    public bool IsActive = false;

    public float[] CurrentValues;
    public Animation(float[] keyframes, int numOfColumns, float animtime, Func<float, float> function) {
        Function = function;
        Animtime = animtime;
        Keyframes = keyframes;
        NumOfColumns = numOfColumns;
        CurrentValues = new float[numOfColumns];
        Function = function;
        for (int i = 0; i < numOfColumns; i++) {
            CurrentValues[i] = keyframes[i];
        }
    }



    public void Stop() {
        Pause();
        Reset();
    }
    public void Pause() {
        for (int i = 0; i < AnimEngine.curAnims.Count; i++) {
            if (AnimEngine.curAnims[i] == this) {
                AnimEngine.curAnims.RemoveAt(i);
            }
        }
        IsActive = false;
    }
    public void Reset() {
        CurrentAnimtime = 0f;
        CurrentKeyFrame = 0;
        for (int i = 0; i < NumOfColumns; i++) {
            CurrentValues[i] = Keyframes[i];
        }
    }
    public void Play() {
        if (IsActive == false) {
            AnimEngine.curAnims.Add(this);
            IsActive = true;
        }
    }



    public void doAnim(float elapsedTime) {
        int keyframeIndex1 = CurrentKeyFrame * NumOfColumns;
        int keyframeIndex2 = (CurrentKeyFrame + 1) * NumOfColumns;

        float normalizedTime1 = Keyframes[keyframeIndex1] / 100;
        float normalizedTime2 = Keyframes[keyframeIndex2] / 100;

        float normalizedCurTime = CurrentAnimtime / Animtime;
        float functionedTime = Function(normalizedCurTime);

        Console.Log(functionedTime, "func");
        Console.Log(normalizedCurTime, "norm");

        float keyFrameTime = normalizedTime2 - normalizedTime1;
        float keyFrameCurrentTime = functionedTime - normalizedTime1;

        CurrentValues[0] = functionedTime;
        for (int i = 1; i < NumOfColumns; i++) {
            float value1 = Keyframes[keyframeIndex1 + i];
            float value2 = Keyframes[keyframeIndex2 + i];
            float newValue = value1 + (value2 - value1) * (keyFrameCurrentTime / keyFrameTime);
            CurrentValues[i] = newValue;
        }
        CurrentAnimtime += elapsedTime;
        if (normalizedCurTime >= 1f) {
            this.Stop();
        } else
        if (functionedTime > normalizedTime2) {
            CurrentKeyFrame++;
        }
    }
}

public partial class AnimEngine {
    static public List<Animation> curAnims = new List<Animation>();
    static public void UpdateAnim(GameTime gameTime) {
        for (int i = 0; i < AnimEngine.curAnims.Count; i++) {
            AnimEngine.curAnims[i].doAnim((float)gameTime.ElapsedGameTime.TotalMilliseconds);
        }
    }
}



public static class Functions {
    static public readonly Func<float, float> linear = Linear;
    static public readonly Func<float, float> easeInSine = EaseInSine;
    static public readonly Func<float, float> easeOutSine = EaseOutSine;
    static public readonly Func<float, float> easeInOutSine = EaseInOutSine;    // Синусоидная

    static public readonly Func<float, float> easeInQuad = EaseInQuad;          // Степенная 2
    static public readonly Func<float, float> easeOutQuad = EaseOutQuad;
    static public readonly Func<float, float> easeInOutQuad = EaseInOutQuad;
    static public readonly Func<float, float> easeInCubic = EaseInCubic;          // Степенная 3
    static public readonly Func<float, float> easeOutCubic = EaseOutCubic;
    static public readonly Func<float, float> easeInOutCubic = EaseInOutCubic;
    static public readonly Func<float, float> easeInQuart = EaseInQuart;          // Степенная 4
    static public readonly Func<float, float> easeOutQuart = EaseOutQuart;
    static public readonly Func<float, float> easeInOutQuart = EaseInOutQuart;
    static public readonly Func<float, float> easeInQuint = EaseInQuint;          // Степенная 5
    static public readonly Func<float, float> easeOutQuint = EaseOutQuint;
    static public readonly Func<float, float> easeInOutQuint = EaseInOutQuint;

    static public readonly Func<float, float> easeInCirc = EaseInCirc;          // Круговая
    static public readonly Func<float, float> easeOutCirc = EaseOutCirc;
    static public readonly Func<float, float> easeInOutCirc = EaseInOutCirc;
    static public readonly Func<float, float> easeInExpo = EaseInExpo;          // Экспоненциальная
    static public readonly Func<float, float> easeOutExpo = EaseOutExpo;
    static public readonly Func<float, float> easeInOutExpo = EaseInOutExpo;
    static public readonly Func<float, float> easeInBounce = EaseInBounce;      // Отскок
    static public readonly Func<float, float> easeOutBounce = EaseOutBounce;
    static public readonly Func<float, float> easeInOutBounce = EaseInOutBounce;


    static public float Linear(float x) {
        return x;
    }



    static public float EaseInQuad(float x) {
        return MathF.Pow(x, 2);
    }
    static public float EaseOutQuad(float x) {
        return 1 - MathF.Pow(1 - x, 2);
    }
    static public float EaseInOutQuad(float x) {
        return x < 0.5 ? 2 * MathF.Pow(x, 2) : 1 - MathF.Pow(-2 * x + 2, 2) / 2;
    }

    static public float EaseInCubic(float x) {
        return MathF.Pow(x, 3);
    }
    static public float EaseOutCubic(float x) {
        return 1 - MathF.Pow(1 - x, 3);
    }
    static public float EaseInOutCubic(float x) {
        return x < 0.5 ? MathF.Pow(2, 2) * MathF.Pow(x, 3) : 1 - MathF.Pow(-2 * x + 2, 3) / 2;
    }

    static public float EaseInQuart(float x) {
        return MathF.Pow(x, 4);
    }
    static public float EaseOutQuart(float x) {
        return 1 - MathF.Pow(1 - x, 4);
    }
    static public float EaseInOutQuart(float x) {
        return x < 0.5 ? MathF.Pow(2, 3) * MathF.Pow(x, 4) : 1 - MathF.Pow(-2 * x + 2, 4) / 2;
    }

    static public float EaseInQuint(float x) {
        return MathF.Pow(x, 5);
    }
    static public float EaseOutQuint(float x) {
        return 1 - MathF.Pow(1 - x, 5);
    }
    static public float EaseInOutQuint(float x) {
        return x < 0.5 ? MathF.Pow(2, 4) * MathF.Pow(x, 5) : 1 - MathF.Pow(-2 * x + 2, 5) / 2;
    }


    static public float EaseInSine(float x) {
        return 1 - MathF.Cos((x* MathF.PI) / 2);
    }
    static public float EaseOutSine(float x) {
        return MathF.Sin((x * MathF.PI) / 2);
    }
    static public float EaseInOutSine(float x) {
        return -(MathF.Cos(MathF.PI * x) - 1) / 2;
    }



    static public float EaseInCirc(float x) {
            return 1 - MathF.Sqrt(1 - MathF.Pow(x, 2));
    }
    static public float EaseOutCirc(float x) {
        return MathF.Sqrt(1 - MathF.Pow(x - 1, 2));
    }
    static public float EaseInOutCirc(float x) {
        return x < 0.5
        ? (1 - MathF.Sqrt(1 - MathF.Pow(2 * x, 2))) / 2
        : (MathF.Sqrt(1 - MathF.Pow(-2 * x + 2, 2)) + 1) / 2;
    }



    static public float EaseInExpo(float x) {
        return x == 0 ? 0 : MathF.Pow(2, 10 * x - 10);
    }
    static public float EaseOutExpo(float x) {
        return x == 1 ? 1 : 1 - MathF.Pow(2, -10 * x);
    }
    static public float EaseInOutExpo(float x) {
        return x == 0
          ? 0
          : x == 1
          ? 1
          : x < 0.5 ? MathF.Pow(2, 20 * x - 10) / 2
          : (2 - MathF.Pow(2, -20 * x + 10)) / 2;
    }


    static public float EaseInBounce(float x) {
        return 1 - EaseInBounce(1 - x);
    }
    static public float EaseOutBounce(float x) {
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
    static public float EaseInOutBounce(float x) {
        return x < 0.5
          ? (1 - EaseOutBounce(1 - 2 * x)) / 2
          : (1 + EaseOutBounce(2 * x - 1)) / 2;
    }

}
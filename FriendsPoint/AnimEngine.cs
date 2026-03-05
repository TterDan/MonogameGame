
using FriendsPoint;
public class Animation {
    private string function = "linear";
    private string funcType = "ease";
    public float animtime;
    public float currentanimtime = 0f;
    private float[] keyframes;
    private int currentKeyFrame = 0;
    private int numOfColumns;
    private bool isPlaying = false;

    public float[] currentValues;
    public Animation(float[] _keyframes, int _numOfColumns, float _animtime, string _function, string _funcType) {
        function = _function;
        animtime = _animtime;
        keyframes = _keyframes;
        numOfColumns = _numOfColumns;
        currentValues = new float[numOfColumns];
        for (int i = 0; i < _numOfColumns; i++) {
            currentValues[i] = keyframes[i];
        }
    }
    public Animation(float[] _keyframes, int _numOfColumns, float _animtime) {
        animtime = _animtime;
        keyframes = _keyframes;
        numOfColumns = _numOfColumns;
        currentValues = new float[numOfColumns];
        for (int i = 0; i < _numOfColumns; i++) {
            currentValues[i] = keyframes[i];
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
        isPlaying = false;
    }
    public void Reset() {
        currentanimtime = 0f;
        currentKeyFrame = 0;
        for (int i = 0; i < numOfColumns; i++) {
            currentValues[i] = keyframes[i];
        }
    }
    public void Play() {
        if (isPlaying == false) {
            AnimEngine.curAnims.Add(this);
            isPlaying = true;
        }
    }



    public void doAnim(float elapsedTime) {
        int keyframeIndex1 = currentKeyFrame * numOfColumns;
        int keyframeIndex2 = (currentKeyFrame + 1) * numOfColumns;

        float normalizedTime1 = keyframes[keyframeIndex1] / 100;
        float normalizedTime2 = keyframes[keyframeIndex2] / 100;

        float normalizedCurTime = currentanimtime / animtime;

        float keyFrameTime = normalizedTime2 - normalizedTime1;
        float keyFrameCurrentTime = normalizedCurTime - normalizedTime1;

        currentValues[0] = normalizedCurTime;
        for (int i = 1; i < numOfColumns; i++) {
            float value1 = keyframes[keyframeIndex1 + i];
            float value2 = keyframes[keyframeIndex2 + i];
            float newValue = value1 + (value2 - value1) * (keyFrameCurrentTime / keyFrameTime);
            currentValues[i] = newValue;
        }
        currentanimtime += elapsedTime;
        if (normalizedCurTime >= 1f) {
            this.Stop();
        }
        if (normalizedCurTime >= normalizedTime2) {
            currentKeyFrame++;
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
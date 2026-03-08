
using FriendsPoint;
using System.Timers;
public class Timer {
    public float Value;
    public float End;
    public float Step;
    public string StepType;
    public bool IsActive;
    public int stepModifier = 1;
    public Action Func;

    public Timer(float _Value, float _End, float _Step, string _StepType, Action _func) {
        IsActive = false;
        Value = _Value;
        End = _End;
        Step = _Step;
        StepType = _StepType;               // 1 - counter, 2 - timer       ; 1 - счетчик (любой шаг), 2 - Таймер в миллисекундах 
        Func = _func;
    }

    public void Stop() {
        Pause();
        Reset();
    }
    public void Pause() {
        for (int i = 0; i < TimerEngine.Timers.Count; i++) {
            if (TimerEngine.Timers[i] == this) {
                TimerEngine.Timers.RemoveAt(i);
            }
        }
        IsActive = false;
    }
    public void Reset() {
        Value = 0f;
    }
    public void Play() {
        if (IsActive == false) {
            TimerEngine.Timers.Add(this);
            IsActive = true;
        }
    }



    public void doTimer(GameTime gameTime) {
        if (this.IsActive == true) {
            if (this.StepType == "Timer") {
                this.Value += (float)gameTime.ElapsedGameTime.TotalMilliseconds * this.stepModifier;
            } else {
                this.Value += this.Step * this.stepModifier;
            }
            if (this.Value >= this.End) {
                this.Stop();
                Func();
            }
        }
    }
}
static public class TimerEngine {
    static public List<Timer> Timers;
    static public void Init() {
        Timers = new List<Timer>();
    }
    static public void UpdateTimer(GameTime gameTime) {
        for (int i = 0; i < TimerEngine.Timers.Count; i++) {
            TimerEngine.Timers[i].doTimer(gameTime);
        }
    }
}


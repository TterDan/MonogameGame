
using System.Linq;
using System.Timers;

namespace FriendsPoint
{
    public class Timer {
        public float Value;
        public float End;
        public float Step;
        public string StepType;
        public string Key;
        public bool IsActive;
        public void SetTimer(float _Value, float _End, float _Step, string _Key, string _StepType) {
            IsActive = true;
            Value = _Value;
            End = _End;
            Step = _Step;
            Key = _Key;
            StepType = _StepType;               // 1 - counter, 2 - timer       ; 1 - счетчик (любой шаг), 2 - Таймер в миллисекундах 
        }
    }
    static public class TimerEngine {
        static public List<Timer> timers;
        static public void Init() {
            timers = new List<Timer>();
        }
        static public void AddTimer(float _Value, float _End, float _Step, string _Key, string _StepType) {
            for (int i = 0; i < timers.Count; i++) {
                if (timers[i].IsActive == false) {
                    timers[i].SetTimer(_Value, _End, _Step, _Key, _StepType);
                    return;
                }
            }
            Timer timer = new Timer();
            timer.SetTimer(_Value, _End, _Step, _Key, _StepType);
            timers.Add(timer);
        }
        static public int GetTimerIndex(string key) {
            for (int i = 0; i < timers.Count; i++) {
                if (timers[i].Key == key) {
                    return i;
                }
            }
            return 0;
        }
        static public float GetTimer(int index) {
            return timers[index].Value;
        }
        static public void UpdateTimer(GameTime gameTime) {
            for (int i = 0; i < timers.Count; i++) {
                if (timers[i].IsActive == true) {
                    if (timers[i].StepType == "Timer") {
                        timers[i].Value += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    } else {
                        timers[i].Value += timers[i].Step;
                    }
                    if (timers[i].Value >= timers[i].End) {
                        timers[i].Value = timers[i].End;
                        timers[i].IsActive = false;
                    }
                }
            }
        }
    }
}
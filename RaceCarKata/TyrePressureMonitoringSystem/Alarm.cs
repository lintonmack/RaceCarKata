using System.Runtime.InteropServices.ComTypes;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        private readonly ISensor _sensor;

        public Alarm(ISensor sensor)
        {
            _sensor = sensor;
            _alarmOn = false;
            _alarmCount = 0;
        }

        private bool _alarmOn;
        private long _alarmCount;


        public void Check()
        {
            double psiPressureValue = GetPsiValue();
            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                TurnAlarmOn();
            }
        }

        private double GetPsiValue()
        {
            return _sensor.PopNextPressurePsiValue();
        }

        public bool AlarmOn()
        {
            return _alarmOn; 
        }

        public long GetAlarmCount()
        {
            return _alarmCount;
        }

        private void TurnAlarmOn()
        {
            _alarmOn = true;
            _alarmCount += 1;
        }
    }
}

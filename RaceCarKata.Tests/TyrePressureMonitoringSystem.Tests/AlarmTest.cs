
using NSubstitute;
using NUnit.Framework;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AlarmTest
    {
        [Test]
        public void GivenATyrePressureBelowMinimumThreshold_WhenCheckIsCalled_AlarmCountIncreases()
        {
            // Given
            var mockSensor = Substitute.For<ISensor>();
            var alarm = new Alarm(mockSensor);

            mockSensor.PopNextPressurePsiValue().Returns(12);
            
            // When 
            alarm.Check();

            // Then 
            Assert.AreEqual(1, alarm.GetAlarmCount());
        }
        
        [Test]
        public void GivenATyrePressureAboveMaximumThreshold_WhenCheckIsCalled_AlarmCountIncreases()
        {
            // Given
            var mockSensor = Substitute.For<ISensor>();
            var alarm = new Alarm(mockSensor);

            mockSensor.PopNextPressurePsiValue().Returns(22);
            
            // When 
            alarm.Check();

            // Then 
            Assert.AreEqual(1, alarm.GetAlarmCount());
        }
        
        
    }
}
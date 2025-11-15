using System.Collections.Generic;
using LibreHardwareMonitor.Hardware;
using _1115_HWINFO.Core.Model;


namespace _1115_HWINFO.Core.Provider
{
    public class SensorProvider
    {
        private readonly Computer _computer;
        private readonly UpdateVisitor _updateVisitor;


        public SensorProvider()
        {
            _computer = new Computer
            {
                IsCpuEnabled = true ,
                IsGpuEnabled = true ,
                IsMemoryEnabled = true ,
                IsMotherboardEnabled = true ,
                IsStorageEnabled = true
            };

            _computer.Open();
            _updateVisitor = new UpdateVisitor();
        }

        public List<SensorValue_model> GetCurrentSensorValues()
        {
            var list_result = new List<SensorValue_model>();

            // 먼저 전체 하드웨어/서브하드웨어를 업데이트
            _computer.Accept(_updateVisitor);

            // 그 다음 센서 읽기
            foreach ( var hardware in _computer.Hardware )
            {
                CollectSensorsRecursive(hardware , list_result);
            }

            return list_result;
        }

        private void CollectSensorsRecursive(IHardware hardware , List<SensorValue_model> list_result)
        {
            var hardwareName = hardware.Name;
            var hardwareType = hardware.HardwareType.ToString();

            foreach ( var sensor in hardware.Sensors )
            {
                if ( sensor.SensorType != SensorType.Temperature &&
                    sensor.SensorType != SensorType.Load &&
                    sensor.SensorType != SensorType.Fan )
                {
                    continue;
                }

                var model = new SensorValue_model
                {
                    Name     = sensor.Name,
                    Hardware = $"{hardwareType} - {hardwareName}",
                    Type     = sensor.SensorType.ToString(),
                    Value    = sensor.Value,
                    Unit     = GetUnit(sensor.SensorType)
                };

                list_result.Add(model);
            }

            foreach ( var sub in hardware.SubHardware )
            {
                CollectSensorsRecursive(sub , list_result);
            }
        }

        private string GetUnit(SensorType sensorType)
        {
            switch ( sensorType )
            {
                case SensorType.Temperature: return "°C";
                case SensorType.Load: return "%";
                case SensorType.Fan: return "RPM";
                default: return "";
            }
        }

        public void Dispose()
        {
            _computer.Close();
        }
    }
    // 모든 하드웨어/서브하드웨어를 재귀적으로 Update 해주는 Visitor
    public class UpdateVisitor : IVisitor
    {
        public void VisitComputer(IComputer computer)
        {
            computer.Traverse(this);
        }

        public void VisitHardware(IHardware hardware)
        {
            hardware.Update();
            foreach ( var subHardware in hardware.SubHardware )
            {
                subHardware.Accept(this);
            }
        }

        public void VisitSensor(ISensor sensor) { }
        public void VisitParameter(IParameter parameter) { }
    }
}
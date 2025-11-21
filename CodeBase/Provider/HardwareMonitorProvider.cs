using LibreHardwareMonitor.Hardware;
using MyHwInfo.HWMonitor;

namespace MyHwInfo.CodeBase.Provider
{
    public interface IHardwareMonitorProvider
    {
        HardwareMonitorSnapshot_Model GetSnapShot();
    }

    public class HardwareMonitorProvider : IHardwareMonitorProvider, IDisposable
    {
        private readonly Computer _computer;

        public HardwareMonitorProvider()
        {
            _computer = new Computer
            {
                IsCpuEnabled = true ,
                IsGpuEnabled = true ,
                IsMotherboardEnabled = false ,
                IsMemoryEnabled = false ,
                IsControllerEnabled = false ,
                IsNetworkEnabled = false ,
                IsStorageEnabled = false
            };

            _computer.Open();
        }

        public HardwareMonitorSnapshot_Model GetSnapShot()
        {
            UpdateAllHardware();

            var tCpuInfo = BuildCpuInfo();
            var list_gpuInfos = BuildGpuInfos();

            return new HardwareMonitorSnapshot_Model
            {
                Cpu = tCpuInfo,
                list_Gpus = list_gpuInfos
            };
        }

        private void UpdateAllHardware()
        {
            foreach ( var tHardware in _computer.Hardware )
            {
                tHardware.Update();
                foreach ( var tSub in tHardware.SubHardware )
                {
                    tSub.Update();
                }
            }
        }

        #region CPU INFO
        private HardwareMonitor_model BuildCpuInfo()
        {
            var list_cpuHardwares = _computer.Hardware
                .Where(h => h.HardwareType == HardwareType.Cpu)
                .ToList();

            if ( list_cpuHardwares.Count == 0 )
            {
                return default;
            }

            string tName = list_cpuHardwares[0].Name;

            // 1) 온도 : Core 0 센서 하나만 사용
            //    보통 이름이 "Core #0" / "Core 0" 형태라서 문자열로 필터링
            var tCore0TempSensor = FindSingleSensor
            (
                list_cpuHardwares,
                SensorType.Temperature,
                nameContainsAny: new[] { "Core #0", "Core 0" }
            );


            // 2) 사용률 : "CPU Total" 또는 "Processor" 센서 하나만 사용
            var tProcessorLoadSensor = FindSingleSensor
            (
                list_cpuHardwares,
                SensorType.Load,
                // 머신에 따라 "CPU Total" 또는 "Processor" 등으로 나올 수 있으니
                // 우선순위 있게 검색
                nameContainsAny: new[] { "CPU Total", "Processor" }
            );

            // 3) 클럭 : 코어 클럭은 기존처럼 여러 센서 평균을 사용 (그대로 유지)
            var list_clockSensors = CollectSensors(list_cpuHardwares, SensorType.Clock);

            var tResult = new HardwareMonitor_model
            {
                Name = tName
            };

            // Core 0 온도 하나만 사용
            if ( tCore0TempSensor != null && tCore0TempSensor.Value.HasValue )
            {
                float tValue = tCore0TempSensor.Value.Value;
                tResult.AverageTemperatureC = tValue;
                tResult.MinTemperatureC = tCore0TempSensor.Min ?? tValue;
                tResult.MaxTemperatureC = tCore0TempSensor.Max ?? tValue;
            }

            // Processor(CPU 전체) 사용률 하나만 사용
            if ( tProcessorLoadSensor != null && tProcessorLoadSensor.Value.HasValue )
            {
                float tValue = tProcessorLoadSensor.Value.Value;
                tResult.AverageUsagePercent = tValue;
                tResult.MinUsagePercent = tProcessorLoadSensor.Min ?? tValue;
                tResult.MaxUsagePercent = tProcessorLoadSensor.Max ?? tValue;
            }

            // 클럭은 예전처럼 여러 센서 평균
            FillAverages(list_clockSensors ,
                out tResult.AverageClockMHz ,
                out tResult.MinClockMHz ,
                out tResult.MaxClockMHz);

            return tResult;
        }

        private static ISensor FindSingleSensor
        (
            IEnumerable<IHardware> list_hardwares ,
            SensorType sensorType ,
            string nameContains = null ,
            string[] nameContainsAny = null
        )
        {
            var list_sensors = new List<ISensor>();

            foreach ( var tHardware in list_hardwares )
            {
                foreach ( var tSensor in tHardware.Sensors )
                {
                    if ( tSensor.SensorType != sensorType || !tSensor.Value.HasValue )
                        continue;

                    list_sensors.Add(tSensor);
                }

                foreach ( var tSub in tHardware.SubHardware )
                {
                    foreach ( var tSensor in tSub.Sensors )
                    {
                        if ( tSensor.SensorType != sensorType || !tSensor.Value.HasValue )
                            continue;

                        list_sensors.Add(tSensor);
                    }
                }
            }

            if ( nameContainsAny != null && nameContainsAny.Length > 0 )
            {
                foreach ( var tKey in nameContainsAny )
                {
                    var tMatch = list_sensors.FirstOrDefault(s =>
                        s.Name.IndexOf(tKey, StringComparison.OrdinalIgnoreCase) >= 0);
                    if ( tMatch != null )
                        return tMatch;
                }
            }

            if ( !string.IsNullOrEmpty(nameContains) )
            {
                return list_sensors.FirstOrDefault(s =>
                    s.Name.IndexOf(nameContains , StringComparison.OrdinalIgnoreCase) >= 0);
            }

            // 조건이 없다면 첫 센서
            return list_sensors.FirstOrDefault();
        }
        #endregion

        #region GPU INFO
        // ----------------- 이하 GPU / 공통 로직은 그대로 -----------------

        private List<HardwareMonitor_model> BuildGpuInfos()
        {
            var list_gpuHardwares = _computer.Hardware
            .Where(h =>
                h.HardwareType == HardwareType.GpuNvidia ||
                h.HardwareType == HardwareType.GpuAmd ||
                h.HardwareType == HardwareType.GpuIntel)
            .ToList();

            var list_result = new List<HardwareMonitor_model>();

            foreach ( var tGpuHardware in list_gpuHardwares )
            {
                var tInfo = BuildSingleGpuInfo(tGpuHardware);
                list_result.Add(tInfo);
            }

            return list_result;
        }

        private HardwareMonitor_model BuildSingleGpuInfo(IHardware gpuHardware)
        {
            string tName = gpuHardware.Name;

            var list_tempSensors = CollectSensors(new[] { gpuHardware }, SensorType.Temperature);
            var list_loadSensors = CollectSensors(new[] { gpuHardware }, SensorType.Load);
            var list_clockSensors = CollectSensors(new[] { gpuHardware }, SensorType.Clock);

            var tResult = new HardwareMonitor_model
            {
                Name = tName
            };

            FillAverages(list_tempSensors ,
                out tResult.AverageTemperatureC ,
                out tResult.MinTemperatureC ,
                out tResult.MaxTemperatureC);

            FillAverages(list_loadSensors ,
                out tResult.AverageUsagePercent ,
                out tResult.MinUsagePercent ,
                out tResult.MaxUsagePercent);

            FillAverages(list_clockSensors ,
                out tResult.AverageClockMHz ,
                out tResult.MinClockMHz ,
                out tResult.MaxClockMHz);

            return tResult;
        }
        #endregion

        private static List<ISensor> CollectSensors(IEnumerable<IHardware> list_hardwares , SensorType sensorType)
        {
            var list_sensors = new List<ISensor>();

            foreach ( var tHardware in list_hardwares )
            {
                foreach ( var tSensor in tHardware.Sensors )
                {
                    if ( tSensor.SensorType == sensorType && tSensor.Value.HasValue )
                    {
                        list_sensors.Add(tSensor);
                    }
                }

                foreach ( var tSub in tHardware.SubHardware )
                {
                    foreach ( var tSensor in tSub.Sensors )
                    {
                        if ( tSensor.SensorType == sensorType && tSensor.Value.HasValue )
                        {
                            list_sensors.Add(tSensor);
                        }
                    }
                }
            }

            return list_sensors;
        }

        private static void FillAverages
        (
            List<ISensor> list_sensors ,
            out float avg ,
            out float min ,
            out float max
        )
        {
            if ( list_sensors == null || list_sensors.Count == 0 )
            {
                avg = 0f;
                min = 0f;
                max = 0f;
                return;
            }

            float tSum = 0f;
            float tMin = float.MaxValue;
            float tMax = float.MinValue;

            foreach ( var tSensor in list_sensors )
            {
                float tValue = tSensor.Value ?? 0f;
                tSum += tValue;

                if ( tSensor.Min.HasValue )
                {
                    float tMinValue = tSensor.Min.Value;
                    if ( tMinValue < tMin ) tMin = tMinValue;
                }

                if ( tSensor.Max.HasValue )
                {
                    float tMaxValue = tSensor.Max.Value;
                    if ( tMaxValue > tMax ) tMax = tMaxValue;
                }
            }

            avg = tSum / list_sensors.Count;

            if ( tMin == float.MaxValue ) tMin = avg;
            if ( tMax == float.MinValue ) tMax = avg;

            min = tMin;
            max = tMax;
        }

        public void Dispose()
        {
            _computer.Close();
        }

    }
}

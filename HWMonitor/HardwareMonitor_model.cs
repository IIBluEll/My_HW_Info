namespace MyHwInfo.HWMonitor
{
    public class HardwareMonitor_model
    {
        public string Name;
        public float AverageTemperatureC;
        public float MinTemperatureC;
        public float MaxTemperatureC;

        public float AverageUsagePercent;
        public float MinUsagePercent;
        public float MaxUsagePercent;

        public float AverageClockMHz;
        public float MinClockMHz;
        public float MaxClockMHz;
    }

    public struct HardwareMonitorSnapshot_Model
    {
        public HardwareMonitor_model Cpu;
        public List<HardwareMonitor_model> list_Gpus;
    }
}

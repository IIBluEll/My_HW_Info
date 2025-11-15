namespace _1115_HWINFO.Core.Model
{
    public class SystemInfo_model
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
    }

    public class CpuInfo_model
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int CoreCount { get; set; }
        public int LogicalProcessorCount { get; set; }
        public string MaxClockSpeed { get; set; }
    }

    public class GpuInfo_model
    {
        public string Name { get; set; }
        public string ChipType { get; set; }
        public string DriverVersion { get; set; }
    }

    public class MemoryInfo_model
    {
        public long TotalPhysicalMB { get; set; }
    }

    public class DiskInfo_model
    {
        public string Model { get; set; }
        public long GBSize { get; set; }
    }
}

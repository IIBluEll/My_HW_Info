using _1115_HWINFO.Core.Model;
using System.Management;

namespace _1115_HWINFO.Core.Provider
{
    public class HWInfoProvider
    {
        public SystemInfo_model GetSystemInfo()
        {
            var tResult = new SystemInfo_model();

            using ( var tSearcher = new ManagementObjectSearcher("SELECT Manufacturer, Model FROM Win32_ComputerSystem") )
            {
                foreach ( var tObj in tSearcher.Get() )
                {
                    tResult.Manufacturer = tObj[ "Manufacturer" ]?.ToString();
                    tResult.Model = tObj[ "Model" ]?.ToString();
                    break;
                }
            }

            return tResult;
        }


        public CpuInfo_model GetCpuInfo()
        {
            var tResult = new CpuInfo_model();

            using ( var tSearcher = new ManagementObjectSearcher("SELECT Name, Manufacturer, NumberOfCores, NumberOfLogicalProcessors, MaxClockSpeed FROM Win32_Processor") )
            {
                foreach ( var tObj in tSearcher.Get() )
                {
                    tResult.Name = tObj[ "Name" ]?.ToString();
                    tResult.Manufacturer = tObj[ "Manufacturer" ]?.ToString();

                    if ( int.TryParse(tObj[ "NumberOfCores" ]?.ToString() , out var tCores) )
                    {
                        tResult.CoreCount = tCores;
                    }

                    if ( int.TryParse(tObj[ "NumberOfLogicalProcessors" ]?.ToString() , out var tLogical) )
                    {
                        tResult.LogicalProcessorCount = tLogical;
                    }

                    if ( int.TryParse(tObj[ "MaxClockSpeed" ]?.ToString() , out var tClock) )
                    {
                        tResult.MaxClockSpeed = $"{tClock} MHz";
                    }

                    break; // 보통 CPU 1개 기준
                }
            }

            return tResult;
        }

        public List<GpuInfo_model> GetGpuInfos()
        {
            var list_result = new List<GpuInfo_model>();

            using ( var tSearcher = new ManagementObjectSearcher("SELECT Name, VideoProcessor, DriverVersion FROM Win32_VideoController") )
            {
                foreach ( var tObj in tSearcher.Get() )
                {
                    var tInfo = new GpuInfo_model
                    {
                        Name = tObj["Name"]?.ToString(),
                        ChipType = tObj["VideoProcessor"]?.ToString(),
                        DriverVersion = tObj["DriverVersion"]?.ToString()
                    };

                    list_result.Add(tInfo);
                }
            }

            return list_result;
        }

        public MemoryInfo_model GetMemoryInfo()
        {
            // 총 물리 메모리 용량 (MB 단위)
            long tTotalBytes = 0;

            using ( var tSearcher = new ManagementObjectSearcher("SELECT Capacity FROM Win32_PhysicalMemory") )
            {
                foreach ( var tObj in tSearcher.Get() )
                {
                    if ( long.TryParse(tObj[ "Capacity" ]?.ToString() , out var tCap) )
                    {
                        tTotalBytes += tCap;
                    }
                }
            }

            var tResult = new MemoryInfo_model
            {
                TotalPhysicalMB = tTotalBytes / (1024 * 1024)
            };

            return tResult;
        }

        public List<DiskInfo_model> GetDiskInfos()
        {
            var list_result = new List<DiskInfo_model>();

            using ( var tSearcher = new ManagementObjectSearcher("SELECT Model, Size FROM Win32_DiskDrive") )
            {
                foreach ( var tObj in tSearcher.Get() )
                {
                    var tInfo = new DiskInfo_model
                    {
                        Model = tObj["Model"]?.ToString()
                    };

                    if ( long.TryParse(tObj[ "Size" ]?.ToString() , out var tSizeBytes) )
                    {
                        tInfo.GBSize = tSizeBytes / ( 1024 * 1024 * 1024 );
                    }

                    list_result.Add(tInfo);
                }
            }

            return list_result;
        }
    }
}

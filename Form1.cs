using _1115_HWINFO.Core.Model;
using System.Text;

namespace _1115_HWINFO
{
    public partial class Form1 : Form
    {
        private HWInfoProvider _hwInfoProvider;

        public Form1()
        {
            InitializeComponent();

            _hwInfoProvider = new HWInfoProvider();

            LoadHardWareInfo();
        }

        private void LoadHardWareInfo()
        {
            var tSystemInfo = _hwInfoProvider.GetSystemInfo();
            var tCpuInfo = _hwInfoProvider.GetCpuInfo();
            var tMemoryInfo = _hwInfoProvider.GetMemoryInfo();
            var list_Gpu = _hwInfoProvider.GetGpuInfos();
            var list_Disk = _hwInfoProvider.GetDiskInfos();

            var tHwText = new StringBuilder();
            tHwText.AppendLine("=== System ===");
            tHwText.AppendLine($"Manufacturer : {tSystemInfo.Manufacturer}");
            tHwText.AppendLine($"Model        : {tSystemInfo.Model}");
            tHwText.AppendLine();
            tHwText.AppendLine("=== CPU ===");
            tHwText.AppendLine($"Name         : {tCpuInfo.Name}");
            tHwText.AppendLine($"Manufacturer : {tCpuInfo.Manufacturer}");
            tHwText.AppendLine($"Cores        : {tCpuInfo.CoreCount}");
            tHwText.AppendLine($"Logical      : {tCpuInfo.LogicalProcessorCount}");
            tHwText.AppendLine($"Max Clock    : {tCpuInfo.MaxClockSpeed}");
            tHwText.AppendLine();

            tHwText.AppendLine("=== Memory ===");
            tHwText.AppendLine($"Total RAM    : {tMemoryInfo.TotalPhysicalMB} MB");
            tHwText.AppendLine();

            tHwText.AppendLine("=== GPU ===");
            if ( list_Gpu.Count == 0 )

            {
                tHwText.AppendLine("No GPU detected");
            }
            else
            {
                for ( int tIndex = 0; tIndex < list_Gpu.Count; tIndex++ )
                {
                    var tGpu = list_Gpu[tIndex];
                    tHwText.AppendLine($"[GPU {tIndex}]");
                    tHwText.AppendLine($"  Name       : {tGpu.Name}");
                    tHwText.AppendLine($"  Chip       : {tGpu.ChipType}");
                    tHwText.AppendLine($"  Driver     : {tGpu.DriverVersion}");
                }
            }
            tHwText.AppendLine();
            tHwText.AppendLine("=== Disk ===");
            if ( list_Disk.Count == 0 )
            {
                tHwText.AppendLine("No Disk detected");
            }
            else
            {
                for ( int tIndex = 0; tIndex < list_Disk.Count; tIndex++ )
                {
                    var tDisk = list_Disk[tIndex];
                    tHwText.AppendLine($"[Disk {tIndex}]");
                    tHwText.AppendLine($"  Model      : {tDisk.Model}");
                    tHwText.AppendLine($"  Size       : {tDisk.GBSize} GB");
                }
            }

            HWInfoTextBox.Text = tHwText.ToString();
        }
    }
}

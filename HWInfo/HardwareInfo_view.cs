using MyHwInfo.CodeBase.Interface;

namespace MyHwInfo.HWInfo
{
    public partial class HardwareInfo_view : Form, IHardwareInfoView
    {
        public HardwareInfo_view()
        {
            InitializeComponent();
        }

        public void RenderCpuInfo(string cpuName , int coreCount , int threadCount)
        {
            cpuNameLabel.Text = cpuName; 
            cpuCoreLabel.Text = $"{coreCount} Cores / {threadCount} Threads";
        }

        public void RenderGpuInfo(string gpuName , string vramInfo)
        {
            gpuNameLabel.Text = gpuName;
            gpuVramLabel.Text = vramInfo;
        }
    }
}

using MyHwInfo.HWMonitor;

namespace MyHwInfo.CodeBase.Interface
{
    public interface IHardwareInfoView
    {
        void RenderCPU(HardwareMonitor_model cpuInfo);
        void RenderGPU(IReadOnlyList<HardwareMonitor_model> gpuInfos);
    }
}

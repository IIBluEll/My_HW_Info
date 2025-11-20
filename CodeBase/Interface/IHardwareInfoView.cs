namespace MyHwInfo.CodeBase.Interface
{
    public interface IHardwareInfoView
    {
        void RenderCpuInfo(string cpuName , int coreCount , int threadCount);
        void RenderGpuInfo(string gpuName , string vramInfo);
    }
}

using MyHwInfo.CodeBase.Interface;

namespace MyHwInfo.HWInfo
{
    public class HardwareInfo_presenter
    {
        private readonly IHardwareInfoView _view;

        public HardwareInfo_presenter(IHardwareInfoView hardwareInfoView)
        {
            _view = hardwareInfoView;
        }
    }
}

using MyHwInfo.CodeBase.Interface;
using MyHwInfo.CodeBase.Provider;

using Timer = System.Windows.Forms.Timer;

namespace MyHwInfo.HWMonitor
{
    public class HardwareMonitor_presenter
    {
        private readonly IHardwareInfoView _view;
        private readonly IHardwareMonitorProvider _provider;

        private readonly Timer _updateTimer;

        public HardwareMonitor_presenter(IHardwareInfoView hardwareInfoView, IHardwareMonitorProvider hardwareInfoProvider)
        {
            _view = hardwareInfoView;
            _provider = hardwareInfoProvider;

            _updateTimer = new Timer();
            _updateTimer.Interval = 500; // .5초
            _updateTimer.Tick += OnUpdateTimerTick;
            _updateTimer.Start();

            UpdateOnce();
        }

        private void OnUpdateTimerTick(object sender , EventArgs e)
        {
            UpdateOnce();
        }

        private void UpdateOnce()
        {
            try
            {
                HardwareMonitorSnapshot_Model tSnapshot = _provider.GetSnapShot();

                _view.RenderCPU(tSnapshot.Cpu);
                _view.RenderGPU(tSnapshot.list_Gpus);
            }
            catch ( Exception ex )
            {
                // 로깅 혹은 Debug 출력용, UI 예외는 삼가
                System.Diagnostics.Debug.WriteLine($"[HardwareInfoPresenter] Update error: {ex}");
            }
        }

        public void Dispose()
        {
            _updateTimer.Stop();
            _updateTimer.Tick -= OnUpdateTimerTick;
            _updateTimer.Dispose();
        }
    }
}

using MyHwInfo.CodeBase.Interface;
using MyHwInfo.CodeBase.Provider;
using MyHwInfo.HWMonitor;
using System.Windows.Forms;

namespace MyHwInfo.StartProgram
{
    public class Startup_presenter
    {
        private readonly IStartupView _view;

        private int _openedFormCount;
        public Startup_presenter(IStartupView view)
        {
            _view = view;
            _view.OnStartClicked += OnStartClick_Action;
        }

        private void OnStartClick_Action()
        {
            // 아무것도 선택 안되었을 때는 무시하거나 메시지 박스
            if ( !_view.IsHardwareMonitorChecked &&
                !_view.IsHardwareInfoChecked &&
                !_view.IsEventLogChecked )
            {
                MessageBox.Show("실행할 항목을 하나 이상 선택해 주세요." , "알림" ,
                    MessageBoxButtons.OK , MessageBoxIcon.Information);
                return;
            }

            if ( _view.IsHardwareMonitorChecked )
            {
                var tHardwareInfoView = new HardwareMonitor_view();
                var tProvider = new HardwareMonitorProvider();

                var tHardwareInfoPresenter = new HardwareMonitor_presenter (tHardwareInfoView,tProvider);

                tHardwareInfoView.FormClosed += OnChildFormClosed;

                _openedFormCount++;
                tHardwareInfoView.Show();
            }

            //if ( _view.IsHardwareInfoChecked )
            //{
            //    return;
            //}

            //if ( _view.IsEventLogChecked )
            //{
            //    var tEventLogView = new EventLogForm_view();
            //    var tEventLogPresenter = new EventLogPresenter_presenter(tEventLogView);
            //            _openedFormCount++;

            //    tEventLogView.Show();
            //}

            _view.HideWindow();
        }

        private void OnChildFormClosed(object sender , FormClosedEventArgs e)
        {
            _openedFormCount--;

            if ( _openedFormCount <= 0 )
            {
                // 더 이상 열려 있는 기능 폼이 없으면 전체 종료
                Application.Exit();
            }
        }
    }
}

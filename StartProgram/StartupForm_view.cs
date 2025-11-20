using MyHwInfo.CodeBase.Interface;

namespace MyHwInfo.StartProgram
{
    public partial class StartupForm_view : Form, IStartupView
    {
        public bool IsHardwareMonitorChecked => hardwareMonitorCheckBox.Checked;
        public bool IsHardwareInfoChecked => hardwareInfoCheckBox.Checked;
        public bool IsEventLogChecked => eventLogCheckBox.Checked;

        public event Action OnStartClicked;

        public StartupForm_view()
        {
            InitializeComponent();
            BindEvent();
        }

        private void BindEvent()
        {
            startBtn.Click += OnStartBtnClicked;
        }
       
        private void OnStartBtnClicked(object sender, EventArgs e)
        {
            OnStartClicked?.Invoke();
        }

        public void HideWindow()
        {
            Hide();
        }
    }
}

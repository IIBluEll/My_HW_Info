namespace MyHwInfo.CodeBase.Interface
{
    public interface IStartupView
    {
        bool IsHardwareMonitorChecked { get; }
        bool IsHardwareInfoChecked { get; }
        bool IsEventLogChecked { get; }

        event Action OnStartClicked;

        void HideWindow();
    }
}

using _1115_HWINFO.Core.Model;
using _1115_HWINFO.Core.Provider;
using System;
using System.Text;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace _1115_HWINFO
{
    public partial class Form1 : Form
    {
        private HWInfoProvider _hwInfoProvider;
        private SensorProvider _sensorProvider;
        private Timer _sensorTimer;

        public Form1()
        {
            InitializeComponent();

            _hwInfoProvider = new HWInfoProvider();
            _sensorProvider = new SensorProvider();

            LoadHardWareInfo();
            InitializeSensorListView();
            InitializeSensorTimer();
        }

        private void InitializeSensorListView()
        {
            sensorListView.Columns.Clear();
            sensorListView.Columns.Add("Hardware" , 200);
            sensorListView.Columns.Add("Name" , 200);
            sensorListView.Columns.Add("Type" , 100);
            sensorListView.Columns.Add("Value" , 100);
        }

        private void InitializeSensorTimer()
        {
            _sensorTimer = new Timer();
            _sensorTimer.Interval = 1000; // 1초마다 갱신
            _sensorTimer.Tick += OnSensorTimerTick;
            _sensorTimer.Start();
        }

        private void OnSensorTimerTick(object sender , EventArgs e)
        {
            List<SensorValue_model> tValues = _sensorProvider.GetCurrentSensorValues();

            sensorListView.BeginUpdate();
            sensorListView.Items.Clear();

            foreach ( var tSensor in tValues )
            {
                string tValueText = tSensor.Value.HasValue
                    ? $"{tSensor.Value.Value:F1} {tSensor.Unit}"
                    : "-";

                var tItem = new ListViewItem(new[]
                {
                    tSensor.Hardware,
                    tSensor.Name,
                    tSensor.Type,
                    tValueText
                });

                sensorListView.Items.Add(tItem);
            }

            sensorListView.EndUpdate();
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

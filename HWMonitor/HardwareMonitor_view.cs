using MyHwInfo.CodeBase.Interface;

namespace MyHwInfo.HWMonitor
{
    public partial class HardwareMonitor_view : Form, IHardwareInfoView
    {
        private (ListViewGroup Group, ListViewItem Temp, ListViewItem Usage, ListViewItem Clock)? _cpuRows;

        private readonly List<(ListViewGroup Group, ListViewItem Temp, ListViewItem Usage, ListViewItem Clock)>
            _list_gpuRows = new List<(ListViewGroup, ListViewItem, ListViewItem, ListViewItem)>();

        public HardwareMonitor_view()
        {
            InitializeComponent();
            InitializeListView();
        }

        private void InitializeListView()
        {
            hardwareListView.View = View.Details;
            hardwareListView.FullRowSelect = true;
            hardwareListView.GridLines = true;
            hardwareListView.HideSelection = false;

            if ( hardwareListView.Columns.Count == 0 )
            {
                hardwareListView.Columns.Add("Sensor" , 220 , HorizontalAlignment.Left);
                hardwareListView.Columns.Add("Value" , 100 , HorizontalAlignment.Right);
                hardwareListView.Columns.Add("Min" , 100 , HorizontalAlignment.Right);
                hardwareListView.Columns.Add("Max" , 100 , HorizontalAlignment.Right);
            }
        }

        private ListViewItem CreateItem(ListViewGroup group , string sensorName)
        {
            var tItem = new ListViewItem(sensorName);
            tItem.SubItems.Add(""); // Value
            tItem.SubItems.Add(""); // Min
            tItem.SubItems.Add(""); // Max

            tItem.Group = group;
            tItem.UseItemStyleForSubItems = false;

            hardwareListView.Items.Add(tItem);
            return tItem;
        }

        private void ApplyThresholdColor
        (
            ListViewItem item ,
            int subIndex ,
            float value ,
            float threshold
        )
        {
            if ( item == null )
            {
                return;
            }

            var tSub = item.SubItems[subIndex];

            if ( value >= threshold )
            {
                tSub.ForeColor = Color.Red;
            }
            else
            {
                tSub.ForeColor = SystemColors.WindowText;
            }
        }

        // ------------------------ IHardwareInfoView ------------------------

        public void RenderCPU(HardwareMonitor_model cpuInfo)
        {
            if ( _cpuRows == null )
            {
                var tCpuGroup = new ListViewGroup("CPU0", HorizontalAlignment.Left)
                {
                    Name = "CPU0Group"
                };
                hardwareListView.Groups.Add(tCpuGroup);

                var tTempItem  = CreateItem(tCpuGroup, "CPU Temperature");
                var tUsageItem = CreateItem(tCpuGroup, "CPU Utilization");
                var tClockItem = CreateItem(tCpuGroup, "CPU Clock");

                _cpuRows = (tCpuGroup, tTempItem, tUsageItem, tClockItem);
            }

            var tRow = _cpuRows.Value;

            tRow.Group.Header = $"{cpuInfo.Name}";

            tRow.Temp.SubItems[ 1 ].Text = $"{cpuInfo.AverageTemperatureC:F1} °C";
            tRow.Temp.SubItems[ 2 ].Text = $"{cpuInfo.MinTemperatureC:F1} °C";
            tRow.Temp.SubItems[ 3 ].Text = $"{cpuInfo.MaxTemperatureC:F1} °C";

            tRow.Usage.SubItems[ 1 ].Text = $"{cpuInfo.AverageUsagePercent:F1} %";
            tRow.Usage.SubItems[ 2 ].Text = $"{cpuInfo.MinUsagePercent:F1} %";
            tRow.Usage.SubItems[ 3 ].Text = $"{cpuInfo.MaxUsagePercent:F1} %";

            tRow.Clock.SubItems[ 1 ].Text = $"{cpuInfo.AverageClockMHz:F0} MHz";
            tRow.Clock.SubItems[ 2 ].Text = $"{cpuInfo.MinClockMHz:F0} MHz";
            tRow.Clock.SubItems[ 3 ].Text = $"{cpuInfo.MaxClockMHz:F0} MHz";

            ApplyThresholdColor(tRow.Temp , 1 , cpuInfo.AverageTemperatureC , 85f);
            ApplyThresholdColor(tRow.Usage , 1 , cpuInfo.AverageUsagePercent , 90f);
        }

        public void RenderGPU(IReadOnlyList<HardwareMonitor_model> gpuInfos)
        {
            while ( _list_gpuRows.Count < gpuInfos.Count )
            {
                int tIndex = _list_gpuRows.Count;

                var tGpuGroup = new ListViewGroup($"GPU{tIndex}", HorizontalAlignment.Left)
                {
                    Name = $"GPU{tIndex}Group"
                };
                hardwareListView.Groups.Add(tGpuGroup);

                var tTempItem  = CreateItem(tGpuGroup, $"GPU{tIndex} Temperature");
                var tUsageItem = CreateItem(tGpuGroup, $"GPU{tIndex} Utilization");
                var tClockItem = CreateItem(tGpuGroup, $"GPU{tIndex} Clock");

                _list_gpuRows.Add((tGpuGroup, tTempItem, tUsageItem, tClockItem));
            }

            for ( int tIndex = 0; tIndex < gpuInfos.Count; tIndex++ )
            {
                var tInfo = gpuInfos[tIndex];
                var tRow  = _list_gpuRows[tIndex];

                tRow.Group.Header = $"{tInfo.Name}";

                tRow.Temp.SubItems[ 1 ].Text = $"{tInfo.AverageTemperatureC:F1} °C";
                tRow.Temp.SubItems[ 2 ].Text = $"{tInfo.MinTemperatureC:F1} °C";
                tRow.Temp.SubItems[ 3 ].Text = $"{tInfo.MaxTemperatureC:F1} °C";

                tRow.Usage.SubItems[ 1 ].Text = $"{tInfo.AverageUsagePercent:F1} %";
                tRow.Usage.SubItems[ 2 ].Text = $"{tInfo.MinUsagePercent:F1} %";
                tRow.Usage.SubItems[ 3 ].Text = $"{tInfo.MaxUsagePercent:F1} %";

                tRow.Clock.SubItems[ 1 ].Text = $"{tInfo.AverageClockMHz:F0} MHz";
                tRow.Clock.SubItems[ 2 ].Text = $"{tInfo.MinClockMHz:F0} MHz";
                tRow.Clock.SubItems[ 3 ].Text = $"{tInfo.MaxClockMHz:F0} MHz";

                ApplyThresholdColor(tRow.Temp , 1 , tInfo.AverageTemperatureC , 85f);
                ApplyThresholdColor(tRow.Usage , 1 , tInfo.AverageUsagePercent , 90f);
            }
        }
    }
}

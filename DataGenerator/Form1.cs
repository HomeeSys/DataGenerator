using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
namespace DataGenerator;

public partial class Form1 : Form
{
    private BindingList<DeviceConfiguration> DeviceConfigurations;
    private BindingList<MeasurementFrequency> FrequenciesConfiguration;

    private static string ApplicationName = "Measurements generator";
    private static string ApplicationDirectory = Directory.GetCurrentDirectory();
    private static string ApplicationOutputDir = Path.Combine([ApplicationDirectory, "Output"]);

    public Form1()
    {
        InitializeComponent();

        //  Initialize devices
        DeviceConfigurations = new BindingList<DeviceConfiguration>();
        DeviceConfiguration config = new DeviceConfiguration();
        config.Name = $"Device {1}";
        DeviceConfigurations.Add(config);

        //ComboBoxFrequency
        FrequenciesConfiguration = new BindingList<MeasurementFrequency>()
        {
            new MeasurementFrequency()
            {
                Name = "5 minutes",
                Duration = TimeSpan.FromMinutes(5)
            },
            new MeasurementFrequency()
            {
                Name = "15 minutes",
                Duration = TimeSpan.FromMinutes(15)
            },
            new MeasurementFrequency()
            {
                Name = "30 minutes",
                Duration = TimeSpan.FromMinutes(30)
            },
            new MeasurementFrequency()
            {
                Name = "60 minutes",
                Duration = TimeSpan.FromMinutes(60)
            },
            new MeasurementFrequency()
            {
                Name = "2 hours",
                Duration = TimeSpan.FromHours(2)
            },
            new MeasurementFrequency()
            {
                Name = "6 hours",
                Duration = TimeSpan.FromHours(6)
            },
            new MeasurementFrequency()
            {
                Name = "12 hours",
                Duration = TimeSpan.FromHours(12)
            },
            new MeasurementFrequency()
            {
                Name = "24 hours",
                Duration = TimeSpan.FromHours(24)
            },
        };
        ComboBoxFrequency.DataSource = FrequenciesConfiguration;
        ComboBoxFrequency.DisplayMember = "Name";
        ComboBoxFrequency.SelectedValueChanged += ComboBoxFrequency_SelectedValueChanged;

        TextBoxDevicesAmount.Text = DeviceConfigurations.Count.ToString();

        TrackBarDevices.ValueChanged += TrackBarDevices_ValueChanged;

        CheckedListBoxConfigs.ItemCheck += CheckedListBoxConfigs_ItemCheck;

        DateTimePickerDateStart.Validating += ValidateSelectedDateTime;
        DateTimePickerTimeStart.Validating += ValidateSelectedDateTime;
        DateTimePickerDateEnd.Validating += ValidateSelectedDateTime;
        DateTimePickerTimeEnd.Validating += ValidateSelectedDateTime;

        DateTimePickerDateStart.ValueChanged += DateTimePickerDateStart_ValueChanged;
        DateTimePickerDateEnd.ValueChanged += DateTimePickerDateEnd_ValueChanged;
        DateTimePickerTimeStart.ValueChanged += DateTimePickerTimeStart_ValueChanged;
        DateTimePickerTimeEnd.ValueChanged += DateTimePickerTimeEnd_ValueChanged;

        ComboBoxDevices.DataSource = DeviceConfigurations;
        ComboBoxDevices.DisplayMember = "Name";
        ComboBoxDevices.SelectedValueChanged += ComboBoxDevices_SelectedValueChanged;
        ComboBoxDevices.SelectedIndex = 0;
        UpdateSelectedDeviceConfiguration();
    }

    private void DateTimePickerTimeEnd_ValueChanged(object? sender, EventArgs e)
    {
        DeviceConfiguration config = ComboBoxDevices.SelectedValue as DeviceConfiguration;
        if (config == null)
        {
            return;
        }

        config.EndDate = config.EndDate.Date + DateTimePickerTimeEnd.Value.TimeOfDay;

        RefreshEstimated();
    }

    private void DateTimePickerDateStart_ValueChanged(object? sender, EventArgs e)
    {
        DeviceConfiguration config = ComboBoxDevices.SelectedValue as DeviceConfiguration;
        if (config == null)
        {
            return;
        }

        config.StartDate = config.StartDate.Date + DateTimePickerDateStart.Value.TimeOfDay;

        RefreshEstimated();
    }

    private void DateTimePickerTimeStart_ValueChanged(object? sender, EventArgs e)
    {
        DeviceConfiguration config = ComboBoxDevices.SelectedValue as DeviceConfiguration;
        if (config == null)
        {
            return;
        }

        config.StartDate = config.StartDate.Date + DateTimePickerTimeStart.Value.TimeOfDay;

        RefreshEstimated();
    }

    private void DateTimePickerDateEnd_ValueChanged(object? sender, EventArgs e)
    {
        DeviceConfiguration config = ComboBoxDevices.SelectedValue as DeviceConfiguration;
        if (config == null)
        {
            return;
        }

        config.EndDate = config.EndDate.Date + DateTimePickerDateEnd.Value.TimeOfDay;

        RefreshEstimated();
    }

    private void ValidateSelectedDateTime(object? sender, CancelEventArgs e)
    {
        TimeSpan startTime = DateTimePickerTimeStart.Value.TimeOfDay;
        TimeSpan endTime = DateTimePickerTimeEnd.Value.TimeOfDay;

        DateTime startDate = DateTimePickerDateStart.Value.Date;
        DateTime endDate = DateTimePickerDateEnd.Value.Date;

        DateTime start = startDate + startTime;
        DateTime end = endDate + endTime;

        if (start >= end)
        {
            e.Cancel = true;
            MessageBox.Show("Starting date has to be earlier than ending date!", ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ComboBoxFrequency_SelectedValueChanged(object? sender, EventArgs e)
    {
        RefreshEstimated();
    }

    private void RefreshEstimated()
    {
        MeasurementFrequency freq = ComboBoxFrequency.SelectedValue as MeasurementFrequency;
        if (freq == null)
        {
            return;
        }

        DeviceConfiguration config = ComboBoxDevices.SelectedValue as DeviceConfiguration;
        if (config == null)
        {
            return;
        }

        config.Frequency = freq;

        TimeSpan span = config.EndDate - config.StartDate;

        int estiamted = (int)(span / freq.Duration);

        TextBoxEstimatedMeasurements.Text = estiamted.ToString();
    }

    private void CheckedListBoxConfigs_ItemCheck(object? sender, ItemCheckEventArgs e)
    {
        try
        {
            this.BeginInvoke(() =>
            {
                var item = CheckedListBoxConfigs.Items[e.Index] as MeasurementEntry;
                if (item != null)
                {
                    item.Included = CheckedListBoxConfigs.GetItemChecked(e.Index);
                }
            });
        }
        catch (Exception)
        {

        }
    }

    private void UpdateSelectedDeviceConfiguration()
    {
        TextBoxDeviceNumber.DataBindings.Clear();
        TextBoxDeviceNumber.DataBindings.Add(
            "Text",
            ComboBoxDevices,
            "SelectedItem.DeviceNumber",
            true,
            DataSourceUpdateMode.OnPropertyChanged
        );

        DateTimePickerDateStart.DataBindings.Clear();
        DateTimePickerDateStart.DataBindings.Add(
            "Value",
            ComboBoxDevices,
            "SelectedItem.StartDate",
            true,
            DataSourceUpdateMode.OnPropertyChanged
        );

        DateTimePickerTimeStart.DataBindings.Clear();
        DateTimePickerTimeStart.DataBindings.Add(
            "Value",
            ComboBoxDevices,
            "SelectedItem.StartDate",
            true,
            DataSourceUpdateMode.OnPropertyChanged
        );

        DateTimePickerDateEnd.DataBindings.Clear();
        DateTimePickerDateEnd.DataBindings.Add(
            "Value",
            ComboBoxDevices,
            "SelectedItem.EndDate",
            true,
            DataSourceUpdateMode.OnPropertyChanged
        );

        DateTimePickerTimeEnd.DataBindings.Clear();
        DateTimePickerTimeEnd.DataBindings.Add(
            "Value",
            ComboBoxDevices,
            "SelectedItem.EndDate",
            true,
            DataSourceUpdateMode.OnPropertyChanged
        );

        CheckedListBoxConfigs.Items.Clear();
        DeviceConfiguration selectedConfig = ComboBoxDevices?.SelectedItem as DeviceConfiguration;
        if (selectedConfig == null)
        {
            return;
        }

        foreach (var measurement in selectedConfig.Measurements)
        {
            CheckedListBoxConfigs.Items.Add(measurement, measurement.Included);
        }

        MeasurementFrequency found = FrequenciesConfiguration.FirstOrDefault(x => x.Name == selectedConfig.Frequency.Name);
        int index = FrequenciesConfiguration.IndexOf(found);

        ComboBoxFrequency.SelectedIndex = index;
    }

    private void ComboBoxDevices_SelectedValueChanged(object? sender, EventArgs e)
    {
        UpdateSelectedDeviceConfiguration();
    }

    private void TrackBarDevices_ValueChanged(object? sender, EventArgs e)
    {
        TrackBar tb = (TrackBar)sender;

        int newValue = tb.Value;
        int currValue = DeviceConfigurations.Count;
        int removedCount = Math.Abs(currValue - newValue);

        if (newValue < currValue)
        {
            //  Removed
            for (int i = removedCount - 1; i >= 0; i--)
            {
                DeviceConfigurations.RemoveAt(DeviceConfigurations.Count - 1);
            }
        }
        else
        {
            //  Added
            for (int i = removedCount - 1; i >= 0; i--)
            {
                DeviceConfiguration config = new DeviceConfiguration();
                config.Name = $"Device {DeviceConfigurations.Count + 1}";
                DeviceConfigurations.Add(config);
            }
        }

        TextBoxDevicesAmount.Text = DeviceConfigurations.Count.ToString();
    }

    private void ButtonGenerate_Click(object sender, EventArgs e)
    {
        if (!Directory.Exists(ApplicationOutputDir))
        {
            try
            {
                Directory.CreateDirectory(ApplicationOutputDir);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Failed to create output directory!", ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        if (Directory.Exists(ApplicationOutputDir))
        {
            try
            {
                foreach (string file in Directory.GetFiles(ApplicationOutputDir))
                {
                    File.Delete(file);
                }

                // Delete all subdirectories
                foreach (string dir in Directory.GetDirectories(ApplicationOutputDir))
                {
                    Directory.Delete(dir, true);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Failed to clear output directory!", ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        else
        {
            MessageBox.Show(this, "Failed to clear output directory!", ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            //  First step is to generate `.json` file with devices and their `DeviceNumber`s.
            var deviceNubers = DeviceConfigurations.Select(x => new { Name = x.Name, DeviceNumber = x.DeviceNumber }).ToList();

            string filePath = "DeviceNumbers.json";
            string fullPath = Path.Combine([ApplicationOutputDir, filePath]);
            string json = JsonSerializer.Serialize(deviceNubers, new JsonSerializerOptions { WriteIndented = true });

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            try
            {
                File.WriteAllText(fullPath, json);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Failed to generate device numbers!", ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  Generate measurement data.
            foreach (DeviceConfiguration deviceConfig in DeviceConfigurations)
            {
                List<MeasurementSet> measurementSets = new List<MeasurementSet>();
                TimeSpan ts = TimeSpan.Zero;
                DateTime newDate = deviceConfig.StartDate + ts;

                //  Untill full time is reached.
                while (newDate < deviceConfig.EndDate)
                {
                    //  Append basic info
                    MeasurementSet newSet = new MeasurementSet()
                    {
                        DeviceNumber = deviceConfig.DeviceNumber,
                        RegisterDate = newDate
                    };

                    //  Append info based on whether it is defined.
                    List<MeasurementEntry> mesConfigs = deviceConfig.Measurements.ToList();

                    //  Temperature
                    MeasurementEntry? tempEntry = mesConfigs.FirstOrDefault(x => x.Name == MeasurementEntry.Temperature);
                    if (tempEntry != null)
                    {
                        newSet.Temperature = tempEntry.ToMeasurement(Generator.GenerateTemperature());
                    }

                    // Humidity
                    MeasurementEntry? humidityEntry = mesConfigs.FirstOrDefault(x => x.Name == MeasurementEntry.Humidity);
                    if (humidityEntry != null)
                    {
                        newSet.Humidity = humidityEntry.ToMeasurement(Generator.GenerateHumidity());
                    }

                    // CO2
                    var co2Entry = mesConfigs.FirstOrDefault(x => x.Name == MeasurementEntry.CO2);
                    if (co2Entry != null)
                    {
                        newSet.CO2 = co2Entry.ToMeasurement(Generator.GenerateCO2());
                    }

                    // VOC
                    var vocEntry = mesConfigs.FirstOrDefault(x => x.Name == MeasurementEntry.VOC);
                    if (vocEntry != null)
                    {
                        newSet.VOC = vocEntry.ToMeasurement(Generator.GenerateVOC());
                    }

                    // PM1
                    var pm1Entry = mesConfigs.FirstOrDefault(x => x.Name == MeasurementEntry.ParticulateMatter1);
                    if (pm1Entry != null)
                    {
                        newSet.ParticulateMatter1 = pm1Entry.ToMeasurement(Generator.GeneratePM1());
                    }

                    // PM2.5
                    var pm25Entry = mesConfigs.FirstOrDefault(x => x.Name == MeasurementEntry.ParticulateMatter2_5);
                    if (pm25Entry != null)
                    {
                        newSet.ParticulateMatter2v5 = pm25Entry.ToMeasurement(Generator.GeneratePM2_5());
                    }

                    // PM10
                    var pm10Entry = mesConfigs.FirstOrDefault(x => x.Name == MeasurementEntry.ParticulateMatter10);
                    if (pm10Entry != null)
                    {
                        newSet.ParticulateMatter10 = pm10Entry.ToMeasurement(Generator.GeneratePM10());
                    }

                    // Formaldehyde
                    var formaldehydeEntry = mesConfigs.FirstOrDefault(x => x.Name == MeasurementEntry.Formaldehyde);
                    if (formaldehydeEntry != null)
                    {
                        newSet.Formaldehyde = formaldehydeEntry.ToMeasurement(Generator.GenerateFormaldehyde());
                    }

                    // CO
                    var coEntry = mesConfigs.FirstOrDefault(x => x.Name == MeasurementEntry.CO);
                    if (coEntry != null)
                    {
                        newSet.CO = coEntry.ToMeasurement(Generator.GenerateCO());
                    }

                    // O3
                    var o3Entry = mesConfigs.FirstOrDefault(x => x.Name == MeasurementEntry.O3);
                    if (o3Entry != null)
                    {
                        newSet.O3 = o3Entry.ToMeasurement(Generator.GenerateO3());
                    }

                    // Ammonia
                    var ammoniaEntry = mesConfigs.FirstOrDefault(x => x.Name == MeasurementEntry.Ammonia);
                    if (ammoniaEntry != null)
                    {
                        newSet.Ammonia = ammoniaEntry.ToMeasurement(Generator.GenerateAmmonia());
                    }

                    // Airflow
                    var airflowEntry = mesConfigs.FirstOrDefault(x => x.Name == MeasurementEntry.Airflow);
                    if (airflowEntry != null)
                    {
                        newSet.Airflow = airflowEntry.ToMeasurement(Generator.GenerateAirflow());
                    }

                    // Air Ionization
                    var ionEntry = mesConfigs.FirstOrDefault(x => x.Name == MeasurementEntry.AirIonizationLevel);
                    if (ionEntry != null)
                    {
                        newSet.AirIonizationLevel = ionEntry.ToMeasurement(Generator.GenerateAirIonizationLevel());
                    }

                    // O2
                    var o2Entry = mesConfigs.FirstOrDefault(x => x.Name == MeasurementEntry.O2);
                    if (o2Entry != null)
                    {
                        newSet.O2 = o2Entry.ToMeasurement(Generator.GenerateO2());
                    }

                    // Radon
                    var radonEntry = mesConfigs.FirstOrDefault(x => x.Name == MeasurementEntry.Radon);
                    if (radonEntry != null)
                    {
                        newSet.Radon = radonEntry.ToMeasurement(Generator.GenerateRadon());
                    }

                    // Illuminance
                    var illuminanceEntry = mesConfigs.FirstOrDefault(x => x.Name == MeasurementEntry.Illuminance);
                    if (illuminanceEntry != null)
                    {
                        newSet.Illuminance = illuminanceEntry.ToMeasurement(Generator.GenerateIlluminance());
                    }

                    // Sound Level
                    var soundEntry = mesConfigs.FirstOrDefault(x => x.Name == MeasurementEntry.SoundLevel);
                    if (soundEntry != null)
                    {
                        newSet.SoundLevel = soundEntry.ToMeasurement(Generator.GenerateSoundLevel());
                    }

                    measurementSets.Add(newSet);

                    //  Update date
                    ts += deviceConfig.Frequency.Duration;
                    newDate = deviceConfig.StartDate + ts;
                }

                //  Serialize data.
                string measurementsFile = $"Measurement - {deviceConfig.Name} - {deviceConfig.DeviceNumber}.json";
                string measFileFullPath = Path.Combine([ApplicationOutputDir, measurementsFile]);
                string measJson = JsonSerializer.Serialize(measurementSets, new JsonSerializerOptions { WriteIndented = true });

                if (File.Exists(measFileFullPath))
                {
                    File.Delete(measFileFullPath);
                }
                try
                {
                    File.WriteAllText(measFileFullPath, measJson);
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Failed to save measurement data!", ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show(this, "Measurement data was generated!", ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception)
        {
            MessageBox.Show(this, "Failed to generate devices!", ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ButtonApplyConfigToAll_Click(object sender, EventArgs e)
    {
        try
        {
            //  Get selected config
            DeviceConfiguration selectedConfig = ComboBoxDevices.SelectedItem as DeviceConfiguration;
            if (selectedConfig == null)
            {
                return;
            }

            foreach (DeviceConfiguration config in DeviceConfigurations)
            {
                config.StartDate = selectedConfig.StartDate;
                config.EndDate = selectedConfig.EndDate;
                config.Interval = selectedConfig.Interval;
                config.Frequency = selectedConfig.Frequency;

                for (int i = 0; i < config.Measurements.Count; i++)
                {
                    MeasurementEntry configsEntry = config.Measurements[i];
                    MeasurementEntry selectedEntry = selectedConfig.Measurements[i];

                    configsEntry.Included = selectedEntry.Included;
                }
            }

            MessageBox.Show(this, "Configurations synchronized!", ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception)
        {
            MessageBox.Show(this, "Failed to synchronize configurations!", ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CheckedListBoxConfigs_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void ButtonOutput_Click(object sender, EventArgs e)
    {
        if (!Directory.Exists(ApplicationOutputDir))
        {
            return;
        }

        Process.Start("explorer.exe", ApplicationOutputDir);
    }
}

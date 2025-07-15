using System.ComponentModel;

namespace DataGenerator;

internal class DeviceConfiguration
{
    public string Name { get; set; }
    public Guid DeviceNumber { get; set; } = Guid.NewGuid();
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TimeSpan Interval { get; set; } = TimeSpan.FromHours(1);
    public MeasurementFrequency Frequency { get; set; }
    public BindingList<MeasurementEntry> Measurements { get; set; }
    public DeviceConfiguration()
    {
        //  Ensue only yyyy-mm-dd-hh-mm-ss are taken into account.
        DateTime current = DateTime.Now;
        DateTime nonMs = new DateTime(current.Year, current.Month, current.Day, current.Hour, current.Minute, current.Second);
        StartDate = nonMs - TimeSpan.FromDays(1);
        EndDate = nonMs;

        Frequency = new MeasurementFrequency()
        {
            Name = "5 minutes",
            Duration = TimeSpan.FromMinutes(5)
        };

        Measurements = new BindingList<MeasurementEntry>()
        {
            new MeasurementEntry()
            {
                Name = "Temperature",
                Label = "Temperature",
                Unit = "°C"
            },
            new MeasurementEntry()
            {
                Name = "Humidity",
                Label = "Humidity",
                Unit = "% RH"
            },
            new MeasurementEntry()
            {
                Name = "CO2",
                Label = "Carbon dioxide",
                Unit = "ppm"
            },
            new MeasurementEntry()
            {
                Name = "VOC",
                Label = "Volatile organic compounds",
                Unit = "µg/m³"
            },
            new MeasurementEntry()
            {
                Name = "ParticulateMatter1",
                Label = "Particulate matter < 1[inch]",
                Unit = "µg/m³"
            },
            new MeasurementEntry()
            {
                Name = "ParticulateMatter2_5",
                Label = "Particulate matter < 2.5[inch]",
                Unit = "µg/m³"
            },
            new MeasurementEntry()
            {
                Name = "ParticulateMatter10",
                Label = "Particulate matter < 10[inch]",
                Unit = "µg/m³"
            },
            new MeasurementEntry()
            {
                Name = "Formaldehyde",
                Label = "Formaldehyde",
                Unit = "µg/m³"
            },
            new MeasurementEntry()
            {
                Name = "CO",
                Label = "Carbon monoxide",
                Unit = "ppm"
            },
            new MeasurementEntry()
            {
                Name = "O3",
                Label = "Ozone",
                Unit = "ppb"
            },
            new MeasurementEntry()
            {
                Name = "Ammonia",
                Label = "Ammonia",
                Unit = "mg/m³"
            },
            new MeasurementEntry()
            {
                Name = "Airflow",
                Label = "Airflow",
                Unit = "CFM"
            },
            new MeasurementEntry()
            {
                Name = "AirIonizationLevel",
                Label = "Air ionization level",
                Unit = "ions/cm³"
            },
            new MeasurementEntry()
            {
                Name = "O2",
                Label = "Oxygen",
                Unit = "%"
            },
            new MeasurementEntry()
            {
                Name = "Radon",
                Label = "Radon",
                Unit = "Bq/m³"
            },
            new MeasurementEntry()
            {
                Name = "Illuminance",
                Label = "Illuminance",
                Unit = "lux"
            },
            new MeasurementEntry()
            {
                Name = "SoundLevel",
                Label = "Sound level",
                Unit = "dB"
            },
        };
    }
}

namespace DataGenerator;

internal class MeasurementSet
{
    public Guid id { get; set; } = Guid.NewGuid();
    public Guid DeviceNumber { get; set; }
    public DateTime RegisterDate { get; set; }
    public Measurement? Temperature { get; set; } = default;
    public Measurement? Humidity { get; set; } = default;
    public Measurement? CO2 { get; set; } = default;
    public Measurement? VOC { get; set; } = default;
    public Measurement? ParticulateMatter1 { get; set; } = default;
    public Measurement? ParticulateMatter2v5 { get; set; } = default;
    public Measurement? ParticulateMatter10 { get; set; } = default;
    public Measurement? Formaldehyde { get; set; } = default;
    public Measurement? CO { get; set; } = default;
    public Measurement? O3 { get; set; } = default;
    public Measurement? Ammonia { get; set; } = default;
    public Measurement? Airflow { get; set; } = default;
    public Measurement? AirIonizationLevel { get; set; } = default;
    public Measurement? O2 { get; set; } = default;
    public Measurement? Radon { get; set; } = default;
    public Measurement? Illuminance { get; set; } = default;
    public Measurement? SoundLevel { get; set; } = default;
}

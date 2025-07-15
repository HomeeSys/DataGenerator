namespace DataGenerator;

internal class MeasurementEntry
{
    public int Id { get; set; }
    public string Label { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; }
    public bool Included { get; set; } = true;
    public override string ToString()
    {
        return Label;
    }

    public Measurement ToMeasurement(double value)
    {
        return new Measurement() { Value = value, Unit = Unit };
    }

    public static string Temperature = "Temperature";
    public static string Humidity = "Humidity";
    public static string CO2 = "CO2";
    public static string VOC = "VOC";
    public static string ParticulateMatter1 = "ParticulateMatter1";
    public static string ParticulateMatter2_5 = "ParticulateMatter2_5";
    public static string ParticulateMatter10 = "ParticulateMatter10";
    public static string Formaldehyde = "Formaldehyde";
    public static string CO = "CO";
    public static string O3 = "O3";
    public static string Ammonia = "Ammonia";
    public static string Airflow = "Airflow";
    public static string AirIonizationLevel = "AirIonizationLevel";
    public static string O2 = "O2";
    public static string Radon = "Radon";
    public static string Illuminance = "Illuminance";
    public static string SoundLevel = "SoundLevel";
}

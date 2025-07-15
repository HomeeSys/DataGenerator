namespace DataGenerator;

internal static class Generator
{
    private static readonly Random random = new();

    public static double GenerateTemperature() => RandomDouble(18, 26);

    public static double GenerateHumidity() => RandomDouble(30, 60);

    public static double GenerateCO2() => RandomDouble(400, 1000);

    public static double GenerateVOC() => RandomDouble(50, 300);

    public static double GeneratePM1() => RandomDouble(0, 15);

    public static double GeneratePM2_5() => RandomDouble(5, 25);

    public static double GeneratePM10() => RandomDouble(10, 50);

    public static double GenerateFormaldehyde() => RandomDouble(0.01, 0.1);

    public static double GenerateCO() => RandomDouble(0.1, 5);

    public static double GenerateO3() => RandomDouble(10, 50);

    public static double GenerateAmmonia() => RandomDouble(0.1, 3);

    public static double GenerateAirflow() => RandomDouble(20, 100);

    public static double GenerateAirIonizationLevel() => RandomDouble(5000, 50000);

    public static double GenerateO2() => RandomDouble(20, 21);

    public static double GenerateRadon() => RandomDouble(10, 100);

    public static double GenerateIlluminance() => RandomDouble(100, 800);

    public static double GenerateSoundLevel() => RandomDouble(30, 70);

    private static double RandomDouble(double min, double max)
    {
        return min + (random.NextDouble() * (max - min));
    }
}

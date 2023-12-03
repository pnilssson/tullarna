namespace TollFeeCalculator.Data;

public static class TollFreeDateData
{
    public static DateTime[] Dates()
    {
        return new[]
        {
            // Nyårsdagen
            new DateTime(2023, 1, 1),
            // Trettondedag jul
            new DateTime(2023, 1, 6),
            // Långfredagen
            new DateTime(2023, 4, 7),
            // Påskdagen
            new DateTime(2023, 4, 9),
            // Annandag påsk
            new DateTime(2023, 4, 10),
            // Första maj
            new DateTime(2023, 5, 1),
            // Kristi himmelfärdsdag
            new DateTime(2023, 5, 18),
            // Pingstdagen
            new DateTime(2023, 5, 28),
            // Sveriges nationaldag
            new DateTime(2023, 6, 6),
            // Midsommardagen
            new DateTime(2023, 6, 24),
            // Alla helgons dag
            new DateTime(2023, 11, 4),
            // Juldagen
            new DateTime(2023, 12, 25),
            // Annandag jul
            new DateTime(2023, 12, 26),
        };
    }

    public static int[] ValidYears => new[] { 2023 };
}
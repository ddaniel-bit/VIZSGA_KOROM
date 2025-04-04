using AutokConsole;
internal class Program
{
    private static void Main(string[] args)
    {
        List<Auto> autoklistaja = Auto.Beolvasas("../../../autok.csv");


        Console.WriteLine($"5. feladat: {autoklistaja.Count()}");
        Console.WriteLine($"6. feladat: {autoklistaja.Average(x=>x.Eladott_darabszam)}");
        List<Auto> elmult5ev = autoklistaja.Where(x => x.Gyartasi_ev >= 2020).ToList();
        Console.WriteLine("7. feladat: Az elmúlt 5 évben gyártott autók:");
        foreach (var item in elmult5ev)
        {
            Console.WriteLine($"    - {item.Marka} {item.Model}: {item.Gyartasi_ev}");
        }
        Console.WriteLine("8. feladat: Legsikeresebb márkák listája az eladott darabszám alapján:");
        var markaEladasok = autoklistaja
            .GroupBy(x => x.Marka)
            .Select(g => new { Marka = g.Key, OsszesEladas = g.Sum(a => a.Eladott_darabszam) })
            .OrderByDescending(x => x.OsszesEladas);

        foreach (var item in markaEladasok)
        {
            Console.WriteLine($"    - {item.Marka}: {item.OsszesEladas} darab");
        }
    }
}
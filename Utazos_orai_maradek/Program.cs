using _20221107Utazas;

Utazok utazok1 = new Utazok();
Utazok utazok2 = new Utazok("Pápa");
utazok1.Utazik("Pápa");
utazok2.Utazik("Budapest");
utazok2.Utazik("Piliscsaba");
utazok2.Utazik("Pilisvörösvár");
utazok2.Utazik("Pilisvörösvár");
utazok2.Utazik("Pilisvörösvár");
Console.WriteLine(utazok1.allomasok.Length);
Console.WriteLine(utazok2.allomasok.Length);
Console.WriteLine(utazok1.allomasok);
Console.WriteLine(utazok2.allomasok);

Console.WriteLine($"\n3. feladat: Járt-e a városban: {utazok2.JartE("London")}");
Console.WriteLine($"\n4. feladat: Hány helyen járt? --> {utazok2.HanyHelyenJart}");
Console.WriteLine($"\n5. feladat: Hol volt előbb? --> {utazok2.HolVoltElobb("Pápa", "Budapest")}");
Console.WriteLine("\n6. feladat: Ezeken a helyeken járt eddig:");
string[] ismnelk = utazok2.HelyekIsmetlesNelkul();
foreach (string item in ismnelk)
{
    Console.WriteLine(item);
}

Console.WriteLine("\n7. feladat: Ezeken a helyeken kárt eddig többször:");
string[] tobbszor = utazok2.HelyekAholTobbszorJart();
foreach (string item in tobbszor)
{
    Console.WriteLine(item);
}
using Kivetelek;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BankirendszerTesztek
{
    [TestFixture]
    public class BankSzamlaTeszt
    {
        BankSzamla szamla;        
        [SetUp]
        public void SetUp()
        {
            szamla = new BankSzamla(10, "Teszt Elek", 1000);            
        }
        [TestCase(10)]
        [TestCase(20)]
        public void TerhelesTeszt(int osszeg)
        {
            int maradandoOsszeg = szamla.AktualiEgyenleg - osszeg;
            szamla.Terhel(osszeg);
            Assert.That(szamla.AktualiEgyenleg, Is.EqualTo(maradandoOsszeg));
        }
        [TestCase(100000)]
        [TestCase(200000000)]
        [TestCase(30000000)]
        public void TerhelesTeszt_Throw(int terhelesOsszeg)
        {
            //szam = 3
            // (2) => szam - 1
            //() => fuggvenyszamitTesztelek, Elvarthiba
            Assert.That(() => szamla.Terhel(terhelesOsszeg), Throws.TypeOf<SzamlanNincsFedezetException>());
        }
        [Test]
        public void UjSzamlaNyitasaTesztEgyUgyfelHozzaadasSzamlakListahoz()
        {
            Bank tesztbank = new Bank();
            tesztbank.UjSzamlaNyitasa("Teszt1", 1000, 11);
            int i = tesztbank.Szamla.Count;
            Assert.That(i == 1, Is.True);
        }
        [TestCase("Teszt1", 1000, 0)]
        [TestCase("Teszt1", 0, 11)]
        [TestCase(null , 1000, 11)]
        [TestCase(null , 0, 0)]
        public void UjSzamlaNyitasTeszt_Throw(string tulaj, int nyitoOsszeg, int ID)
        {
            Bank tesztbank = new Bank();
            Assert.That(() => tesztbank.UjSzamlaNyitasa(tulaj, nyitoOsszeg, ID), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void BeszedesTesztUjugyfelLevonas()
        {
            Bank tesztbank = new Bank();
            tesztbank.UjSzamlaNyitasa("Teszt1", 1000, 11);
            Beszedes beszedteszteset = new Beszedes("NAV", "Teszt1", 500);
            tesztbank.CsoportosBeszedes(beszedteszteset);
            int levonasutan = tesztbank.Szamla[0].AktualiEgyenleg;
            Assert.That(levonasutan == 500, Is.True);
        }
    }
}
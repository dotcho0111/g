using NUnit.Framework;
using _20221220_Telefon;

namespace TelefonTeszt
{
    [TestFixture]
    public class TelefonTeszt
    {
        private Telefon telefontelefon;
        private Telefon telefontelefon2;
        [OneTimeSetUp]

        public void SetUp()
        {
            telefontelefon = new Telefon(707418529);
            telefontelefon2 = new Telefon(709638527);
        }

        [Test]
        public void EgyenlegFeltoltes()
        {
            telefontelefon.EgyenlegFeltoltes(500);
            Assert.That(telefontelefon.Egyenleg, Is.EqualTo(500));
        }

        [Test]
        public void HivasKezdemenyez()
        {
            Telefon telefontelefonTeszt1 = new Telefon(123);
            telefontelefonTeszt1.HivasKezdemenyez(709638527, telefontelefon2);
            Assert.That(telefontelefonTeszt1.Egyenleg, Is.EqualTo(-50));
            Assert.That(telefontelefonTeszt1.Hivasok.Count, Is.EqualTo(1));
        }

        [Test]
        public void HivasFogadas()
        {
            Telefon telefontelefonTeszt2 = new Telefon(123);
            Telefon telefontelefonTeszt3 = new Telefon(321);
            telefontelefonTeszt2.HivasKezdemenyez(321, telefontelefonTeszt3);
            Assert.That(telefontelefonTeszt3.Hivasok.Count, Is.EqualTo(1));
        }
    }
}
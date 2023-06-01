using ProgtetelekTesztelese;
using NUnit.Framework;
using System;

namespace ProgramozasiTetelekTest
{
    [TestFixture]
    public class ProgramozasiTetelekTest
    {
        ProgramozasiTetelek tomb;
        [SetUp]
        public void SetUP()
        {
            tomb = new ProgramozasiTetelek();
        }

        [TestCase(new int[] { 2, 4, 6 })]
        [TestCase(new int[] { 2, 2, 22, -2 })]
        public void VanETesztTrue(int[] tomb)
        {
            Assert.That(ProgramozasiTetelek.VanE(tomb, 2), Is.EqualTo(true));
        }

        [TestCase(new int[] { 2, 4, 6 })]
        [TestCase(new int[] { 2, 2, 22, -2 })]
        public void VanETesztFalse(int[] tomb)
        {
            Assert.That(ProgramozasiTetelek.VanE(tomb, 3), Is.EqualTo(false));
        }



        [TestCase(new int[] { 2, 2, 22, -2 })]
        public void OsszegzesTeszt(int[] tomb)
        {
            Assert.That(ProgramozasiTetelek.Osszegzes(tomb), Is.EqualTo(24));
        }



        [TestCase(new int[] { 2, 2, 22, -2 })]
        public void KivalasztasTeszt(int[] tomb)
        {
            Assert.That(ProgramozasiTetelek.Kivalasztas(tomb, 2), Is.EqualTo(0));
        }

        [TestCase(new int[] { 2, 2, 22, -2 })]
        public void KivalasztasTesztReturn_minus1(int[] tomb)
        {
            Assert.That(ProgramozasiTetelek.Kivalasztas(tomb, 3), Is.EqualTo(-1));
        }



        [TestCase(new int[] { 2, 2, 22, -2 })]
        public void MegszamolTesztparosVaneTrue(int[] tomb)
        {
            Assert.That(ProgramozasiTetelek.Megszamlalas(tomb), Is.EqualTo(4));
        }



        [TestCase(new int[] { 2, 2, 22, -2 })]
        public void MaxKivalasztas(int[] tomb)
        {
            Assert.That(ProgramozasiTetelek.Maxindex(tomb), Is.EqualTo(2));
        }



        [TestCase(new int[] { 2, 2, 22, -2 })]
        public void MinKivalasztas(int[] tomb)
        {
            Assert.That(ProgramozasiTetelek.Minindex(tomb), Is.EqualTo(3));
        }


        [TestCase(new int[] { 2, 2, 22, -2 })]
        public void KivalagotasTesztVan(int[] tomb)
        {
            int[] kimenet = new int[] { 2, 2, -2, 0 };
            Assert.That(ProgramozasiTetelek.Kivalagotas(tomb), Is.EqualTo(kimenet));
        }



        [TestCase(new int[] { 2, 2, 22, -2 })]
        public void BuborekNovekvo(int[] tomb)
        {
            int[] kimenet = new int[] { -2, 2, 2, 22 };
            Assert.That(ProgramozasiTetelek.Buborek(tomb), Is.EqualTo(kimenet));
        }

    }
}
using _20221221_Verem_Teszt;
using NUnit.Framework;

namespace VeremTeszt
{
    [TestFixture]
    public class VeremTeszt
    {
        Verem vermem;
        [SetUp]
        public void SetUP()
        {
            vermem = new Verem(1);
        }

        [Test]
        public void PushTest()
        {
            vermem.Push(1);
            int? elso = vermem.Veremelemek[0];
            Assert.That(elso, Is.EqualTo(1));
        }

        [Test]
        public void PushTest_Throw()
        {
            vermem.Push(1);
            Assert.That(() => vermem.Push(2), Throws.TypeOf<VeremMegteltKivetel>());
        }

        [Test]
        public void PopTest()
        {
            vermem.Push(1);
            vermem.Pop();
            Assert.That(vermem.Veremelemek[0], Is.EqualTo(null));
        }

        [Test]
        public void PopTest_Throw()
        {
            Assert.That(() => vermem.Pop(), Throws.TypeOf<VeremUresKivetel>());
        }
    }
}
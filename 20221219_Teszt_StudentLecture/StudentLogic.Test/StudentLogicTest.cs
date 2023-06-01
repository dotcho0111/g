using NUnit.Framework;
using StudentLogic.Model;

namespace StudentLogic.Test
{
    [TestFixture]
    public class StudentLogicTest
    {
        private StudentLogic studentLogic; //ez minden tesztnél kell | ezt nem lehet feloldani

        [OneTimeSetUp] //Logicnál mindig csak egyszer kell példányosítani

        public void SetUP()
        {
            studentLogic = new StudentLogic();
            studentLogic.AddStudent(new Student()
            {
                Name = "Test Person #0", //ez hibás adatnak számít
                StartYear = 2008
            }); //kézzel adom meg az adatoakt hogy melyik érték mire álljon be
            studentLogic.AddStudent(new Student()
            {
                Name = "Test Person #1", //ez hibás adatnak számít
                StartYear = 2016
            });
            studentLogic.AddStudent(new Student()
            {
                Name = "Test Person #2", //ez hibás adatnak számít
                StartYear = 2001
            });
        }

        [TestCase(3, "Person #3")] //3. helyre szurom be a tesztben a Person #3 nevű embert és igaz-e az allítás hogy ez a neve
        [TestCase(4, "Person #4")]
        public void AddStudentTest(int index, string studName)
        {
            studentLogic.AddStudent(new Student()
            {
                Name = studName
            });
            Assert.That(studentLogic.GetStudentByIndex(index).Name, Is.EqualTo(studName)); //<---- ez probléma lehet, ha rosszul van megírva, mert kettő függvényt tesztel
        }

        [Test]
        public void AddStudentTestNull_Throws()
        {
            Student tanulo = new Student();
            Assert.That(() => studentLogic.AddStudent(tanulo), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void AddStudentTestEmpty_Throws()
        {
            Student tanulo = new Student() { Name = "" };
            Assert.That(() => studentLogic.AddStudent(tanulo), Throws.TypeOf<Exception>());
        }




        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void GetStudentByIndex(int index)
        {
            var x = studentLogic.GetStudentByIndex(index);
            var y = studentLogic.GetStudentByIndex(index);
            Assert.That(x, Is.SameAs(y)); //azért SameAs mert objektumokat hasonlítunk | az első megegyezik-e önmagával
        }


        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)] //azt nézzük hibát hogyan dob el, ezért direkt rosszak az indexek
        public void RemoveStudentByIndex(int index)
        {
            Assert.That( //a nyilacska névtelen függvény, az utasítást egyszer lefuttatja, az utasítás érétékét eltárolja a ()-ben és azt lehet ellenőrizni
                () => studentLogic.RemoveStudentByIndex(index), Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        public void OrderStudents() //ez a comperto tesztje lesz
        {
            List<Student> copy = new List<Student>();
            foreach (var item in studentLogic.GetAll())
            {
                copy.Add(item);//átmásoltam a tanulókat egy másik listába                
            }
            copy.Sort();
            /*string v1 = copy[0].Name;
            string v2 = studentLogic.GetAll()[0].Name;
            ; Ez csak a teszt tesztje volt */
            Assert.That(copy[0].Name, Is.Not.EqualTo(studentLogic.GetAll()[0].Name));
        }

        [Test]
        public void CountSemesterTeszt()
        {
            var helper = new Student()
            {
                Name = "Gipsz Jakab",
                StartYear = 2019
            };
            Assert.That(helper.CountSemester(), Is.EqualTo((DateTime.Now.Year - 2019) * 2));
        }


        [Test]
        public void CreateInstanceFromStringTeszt_Throws()
        {
            var helper = new Student()
            {
                Name = "Gipsz Jakab",
                StartYear = 2019
            };
            Assert.That(() => helper.CreateInstanceFromString("#"), Throws.TypeOf<FormatException>());
        }


        [Test]
        public void CreateInstanceFromStringTeszt()
        {
            Student helper = new Student();            
            helper.CreateInstanceFromString("Neve%2010");
            Assert.That(helper.Name, Is.EqualTo("Neve"));            
            Assert.That(helper.StartYear, Is.EqualTo(2010));            
        }

        [Test]
        public void GetFirstCharacterTeszt()
        {
            var helper = new Student()
            {
                Name = "Macska Kaja",
                StartYear = 2019
            };
            Assert.That(helper.GetFirstCharacter, Is.EqualTo('M'));
        }

        [Test]
        public void GetAllTeszt()
        {
            List<Student> elvart = new List<Student>();
            foreach (var item in studentLogic.GetAll())
            {
                elvart.Add(item);//átmásoltam a tanulókat egy másik listába                
            }
            Assert.That(elvart, Is.EqualTo(studentLogic.GetAll()));
        }
    }
}
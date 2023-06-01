using NUnit.Framework;
using StudentLogic;
using StudentLogic.Model;
using System;

namespace LectureLogic.Test
{
    [TestFixture]
    public class LectureLogicTest
    {
        private ILectureLogic lectureLogic; //ennyi a dependency injection, feloldható függőség: bármelyik ponton a futás során bármikor létrehozható és feloldható
        [OneTimeSetUp] //osztályfüggés nem feloldható, az interfészfüggés igen (leegyszerűsítve)

        public void SetUp()
        {
            lectureLogic = new LectureLogic(); //megvalósítja az "I" interfészét
            lectureLogic.AddLecture(new Lecture()
                {
                Name = "Test Lecture #0",
                HoursPerSemester = 30,
                Credit = 3
            });
            lectureLogic.AddLecture(new Lecture()
            {
                Name = "Test Lecture #1",
                HoursPerSemester = 100,
                Credit = 10
            });
        }

        [TestCase(2, "Lecture #2")]
        [TestCase(3, "Lecture #3")]
        public void AddLectureTest(int index, string lectureName)
        {
            lectureLogic.AddLecture(new Lecture()
            {
                Name = lectureName
            });
            Assert.That(lectureLogic.GetLectureByID(index).Name, Is.EqualTo(lectureName));
        }

        [Test]
        public void AddStudentToLectureTest()
        {
            var helper = new Student()
            {
                Name = "Gipsz Jakab",
                StartYear = 2019
            };
            lectureLogic.GetLectureByID(1).Students.Add(helper);
            Assert.That(lectureLogic.GetLectureByID(1).Students.Contains(helper), Is.True);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void GetLectureByIDTeszt(int id)
        {
            var x = lectureLogic.GetLectureByID(id);
            var y = lectureLogic.GetLectureByID(id);
            Assert.That(x, Is.SameAs(y));
        }

        [Test]
        public void GetAllTeszt()
        {
            List<Lecture> elvart = new List<Lecture>();
            foreach (var item in lectureLogic.GetAll())
            {
                elvart.Add(item);//átmásoltam a tanulókat egy másik listába                
            }
            Assert.That(elvart, Is.EqualTo(lectureLogic.GetAll()));
        }

        [Test]
        public void LectureCountTeszt()
        {
            Assert.That(lectureLogic.LectureCount, Is.EqualTo(4));
        }
    }
}
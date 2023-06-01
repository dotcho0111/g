using StudentLogic.Model;

namespace LectureLogic
{
    public class Lecture
    {
        public string Name { get; set; }
        public int HoursPerSemester { get; set; }
        public int Credit { get; set; }
        public List<Student> Students { get; set; } // dotnet add reference !!! a student-hez

        public Lecture()
        {
            this.Students = new List<Student>();
        }
    }
    public interface ILectureLogic
    {
        int LectureCount { get; }
        List<Lecture> GetAll(); //lekéri az összes oktatót
        void AddLecture(Lecture lecture); //hozzáad egy oktatót
        Lecture GetLectureByID(int id);
        void AddStudentToLecture(Student student, int lectureID);
    }

    public class LectureLogic : ILectureLogic
    {
        private List<Lecture> lectures;
        public LectureLogic()
        {
            lectures = new List<Lecture>();
        }

        public int LectureCount //tesztelve
        {
            get
            {
                return this.lectures.Count;
            }
        }

        public void AddLecture(Lecture lecture) //tesztelve
        {
            lectures.Add(lecture);
        }

        public void AddStudentToLecture(Student student, int lectureID) //tesztelve
        {
            lectures[lectureID].Students.Add(student); //adott indexű oktatók kiválasztok és hozzáadom a diákot
        }

        public List<Lecture> GetAll() //tesztelve
        {
            return lectures;
        }

        public Lecture GetLectureByID(int id) //tesztelve
        {
            return lectures[id];
        }
    }
}
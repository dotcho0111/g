using StudentLogic.Model;

namespace StudentLogic
{
    public class StudentLogic //tanulokat tarol
    {
        private List<Student> students;
        public StudentLogic() //példányosít egy listát
        {
            this.students = new List<Student>(); //this: osztalyon beluli listára hivatkozunk. Ez egy rejett függőség ami nem jó, de most jó lesz.
        }

        public void AddStudent(Student student) //diákot ad hozzá //tesztelve
        {
            if (student.Name == null)
                throw new NullReferenceException("Error:: name was null!"); //ezt dobja ha üres a Name
            if (student.Name == "")
                throw new Exception("Error:: name was empty string!");
            this.students.Add(student);
        }

        public void RemoveStudentByIndex(int index) //diákot töröl index alapján //tesztelve
        {
            if (index < 0 || index >= this.students.Count)
                throw new IndexOutOfRangeException("Error:: index value was too big or too small!");
            this.students.RemoveAt(index);
        }

        public List<Student> GetAll() //visszaadja a diákokat //tesztelve
        {
            return this.students;
        }

        public Student GetStudentByIndex(int index) //visszadja az indexen lévő diákot //tesztelve
        {
            if (index < 0 || index >= this.students.Count)
            {
                throw new IndexOutOfRangeException("Error:: index value was too big or too small!");
            }   
            return this.students[index];
        }
    }
}
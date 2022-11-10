using StudentClass;

namespace SchoolchildClass
{
    public class Schoolchild : Students
    {
        public Schoolchild(string surname, int birthYear, string status, string institution, int classNum, int[] marks) : base(surname, birthYear, status, institution, marks)
        {
            this.classNum = classNum;
        }

        protected int classNum { get; set; }

        public override string GetInfo()
        {
            return $"{surname} {institution} {classNum} {status} {birthYear} {Intelligence()}";
        }

        public bool isHaveTwos()
        {
            int i = 0;
            bool oneTwos = false;
            while (i < marks.Length && marks[i] != 0)
            {
                if(marks[i] == 2 && oneTwos)
                {
                    return true;
                }
                else if(marks[i] == 2)
                {
                    oneTwos=true;
                }
                i++;
            }
            return false;
        }
    }
}
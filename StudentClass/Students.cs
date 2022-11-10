using HumanClass;

namespace StudentClass
{
    public class Students : Human
    {
        public Students(string surname, int birthYear, string status, string institution, int[] marks) : base(surname, birthYear, status)
        {
            this.institution = institution;
            this.marks = marks;
        }

        protected string institution { get; set; } = "";
        protected int[] marks { get; set; }

        public override string GetInfo()
        {
            throw new NotImplementedException();
        }

        public override double Intelligence()
        {
            int sum = 0, i = 0;
            foreach (var mark in marks)
            {
                if(mark == 0)
                {
                    break;
                }    
                sum += mark;
                i++;
            }
            double ans = sum / i;
            return ans;
        }
    }
}
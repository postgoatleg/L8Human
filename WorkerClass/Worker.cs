using HumanClass;

namespace WorkerClass
{
    public class Worker : Human, IComparable
    {
        public Worker(string surname, int birthYear, string status, string workPlace, int[] salary) : base(surname, birthYear, status)
        {
            this.salary = salary;
            this.workPlace = workPlace;
        }

        protected int[] salary { get; set; } = new int[12];
        protected string workPlace { get; set; }
        public int CompareTo(object? obj)
        {
            if (obj is Worker worker)
            {
                return surname.CompareTo(worker.surname);
            }
            else
            {
                throw new Exception("Can't compare two objects");
            }
        }

        public override string GetInfo()
        {
            return $"{surname} {status} {birthYear} {workPlace} {Intelligence()}";
        }

        public override double Intelligence()
        {
            int max = salary[0];
            for (int i = 1; i < salary.Length; i++)
            {
                if (max < salary[i])
                {
                    max = salary[i];
                }
            }
            return max;
        }
    }
}
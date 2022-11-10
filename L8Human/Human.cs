namespace HumanClass
{
    abstract public class Human
    {
        public Human(string surname, int birthYear, string status)
        {
            this.surname = surname;
            this.birthYear = birthYear;
            this.status = status;
        }
        public string surname { get; set; } = "";
        public int birthYear { get; set; }
        public string status { get; set; } = "";

        public abstract double Intelligence();
        public abstract string GetInfo();
    }
}
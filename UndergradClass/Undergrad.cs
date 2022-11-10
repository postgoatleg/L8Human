using StudentClass;

namespace UndergradClass
{
    public class Undergrad : Students
    {
        public Undergrad(string surname, int birthYear, string status, string institution, string groupName, int[] marks) : base(surname, birthYear, status, institution, marks)
        {
            this.groupName = groupName;
        }

        public string groupName { get; set; } = "";

        public override string GetInfo()
        {
            return $"{surname} {institution} {groupName} {status} {birthYear} {Intelligence()}";
        }
    }
}
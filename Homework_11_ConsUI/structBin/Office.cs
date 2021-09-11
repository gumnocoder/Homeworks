using Homework_11_ConsUI.employeBin;

namespace Homework_11_ConsUI.structBin
{
    class Office : WorkPlace
    {
        public Office(string Name)
        {
            this.Name = Name;
            Workers = new();
        }

        public override void Hire(Intern intern)
        {
            Workers.Add(intern);
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}

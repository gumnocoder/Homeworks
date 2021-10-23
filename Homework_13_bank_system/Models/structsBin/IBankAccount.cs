using Homework_13_bank_system.Models.personsBin;

namespace Homework_13_bank_system.Models.structsBin
{
    public interface IBankAccount<out T>
    {
        T Account { get; }
    }
}

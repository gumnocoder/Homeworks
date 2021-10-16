namespace Homework_13_bank_system.Models.personsBin
{
    interface IClient
    {
        /// <summary>
        /// значение рейтинга клиента в банке
        /// </summary>
        int Reputation { get; set; }

        /// <summary>
        /// повышение рейтинга в банке
        /// </summary>
        /// <param name="value"></param>
        public void IncreaseRep(int value) { }

        /// <summary>
        /// понижение рейтинга в банке
        /// </summary>
        /// <param name="value"></param>
        void DecreaseRep(int value) { }
    }
}

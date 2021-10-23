namespace Homework_13_bank_system.Models.structsBin
{
    /// <summary>
    /// Класс предназначеный дял иммитации временных отрезков
    /// </summary>
    public sealed class Timelapse
    {
        /// <summary>
        /// инстансный экземпляр машины времени
        /// </summary>
        static Timelapse timelapseInstance = null;

        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        private Timelapse() { monthCount = 1; }

        /// <summary>
        /// возвращает инстансный экземпляр
        /// </summary>
        public static Timelapse TimelapseInstance
        {
            get
            {
                if (timelapseInstance == null) timelapseInstance = new();
                return timelapseInstance;
            }
        }
        /// <summary>
        /// счетчик месяцев
        /// </summary>
        static int monthCount;

        /// <summary>
        /// счетчик месяцев
        /// </summary>
        public static int MonthCount
        {
            get => monthCount;
            set { monthCount++; if (MonthPropertyChanged != null) MonthPropertyChanged(); }
        }

        /// <summary>
        /// метод пропуска месяца
        /// </summary>
        public static void NextMonthTurn()
        {
            MonthCount++;
        }

        #region События

        public delegate void MonthPropertyChangedContainer();

        /// <summary>
        /// сигнализирует о наступлении следующего месяца
        /// </summary>
        public static event MonthPropertyChangedContainer MonthPropertyChanged;

        #pragma warning disable
        protected static void OnMonthPropertyChanged()
        {
            if (MonthPropertyChanged != null) MonthPropertyChanged();
        }

        #endregion
    }
}

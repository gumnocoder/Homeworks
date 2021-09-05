namespace Homework_10
{
    class MessageLog
    {
        /// <summary>
        /// время отправки
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// ID отправителя
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// Имя отправителя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Time">время отправки</param>
        /// <param name="Msg">Текст сообщения</param>
        /// <param name="FirstName">Имя отправителя
        /// </summary></param>
        /// <param name="Id">ID отправителя</param>
        public MessageLog(
            string Time, 
            string Msg, 
            string FirstName, 
            long Id)
        {
            this.Time = Time;
            this.Msg = Msg;
            this.FirstName = FirstName;
            this.Id = Id;
        }
    }
}

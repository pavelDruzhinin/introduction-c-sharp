namespace SaleProgresses.Domain
{
    public enum TaskType
    {
        /// <summary>
        /// Звонок
        /// </summary>
        Call,

        /// <summary>
        /// Встреча
        /// </summary>
        Appointment,

        /// <summary>
        /// Дистанционная встреча
        /// </summary>
        Demo,

        /// <summary>
        /// Коммерческое предложение
        /// </summary>
        CommercialRequest,

        /// <summary>
        /// Счет
        /// </summary>
        Invoice,

        /// <summary>
        /// Первичный контакт
        /// </summary>
        FirstContact
    }
}
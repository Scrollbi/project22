using project;

namespace project.Entities
{
    /// <summary>
    /// Сущность "Заявка"
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Номер заявки
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime AddedDate { get; set; }
        /// <summary>
        /// Вид авто
        /// </summary>
        public CarType CarType { get; set; }
        /// <summary>
        /// Модель авто
        /// </summary>
        public required string CarModel { get; set; }
        /// <summary>
        /// Описание проблемы
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// ФИО клиента
        /// </summary>
        public required string ClientLFP { get; set; }
        /// <summary>
        /// Номер телефона клиента
        /// </summary>
        public required string PhoneNumber { get; set; }
        /// <summary>
        /// Статус заявки
        /// </summary>
        public RequestStatus Status { get; set; }
        public string ResponsibleMechanic { get; set; }
    }
}

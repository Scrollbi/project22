using System.ComponentModel;

namespace project
{
    /// <summary>
    /// Вид автомобиля (классификация Европейской экономической комиссии)
    /// </summary>
    public enum CarType
    {
        /// <summary>
        /// Микроавтомобили
        /// </summary>
        [Description("Микроавтомобили")]
        MiniCar,
        /// <summary>
        /// Компактный класс
        /// </summary>
        [Description("Компактный класс")]
        SmallCar,
        /// <summary>
        /// "Гольф-класс"
        /// </summary>
        [Description("Гольф-класс")]
        MediumCar,
        /// <summary>
        /// Семейный класс
        /// </summary>
        [Description("Семейный класс")]
        LargerCar,
        /// <summary>
        /// Бизнес-класс
        /// </summary>
        [Description("Бизнес-класс")]
        ExecutiveCar,
        /// <summary>
        /// Представительский класс
        /// </summary>
        [Description("Представительский класс")]
        LuxuryCar,
        /// <summary>
        /// Внедорожники
        /// </summary>
        [Description("Внедорожники")]
        SUV,
        /// <summary>
        /// Минивэны и УПВ
        /// </summary>
        [Description("Минивэны и УПВ")]
        MPC,
        /// <summary>
        /// Спорткупе
        /// </summary>
        [Description("Спорткупе")]
        SportCoupe
    }
}

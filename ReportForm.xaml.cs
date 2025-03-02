using System.Collections.Generic;
using System.Windows;
using project.Entities;

namespace project
{
    public partial class ReportForm : Window
    {
        public ReportForm(List<Request> requests)
        {
            InitializeComponent();
            GenerateReport(requests);
        }

        private void GenerateReport(List<Request> requests)
        {
            if (requests.Count == 0) return;

            var request = requests[0];
            string report = "Отчет о заявке:\n\n" +
                            $"Заявка №{request.Number}\n" +
                            $"Клиент: {request.ClientLFP}\n" +
                            $"Статус: {request.Status.GetDescription()}\n" +
                            $"Описание: {request.Description}\n" +
                            $"Модель автомобиля: {request.CarModel}\n" +
                            $"Тип автомобиля: {request.CarType.GetDescription()}\n" +
                            $"Дата добавления: {request.AddedDate}\n" +
                            $"Ответственный механик: {(string.IsNullOrEmpty(request.ResponsibleMechanic) ? "Не назначен" : request.ResponsibleMechanic)}\n" +
                            $"Телефон: {request.PhoneNumber}\n";

            
            if (request.SpareParts.Count > 0)
            {
                report += $"Запчасти:\n- " + string.Join("\n- ", request.SpareParts) + "\n";
            }
            else
            {
                report += "Запчасти: Нет\n";
            }

            report += "-------------------------------\n";

            reportTextBox.Text = report;
        }
    }
}

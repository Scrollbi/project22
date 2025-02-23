using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using project.Entities;

namespace project
{
    public partial class MainWindow : Window
    {
        private ApplicationContext _context;
        private List<Request> _requests; 

        public MainWindow()
        {
            InitializeComponent();
            _context = new ApplicationContext();
            LoadRequests();
        }

        private void LoadRequests()
        {
            _requests = _context.Requests.ToList(); 
            dataGrid.ItemsSource = _requests.Select(r => new
            {
                r.Number,
                r.AddedDate,
                r.CarType,
                r.CarModel,
                r.Description,
                r.ClientLFP,
                r.PhoneNumber,
                Status = r.Status.ToString(),
                ResponsibleMechanic = string.IsNullOrEmpty(r.ResponsibleMechanic) ? "Не назначен" : r.ResponsibleMechanic 
            }).ToList(); 
        }


        private void buttonAdd_Click_1(object sender, RoutedEventArgs e)
        {
            var requestForm = new AddRequestForm(_context); 
            if (requestForm.ShowDialog() == true) 
            {
                LoadRequests(); 
            }
        }

        private void buttonEdit_Click_1(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                var selectedRow = dataGrid.SelectedItem;
                var selectedRequest = _requests.FirstOrDefault(r => r.Number == ((dynamic)selectedRow).Number); 
                if (selectedRequest != null)
                {
                    var requestForm = new RequestForm(_context, selectedRequest); 
                    if (requestForm.ShowDialog() == true) 
                    {
                        LoadRequests(); // Перезагружаем данные
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для редактирования."); 
            }
        }

    }
}

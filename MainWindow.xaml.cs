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
            _context.RequestStatusChanged += Context_RequestStatusChanged; 
            LoadRequests();
        }

        private void Context_RequestStatusChanged(object sender, RequestStatusChangedEventArgs e)
        {
            MessageBox.Show($"Статус заявки {e.Request.Number} изменен на {e.NewStatus.GetDescription()}");
            LoadRequests(); 
        }

        private void LoadRequests()
        {
            _requests = _context.Requests.ToList();
            FilterRequests(string.Empty); 
        }

        private void FilterRequests(string searchQuery)
        {
            var filteredRequests = _requests.Where(r =>
                r.Number.ToString().Contains(searchQuery) ||
                (r.ClientLFP?.ToLower().Contains(searchQuery) ?? false) ||
                (r.Description?.ToLower().Contains(searchQuery) ?? false) ||
                (r.CarModel?.ToLower().Contains(searchQuery) ?? false) ||
                (r.CarType.GetDescription().ToLower().Contains(searchQuery))).ToList();

            dataGrid.ItemsSource = filteredRequests.Select(r => new
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
                    requestForm.RequestStatusChanged += (s, args) => LoadRequests(); 

                    if (requestForm.ShowDialog() == true)
                    {
                        MessageBox.Show($"Статус заявки {selectedRequest.Number} изменен на {selectedRequest.Status.GetDescription()}");
                        LoadRequests(); 
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для редактирования.");
            }
        }

        private void Button_search_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = textBoxSearch.Text.ToLower(); 
            FilterRequests(searchQuery); 
        }
    }
}
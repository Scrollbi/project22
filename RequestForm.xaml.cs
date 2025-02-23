using System.Linq;
using System.Windows;
using project.Entities;

namespace project
{
    public partial class RequestForm : Window
    {
        private ApplicationContext _context;
        private Request _request;

        public RequestForm(ApplicationContext context, Request request)
        {
            InitializeComponent();
            _context = context;
            _request = request; 
            InitializeFields();
        }

        private void InitializeFields()
        {
            comboBoxStatus.ItemsSource = EnumExtensions.GetEnumValues<RequestStatus>()
                .Select(status => new RequestStatusItem
                {
                    Status = status,
                    Description = status.GetDescription() 
                })
                .ToList();

            // Устанавливаем текущий статус
            comboBoxStatus.SelectedItem = comboBoxStatus.Items
                .Cast<RequestStatusItem>()
                .FirstOrDefault(item => item.Status == _request.Status);

            textBoxDescription.Text = _request.Description; 
            textBoxMechanic.Text = _request.ResponsibleMechanic; 
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxStatus.SelectedItem is RequestStatusItem selectedStatus)
            {
                _request.Status = selectedStatus.Status; 
            }
            else
            {
                MessageBox.Show("Выберите корректный статус."); 
                return;
            }

            _request.Description = textBoxDescription.Text;
            _request.ResponsibleMechanic = textBoxMechanic.Text; 

            DialogResult = true; 
            Close(); 
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; 
            Close(); 
        }
    }
}

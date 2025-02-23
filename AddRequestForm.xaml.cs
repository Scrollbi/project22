using System;
using System.Windows;
using project.Entities;

namespace project
{
    public partial class AddRequestForm : Window
    {
        private ApplicationContext _context;

        public AddRequestForm(ApplicationContext context)
        {
            InitializeComponent();
            _context = context;
            DataContext = this;
            LoadCarTypes();
            LoadRequestStatuses();
        }

        private void LoadRequestStatuses()
        {
            var requestStatuses = EnumExtensions.GetEnumValues<RequestStatus>()
                                           .Select(status => new RequestStatusItem
                                           {
                                               Status = status,
                                               Description = status.GetDescription()
                                           })
                                           .ToList();
            ComboBoxStatus.ItemsSource = requestStatuses;
        }

        private void LoadCarTypes()
        {
            var carTypes = EnumExtensions.GetEnumValues<CarType>()
                                          .Select(type => new CarTypeItem
                                          {
                                              Type = type,
                                              Description = type.GetDescription()
                                          })
                                          .ToList();
            ComboBoxCarType.ItemsSource = carTypes;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxNumber.Text) ||
                string.IsNullOrWhiteSpace(TextBoxCarModel.Text) ||
                string.IsNullOrWhiteSpace(TextBoxClientLFP.Text) ||
                string.IsNullOrWhiteSpace(TextBoxPhoneNumber.Text) ||
                ComboBoxCarType.SelectedItem == null ||
                DatePickerAddedDate.SelectedDate == null)
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var request = new Request
                {
                    Number = int.Parse(TextBoxNumber.Text),
                    AddedDate = DatePickerAddedDate.SelectedDate.Value,
                    CarType = ((CarTypeItem)ComboBoxCarType.SelectedItem).Type,
                    CarModel = TextBoxCarModel.Text,
                    Description = TextBoxDescription.Text,
                    ClientLFP = TextBoxClientLFP.Text,
                    PhoneNumber = TextBoxPhoneNumber.Text,
                    Status = ((RequestStatusItem)ComboBoxStatus.SelectedItem).Status,
                };

                _context.AddRequest(request);
                DialogResult = true;
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Номер заявки должен быть числом.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}

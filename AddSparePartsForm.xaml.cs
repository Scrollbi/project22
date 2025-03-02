using System;
using System.Linq;
using System.Windows;
using project.Entities;

namespace project
{
    public partial class AddSparePartsForm : Window
    {
        private Request _request;

        public AddSparePartsForm(Request request)
        {
            InitializeComponent();
            _request = request;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            
            var parts = textBoxParts.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(p => p.Trim())
                                          .ToList();

           
            foreach (var part in parts)
            {
                if (!string.IsNullOrWhiteSpace(part))
                {
                    _request.SpareParts.Add(part);
                }
            }

            DialogResult = true; 
            Close();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; 
            Close();
        }
    }
}

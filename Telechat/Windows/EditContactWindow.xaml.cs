using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telechat.Core;
using static Telechat.Contact;

namespace Telechat.Windows
{
  /// <summary>
  /// Interaction logic for EditContactWindow.xaml
  /// </summary>
  public partial class EditContactWindow : Window
  {
    public MainWindow mainWindow;
    public EditContactWindow(MainWindow mainWindow)
    {
      InitializeComponent();
      this.mainWindow = mainWindow;
      DataContext = mainWindow.dataContext;

      statusComboBox.ItemsSource = Enum.GetValues(typeof(ContactStatus));
      statusComboBox.SelectedItem = mainWindow.dataContext.SelectedContact.Status;

    }

    private void uploadContactImage_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog op = new OpenFileDialog();
      op.Title = "Select a picture";
      op.Filter = "All supported graphics| *.jpg; *.jpeg; *.png | " +
        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
        "Portable Network Graphic (*.png)|*.png";
      if (op.ShowDialog() == true)
      {
        contactImage.Source = new BitmapImage(new Uri(op.FileName));
      }

    }

    private void UpdateContact_Click(object sender, RoutedEventArgs e)
    {
      if (statusComboBox.SelectedItem != null)
      {
        Contact.ContactStatus selectedStatus = (Contact.ContactStatus)statusComboBox.SelectedItem;
        mainWindow.dataContext.SelectedContact.Status = selectedStatus;
      }


      //Update contact
      mainWindow.dataContext.SelectedContact.Name = contactName.Text;
      mainWindow.dataContext.SelectedContact.Username = contactUsername.Text;
      mainWindow.dataContext.SelectedContact.ImageSource = contactImage.Source.ToString();


      // Update contact in chatitem
      for (int i = 0; i < mainWindow.dataContext.SelectedContact.Messages.Count; i++)
      {
        if (mainWindow.dataContext.SelectedContact.Messages[i].Name != mainWindow.dataContext.Profile.Name && mainWindow.dataContext.SelectedContact.Messages[i].ImageSource != mainWindow.dataContext.Profile.ImageSource && mainWindow.dataContext.SelectedContact.Messages[i].Username != mainWindow.dataContext.Profile.Username)
        {
          mainWindow.dataContext.SelectedContact.Messages[i].Name = contactName.Text;
          mainWindow.dataContext.SelectedContact.Messages[i].Username = contactUsername.Text;
          mainWindow.dataContext.SelectedContact.Messages[i].ImageSource = contactImage.Source.ToString();
        }
      }
    }
  }
}

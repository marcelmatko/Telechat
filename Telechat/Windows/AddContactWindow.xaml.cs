using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Telechat.ViewModel;
using static System.Net.Mime.MediaTypeNames;

namespace Telechat.Windows
{
  /// <summary>
  /// Interaction logic for AddContactWindow.xaml
  /// </summary>
  public partial class AddContactWindow : Window
  {


    public MainWindow mainWindow;

    public AddContactWindow(MainWindow mainWindow)
    {
      InitializeComponent();
      this.mainWindow = mainWindow;
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {

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

    private void NewContact_Click(object sender, RoutedEventArgs e)
    {

      Random random = new Random();
      int randomNumber = random.Next(0, 3);

      if (contactName.Text != null && contactUsername.Text != null && contactImage.Source != null)
      {
        mainWindow.dataContext.Contacts.Add(new Contact
        {
          Name = contactName.Text,
          Username = contactUsername.Text,
          ImageSource = contactImage.Source.ToString(),
          Status = (Contact.ContactStatus)randomNumber,
          Messages = new ObservableCollection<Message>(new List<Message>
                    {
                        new Message()
                        {
                            Name = contactName.Text,
                            Username = contactUsername.Text,
                            ImageSource = contactImage.Source.ToString(),
                            MessageContent = "Hey. Nice to meet you. This is my first message :)",
                            Time = DateTime.Now,
                            MsgPosition = Message.MessagePosition.Left,

                        },

                        new Message()
                        {
                            Name = mainWindow.dataContext.Profile.Name,
                            Username = mainWindow.dataContext.Profile.Username,
                            ImageSource = mainWindow.dataContext.Profile.ImageSource.ToString(),
                            MessageContent = "Wassup. Thanks for adding me and nice to meet you...",
                            Time = DateTime.Now,
                            MsgPosition = Message.MessagePosition.Right,
                        }

                    })
        });

        contactName.Text = String.Empty;
        contactUsername.Text = String.Empty;
        contactImage.Source = null;

      }
    }

  }
}

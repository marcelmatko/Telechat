using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Threading;
using System.Xml.Serialization;
using Telechat.Classes;
using Telechat.ViewModel;
using static Telechat.Classes.Profile;
using Path = System.IO.Path;

namespace Telechat
{
  /// <summary>
  /// Interaction logic for SettingsWindow.xaml
  /// </summary>
  public partial class SettingsWindow : Window
  {
    public MainWindow mainWindow;
    private DispatcherTimer timer = new DispatcherTimer();

    public SettingsWindow(MainWindow mainWindow)
    {
      InitializeComponent();
      this.mainWindow = mainWindow;
      DataContext = mainWindow.dataContext;

      statusComboBox.ItemsSource = Enum.GetValues(typeof(ContactStatus));
      statusComboBox.SelectedItem = mainWindow.dataContext.Profile.Status;

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
        profileImage.Source = new BitmapImage(new Uri(op.FileName));
      }
    }

    private void SaveChangesProfile_Click(object sender, RoutedEventArgs e)
    {

      if (statusComboBox.SelectedItem != null)
      {
        Profile.ContactStatus selectedStatus = (Profile.ContactStatus)statusComboBox.SelectedItem;
        mainWindow.dataContext.Profile.Status = selectedStatus;
      }

      mainWindow.dataContext.Profile.Name = profileName.Text;
      mainWindow.dataContext.Profile.Username = profileUsername.Text;
      mainWindow.dataContext.Profile.Email = profileEmail.Text;
      mainWindow.dataContext.Profile.AboutMe = profileAboutMe.Text;
      mainWindow.dataContext.Profile.ImageSource = profileImage.Source.ToString();

    }

    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
      int minutes;
      if (int.TryParse(minutesInput.Text, out minutes))
      {
        timer.Interval = TimeSpan.FromMinutes(minutes);
        timer.Tick += AutoSave;
        timer.Start();
      }

    }

    private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
    {
      timer.Stop();
    }

    private void AutoSave(object sender, EventArgs e)
    {
      string path = "../XML/exportedContacts.xml";
      var serializer = new XmlSerializer(typeof(ObservableCollection<Contact>));
      using (var writer = new StreamWriter(path))
      {
        serializer.Serialize(writer, mainWindow.dataContext.Contacts);
      }
    }
  }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using Telechat.Classes;
using Telechat.Core;
using Telechat.ViewModel;
using Telechat.Windows;

namespace Telechat
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    public DataContext dataContext;



    public MainWindow()
    {

      InitializeComponent();
      this.dataContext = new DataContext();
      this.DataContext = dataContext;
      LoadDataFromFile();

        }



    private void LoadDataFromFile()
    {
      string path = "../XML/exportedContacts.xml";
      XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Contact>));
      using (FileStream reader = new FileStream(path, FileMode.Open))
      {

        dataContext.Contacts = (ObservableCollection<Contact>)serializer.Deserialize(reader);
      }
    }



    private void DodajStik_btn(object sender, RoutedEventArgs e)
    {
      AddContactWindow addContactWindow = new AddContactWindow(this);
      addContactWindow.Show();

    }

    private void EditContact_btn(object sender, RoutedEventArgs e)
    {
      EditContactWindow editContactWindow = new EditContactWindow(this);
      editContactWindow.Show();
    }

    private void DeleteContact_btn(object sender, RoutedEventArgs e)
    {
      dataContext.Contacts.Remove(dataContext.SelectedContact);
            dataContext.Visibility = Visibility.Visible;
        }

    private void Import_btn(object sender, RoutedEventArgs e)
    {
      ImportWindow importWindow = new ImportWindow(this);
      importWindow.Show();
    }
    private void Export_btn(object sender, RoutedEventArgs e)
    {
      ExportWindow exportWindow = new ExportWindow(this);
      exportWindow.Show();
    }


    private void Exit_btn(object sender, RoutedEventArgs e)
    {
      System.Windows.Application.Current.Shutdown();
    }

    private void Nastavitve_Click(object sender, RoutedEventArgs e)
    {
      SettingsWindow settingsWindow = new SettingsWindow(this);
      settingsWindow.Show();
    }



    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Button_ShowMenu(object sender, RoutedEventArgs e)
    {

    }

    private async void Button_SendMessage(object sender, RoutedEventArgs e)
    {

            Random random = new Random();
            int randomNumber = random.Next(0, 10);

            if (dataContext.MessageContent != null && dataContext.MessageContent.Trim().Length > 0)
            {
                dataContext.SelectedContact.Messages.Add(new Message
                {
                    Name = dataContext.Profile.Name,
                    Username = dataContext.Profile.Username,
                    ImageSource = dataContext.Profile.ImageSource,
                    MessageContent = dataContext.MessageContent,
                    Time = DateTime.Now,
                    MsgPosition = Message.MessagePosition.Right
                });
                dataContext.MessageContent = null;




                await Task.Delay(1000);

                dataContext.SelectedContact.Messages.Add(new Message()
                {
                    Name = dataContext.SelectedContact.Name,
                    Username = dataContext.SelectedContact.Username,
                    ImageSource = dataContext.SelectedContact.ImageSource,
                    MessageContent = dataContext.dummyTexts[randomNumber],
                    Time = DateTime.Now,
                    MsgPosition = Message.MessagePosition.Left
                });
                dataContext.MessageContent = null;
            }

        }

    private void minimizeWindowBtn_Click(object sender, RoutedEventArgs e)
    {
      Application.Current.MainWindow.WindowState = WindowState.Minimized;
    }

    private void windowStateBtn_Click(object sender, RoutedEventArgs e)
    {
      if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
        Application.Current.MainWindow.WindowState = WindowState.Maximized;
      else
        Application.Current.MainWindow.WindowState = WindowState.Normal;
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if (e.LeftButton == MouseButtonState.Pressed)
        DragMove();
    }


    public Predicate<object> GetFilter()
    {
      return NameFilter;
    }

    private bool NameFilter(object obj)
    {
      var Filter_obj = obj as Contact;
      return Filter_obj.Name.ToLower().Contains(FilterSearch.Text.ToLower());
    }

    private void FilterSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (FilterSearch.Text == null)
      {
        ListContacts.Items.Filter = null;
      }
      else
      {
        ListContacts.Items.Filter = GetFilter();
                dataContext.Visibility = Visibility.Visible;
            }
    }
  }
}

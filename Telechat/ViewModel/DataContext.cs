using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using INotifyPropertyChanged = Telechat.Core.INotifyPropertyChanged;

namespace Telechat.ViewModel
{
  public class DataContext : INotifyPropertyChanged
  {


    public MainWindow mainWindow;

    private ObservableCollection<Contact> _contacts;
    private ObservableCollection<Message> _messages;

    public ObservableCollection<Contact> Contacts
    {
      get { return _contacts; }
      set
      {
        _contacts = value;
        OnPropertyChanged();
      }
    }


    public ObservableCollection<Message> Messages
    {

      get { return _messages; }
      set
      {
        _messages = value;
        OnPropertyChanged();
      }

    }

    public RelayCommand SendCommand { get; set; }

    private Contact _selectedContact;

    public Contact SelectedContact
    {

      get
      {
        return _selectedContact;

      }
      set
      {

        _selectedContact = value;
        Visibility = Visibility.Hidden;

        OnPropertyChanged();
      }




    }

    private string _messageContent;

    public string MessageContent
    {
      get { return _messageContent; }
      set
      {
        _messageContent = value;
        OnPropertyChanged();
      }
    }


    private Profile _profile;
    public Profile Profile
    {
      get { return _profile; }
      set
      {
        _profile = value;
        OnPropertyChanged();
      }
    }




    private Visibility visibility;
    public Visibility Visibility
    {
      get
      {
        return visibility;
      }
      set
      {
        visibility = value;
        OnPropertyChanged();
      }
    }

    // SIDEBAR
    private bool _isPanelVisible;
    private ICommand _showPanelCommand;
    private ICommand _hidePanelCommand;


    // Panel Visibility Property //
    public bool IsPanelVisible
    {
      get
      {
        return _isPanelVisible;
      }
      set
      {
        _isPanelVisible = value;
        OnPropertyChanged("IsPanelVisible");
      }
    }

    // Show Panel Method //
    public void ShowPanel()
    {
      IsPanelVisible = true;
    }

    // Show Panel Command //
    public ICommand ShowPanelCommand
    {
      get
      {
        if (_showPanelCommand == null)
        {
          _showPanelCommand = new RelayCommand(p => ShowPanel());
        }
        return _showPanelCommand;
      }
    }

    // Hide Panel Method //
    public void HidePanel()
    {
      IsPanelVisible = false;
    }

    // Hide Panel Command //
    public ICommand HidePanelCommand
    {
      get
      {
        if (_hidePanelCommand == null)
        {
          _hidePanelCommand = new RelayCommand(p => HidePanel());
        }
        return _hidePanelCommand;
      }
    }


    public List<string> dummyTexts;

    public DataContext()
    {



      IsPanelVisible = false; // SIDEBAR PANEL
      Messages = new ObservableCollection<Message>();
      Contacts = new ObservableCollection<Contact>();

      dummyTexts = new List<string>();


      dummyTexts.Add("Okay, sounds good!");
      dummyTexts.Add("Sorry, I can't talk right now.");
      dummyTexts.Add("I'll respond to you later.");
      dummyTexts.Add("Hey, what's up?");
      dummyTexts.Add("Hey, sorry for late reply");
      dummyTexts.Add("Thanks - just at work right now will check it out soon.");
      dummyTexts.Add("Hi mate, how’s things looking?");
      dummyTexts.Add("Hi mate, are we on track for tomorrow?");
      dummyTexts.Add("Sounds good, thanks");
      dummyTexts.Add("Sorry to disturb you");


      SendCommand = new RelayCommand(async o =>
      {

        Random random = new Random();
        int randomNumber = random.Next(0, 10);

        if (MessageContent != null && MessageContent.Trim().Length > 0)
        {
          SelectedContact.Messages.Add(new Message
          {
            Name = Profile.Name,
            Username = Profile.Username,
            ImageSource = Profile.ImageSource,
            MessageContent = MessageContent,
            Time = DateTime.Now,
            MsgPosition = Message.MessagePosition.Right
          });
          MessageContent = null;




          await Task.Delay(1000);

          SelectedContact.Messages.Add(new Message()
          {
            Name = SelectedContact.Name,
            Username = SelectedContact.Username,
            ImageSource = SelectedContact.ImageSource,
            MessageContent = dummyTexts[randomNumber],
            Time = DateTime.Now,
            MsgPosition = Message.MessagePosition.Left
          });
          MessageContent = null;
        }




      });

      Profile = new Profile
      {
        Name = "Mallow",
        Username = "@mallow#2312",
        Email = "matko518@gmail.com",
        ImageSource = "https://avatars.githubusercontent.com/u/24531357?v=4",
        AboutMe = "Nothing to find here.",
        Status = (Profile.ContactStatus)0

      };


    }

  }
}

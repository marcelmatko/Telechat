using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using System.Xml.Serialization;
using Telechat.Core;

namespace Telechat
{
  [Serializable()]
  public class Contact : INotifyPropertyChanged
  {
    private string _name;
    private string _username;
    private string _imagesource;
    private ObservableCollection<Message> _messages;


    public string Name
    {
      get { return _name; }
      set
      {
        _name = value;
        OnPropertyChanged();
      }
    }

    public string Username
    {
      get { return _username; }
      set
      {
        _username = value;
        OnPropertyChanged();
      }
    }

    public string ImageSource
    {
      get { return _imagesource; }
      set
      {
        _imagesource = value;
        OnPropertyChanged();
      }
    }

    [XmlArrayItem("Message", Type = typeof(Message))]
    public ObservableCollection<Message> Messages
    {
      get { return _messages; }
      set
      {
        _messages = value;
        OnPropertyChanged();
      }
    }

    private ContactStatus _contactStatus;
    public enum ContactStatus { Available, Away, DoNotDisturb }

    public ContactStatus Status
    {
      get { return _contactStatus; }
      set
      {
        _contactStatus = value;
        OnPropertyChanged();
      }
    }

    public string LastMessage => Messages.Last().MessageContent;


  }
}

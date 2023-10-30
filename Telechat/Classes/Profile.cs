using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Telechat.Core;

namespace Telechat.Classes
{
  public class Profile : INotifyPropertyChanged
  {

    private string _name;
    private string _username;
    private string _email;
    private string _aboutme;
    private string _imagesource;

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
    public string Email
    {
      get { return _email; }
      set
      {
        _email = value;
        OnPropertyChanged();
      }
    }
    public string AboutMe
    {
      get { return _aboutme; }
      set
      {
        _aboutme = value;
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


    public Profile()
    {

    }

    public Profile(string name, string username, string email, string aboutme, string imagesource)
    {
      this._name = name;
      this._username = username;
      this._email = email;
      this._aboutme = aboutme;
      this._imagesource = imagesource;

    }
  }
}

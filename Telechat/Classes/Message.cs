using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;
using Telechat.Core;

namespace Telechat
{
  [Serializable()]
  public class Message : Contact
  {

    private string _messagecontent;
    private DateTime _time;



    public string MessageContent
    {
      get { return _messagecontent; }
      set
      {
        _messagecontent = value;
        OnPropertyChanged();
      }
    }


    public DateTime Time
    {
      get { return _time; }
      set
      {
        _time = value;
        OnPropertyChanged();
      }
    }




    private MessagePosition _messagePosition;
    public enum MessagePosition { Left, Right }
    public MessagePosition MsgPosition
    {
      get { return _messagePosition; }
      set
      {
        _messagePosition = value;
        OnPropertyChanged();
      }
    }

  }
}

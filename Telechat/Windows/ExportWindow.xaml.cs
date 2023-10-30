using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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
using System.Xml.Linq;
using System.Xml.Serialization;
using Path = System.IO.Path;

namespace Telechat.Windows
{
  /// <summary>
  /// Interaction logic for ExportWindow.xaml
  /// </summary>


  public partial class ExportWindow : Window
  {
    public MainWindow mainWindow;
    public ExportWindow(MainWindow mainWindow)
    {
      InitializeComponent();
      this.mainWindow = mainWindow;

    }
    string path = "../XML/exportedContacts.xml";
    private void exportXML_btn(object sender, RoutedEventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "XML File |*.xml";
      saveFileDialog.Title = "Export Contacts";
      saveFileDialog.InitialDirectory = path;

      if (saveFileDialog.ShowDialog() == true)
      {
        var serializer = new XmlSerializer(typeof(ObservableCollection<Contact>));
        using (var writer = new StreamWriter(Path.Combine(path, saveFileDialog.FileName)))
        {
          serializer.Serialize(writer, mainWindow.dataContext.Contacts);
        }

      }




    }
  }
}

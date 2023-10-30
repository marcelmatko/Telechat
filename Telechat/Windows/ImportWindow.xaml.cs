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
using System.Xml.Serialization;

namespace Telechat.Windows
{
  /// <summary>
  /// Interaction logic for ImportWindow.xaml
  /// </summary>
  public partial class ImportWindow : Window
  {
    public MainWindow mainWindow;
    public ImportWindow(MainWindow mainWindow)
    {
      InitializeComponent();
      this.mainWindow = mainWindow;
    }

    private void importXML_btn(object sender, RoutedEventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "XML Files (*.xml)|*.xml";
      openFileDialog.FilterIndex = 0;
      openFileDialog.DefaultExt = "xml";


      if (openFileDialog.ShowDialog() == true)
      {

        XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Contact>));
        using (FileStream reader = new FileStream(openFileDialog.FileName, FileMode.Open))
        {

          mainWindow.dataContext.Contacts = (ObservableCollection<Contact>)serializer.Deserialize(reader);
        }
      }
    }
  }
}

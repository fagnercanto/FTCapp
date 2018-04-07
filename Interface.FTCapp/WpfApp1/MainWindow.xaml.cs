using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace WpfApp1
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var elementos = new[]{

                //new {    CDUNIDADEGESTORA= "270002",     CDGESTAO= "1",     NUEDITALLICITACAO= "000031",     ANOEDITALLICITACAO= "2018", 
//vNUMERODO="SIM-IGUAL", 
//vNUMERODO2="NAO-IGUAL",
//vNUMERODO3="SIM-MAIOR",
//vNUMERODO4="SIM-IGUAL",
//vCDUNIDADEGESTORA="SIM=READONLY",
//vCDUNIDADEGESTORA2="SIM-VISIVEL",
//vDTNOVASITUACAO="SIM-MAIOR",
//vDTNOVASITUACAO2="NAO-IGUAL",
//vNOVASITUACAO="SIM-CONTEM",
//vNUMERODOREPUBLICADO="SIM-ENTRE",
//vSITUACAOATUAL="SIM-CONTIDO" }



 new {    CDUNIDADEGESTORA= "270002",     CDGESTAO= "1",     NUEDITALLICITACAO= "000031",     ANOEDITALLICITACAO= "2018", 
vNUMERODO="2", 
vNUMERODO2="3",
vNUMERODO3="1",
vNUMERODO4="2",
vCDUNIDADEGESTORA="SIM=READONLY",
vCDUNIDADEGESTORA2="SIM-VISIVEL",
vDTNOVASITUACAO="H",
vDTNOVASITUACAO2="NAO-IGUAL",
vNOVASITUACAO="Edição",
vNUMERODOREPUBLICADO="1,20",
vSITUACAOATUAL="Em Edição, Aprovado" }

// new {    CDUNIDADEGESTORA= "270002",     CDGESTAO= "1",     NUEDITALLICITACAO= "000031",     ANOEDITALLICITACAO= "2018"  }
// ,
// new {    CDUNIDADEGESTORA= "270002",     CDGESTAO= "1",     NUEDITALLICITACAO= "000016",     ANOEDITALLICITACAO= "2018"  }
//,
// new {    CDUNIDADEGESTORA= "270002",     CDGESTAO= "1",     NUEDITALLICITACAO= "000042",     ANOEDITALLICITACAO= "2018"  },
// new {    CDUNIDADEGESTORA= "270002",     CDGESTAO= "1",     NUEDITALLICITACAO= "000045",     ANOEDITALLICITACAO= "2018"  },
//new  {    CDUNIDADEGESTORA= "270002",     CDGESTAO= "1",     NUEDITALLICITACAO= "000048",     ANOEDITALLICITACAO= "2018"  },
//new  {    CDUNIDADEGESTORA= "270002",     CDGESTAO= "1",     NUEDITALLICITACAO= "000003",     ANOEDITALLICITACAO= "2018"  },
//new  {    CDUNIDADEGESTORA= "270002",     CDGESTAO= "1",     NUEDITALLICITACAO= "000049",     ANOEDITALLICITACAO= "2018"  },
//new  {    CDUNIDADEGESTORA= "270002",     CDGESTAO= "1",     NUEDITALLICITACAO= "000007",     ANOEDITALLICITACAO= "2018"  },
//new  {    CDUNIDADEGESTORA= "270002",     CDGESTAO= "1",     NUEDITALLICITACAO= "000050",     ANOEDITALLICITACAO= "2018"  },
//new  {    CDUNIDADEGESTORA= "270002",     CDGESTAO= "1",     NUEDITALLICITACAO= "000006",     ANOEDITALLICITACAO= "2018"  }
};


            GridElementos.ItemsSource = elementos;

            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        }

        #region ritchtext

           

            private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
            {
                object temp = rtbEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
                btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
                temp = rtbEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
                btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
                temp = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
                btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

                temp = rtbEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
                cmbFontFamily.SelectedItem = temp;
                temp = rtbEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
                cmbFontSize.Text = temp.ToString();
            }

            private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
                if (dlg.ShowDialog() == true)
                {
                    FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
                    TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                    range.Load(fileStream, DataFormats.Rtf);
                }
            }

            private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
                if (dlg.ShowDialog() == true)
                {
                    FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                    TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                    range.Save(fileStream, DataFormats.Rtf);
                }
            }

            private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (cmbFontFamily.SelectedItem != null)
                    rtbEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
            }

            private void cmbFontSize_TextChanged(object sender, TextChangedEventArgs e)
            {
                rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.Text);
            }
        
        #endregion
    }
}

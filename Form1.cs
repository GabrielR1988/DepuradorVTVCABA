using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepuradorVTVCABA
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private string revisarCarpeta(string path)
    {
      string[] listaDeArchivos = Directory.GetFiles(path,"*.xlsx");

      if (listaDeArchivos.Length == 0)
      {
        btnComenzar.Enabled = false;
        return "La carpeta no contiene archivos compatibles";
      }

      btnComenzar.Enabled = true;
      return "";
      
    }

    private void btnSelCarpeta_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog seleccionarCarpeta = new FolderBrowserDialog();
      seleccionarCarpeta.ShowDialog();
      pathCarpetaXLSX.Text = seleccionarCarpeta.SelectedPath;

      revisarCarpeta(pathCarpetaXLSX.Text);
    }

    private void btnSeleccionarDiccionario_Click(object sender, EventArgs e)
    {
      OpenFileDialog seleccionarDiccionario = new OpenFileDialog();
      seleccionarDiccionario.ShowDialog();
      pathDiccionario.Text = seleccionarDiccionario.FileName;
    }

    private void btnComenzar_Click(object sender, EventArgs e)
    {
      
    }
  }
}

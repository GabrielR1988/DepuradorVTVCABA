using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpreadsheetLight;
using DocumentFormat.OpenXml;
using System.IO.Packaging;
using System.Runtime;
using SpreadsheetLight.Drawing;

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
      
      string[] listaDeArchivos = Directory.GetFiles(pathCarpetaXLSX.Text,"*.xlsx");
      
      foreach (var archivo in listaDeArchivos)
      {
        lstLog.Items.Add(archivo);
      }
    }

    private void btnSeleccionarDiccionario_Click(object sender, EventArgs e)
    {
      OpenFileDialog seleccionarDiccionario = new OpenFileDialog();
      seleccionarDiccionario.ShowDialog();
      pathDiccionario.Text = seleccionarDiccionario.FileName;
    }

    private void btnComenzar_Click(object sender, EventArgs e)
    {
      string linea = "";
      bool flag = false;
      string texto = "";
      int contador = 0;
      int filaobservaciones = 1;
      int columnaobservaciones = 1;
      int cantidadfilasobservaciones = 1;
      decimal ValorProgress = 1;
      decimal ValorProgress2 = 0;
      string uno = "";
      string dos = "";
      string tres = "";
      DateTime cuatro = default;
      string cinco = "";
      string seis = "";
      List<string> Diccionario = new List<string>();
      Stopwatch sw = new Stopwatch();
      sw.Start();

      StreamReader sr = new StreamReader(pathDiccionario.Text);
      while ((linea = sr.ReadLine()) != null)
      {
        Diccionario.Add(linea);
      }
      
      string[] listaDeArchivos = Directory.GetFiles(pathCarpetaXLSX.Text,"*.xlsx");

      for (int i = 0; i < listaDeArchivos.Length; i++)
      {
        SLDocument observaciones = new SLDocument(listaDeArchivos[i]);
        SLDocument resultado = new SLDocument();
        
        SLDocument Log = new SLDocument();
        SLStyle style = new SLStyle();
        style.FormatCode = "dd/mm/yyyy";
        resultado.SetColumnStyle(4, style);
        
        DataTable dt = new DataTable();
        dt.Columns.Add("dominio",typeof(string));
        dt.Columns.Add("planta",typeof(string));
        dt.Columns.Add("motivo",typeof(string));
        dt.Columns.Add("fecha",typeof(DateTime));
        dt.Columns.Add("observaciones Orig",typeof(string));
        dt.Columns.Add("observaciones Resul",typeof(string));
        
        DataTable logErrores = new DataTable();
        logErrores.Columns.Add("errores", typeof(string));

        //string prueba1 = observaciones.GetCellValueAsString(cantidadfilasobservaciones, 1);

        while (!string.IsNullOrEmpty(observaciones.GetCellValueAsString(cantidadfilasobservaciones,1)))
        {
          cantidadfilasobservaciones++;
        }

        for (int j = 1; j < cantidadfilasobservaciones; j++)
        {
          for (int k = 1; k <= 5; k++)
          {
            switch (k)
            {
              case 1: uno = observaciones.GetCellValueAsString(j, k);
                break;
              case 2: dos = observaciones.GetCellValueAsString(j, k);
                break;
              case 3: tres = observaciones.GetCellValueAsString(j, k);
                break;
              case 4: cuatro =observaciones.GetCellValueAsDateTime(j, k);
                break;
              case 5:
                if (observaciones.GetCellValueAsString(j,k) != "-" && observaciones.GetCellValueAsString(j,5).Contains("IF-20") == false)
                {
                  foreach (var cadena in Diccionario)
                  {
                    if (observaciones.GetCellValueAsString(j, k).Contains(cadena) && texto.Contains(cadena))
                    {
                      contador++;
                    }
                    else if (observaciones.GetCellValueAsString(j,k).Contains(cadena))
                    {
                      texto = texto + cadena + ", ";
                      contador++;
                    }
                    cinco = observaciones.GetCellValueAsString(j, k);
                  }
                }
                else
                {
                  cinco = observaciones.GetCellValueAsString(j, k);
                }
                break;
            }
          }

          if (contador == 0)
          {
            seis = observaciones.GetCellValueAsString(j, 5);
          }
          
          if (contador == 0 && observaciones.GetCellValueAsString(j,5).Contains("IF-20") == false && observaciones.GetCellValueAsString(j,5) != "-")
          {
            logErrores.Rows.Add(listaDeArchivos[i] + ", fila " + j + " no encontro coincidencias" + " " + observaciones.GetCellValueAsString(j, 5));
          }

          if (contador > 0)
          {
            seis = texto.Remove(texto.Length - 2, 2); 
          }

          contador = 0;
          texto = "";
          dt.Rows.Add(uno,dos,tres,cuatro,cinco,seis);
        }
        
        resultado.ImportDataTable(1,1,dt,false);
        Log.ImportDataTable(1,1,logErrores,false);
        
        resultado.SaveAs(listaDeArchivos[i].Replace(".xlsx","-out.xlsx"));
        Log.SaveAs(listaDeArchivos[i].Replace(".xlsx","-err.xlsx"));
        observaciones.CloseWithoutSaving();
        dt.Dispose();
        logErrores.Dispose();
        
      }

      TimeSpan ts = sw.Elapsed;

      MessageBox.Show("Al fin termine " + ts,ToString());
      
      Application.Exit();
    }
  }
}

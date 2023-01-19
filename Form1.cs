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
    
    //CEsta funcion evalua que dentro de la carpeta seleccionada existan archivos compatibles
    private string RevisarCarpeta(string path)
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

    //Se listan los archivos compatibles si es que existen y los agrega al listbox
    private void btnSelCarpeta_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog seleccionarCarpeta = new FolderBrowserDialog();
      seleccionarCarpeta.ShowDialog();
      pathCarpetaXLSX.Text = seleccionarCarpeta.SelectedPath;

      RevisarCarpeta(pathCarpetaXLSX.Text);
      
      string[] listaDeArchivos = Directory.GetFiles(pathCarpetaXLSX.Text,"*.xlsx");
      
      foreach (var archivo in listaDeArchivos)
      {
        lstLog.Items.Add(archivo);
      }
    }

    //Selecciona la ubicacion del diccionario y la muestra en el textbox asociado
    private void btnSeleccionarDiccionario_Click(object sender, EventArgs e)
    {
      OpenFileDialog seleccionarDiccionario = new OpenFileDialog();
      seleccionarDiccionario.ShowDialog();
      pathDiccionario.Text = seleccionarDiccionario.FileName;
    }

    private void btnComenzar_Click(object sender, EventArgs e)
    {
      string linea = "";
      string texto = "";
      int contador = 0;
      int cantidadfilasobservaciones = 1;
      string coluno = "";
      string coldos = "";
      string coltres = "";
      DateTime colcuatro = default;
      string colcinco = "";
      string colseis = "";
      List<string> diccionario = new List<string>();
      
      /*Se crea el stopwatch para ver el tiempo de ejecucion del programa, no tiene relevancia fuera de la fase de testeo
      Stopwatch sw = new Stopwatch();
      sw.Start();
      */
      
      //Se lee el diccionario y se agregan las linea a la lista "diccionario"
      StreamReader sr = new StreamReader(pathDiccionario.Text);
      while ((linea = sr.ReadLine()) != null)
      {
        diccionario.Add(linea);
      }
      
      //Se completa el array con los nombre de los archivos
      string[] listaDeArchivos = Directory.GetFiles(pathCarpetaXLSX.Text,"*.xlsx");

      //Comienzo de la secuencia de depuracion en la que se van a recorrer todos los archivos del vector "listaDeArchivos"
      for (int i = 0; i < listaDeArchivos.Length; i++)
      {
        //Haciendo uso de la libreria Spreadsheetlight se crean los objetos para recibir y enviar los resultados
        SLDocument observaciones = new SLDocument(listaDeArchivos[i]);
        SLDocument resultado = new SLDocument();
        SLDocument Log = new SLDocument();
        
        //Spreadsheetlight necesita un objeto de la clase SLStyle para darle formato al documento
        SLStyle style = new SLStyle();
        style.FormatCode = "dd/mm/yyyy";
        resultado.SetColumnStyle(4, style);
        
        //Creamos los objetos DataTable que sirven para recibir los datos procesados
        DataTable dt = new DataTable();
        dt.Columns.Add("dominio",typeof(string));
        dt.Columns.Add("planta",typeof(string));
        dt.Columns.Add("motivo",typeof(string));
        dt.Columns.Add("fecha",typeof(DateTime));
        dt.Columns.Add("observaciones Orig",typeof(string));
        dt.Columns.Add("observaciones Resul",typeof(string));
        
        DataTable logErrores = new DataTable();
        logErrores.Columns.Add("errores", typeof(string));
        
        //Obtener la cantidad de filas del documento a procesar
        while (!string.IsNullOrEmpty(observaciones.GetCellValueAsString(cantidadfilasobservaciones,1)))
        {
          cantidadfilasobservaciones++;
        }

        //Por cada documento va entrar y obtener los datos de las 4 primeras columnas para volcarlos en el datatable
        for (int j = 1; j < cantidadfilasobservaciones; j++)
        {
          for (int k = 1; k <= 5; k++)
          {
            switch (k)
            {
              case 1: coluno = observaciones.GetCellValueAsString(j, k);
                break;
              case 2: coldos = observaciones.GetCellValueAsString(j, k);
                break;
              case 3: coltres = observaciones.GetCellValueAsString(j, k);
                break;
              case 4: colcuatro =observaciones.GetCellValueAsDateTime(j, k);
                break;
              case 5:
                //Solo en esta opcion va a realizar un analisis con el diccionario en el caso de que el valor del campo no sea "-" o "IF-20"
                if (observaciones.GetCellValueAsString(j,k) != "-" && observaciones.GetCellValueAsString(j,5).Contains("IF-20") == false)
                {
                  foreach (var cadena in diccionario)
                  {
                    if (observaciones.GetCellValueAsString(j, k).Contains(cadena) && texto.Contains(cadena)) //Revisa que el valor ya no este en el string resultante "texto"
                    {
                      contador++;
                    }
                    else if (observaciones.GetCellValueAsString(j,k).Contains(cadena))
                    {
                      texto = texto + cadena + ", ";
                      contador++;
                    }
                    colcinco = observaciones.GetCellValueAsString(j, k);
                  }
                }
                else
                {
                  colcinco = observaciones.GetCellValueAsString(j, k);
                }
                break;
            }
          }

          //La variable "contador" nos sirve para saber si hay coincidencias en el diccionario
          if (contador == 0)
          {
            colseis = observaciones.GetCellValueAsString(j, 5);
          }
          if (contador == 0 && observaciones.GetCellValueAsString(j,5).Contains("IF-20") == false && observaciones.GetCellValueAsString(j,5) != "-")
          {
            logErrores.Rows.Add(listaDeArchivos[i] + ", fila " + j + " no encontro coincidencias" + " " + observaciones.GetCellValueAsString(j, 5));
          }
          if (contador > 0)
          {
            colseis = texto.Remove(texto.Length - 2, 2); 
          }
          contador = 0;
          texto = "";
          dt.Rows.Add(coluno,coldos,coltres,colcuatro,colcinco,colseis);
        }
        
        //Se importan los resultados al datatable del log de errores y del resultados, se guardan los cambios en los archivos nuevos, se cierra el libro de excel y se vacian los datos de la tabla
        resultado.ImportDataTable(1,1,dt,false);
        Log.ImportDataTable(1,1,logErrores,false);
        resultado.SaveAs(listaDeArchivos[i].Replace(".xlsx","-out.xlsx"));
        Log.SaveAs(listaDeArchivos[i].Replace(".xlsx","-err.xlsx"));
        observaciones.CloseWithoutSaving();
        dt.Dispose();
        logErrores.Dispose();
        
      }

      //TimeSpan ts = sw.Elapsed;

      //MessageBox.Show("Al fin termine " + ts,ToString());
      
      
      MessageBox.Show(@"Procedimiento finalizado");
      
      Application.Exit();
    }
  }
}

namespace DepuradorVTVCABA
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.label1 = new System.Windows.Forms.Label();
      this.btnSelCarpeta = new System.Windows.Forms.Button();
      this.pathCarpetaXLSX = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnSeleccionarDiccionario = new System.Windows.Forms.Button();
      this.pathDiccionario = new System.Windows.Forms.TextBox();
      this.lstLog = new System.Windows.Forms.ListBox();
      this.btnComenzar = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.BarraProgreso = new System.Windows.Forms.ProgressBar();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.ForeColor = System.Drawing.SystemColors.Window;
      this.label1.Location = new System.Drawing.Point(12, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(155, 23);
      this.label1.TabIndex = 0;
      this.label1.Text = "Ruta de la carpeta con los xlsx";
      // 
      // btnSelCarpeta
      // 
      this.btnSelCarpeta.Location = new System.Drawing.Point(173, 9);
      this.btnSelCarpeta.Name = "btnSelCarpeta";
      this.btnSelCarpeta.Size = new System.Drawing.Size(75, 23);
      this.btnSelCarpeta.TabIndex = 1;
      this.btnSelCarpeta.Text = "Seleccionar";
      this.btnSelCarpeta.UseVisualStyleBackColor = true;
      this.btnSelCarpeta.Click += new System.EventHandler(this.btnSelCarpeta_Click);
      // 
      // pathCarpetaXLSX
      // 
      this.pathCarpetaXLSX.Location = new System.Drawing.Point(12, 38);
      this.pathCarpetaXLSX.Name = "pathCarpetaXLSX";
      this.pathCarpetaXLSX.ReadOnly = true;
      this.pathCarpetaXLSX.Size = new System.Drawing.Size(760, 20);
      this.pathCarpetaXLSX.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.ForeColor = System.Drawing.SystemColors.Window;
      this.label2.Location = new System.Drawing.Point(12, 75);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(155, 23);
      this.label2.TabIndex = 3;
      this.label2.Text = "Ruta del diccionario";
      // 
      // btnSeleccionarDiccionario
      // 
      this.btnSeleccionarDiccionario.Location = new System.Drawing.Point(126, 70);
      this.btnSeleccionarDiccionario.Name = "btnSeleccionarDiccionario";
      this.btnSeleccionarDiccionario.Size = new System.Drawing.Size(75, 23);
      this.btnSeleccionarDiccionario.TabIndex = 4;
      this.btnSeleccionarDiccionario.Text = "Seleccionar";
      this.btnSeleccionarDiccionario.UseVisualStyleBackColor = true;
      this.btnSeleccionarDiccionario.Click += new System.EventHandler(this.btnSeleccionarDiccionario_Click);
      // 
      // pathDiccionario
      // 
      this.pathDiccionario.Location = new System.Drawing.Point(12, 101);
      this.pathDiccionario.Name = "pathDiccionario";
      this.pathDiccionario.ReadOnly = true;
      this.pathDiccionario.Size = new System.Drawing.Size(760, 20);
      this.pathDiccionario.TabIndex = 5;
      // 
      // lstLog
      // 
      this.lstLog.FormattingEnabled = true;
      this.lstLog.Location = new System.Drawing.Point(12, 143);
      this.lstLog.Name = "lstLog";
      this.lstLog.Size = new System.Drawing.Size(760, 108);
      this.lstLog.TabIndex = 6;
      // 
      // btnComenzar
      // 
      this.btnComenzar.Enabled = false;
      this.btnComenzar.Location = new System.Drawing.Point(12, 269);
      this.btnComenzar.Name = "btnComenzar";
      this.btnComenzar.Size = new System.Drawing.Size(75, 40);
      this.btnComenzar.TabIndex = 7;
      this.btnComenzar.Text = "Comenzar";
      this.btnComenzar.UseVisualStyleBackColor = true;
      this.btnComenzar.Click += new System.EventHandler(this.btnComenzar_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
      this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pictureBox1.Location = new System.Drawing.Point(607, 368);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(191, 80);
      this.pictureBox1.TabIndex = 8;
      this.pictureBox1.TabStop = false;
      // 
      // BarraProgreso
      // 
      this.BarraProgreso.Location = new System.Drawing.Point(101, 269);
      this.BarraProgreso.Name = "BarraProgreso";
      this.BarraProgreso.Size = new System.Drawing.Size(671, 40);
      this.BarraProgreso.Step = 1;
      this.BarraProgreso.TabIndex = 9;
      this.BarraProgreso.Visible = false;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.IndianRed;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.BarraProgreso);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.btnComenzar);
      this.Controls.Add(this.lstLog);
      this.Controls.Add(this.pathDiccionario);
      this.Controls.Add(this.btnSeleccionarDiccionario);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.pathCarpetaXLSX);
      this.Controls.Add(this.btnSelCarpeta);
      this.Controls.Add(this.label1);
      this.DoubleBuffered = true;
      this.Name = "Form1";
      this.Text = "Depurador VTV CABA";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private System.Windows.Forms.ProgressBar BarraProgreso;

    private System.Windows.Forms.PictureBox pictureBox1;

    private System.Windows.Forms.ListBox lstLog;
    private System.Windows.Forms.Button btnComenzar;

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnSeleccionarDiccionario;
    private System.Windows.Forms.TextBox pathDiccionario;

    private System.Windows.Forms.Button btnSelCarpeta;
    private System.Windows.Forms.TextBox pathCarpetaXLSX;

    private System.Windows.Forms.Label label1;

    #endregion
  }
}


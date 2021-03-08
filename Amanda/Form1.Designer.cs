
namespace Amanda
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BarraDeAudio = new System.Windows.Forms.ProgressBar();
            this.labelText = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BarraDeAudio
            // 
            this.BarraDeAudio.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BarraDeAudio.Location = new System.Drawing.Point(0, 279);
            this.BarraDeAudio.Maximum = 50;
            this.BarraDeAudio.Name = "BarraDeAudio";
            this.BarraDeAudio.Size = new System.Drawing.Size(451, 10);
            this.BarraDeAudio.TabIndex = 0;
            this.BarraDeAudio.Value = 10;
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.BackColor = System.Drawing.Color.Transparent;
            this.labelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelText.ForeColor = System.Drawing.Color.White;
            this.labelText.Location = new System.Drawing.Point(11, 9);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(0, 24);
            this.labelText.TabIndex = 1;
            // 
            // labelStatus
            // 
            this.labelStatus.BackColor = System.Drawing.Color.Black;
            this.labelStatus.Location = new System.Drawing.Point(12, 9);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(12, 10);
            this.labelStatus.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Amanda.Properties.Resources._6e1649_53f90a3ed7e24892be7da1119026dc15_mv2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(451, 289);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.BarraDeAudio);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Amanda";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar BarraDeAudio;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Label labelStatus;
    }
}


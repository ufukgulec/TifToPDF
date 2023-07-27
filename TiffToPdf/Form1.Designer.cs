namespace TiffToPdf
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBrowse = new System.Windows.Forms.Button();
            this.targetDocument = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sourceDocument = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveBrowse = new System.Windows.Forms.Button();
            this.btnConvertPDF = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(6, 49);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(764, 62);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // targetDocument
            // 
            this.targetDocument.Location = new System.Drawing.Point(6, 21);
            this.targetDocument.Name = "targetDocument";
            this.targetDocument.Size = new System.Drawing.Size(764, 22);
            this.targetDocument.TabIndex = 1;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.sourceDocument);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 117);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kaynak Dosya";
            // 
            // sourceDocument
            // 
            this.sourceDocument.Location = new System.Drawing.Point(6, 21);
            this.sourceDocument.Name = "sourceDocument";
            this.sourceDocument.Size = new System.Drawing.Size(764, 22);
            this.sourceDocument.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveBrowse);
            this.groupBox2.Controls.Add(this.btnConvertPDF);
            this.groupBox2.Controls.Add(this.targetDocument);
            this.groupBox2.Location = new System.Drawing.Point(12, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 195);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hedef Dosya";
            // 
            // btnSaveBrowse
            // 
            this.btnSaveBrowse.Location = new System.Drawing.Point(6, 49);
            this.btnSaveBrowse.Name = "btnSaveBrowse";
            this.btnSaveBrowse.Size = new System.Drawing.Size(764, 62);
            this.btnSaveBrowse.TabIndex = 3;
            this.btnSaveBrowse.Text = "Browse";
            this.btnSaveBrowse.UseVisualStyleBackColor = true;
            this.btnSaveBrowse.Click += new System.EventHandler(this.btnSaveBrowse_Click);
            // 
            // btnConvertPDF
            // 
            this.btnConvertPDF.Location = new System.Drawing.Point(6, 117);
            this.btnConvertPDF.Name = "btnConvertPDF";
            this.btnConvertPDF.Size = new System.Drawing.Size(764, 62);
            this.btnConvertPDF.TabIndex = 3;
            this.btnConvertPDF.Text = "To PDF";
            this.btnConvertPDF.UseVisualStyleBackColor = true;
            this.btnConvertPDF.Click += new System.EventHandler(this.btnConvertPDF_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.SelectedPath = "C:\\Users\\Admin\\Desktop";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 339);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox targetDocument;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox sourceDocument;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConvertPDF;
        private System.Windows.Forms.Button btnSaveBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}


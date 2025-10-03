using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Oficina
{
    partial class HomePage
    {
        private IContainer components = null;
        private Label label1;
        private Label label4;
        private Button button1;
        private FileSystemWatcher fileSystemWatcher1;
        private ComboBox comboBox3;
        private ComboBox comboBox2;
        private Button button2;
        private Button button6;
        private Button button3;
        private BindingSource homePageBindingSource;
        private Button button4;
        private Button button5;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.label1 = new Label();
            this.label4 = new Label();
            this.button1 = new Button();
            this.fileSystemWatcher1 = new FileSystemWatcher();
            this.comboBox2 = new ComboBox();
            this.comboBox3 = new ComboBox();
            this.homePageBindingSource = new BindingSource(this.components);
            this.button2 = new Button();
            this.button6 = new Button();
            this.button3 = new Button();
            this.button4 = new Button();
            this.button5 = new Button();
            ((ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((ISupportInitialize)(this.homePageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(62, 41);
            this.label1.Name = "label1";
            this.label1.Size = new Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empregado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(60, 96);
            this.label4.Name = "label4";
            this.label4.Size = new Size(44, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cliente";
            // 
            // button1
            // 
            this.button1.Location = new Point(62, 219);
            this.button1.Name = "button1";
            this.button1.Size = new Size(73, 43);
            this.button1.TabIndex = 15;
            this.button1.Text = "Próximo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // comboBox2
            // 
            this.comboBox2.ForeColor = SystemColors.MenuText;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new Point(62, 114);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new Size(121, 23);
            this.comboBox2.TabIndex = 16;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.DataSource = this.homePageBindingSource;
            this.comboBox3.ForeColor = SystemColors.MenuText;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new Point(62, 59);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new Size(121, 23);
            this.comboBox3.TabIndex = 17;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // homePageBindingSource
            // 
            this.homePageBindingSource.DataSource = typeof(HomePage);
            // 
            // button2
            // 
            this.button2.Location = new Point(173, 219);
            this.button2.Name = "button2";
            this.button2.Size = new Size(88, 43);
            this.button2.TabIndex = 18;
            this.button2.Text = "Criar Registo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button6
            // 
            this.button6.Location = new Point(204, 114);
            this.button6.Name = "button6";
            this.button6.Size = new Size(57, 23);
            this.button6.TabIndex = 20;
            this.button6.Text = "Info";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button3
            // 
            this.button3.Location = new Point(204, 59);
            this.button3.Name = "button3";
            this.button3.Size = new Size(57, 23);
            this.button3.TabIndex = 21;
            this.button3.Text = "Info";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new Point(294, 219);
            this.button4.Name = "button4";
            this.button4.Size = new Size(88, 43);
            this.button4.TabIndex = 22;
            this.button4.Text = "Criar Empregado";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new Point(419, 219);
            this.button5.Name = "button5";
            this.button5.Size = new Size(88, 43);
            this.button5.TabIndex = 23;
            this.button5.Text = "Relatório";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(693, 345);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "HomePage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.HomePage_Load);
            ((ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((ISupportInitialize)(this.homePageBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

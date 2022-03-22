namespace DXFViewer
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dxfbutton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.FreePenBtn = new System.Windows.Forms.Button();
            this.TenPenBtn = new System.Windows.Forms.Button();
            this.LinePenBtn = new System.Windows.Forms.Button();
            this.SikakuPenBtn = new System.Windows.Forms.Button();
            this.MaruPenBtn = new System.Windows.Forms.Button();
            this.HaniPenBtn = new System.Windows.Forms.Button();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.StatusBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dxfbutton
            // 
            this.dxfbutton.Location = new System.Drawing.Point(20, 18);
            this.dxfbutton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dxfbutton.Name = "dxfbutton";
            this.dxfbutton.Size = new System.Drawing.Size(178, 34);
            this.dxfbutton.TabIndex = 0;
            this.dxfbutton.Text = "DXF読み込み";
            this.dxfbutton.UseVisualStyleBackColor = true;
            this.dxfbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 110);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 774);
            this.textBox1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(208, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1629, 866);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 651);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 42);
            this.button1.TabIndex = 3;
            this.button1.Text = "〇";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(5, 702);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(103, 32);
            this.clearBtn.TabIndex = 4;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // FreePenBtn
            // 
            this.FreePenBtn.Image = ((System.Drawing.Image)(resources.GetObject("FreePenBtn.Image")));
            this.FreePenBtn.Location = new System.Drawing.Point(5, 4);
            this.FreePenBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.FreePenBtn.Name = "FreePenBtn";
            this.FreePenBtn.Size = new System.Drawing.Size(47, 42);
            this.FreePenBtn.TabIndex = 5;
            this.FreePenBtn.UseVisualStyleBackColor = true;
            this.FreePenBtn.Click += new System.EventHandler(this.FreePenBtn_Click);
            // 
            // TenPenBtn
            // 
            this.TenPenBtn.Image = ((System.Drawing.Image)(resources.GetObject("TenPenBtn.Image")));
            this.TenPenBtn.Location = new System.Drawing.Point(62, 4);
            this.TenPenBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TenPenBtn.Name = "TenPenBtn";
            this.TenPenBtn.Size = new System.Drawing.Size(47, 42);
            this.TenPenBtn.TabIndex = 6;
            this.TenPenBtn.UseVisualStyleBackColor = true;
            this.TenPenBtn.Click += new System.EventHandler(this.TenPenBtn_Click);
            // 
            // LinePenBtn
            // 
            this.LinePenBtn.Image = ((System.Drawing.Image)(resources.GetObject("LinePenBtn.Image")));
            this.LinePenBtn.Location = new System.Drawing.Point(118, 4);
            this.LinePenBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.LinePenBtn.Name = "LinePenBtn";
            this.LinePenBtn.Size = new System.Drawing.Size(47, 42);
            this.LinePenBtn.TabIndex = 7;
            this.LinePenBtn.UseVisualStyleBackColor = true;
            this.LinePenBtn.Click += new System.EventHandler(this.LinePenBtn_Click);
            // 
            // SikakuPenBtn
            // 
            this.SikakuPenBtn.Image = ((System.Drawing.Image)(resources.GetObject("SikakuPenBtn.Image")));
            this.SikakuPenBtn.Location = new System.Drawing.Point(5, 56);
            this.SikakuPenBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.SikakuPenBtn.Name = "SikakuPenBtn";
            this.SikakuPenBtn.Size = new System.Drawing.Size(47, 42);
            this.SikakuPenBtn.TabIndex = 8;
            this.SikakuPenBtn.UseVisualStyleBackColor = true;
            this.SikakuPenBtn.Click += new System.EventHandler(this.SikakuPenBtn_Click);
            // 
            // MaruPenBtn
            // 
            this.MaruPenBtn.Image = ((System.Drawing.Image)(resources.GetObject("MaruPenBtn.Image")));
            this.MaruPenBtn.Location = new System.Drawing.Point(62, 56);
            this.MaruPenBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaruPenBtn.Name = "MaruPenBtn";
            this.MaruPenBtn.Size = new System.Drawing.Size(47, 42);
            this.MaruPenBtn.TabIndex = 9;
            this.MaruPenBtn.UseVisualStyleBackColor = true;
            this.MaruPenBtn.Click += new System.EventHandler(this.MaruPenBtn_Click);
            // 
            // HaniPenBtn
            // 
            this.HaniPenBtn.Image = ((System.Drawing.Image)(resources.GetObject("HaniPenBtn.Image")));
            this.HaniPenBtn.Location = new System.Drawing.Point(118, 56);
            this.HaniPenBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.HaniPenBtn.Name = "HaniPenBtn";
            this.HaniPenBtn.Size = new System.Drawing.Size(47, 42);
            this.HaniPenBtn.TabIndex = 10;
            this.HaniPenBtn.UseVisualStyleBackColor = true;
            this.HaniPenBtn.Click += new System.EventHandler(this.HaniPenBtn_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarLabel,
            this.StatusBarLabel2});
            this.StatusBar.Location = new System.Drawing.Point(0, 892);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Padding = new System.Windows.Forms.Padding(2, 0, 23, 0);
            this.StatusBar.Size = new System.Drawing.Size(2023, 30);
            this.StatusBar.TabIndex = 11;
            this.StatusBar.Text = "statusStrip1";
            // 
            // StatusBarLabel
            // 
            this.StatusBarLabel.Name = "StatusBarLabel";
            this.StatusBarLabel.Size = new System.Drawing.Size(138, 25);
            this.StatusBarLabel.Text = "選択してください。";
            // 
            // StatusBarLabel2
            // 
            this.StatusBarLabel2.Name = "StatusBarLabel2";
            this.StatusBarLabel2.Size = new System.Drawing.Size(181, 25);
            this.StatusBarLabel2.Text = "toolStripStatusLabel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FreePenBtn);
            this.panel1.Controls.Add(this.TenPenBtn);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.clearBtn);
            this.panel1.Controls.Add(this.HaniPenBtn);
            this.panel1.Controls.Add(this.MaruPenBtn);
            this.panel1.Controls.Add(this.LinePenBtn);
            this.panel1.Controls.Add(this.SikakuPenBtn);
            this.panel1.Location = new System.Drawing.Point(1848, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 867);
            this.panel1.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(20, 66);
            this.button2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 34);
            this.button2.TabIndex = 14;
            this.button2.Text = "DXF保存";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2023, 922);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dxfbutton);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.Text = "DXFViewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dxfbutton;
        private System.Windows.Forms.TextBox textBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button FreePenBtn;
        private System.Windows.Forms.Button TenPenBtn;
        private System.Windows.Forms.Button LinePenBtn;
        private System.Windows.Forms.Button SikakuPenBtn;
        private System.Windows.Forms.Button MaruPenBtn;
        private System.Windows.Forms.Button HaniPenBtn;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarLabel;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarLabel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
    }
}


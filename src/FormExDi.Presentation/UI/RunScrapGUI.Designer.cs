namespace FormExDi.Presentation.Ui;

partial class RunScrapGUI
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.ProgressBarSearchs = new System.Windows.Forms.ProgressBar();
            this.BtnPause = new System.Windows.Forms.Button();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.ScrapInfo = new System.Windows.Forms.GroupBox();
            this.LogListBoxScrap = new FormExDi.Presentation.UI.Components.LogListBox();
            this.LabelQtt = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TimerInfo = new System.Windows.Forms.Timer(this.components);
            this.ScrapInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgressBarSearchs
            // 
            this.ProgressBarSearchs.Location = new System.Drawing.Point(12, 406);
            this.ProgressBarSearchs.Name = "ProgressBarSearchs";
            this.ProgressBarSearchs.Size = new System.Drawing.Size(649, 32);
            this.ProgressBarSearchs.TabIndex = 0;
            // 
            // BtnPause
            // 
            this.BtnPause.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnPause.Location = new System.Drawing.Point(667, 381);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(132, 65);
            this.BtnPause.TabIndex = 1;
            this.BtnPause.Text = "Pause";
            this.BtnPause.UseVisualStyleBackColor = true;
            this.BtnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // LabelTitle
            // 
            this.LabelTitle.AutoSize = true;
            this.LabelTitle.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelTitle.Location = new System.Drawing.Point(3, 13);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(59, 33);
            this.LabelTitle.TabIndex = 2;
            this.LabelTitle.Text = "title";
            // 
            // ScrapInfo
            // 
            this.ScrapInfo.Controls.Add(this.LogListBoxScrap);
            this.ScrapInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScrapInfo.Location = new System.Drawing.Point(12, 64);
            this.ScrapInfo.Name = "ScrapInfo";
            this.ScrapInfo.Size = new System.Drawing.Size(776, 314);
            this.ScrapInfo.TabIndex = 3;
            this.ScrapInfo.TabStop = false;
            this.ScrapInfo.Text = "Scrap Info";
            // 
            // LogListBoxScrap
            // 
            this.LogListBoxScrap.FormattingEnabled = true;
            this.LogListBoxScrap.HorizontalScrollbar = true;
            this.LogListBoxScrap.ItemHeight = 22;
            this.LogListBoxScrap.Location = new System.Drawing.Point(6, 29);
            this.LogListBoxScrap.LockOnLast = true;
            this.LogListBoxScrap.Name = "LogListBoxScrap";
            this.LogListBoxScrap.Size = new System.Drawing.Size(764, 268);
            this.LogListBoxScrap.TabIndex = 0;
            // 
            // LabelQtt
            // 
            this.LabelQtt.AutoSize = true;
            this.LabelQtt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelQtt.Location = new System.Drawing.Point(372, 381);
            this.LabelQtt.Name = "LabelQtt";
            this.LabelQtt.Size = new System.Drawing.Size(34, 22);
            this.LabelQtt.TabIndex = 4;
            this.LabelQtt.Text = "Qtt";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.LabelTitle);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 46);
            this.panel1.TabIndex = 0;
            // 
            // TimerInfo
            // 
            this.TimerInfo.Enabled = true;
            this.TimerInfo.Interval = 1000;
            this.TimerInfo.Tick += new System.EventHandler(this.TimerInfo_Tick);
            // 
            // RunScrapGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LabelQtt);
            this.Controls.Add(this.ScrapInfo);
            this.Controls.Add(this.BtnPause);
            this.Controls.Add(this.ProgressBarSearchs);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(818, 497);
            this.MinimumSize = new System.Drawing.Size(818, 497);
            this.Name = "RunScrapGUI";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.RunScrapGUI_Load);
            this.ScrapInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private ProgressBar ProgressBarSearchs;
    private Button BtnPause;
    private Label LabelTitle;
    private GroupBox ScrapInfo;
    private Label LabelQtt;
    private Panel panel1;
    private System.Windows.Forms.Timer TimerInfo;
    private UI.Components.LogListBox LogListBoxScrap;
}

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
            this.ProgressBarSearchs = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // ProgressBarSearchs
            // 
            this.ProgressBarSearchs.Location = new System.Drawing.Point(12, 406);
            this.ProgressBarSearchs.Name = "ProgressBarSearchs";
            this.ProgressBarSearchs.Size = new System.Drawing.Size(776, 32);
            this.ProgressBarSearchs.TabIndex = 0;
            // 
            // RunScrapGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ProgressBarSearchs);
            this.Name = "RunScrapGUI";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.RunScrapGUI_Load);
            this.ResumeLayout(false);

    }

    #endregion

    private ProgressBar ProgressBarSearchs;
}

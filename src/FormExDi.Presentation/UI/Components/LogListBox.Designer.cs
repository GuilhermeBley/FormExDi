namespace FormExDi.Presentation.UI.Components
{
    partial class LogListBox
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.TimerLog = new System.Windows.Forms.Timer(this.components);

            HorizontalScrollbar = false;
            ScrollAlwaysVisible = false;

            // 
            // TimerLog
            // 
            this.TimerLog.Enabled = true;
            this.TimerLog.Interval = 1000;
            this.TimerLog.Tick += new System.EventHandler(this.TimerLog_Tick);
        }

        #endregion

        #region My Designer

        private void MyInitializeComponent()
        {
        }

        #endregion

        private System.Windows.Forms.Timer TimerLog;
    }
}

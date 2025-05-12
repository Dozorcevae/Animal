namespace Animals.WinForms
{
    partial class MovementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelDisplay;
        private System.Windows.Forms.Timer paintTimer;

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelDisplay = new System.Windows.Forms.Panel();
            paintTimer = new System.Windows.Forms.Timer(components);

            // panelDisplay
            panelDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            panelDisplay.BackColor = System.Drawing.Color.White;
            panelDisplay.Paint += panelDisplay_Paint;

            // paintTimer
            paintTimer.Interval = 50;
            paintTimer.Tick += paintTimer_Tick;

            // MovementForm
            ClientSize = new System.Drawing.Size(640, 480);
            Controls.Add(panelDisplay);
            Text = "Движение";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) components?.Dispose();
            base.Dispose(disposing);
        }
    }
}

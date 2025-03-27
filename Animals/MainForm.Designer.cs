
namespace Animals
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxAnimals;
        private System.Windows.Forms.Button addAnimalButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxAnimals = new System.Windows.Forms.ListBox();
            this.addAnimalButton = new System.Windows.Forms.Button();

            // 
            // listBoxAnimals
            // 
            this.listBoxAnimals.Location = new System.Drawing.Point(10, 10);
            this.listBoxAnimals.Size = new System.Drawing.Size(480, 390);

            // 
            // addAnimalButton
            // 
            this.addAnimalButton.Location = new System.Drawing.Point(200, 400);
            this.addAnimalButton.Size = new System.Drawing.Size(100, 40);
            this.addAnimalButton.Text = "Добавить животное";
            this.addAnimalButton.Click += new System.EventHandler(this.addAnimalButton_Click);

            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.listBoxAnimals);
            this.Controls.Add(this.addAnimalButton);
            this.Name = "MainForm";
            this.Text = "Список животных";
            this.Load += new System.EventHandler(this.MainForm_Load);
        }
    }
}


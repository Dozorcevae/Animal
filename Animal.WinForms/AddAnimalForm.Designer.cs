
namespace Animals.WinForms
{
    partial class AddAnimalForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxSpecies;
        private System.Windows.Forms.ComboBox comboClass;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.TextBox textBoxHabitats;
        private System.Windows.Forms.Button addButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBoxSpecies = new System.Windows.Forms.TextBox();
            comboClass = new System.Windows.Forms.ComboBox();
            textBoxWeight = new System.Windows.Forms.TextBox();
            textBoxHabitats = new System.Windows.Forms.TextBox();
            addButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // textBoxSpecies
            // 
            textBoxSpecies.Location = new System.Drawing.Point(53, 21);
            textBoxSpecies.PlaceholderText = "Вид";
            textBoxSpecies.Size = new System.Drawing.Size(200, 23);
            // 
            // comboClass
            // 
            comboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboClass.Location = new System.Drawing.Point(53, 50);
            comboClass.Size = new System.Drawing.Size(200, 23);
            // 
            // textBoxWeight
            // 
            textBoxWeight.Location = new System.Drawing.Point(53, 79);
            textBoxWeight.PlaceholderText = "Вес";
            textBoxWeight.Size = new System.Drawing.Size(200, 23);
            // 
            // textBoxHabitats
            // 
            textBoxHabitats.Location = new System.Drawing.Point(53, 108);
            textBoxHabitats.PlaceholderText = "Среда обитания";
            textBoxHabitats.Size = new System.Drawing.Size(200, 23);
            // 
            // addButton
            // 
            addButton.Location = new System.Drawing.Point(100, 184);
            addButton.Size = new System.Drawing.Size(100, 30);
            addButton.Text = "Добавить";
            addButton.Click += addButton_Click;
            // 
            // AddAnimalForm
            // 
            ClientSize = new System.Drawing.Size(300, 250);
            Controls.AddRange(new System.Windows.Forms.Control[]
            {
                textBoxSpecies, comboClass, textBoxWeight, textBoxHabitats, addButton
            });
            MinimumSize = new System.Drawing.Size(316, 289);
            Name = "AddAnimalForm";
            Text = "Внесение данных";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

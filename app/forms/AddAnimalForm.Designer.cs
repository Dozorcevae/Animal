namespace Animals
{
    partial class AddAnimalForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textSpecies;
        private System.Windows.Forms.TextBox textWeight;
        private System.Windows.Forms.TextBox textHabitat;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.Button buttonAdd;

        private void InitializeComponent()
        {
            this.textSpecies = new();
            this.textWeight = new();
            this.textHabitat = new();
            this.comboType = new();
            this.buttonAdd = new();
            this.SuspendLayout();
            // textSpecies
            this.textSpecies.PlaceholderText = "Вид";
            this.textSpecies.Location = new(12, 12);
            // textWeight
            this.textWeight.PlaceholderText = "Вес, кг";
            this.textWeight.Location = new(12, 42);
            // textHabitat
            this.textHabitat.PlaceholderText = "Места обитания";
            this.textHabitat.Location = new(12, 72);
            // comboType
            this.comboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboType.Location = new(12, 102);
            // buttonAdd
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.Location = new(12, 132);
            this.buttonAdd.Click += buttonAdd_Click;
            // AddAnimalForm
            this.ClientSize = new(240, 180);
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                textSpecies, textWeight, textHabitat, comboType, buttonAdd
            });
            this.Text = "Новое животное";
            this.ResumeLayout(false);
        }
    }
}

namespace Animals
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listAnimals;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonExchange;
        private System.Windows.Forms.ComboBox comboExchange;

        private void InitializeComponent()
        {
            this.listAnimals = new();
            this.buttonAdd = new();
            this.buttonDelete = new();
            this.buttonExchange = new();
            this.comboExchange = new();
            this.SuspendLayout();
            // listAnimals
            this.listAnimals.Location = new(12, 12);
            this.listAnimals.Size = new(360, 300);
            // buttonAdd
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.Location = new(12, 320);
            this.buttonAdd.Click += buttonAdd_Click;
            // buttonDelete
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.Location = new(100, 320);
            this.buttonDelete.Click += buttonDelete_Click;
            // comboExchange
            this.comboExchange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboExchange.DataSource = Enum.GetValues(typeof(Animals.Models.AnimalType));
            this.comboExchange.Location = new(188, 322);
            // buttonExchange
            this.buttonExchange.Text = "Обмен";
            this.buttonExchange.Location = new(320, 320);
            this.buttonExchange.Click += buttonExchange_Click;
            // MainForm
            this.ClientSize = new(384, 361);
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                listAnimals, buttonAdd, buttonDelete, comboExchange, buttonExchange
            });
            this.Load += MainForm_Load;
            this.Text = "Animals – клиент";
            this.ResumeLayout(false);
        }
    }
}

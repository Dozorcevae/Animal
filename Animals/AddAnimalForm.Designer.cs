namespace Animals
{
    partial class AddAnimalForm
    {

        private System.Windows.Forms.TextBox textBoxSpecies;
        private System.Windows.Forms.TextBox textBoxClass;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.TextBox textBoxHabitats;
        private System.Windows.Forms.Button addButton;

        

      
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
            textBoxSpecies = new TextBox();
            textBoxClass = new TextBox();
            textBoxHabitats = new TextBox();
            textBoxWeight = new TextBox();
            addButton = new Button();
            
            SuspendLayout();
            // 
            // textBoxSpecies
            // 
            textBoxSpecies.Location = new Point(53, 21);
            textBoxSpecies.Name = "textBoxSpecies";
            textBoxSpecies.PlaceholderText = "Вид";
            textBoxSpecies.Size = new Size(200, 23);
            textBoxSpecies.TabIndex = 0;
            textBoxSpecies.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // textBoxClass
            // 
            textBoxClass.Location = new Point(53, 50);
            textBoxClass.Name = "textBoxClass";
            textBoxClass.PlaceholderText = "Класс";
            textBoxClass.Size = new Size(200, 23);
            textBoxClass.TabIndex = 1;
            textBoxClass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // textBoxHabitats
            // 
            textBoxHabitats.Location = new Point(53, 108);
            textBoxHabitats.Name = "textBoxHabitats";
            textBoxHabitats.PlaceholderText = "Среда обитания";
            textBoxHabitats.Size = new Size(200, 23);
            textBoxHabitats.TabIndex = 3;
            textBoxHabitats.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // textBoxWeight
            // 
            textBoxWeight.Location = new Point(53, 79);
            textBoxWeight.Name = "textBoxWeight";
            textBoxWeight.PlaceholderText = "Вес";
            textBoxWeight.Size = new Size(200, 23);
            textBoxWeight.TabIndex = 2;
            textBoxWeight.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // addButton
            // 
            addButton.Location = new Point(100, 184);
            addButton.Name = "addButton";
            addButton.Size = new Size(100, 30);
            addButton.TabIndex = 4;
            addButton.Text = "Добавить";
            addButton.Click += addButton_Click;
            addButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // AddAnimalForm
            // 
            ClientSize = new Size(300, 250);
            Controls.Add(textBoxClass);
            Controls.Add(textBoxHabitats);
            Controls.Add(textBoxSpecies);
            Controls.Add(textBoxWeight);
            Controls.Add(addButton);
            Name = "AddAnimalForm";
            Text = "Внесение данных";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}

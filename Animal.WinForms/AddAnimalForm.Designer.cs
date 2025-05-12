// Animals.WinForms / AddAnimalForm.Designer.cs
namespace Animals.WinForms
{
    partial class AddAnimalForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxSpecies;
        private System.Windows.Forms.TextBox textBoxClass;
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
            textBoxClass = new System.Windows.Forms.TextBox();
            textBoxWeight = new System.Windows.Forms.TextBox();
            textBoxHabitats = new System.Windows.Forms.TextBox();
            addButton = new System.Windows.Forms.Button();

            SuspendLayout();

            // textBoxSpecies
            textBoxSpecies.Anchor = System.Windows.Forms.AnchorStyles.Top
                                           | System.Windows.Forms.AnchorStyles.Left
                                           | System.Windows.Forms.AnchorStyles.Right;
            textBoxSpecies.Location = new System.Drawing.Point(53, 21);
            textBoxSpecies.Name = "textBoxSpecies";
            textBoxSpecies.PlaceholderText = "Вид";
            textBoxSpecies.Size = new System.Drawing.Size(200, 23);
            textBoxSpecies.TabIndex = 0;

            // textBoxClass
            textBoxClass.Anchor = textBoxSpecies.Anchor;
            textBoxClass.Location = new System.Drawing.Point(53, 50);
            textBoxClass.Name = "textBoxClass";
            textBoxClass.PlaceholderText = "Класс";
            textBoxClass.Size = new System.Drawing.Size(200, 23);
            textBoxClass.TabIndex = 1;

            // textBoxWeight
            textBoxWeight.Anchor = textBoxSpecies.Anchor;
            textBoxWeight.Location = new System.Drawing.Point(53, 79);
            textBoxWeight.Name = "textBoxWeight";
            textBoxWeight.PlaceholderText = "Вес";
            textBoxWeight.Size = new System.Drawing.Size(200, 23);
            textBoxWeight.TabIndex = 2;

            // textBoxHabitats
            textBoxHabitats.Anchor = textBoxSpecies.Anchor;
            textBoxHabitats.Location = new System.Drawing.Point(53, 108);
            textBoxHabitats.Name = "textBoxHabitats";
            textBoxHabitats.PlaceholderText = "Среда обитания";
            textBoxHabitats.Size = new System.Drawing.Size(200, 23);
            textBoxHabitats.TabIndex = 3;

            // addButton
            addButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
                               | System.Windows.Forms.AnchorStyles.Left
                               | System.Windows.Forms.AnchorStyles.Right;
            addButton.Location = new System.Drawing.Point(100, 184);
            addButton.Name = "addButton";
            addButton.Size = new System.Drawing.Size(100, 30);
            addButton.TabIndex = 4;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;

            // AddAnimalForm
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(300, 250);
            Controls.Add(textBoxSpecies);
            Controls.Add(textBoxClass);
            Controls.Add(textBoxWeight);
            Controls.Add(textBoxHabitats);
            Controls.Add(addButton);
            Name = "AddAnimalForm";
            Text = "Внесение данных";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

// Animals.WinForms / MainForm.Designer.cs
namespace Animals.WinForms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxAnimals;
        private System.Windows.Forms.Button addAnimalButton;
        private System.Windows.Forms.Button deleteAnimalButton;
        private System.Windows.Forms.Button editAnimalButton;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem addMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            listBoxAnimals = new System.Windows.Forms.ListBox();
            addAnimalButton = new System.Windows.Forms.Button();
            deleteAnimalButton = new System.Windows.Forms.Button();
            editAnimalButton = new System.Windows.Forms.Button();
            moveButton = new System.Windows.Forms.Button();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            addMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            moveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            infoMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            // ========== LISTBOX ==========
            listBoxAnimals.Anchor = System.Windows.Forms.AnchorStyles.Top
                                      | System.Windows.Forms.AnchorStyles.Bottom
                                      | System.Windows.Forms.AnchorStyles.Left
                                      | System.Windows.Forms.AnchorStyles.Right;
            listBoxAnimals.Location = new System.Drawing.Point(8, 27);
            listBoxAnimals.Name = "listBoxAnimals";
            listBoxAnimals.Size = new System.Drawing.Size(480, 139);
            listBoxAnimals.TabIndex = 0;

            // ========== ADD BUTTON ==========
            addAnimalButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            addAnimalButton.Location = new System.Drawing.Point(8, 181);
            addAnimalButton.Name = "addAnimalButton";
            addAnimalButton.Size = new System.Drawing.Size(480, 30);
            addAnimalButton.Text = "Добавить животное";
            addAnimalButton.Click += addAnimalButton_Click;

            // ========== DELETE BUTTON ==========
            deleteAnimalButton.Anchor = addAnimalButton.Anchor;
            deleteAnimalButton.Location = new System.Drawing.Point(8, 231);
            deleteAnimalButton.Name = "deleteAnimalButton";
            deleteAnimalButton.Size = new System.Drawing.Size(480, 30);
            deleteAnimalButton.Text = "Удалить";
            deleteAnimalButton.Click += deleteAnimalButton_Click;

            // ========== EDIT BUTTON ==========
            editAnimalButton.Anchor = addAnimalButton.Anchor;
            editAnimalButton.Location = new System.Drawing.Point(8, 281);
            editAnimalButton.Name = "editAnimalButton";
            editAnimalButton.Size = new System.Drawing.Size(480, 30);
            editAnimalButton.Text = "Изменить";
            editAnimalButton.Click += editAnimalButton_Click;

            // ========== MOVE BUTTON ==========
            moveButton.Anchor = addAnimalButton.Anchor;
            moveButton.Location = new System.Drawing.Point(8, 399);
            moveButton.Name = "moveButton";
            moveButton.Size = new System.Drawing.Size(480, 30);
            moveButton.Text = "Многопоточность";
            moveButton.Click += moveButton_Click;

            // ========== MENU ==========
            addMenuItem.Text = "Добавить";
            addMenuItem.Click += addAnimalButton_Click;

            editMenuItem.Text = "Изменить";
            editMenuItem.Click += editAnimalButton_Click;

            deleteMenuItem.Text = "Удалить";
            deleteMenuItem.Click += deleteAnimalButton_Click;

            moveMenuItem.Text = "Многопоточность";
            moveMenuItem.Click += moveMenuItem_Click;

            infoMenuItem.Text = "Справка";
            infoMenuItem.Click += ShowAboutDialog;

            fileMenu.Text = "Меню";
            fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                addMenuItem, moveMenuItem, editMenuItem, deleteMenuItem, infoMenuItem
            });

            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileMenu });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(500, 24);

            // ========== FORM ==========
            ClientSize = new System.Drawing.Size(500, 461);
            Controls.AddRange(new System.Windows.Forms.Control[]
            {
                menuStrip1, listBoxAnimals, addAnimalButton,
                deleteAnimalButton, editAnimalButton, moveButton
            });
            MainMenuStrip = menuStrip1;
            MinimumSize = new System.Drawing.Size(500, 500);
            Name = "MainForm";
            Text = "Список животных";
            Load += MainForm_Load;

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

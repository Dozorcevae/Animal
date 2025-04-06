
namespace Animals
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxAnimals;
        private System.Windows.Forms.Button addAnimalButton;
        private System.Windows.Forms.Button deleteAnimalButton;
        private System.Windows.Forms.Button editAnimalButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button moveButton;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            listBoxAnimals = new ListBox();
            addAnimalButton = new Button();
            deleteAnimalButton = new Button();
            editAnimalButton = new Button();
            moveButton = new Button();
            menuStrip1 = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            addMenuItem = new ToolStripMenuItem();
            editMenuItem = new ToolStripMenuItem();
            deleteMenuItem = new ToolStripMenuItem();
            infoMenuItem = new ToolStripMenuItem();
            moveMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxAnimals
            // 
            listBoxAnimals.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxAnimals.ItemHeight = 15;
            listBoxAnimals.Location = new Point(8, 27);
            listBoxAnimals.Name = "listBoxAnimals";
            listBoxAnimals.Size = new Size(480, 139);
            listBoxAnimals.TabIndex = 0;
            // 
            // addAnimalButton
            // 
            addAnimalButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            addAnimalButton.Location = new Point(8, 181);
            addAnimalButton.Name = "addAnimalButton";
            addAnimalButton.Size = new Size(480, 30);
            addAnimalButton.TabIndex = 1;
            addAnimalButton.Text = "Добавить животное";
            addAnimalButton.Click += addAnimalButton_Click;
            // 
            // deleteAnimalButton
            // 
            deleteAnimalButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            deleteAnimalButton.Location = new Point(8, 231);
            deleteAnimalButton.Name = "deleteAnimalButton";
            deleteAnimalButton.Size = new Size(480, 30);
            deleteAnimalButton.TabIndex = 2;
            deleteAnimalButton.Text = "Удалить";
            deleteAnimalButton.Click += deleteAnimalButton_Click;
            // 
            // editAnimalButton
            // 
            editAnimalButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            editAnimalButton.Location = new Point(8, 281);
            editAnimalButton.Name = "editAnimalButton";
            editAnimalButton.Size = new Size(480, 30);
            editAnimalButton.TabIndex = 3;
            editAnimalButton.Text = "Изменить";
            editAnimalButton.Click += editAnimalButton_Click;
            // 
            // moveButton
            // 
            moveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            moveButton.Location = new Point(8, 399);
            moveButton.Name = "moveButton";
            moveButton.Size = new Size(480, 30);
            moveButton.TabIndex = 4;
            moveButton.Text = "Многопоточность";
            moveButton.Click += moveButton_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileMenu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(500, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { addMenuItem, moveMenuItem, editMenuItem, deleteMenuItem, infoMenuItem });
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(53, 20);
            fileMenu.Text = "Меню";
            // 
            // addMenuItem
            // 
            addMenuItem.Name = "addMenuItem";
            addMenuItem.Size = new Size(128, 22);
            addMenuItem.Text = "Добавить";
            addMenuItem.Click += addAnimalButton_Click;
            // 
            // editMenuItem
            // 
            editMenuItem.Name = "editMenuItem";
            editMenuItem.Size = new Size(128, 22);
            editMenuItem.Text = "Изменить";
            editMenuItem.Click += editAnimalButton_Click;
            // 
            // deleteMenuItem
            // 
            deleteMenuItem.Name = "deleteMenuItem";
            deleteMenuItem.Size = new Size(128, 22);
            deleteMenuItem.Text = "Удалить";
            deleteMenuItem.Click += deleteAnimalButton_Click;
            // 
            // infoMenuItem
            // 
            infoMenuItem.Name = "infoMenuItem";
            infoMenuItem.Size = new Size(128, 22);
            infoMenuItem.Text = "Справка";
            infoMenuItem.Click += ShowAboutDialog;
            //
            //moveMenuItem
            //
            moveMenuItem.Name = "moveMenuItem";
            moveMenuItem.Size = new Size(128, 22);
            moveMenuItem.Text = "Многопоточность";
            moveMenuItem.Click += moveMenuItem_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(500, 461);
            Controls.Add(menuStrip1);
            Controls.Add(deleteAnimalButton);
            Controls.Add(editAnimalButton);
            Controls.Add(listBoxAnimals);
            Controls.Add(addAnimalButton);
            Controls.Add(moveButton);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(500, 500);
            Name = "MainForm";
            Text = "Список животных";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

      
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem addMenuItem;
        private ToolStripMenuItem editMenuItem;
        private ToolStripMenuItem deleteMenuItem;
        private ToolStripMenuItem infoMenuItem;
        private ToolStripMenuItem moveMenuItem;
    }
}


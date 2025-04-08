using System;
using System.Windows.Forms;

namespace Animals
{
    public partial class MovementForm : Form
    {
        // КОНТРОЛЫ формы
        private Panel panelDisplay;            // Область для отображения (если нужно)
        private Button btnCreate;             // Кнопка "Создать объекты"
        private Button btnStart;              // Кнопка "Старт"
        private Button btnPause;              // Кнопка "Пауза"
        private Button btnResume;             // Кнопка "Продолжить"
        private Button btnStop;               // Кнопка "Стоп"
        private ComboBox comboBoxPriority;    // Смена приоритета потоков
        private StatusStrip statusStrip;      // Статусная строка
        private ToolStripStatusLabel statusLabel; // Надпись в статус-строке
        // Объявляем два отдельных элемента для статусной строки:
        private System.Windows.Forms.ToolStripStatusLabel statusLabelChaotic;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelCircle;




        private void InitializeComponent()
        {
            panelDisplay = new Panel();
            btnCreate = new Button();
            btnStart = new Button();
            btnPause = new Button();
            btnResume = new Button();
            btnStop = new Button();
            comboBoxPriority = new ComboBox();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // panelDisplay
            // 
            panelDisplay.BorderStyle = BorderStyle.FixedSingle;
            panelDisplay.Location = new Point(12, 12);
            panelDisplay.Name = "panelDisplay";
            panelDisplay.Size = new Size(500, 400);
            panelDisplay.TabIndex = 0;
            panelDisplay.Resize += panelDisplay_Resize;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(530, 12);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(100, 30);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "Создать";
            btnCreate.Click += btnCreate_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(530, 52);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(100, 30);
            btnStart.TabIndex = 2;
            btnStart.Text = "Старт";
            btnStart.Click += btnStart_Click;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(530, 92);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(100, 30);
            btnPause.TabIndex = 3;
            btnPause.Text = "Пауза";
            // 
            // btnResume
            // 
            btnResume.Location = new Point(530, 132);
            btnResume.Name = "btnResume";
            btnResume.Size = new Size(100, 30);
            btnResume.TabIndex = 4;
            btnResume.Text = "Продолжить";
            // 
            // btnStop
            // 
            btnStop.Location = new Point(530, 172);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(100, 30);
            btnStop.TabIndex = 5;
            btnStop.Text = "Стоп";
            // 
            // comboBoxPriority
            // 
            comboBoxPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPriority.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            comboBoxPriority.Location = new Point(530, 220);
            comboBoxPriority.Name = "comboBoxPriority";
            comboBoxPriority.Text = "Скорость";
            comboBoxPriority.Size = new Size(100, 23);
            comboBoxPriority.TabIndex = 6;
            // 
            // statusStrip
            // 
            //statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
            //statusStrip.Location = new Point(0, 428);
            //statusStrip.Name = "statusStrip";
            //statusStrip.Size = new Size(641, 22);
            //statusStrip.TabIndex = 7;

            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabelChaotic = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelCircle = new System.Windows.Forms.ToolStripStatusLabel();

            // Настройка первого индикатора (хаотичные животные)
            this.statusLabelChaotic.Name = "statusLabelChaotic";
            this.statusLabelChaotic.Size = new System.Drawing.Size(200, 17);
            this.statusLabelChaotic.Text = "Хаотичные: неизвестно";

            // Настройка второго индикатора (круговые животные)
            this.statusLabelCircle.Name = "statusLabelCircle";
            this.statusLabelCircle.Size = new System.Drawing.Size(200, 17);
            this.statusLabelCircle.Text = "Круговые: неизвестно";

            // Добавляем оба элемента в статусную строку:
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelChaotic,
            this.statusLabelCircle});

            // Добавляем StatusStrip в коллекцию Controls формы:
            this.Controls.Add(this.statusStrip);

            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(48, 17);
            statusLabel.Text = "Готово.";
            // 
            // MovementForm
            // 
            ClientSize = new Size(641, 450);
            Controls.Add(panelDisplay);
            Controls.Add(btnCreate);
            Controls.Add(btnStart);
            Controls.Add(btnPause);
            Controls.Add(btnResume);
            Controls.Add(btnStop);
            Controls.Add(comboBoxPriority);
            Controls.Add(statusStrip);
            Name = "MovementForm";
            Text = "Multi-Threaded Animals";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
    }
}

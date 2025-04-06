using System;
using System.Windows.Forms;

namespace Animal
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

        public MovementForm() => InitializeComponent();

        private void InitializeComponent()
        {
            // Инициируем компоненты
            this.panelDisplay = new Panel();
            this.btnCreate = new Button();
            this.btnStart = new Button();
            this.btnPause = new Button();
            this.btnResume = new Button();
            this.btnStop = new Button();
            this.comboBoxPriority = new ComboBox();
            this.statusStrip = new StatusStrip();
            this.statusLabel = new ToolStripStatusLabel();

            // ---------- FORM ----------
            this.SuspendLayout(); // Временно приостанавливаем логику лейаута
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Multi-Threaded Animals";

            // ---------- panelDisplay ----------
            this.panelDisplay.Location = new System.Drawing.Point(12, 12);
            this.panelDisplay.Size = new System.Drawing.Size(500, 400);
            this.panelDisplay.BorderStyle = BorderStyle.FixedSingle;
            // Тут будут «бегать» животные (PictureBox'ы или рисование в Paint)

            // ---------- btnCreate ----------
            this.btnCreate.Location = new System.Drawing.Point(530, 12);
            this.btnCreate.Size = new System.Drawing.Size(100, 30);
            this.btnCreate.Text = "Создать";
            // this.btnCreate.Click += new EventHandler(this.btnCreate_Click);

            // ---------- btnStart ----------
            this.btnStart.Location = new System.Drawing.Point(530, 52);
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.Text = "Старт";
            // this.btnStart.Click += new EventHandler(this.btnStart_Click);

            // ---------- btnPause ----------
            this.btnPause.Location = new System.Drawing.Point(530, 92);
            this.btnPause.Size = new System.Drawing.Size(100, 30);
            this.btnPause.Text = "Пауза";
            // this.btnPause.Click += new EventHandler(this.btnPause_Click);

            // ---------- btnResume ----------
            this.btnResume.Location = new System.Drawing.Point(530, 132);
            this.btnResume.Size = new System.Drawing.Size(100, 30);
            this.btnResume.Text = "Продолжить";
            // this.btnResume.Click += new EventHandler(this.btnResume_Click);

            // ---------- btnStop ----------
            this.btnStop.Location = new System.Drawing.Point(530, 172);
            this.btnStop.Size = new System.Drawing.Size(100, 30);
            this.btnStop.Text = "Стоп";
            // this.btnStop.Click += new EventHandler(this.btnStop_Click);

            // ---------- comboBoxPriority ----------
            this.comboBoxPriority.Location = new System.Drawing.Point(530, 220);
            this.comboBoxPriority.Size = new System.Drawing.Size(100, 23);
            // Список вариантов приоритета
            this.comboBoxPriority.Items.AddRange(new object[] { "Lowest", "BelowNormal", "Normal", "AboveNormal", "Highest" });
            this.comboBoxPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxPriority.SelectedIndex = 2; // Normal по умолчанию
            // this.comboBoxPriority.SelectedIndexChanged += new EventHandler(this.comboBoxPriority_SelectedIndexChanged);

            // ---------- statusStrip & statusLabel ----------
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusLabel.Text = "Готово.";
            this.statusStrip.Items.Add(this.statusLabel);

            // ------- Добавляем контролы на форму -------
            this.Controls.Add(this.panelDisplay);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.comboBoxPriority);
            this.Controls.Add(this.statusStrip);

            this.ResumeLayout(false);
            this.PerformLayout(); // Включаем лейаут назад
        }
    }
}

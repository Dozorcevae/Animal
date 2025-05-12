using System;
using System.Linq;
using System.Windows.Forms;
using Animals.Domain;                // AnimalCollection, BaseAnimal
using Animals.Simulation;            // SimulationManager
using Animals.Simulation.Strategies; // ChaoticMovement, CircularMovement
using Animals.Simulation.Exchange;
namespace Animals.WinForms
{
    public partial class MainForm : Form
    {
        private readonly AnimalCollection _collection = new();
        private readonly SimulationManager _sim = new();

        private TcpExchangeService? _tcpSvc;
        public MainForm()
        {
            InitializeComponent();

            classCombo.DataSource = Enum.GetValues(typeof(AnimalClass));

            _sim.Start();                    // фоновая петля симуляции
            //connect to serv 127 0 0 1
            _tcpSvc = new TcpExchangeService("127.0.0.1", 5555, _collection);

            // обработчики событий от сервиса
            _tcpSvc.ClientsChanged += ids => BeginInvoke(() =>
                                peerCombo.DataSource = ids.Where(i => i != _tcpSvc.ClientId).ToList());

            _tcpSvc.ExchangeCompleted += () => BeginInvoke(UpdateAnimalList);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateAnimalList();
        }

        private void addAnimalButton_Click(object sender, EventArgs e)
        {
            using var dlg = new AddAnimalForm(_collection, _sim);
            if (dlg.ShowDialog() == DialogResult.OK) UpdateAnimalList();
        }

        private void editAnimalButton_Click(object sender, EventArgs e)
        {
            var animal = GetSelectedAnimal();
            if (animal == null) return;

            using var dlg = new AddAnimalForm(_collection, _sim, animal);
            if (dlg.ShowDialog() == DialogResult.OK) UpdateAnimalList();
        }

        private void deleteAnimalButton_Click(object sender, EventArgs e)
        {
            var animal = GetSelectedAnimal();
            if (animal == null) return;

            var ok = MessageBox.Show("Удалить выбранное животное?",
                                     "Подтверждение",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
            if (ok == DialogResult.Yes)
            {
                _collection.Remove(animal);
                UpdateAnimalList();
            }
        }

        private void moveButton_Click(object sender, EventArgs e) => ShowMovement();
        private void moveMenuItem_Click(object sender, EventArgs e) => ShowMovement();

        private void ShowAboutDialog(object s, EventArgs e)
        {
            MessageBox.Show(
                "Программа для внесения информации о животных\n" +
                "Разработано Дозорцевой Еленой, ДТ-360а",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ShowMovement()
        {
            using var mv = new MovementForm(_sim);
            mv.ShowDialog();
        }

        private BaseAnimal? GetSelectedAnimal()
        {
            int idx = listBoxAnimals.SelectedIndex;
            if (idx < 0)
            {
                MessageBox.Show("Сначала выберите животное из списка.");
                return null;
            }
            return _collection.ElementAt(idx);
        }

        private void UpdateAnimalList()
        {
            listBoxAnimals.Items.Clear();
            foreach (var a in _collection)
                listBoxAnimals.Items.Add($"{a.Species} ({a.AnimalClass}) – {a.AverageWeight} кг");
        }

        private void exchangeButton_Click(object sender, EventArgs e)
        {
            if (_tcpSvc == null) return;

            if (peerCombo.SelectedItem is not int peerId)
            {
                MessageBox.Show("Нет выбранного клиента.");
                return;
            }

            _tcpSvc.SelectedPeerId = peerId;
            var cls = (AnimalClass)classCombo.SelectedItem!;
            _tcpSvc.ExchangeByClass(_collection, null!, cls);
        }

    }
}

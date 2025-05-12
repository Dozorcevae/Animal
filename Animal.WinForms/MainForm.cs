// Animals.WinForms / MainForm.cs
using System;
using System.Linq;
using System.Windows.Forms;
using Animals.Domain;                // AnimalCollection, BaseAnimal
using Animals.Simulation;            // SimulationManager
using Animals.Simulation.Strategies; // ChaoticMovement, CircularMovement

namespace Animals.WinForms
{
    public partial class MainForm : Form
    {
        private readonly AnimalCollection _collection = new();
        private readonly SimulationManager _sim = new();

        public MainForm()
        {
            InitializeComponent();
            _sim.Start();                    // фоновая петля симуляции
        }

        // ========== ЖИЗНЕННЫЙ ЦИКЛ ФОРМЫ ==========

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateAnimalList();
        }

        // ========== КНОПКИ / МЕНЮ ==========

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

        // ========== ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ==========

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
    }
}

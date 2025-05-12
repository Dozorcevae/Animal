using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Animals.Domain;
using Animals.Simulation;
using Animals.Simulation.Strategies;

namespace Animals.WinForms
{
    public partial class AddAnimalForm : Form
    {
        private readonly AnimalCollection _collection;
        private readonly SimulationManager _sim;
        private readonly BaseAnimal? _animalToEdit;
        private readonly bool _isEdit;

        public AddAnimalForm(AnimalCollection col, SimulationManager sim)
        {
            InitializeComponent();
            _collection = col;
            _sim = sim;
            comboClass.DataSource = Enum.GetValues(typeof(AnimalClass)); // заполняем выпадающий список
        }

        public AddAnimalForm(AnimalCollection col, SimulationManager sim, BaseAnimal toEdit)
            : this(col, sim)
        {
            _animalToEdit = toEdit;
            _isEdit = true;

            textBoxSpecies.Text = toEdit.Species;
            comboClass.SelectedItem = toEdit.AnimalClass;
            textBoxWeight.Text = toEdit.AverageWeight.ToString();
            textBoxHabitats.Text = string.Join(",", toEdit.Habitats);
            addButton.Text = "Сохранить";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                var species = textBoxSpecies.Text.Trim();
                var cls = (AnimalClass)comboClass.SelectedItem!;

                if (!double.TryParse(textBoxWeight.Text.Replace(',', '.'),
                                     System.Globalization.NumberStyles.Float,
                                     System.Globalization.CultureInfo.InvariantCulture,
                                     out var weight))
                    throw new FormatException("Вес должен быть числом.");

                if (weight <= 0)
                    throw new InvalidWeightException("Вес должен быть положительным.");

                var habitats = new List<string>();
                foreach (var h in textBoxHabitats.Text.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    habitats.Add(h.Trim());

                if (_isEdit && _animalToEdit != null)
                {
                    _animalToEdit.Species = species;
                    _animalToEdit.AnimalClass = cls;
                    _animalToEdit.AverageWeight = weight;
                    _animalToEdit.Habitats = habitats;
                }
                else
                {
                    var animal = new ChaoticAnimal
                    {
                        Species = species,
                        AnimalClass = cls,
                        AverageWeight = weight,
                        Habitats = habitats,
                        Movement = new ChaoticMovement()
                    };
                    _collection.Add(animal);
                    _sim.Add(animal);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}

// Animals.WinForms / AddAnimalForm.cs
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Animals.Domain;                       // BaseAnimal, AnimalCollection
using Animals.Domain.Interfaces;            // IMovementStrategy
using Animals.Simulation;                   // SimulationManager
using Animals.Simulation.Strategies;        // ChaoticMovement

namespace Animals.WinForms
{
    public partial class AddAnimalForm : Form
    {
        private readonly AnimalCollection _collection;
        private readonly SimulationManager _sim;          // можно передавать null
        private readonly BaseAnimal? _animalToEdit;
        private readonly bool _isEditMode;

        // режим "добавить"
        public AddAnimalForm(AnimalCollection collection, SimulationManager sim)
        {
            InitializeComponent();
            _collection = collection;
            _sim = sim;
            MinimumSize = new System.Drawing.Size(316, 289);
        }

        // режим "редактировать"
        public AddAnimalForm(AnimalCollection collection,
                             SimulationManager sim,
                             BaseAnimal animalToEdit) : this(collection, sim)
        {
            _animalToEdit = animalToEdit;
            _isEditMode = true;

            textBoxSpecies.Text = animalToEdit.Species;
            textBoxClass.Text = animalToEdit.AnimalClass;
            textBoxWeight.Text = animalToEdit.AverageWeight.ToString();
            textBoxHabitats.Text = string.Join(",", animalToEdit.Habitats);
            addButton.Text = "Сохранить";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                string species = textBoxSpecies.Text.Trim();
                string animalClass = textBoxClass.Text.Trim();
                if (!double.TryParse(textBoxWeight.Text.Replace(',', '.'),
                                     System.Globalization.NumberStyles.Float,
                                     System.Globalization.CultureInfo.InvariantCulture,
                                     out double weight))
                {
                    throw new FormatException("Вес должен быть числом.");
                }

                var habitats = new List<string>();
                foreach (var h in textBoxHabitats.Text.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    habitats.Add(h.Trim());

                if (_isEditMode && _animalToEdit != null)
                {
                    _animalToEdit.Species = species;
                    _animalToEdit.AnimalClass = animalClass;
                    _animalToEdit.AverageWeight = weight;
                    _animalToEdit.Habitats = habitats;
                }
                else
                {
                    var newAnimal = new ChaoticAnimal
                    {
                        Species = species,
                        AnimalClass = animalClass,
                        AverageWeight = weight,
                        Habitats = habitats,
                        Movement = new ChaoticMovement()
                    };

                    _collection.Add(newAnimal);
                    _sim?.Add(newAnimal);        // если SimulationManager передан
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (InvalidWeightException ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Неверный формат данных: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка: {ex.Message}");
            }
        }
    }
}

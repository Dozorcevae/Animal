using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Windows.Forms;
using Animals.Models;
namespace Animals
{
    public partial class AddAnimalForm : Form
    {
        private AnimalCollection animalCollection;
        private BaseAnimal animalToEdit;
        private bool isEditMode = false;

        public AddAnimalForm(AnimalCollection animalCollection)
        {
            InitializeComponent();
            this.animalCollection = animalCollection;
            this.MinimumSize = new Size(316, 289);
        }

        public AddAnimalForm(AnimalCollection animalCollection, BaseAnimal animalToEdit) : this(animalCollection)
        {
            this.animalToEdit = animalToEdit;
            isEditMode = true;

            textBoxSpecies.Text = animalToEdit.Species;
            textBoxClass.Text = animalToEdit.AnimalClass;
            textBoxWeight.Text = animalToEdit.AverageWeigth.ToString();
            textBoxHabitats.Text = string.Join(",", animalToEdit.Habitats);
            addButton.Text = "Сохранить";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                string species = textBoxSpecies.Text;
                string animalClass = textBoxClass.Text;
                double weight = double.Parse(textBoxWeight.Text);
                var habitats = new List<string>(textBoxHabitats.Text.Split(','));

                if (isEditMode)
                {
                    animalToEdit.Species = species;
                    animalToEdit.AnimalClass = animalClass;
                    animalToEdit.AverageWeigth = weight;
                    animalToEdit.Habitats = habitats;
                }

                this.Close();
            }
            catch (InvalidWeigthException ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Неверный формат данных: " + ex.Message);
            }
        }

      
    }
}

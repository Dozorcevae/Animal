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
        public AddAnimalForm(AnimalCollection animalCollection)
        {
            InitializeComponent();
            this.animalCollection = animalCollection;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                string species = textBoxSpecies.Text;
                string animalClass = textBoxClass.Text;
                double weight = double.Parse(textBoxWeight.Text);
                var habitats = new List<string>(textBoxHabitats.Text.Split(','));

                var animal = new AnimalModel(species, animalClass, weight, habitats);
                animalCollection.Add(animal);

                MessageBox.Show("Животное добавлено, ебаное ты животное");
                ClearFields();
                this.Close();
            }
            catch(InvalidWeigthException ex)
            {
                MessageBox.Show("Ебаный ты дебил! Вот почему: " + ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Ебаный ты дебил! Вот почему: " + ex.Message);
            }
        }
        private void ClearFields()
        {
            textBoxSpecies.Text = "";
            textBoxClass.Text = "";
            textBoxWeight.Text = "";
            textBoxHabitats.Text = "";
        }
    }
}
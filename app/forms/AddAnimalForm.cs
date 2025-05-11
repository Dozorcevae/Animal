using System;
using System.Windows.Forms;
using Animals.Models;

namespace Animals
{
    public partial class AddAnimalForm : Form
    {
        private readonly AnimalCollection collection;

        public AddAnimalForm(AnimalCollection c)
        {
            collection = c;
            InitializeComponent();
            comboType.DataSource = Enum.GetValues(typeof(AnimalType));
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var animal = new AnimalModel
                {
                    Species = textSpecies.Text,
                    Type = (AnimalType)comboType.SelectedItem,
                    AverageWeight = double.Parse(textWeight.Text),
                    Habitats = new() { textHabitat.Text }
                };
                if (animal.AverageWeight <= 0)
                    throw new InvalidWeightException("Вес должен быть > 0");

                collection.Add(animal);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

using Animals.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using Animals.Models;
using System.Runtime.CompilerServices;

namespace Animals
{
    public partial class MainForm : Form
    {
        private AnimalCollection animalCollection;

        public MainForm()
        {
            InitializeComponent();
            animalCollection = new AnimalCollection();

            //this.moveButton.Click += new System.EventHandler(this.moveButton_Click);

        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateAnimalList();
        }

        private void addAnimalButton_Click(object sender, EventArgs e)
        {
            var AddForm = new AddAnimalForm(animalCollection);
            AddForm.FormClosed += (s, args) => UpdateAnimalList();
            AddForm.ShowDialog();
        }

        private void UpdateAnimalList()
        {
            listBoxAnimals.Items.Clear();
            foreach (var animal in animalCollection.GetAll())
            {
                listBoxAnimals.Items.Add(animal.GetInfo());
            }
        }

        private void deleteAnimalButton_Click(object sender, EventArgs e)
        {
            int index = listBoxAnimals.SelectedIndex;
            if (index >= 0)
            {
                var confirm = MessageBox.Show("Удалить выбранное животное?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    var animalToRemove = animalCollection.GetAt(index);
                    animalCollection.Remove(animalToRemove);
                    UpdateAnimalList();
                }
            }
            else
            {
                MessageBox.Show("Сначала выберите животное из списка.");
            }
        }
        private void editAnimalButton_Click(object sender, EventArgs e)
        {
            int index = listBoxAnimals.SelectedIndex;
            if (index >= 0)
            {
                var selectedAnimal = animalCollection.GetAt(index);
                var editForm = new AddAnimalForm(animalCollection, selectedAnimal);
                editForm.FormClosed += (s, args) => UpdateAnimalList();
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Сначала выберите животное из списка.");
            }
        }
        private void moveButton_Click(object sender, EventArgs e)
        {
            MovementForm frm = new MovementForm();
            frm.Show();
        }

        private void moveMenuItem_Click(object sender, EventArgs e)
        {
            MovementForm frm = new MovementForm();
            frm.Show();
        }

        private void ShowAboutDialog(object sendet, EventArgs e)
        {
            MessageBox.Show("Программа для внесения информации о животных\nРазработано Дозорцевой Еленой, ДТ-360а", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      
        
    }
}

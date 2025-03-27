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

namespace Animals
{
    public partial class MainForm : Form
    {
        private AnimalCollection animalCollection;

        public MainForm()
        {
            InitializeComponent();
            animalCollection = new AnimalCollection();
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
    }
}

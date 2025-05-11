using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Animals.Models;
using Animals.Networking;

namespace Animals
{
    public partial class MainForm : Form
    {
        private readonly AnimalCollection collection = new();
        private AnimalClient? client;

        public MainForm()
        {
            InitializeComponent();
            listAnimals.DisplayMember = nameof(AnimalModel.Species);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            client = new AnimalClient(collection);
            client.CollectionChanged += RefreshList;
            await client.ConnectAsync();
            RefreshList();
        }

        private void RefreshList()
        {
            if (InvokeRequired) { Invoke((Action)RefreshList); return; }
            listAnimals.DataSource = null;
            listAnimals.DataSource = collection.GetAll().ToList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using var dlg = new AddAnimalForm(collection);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                RefreshList();
                _ = client?.SyncAsync();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var sel = listAnimals.SelectedItem as AnimalModel;
            if (sel == null) return;
            collection.Remove(sel);
            RefreshList();
            _ = client?.SyncAsync();
        }

        private async void buttonExchange_Click(object sender, EventArgs e)
        {
            if (comboExchange.SelectedItem is not AnimalType type) return;
            await client!.ExchangeAsync(type);
        }
    }
}

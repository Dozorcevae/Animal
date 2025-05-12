using System;
using System.Drawing;
using System.Windows.Forms;
using Animals.Domain;
using Animals.Simulation;

namespace Animals.WinForms
{
    public partial class MovementForm : Form
    {
        private readonly SimulationManager _sim;

        public MovementForm(SimulationManager sim)
        {
            _sim = sim;
            InitializeComponent();
            paintTimer.Start();
        }

        private void paintTimer_Tick(object sender, EventArgs e)
        {
            panelDisplay.Invalidate();
        }

        private void panelDisplay_Paint(object sender, PaintEventArgs e)
        {
            foreach (var a in _sim.Snapshot())
            {
                var brush = a is ChaoticAnimal ? Brushes.Red : Brushes.Blue;
                e.Graphics.FillEllipse(brush, (float)a.X, (float)a.Y, 6, 6);
            }
        }
    }
}

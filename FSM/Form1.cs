using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FsmAssembly;

namespace FSM
{
    public partial class Form1 : Form
    {
        protected ThreadSafeRandom _threadRandom = new ThreadSafeRandom(13370);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerateName_Click(object sender, EventArgs e)
        {
            lblGeneratedName.Text =
                CultureInfo.CurrentCulture.TextInfo.ToTitleCase(RandomNameGenerator.GenerateName(_threadRandom, 4, 5) + " the " +
                //RandomNameGenerator.PickStringFromList(_threadRandom, StringListEnum.Color) + "-colored " +
                RandomNameGenerator.PickStringFromList(_threadRandom, StringListEnum.Adjective) + " " +
                RandomNameGenerator.PickStringFromList(_threadRandom, StringListEnum.Verb) + " " +
                RandomNameGenerator.PickStringFromList(_threadRandom, StringListEnum.Animal));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            INameGenerating nameGenerator = new NameGenerator(_threadRandom);
            var network = new FsmNetwork(nameGenerator);
            var ensemble = network.AddFsmEnsemble();
            var fsmInput = ensemble.AddFsmInput();
            fsmInput.AddStateValue("Papper");
            fsmInput.AddStateValue("Sten");
            fsmInput.AddStateValue("Påse");
            var fsmOutput = ensemble.AddFsmOutput();
            fsmOutput.AddStateValue("Äpple");
            fsmOutput.AddStateValue("Päron");
            fsmOutput.AddStateValue("Apelsin");
            var fsm = ensemble.AddFsm();
            fsm.ReceiveSignalFrom(fsmInput);
            fsm.SendSignalTo(fsmOutput);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFADependencyInjection.Models;
using WFADependencyInjection.Models.Characters;

namespace WFADependencyInjection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GamerCharacter gamer = new GamerCharacter(new Warrior());

            gamer.combo();

            GamerCharacter gamer2 = new GamerCharacter(new Assassin());

            gamer2.combo();

            GamerCharacter gamer3 = new GamerCharacter(new Archer());
            GamerCharacter gamer4 = new GamerCharacter(new Mage());

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}

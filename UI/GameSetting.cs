using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class GameSetting : Form
    {
        public GameSetting()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (PlayerTwoName.Enabled)
            {
                PlayerTwoName.Enabled = false;
            }
            else
            {
                PlayerTwoName.Enabled = true;
            }
        }

        public string FirstPlayerName
        {
            get { return m_FirstPlyerName; }
            set { m_FirstPlyerName = value; }
        }

        public string SecondPlayerName
        {
            get { return m_SecondPlyerName; }
            set { m_SecondPlyerName = value; }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            int numOfPlayers;
            if (isNamesAreFilled())
            {
                m_FirstPlyerName = PlayerOneName.Text + ": ";
                if (PlayerTwoExistsCheckBox.Checked)
                {
                    numOfPlayers = 2;
                    m_SecondPlyerName = PlayerTwoName.Text + ": ";
                }
                else
                {
                    numOfPlayers = 1; 
                    m_SecondPlyerName = "computer: ";
                }

                this.Dispose();
                GameUI gameBoard = new GameUI(numOfPlayers, (int)NumOfRowsChoice.Value, (int)NumOfColsChoice.Value);
                gameBoard.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Please enter player's name");
            }
        }

        private bool isNamesAreFilled()
        {
            return (!PlayerOneName.Text.Equals(string.Empty) && !PlayerTwoExistsCheckBox.Checked) ||
                (!PlayerOneName.Text.Equals(string.Empty) && !PlayerTwoName.Text.Equals(string.Empty));
        }        
    }
}

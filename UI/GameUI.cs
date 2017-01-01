using System.Diagnostics;
using System;
using System.Windows.Forms;
using GameLogic;

namespace UI
{
    public partial class GameUI : Form
    {
        private GameManager m_GameManager;

        public GameUI(int i_NumOfPlayers, int i_NumOfRows, int i_NumOfCols)
        {
            m_GameManager = new GameManager(i_NumOfPlayers, i_NumOfRows, i_NumOfCols);
            m_GameManager.Board.OnMoveDone += Board_OnMoveDone;
            m_GameManager.Board.OnWonGame += Board_OnWonGame;
            m_GameManager.Board.OnColDisabled += Board_OnColDisabled;
            m_GameManager.Board.OnTie += Board_OnTie;    
            InitializeComponent(i_NumOfRows, i_NumOfCols);
        }

        private void Board_OnTie()
        {
            DialogResult dialogResult = MessageBox.Show("Tie! Another round?", "A Tie!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                newGame();
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
        }

        private void Board_OnColDisabled(int i_Col)
        {
            m_ButtonsForPlay[i_Col].Enabled = false;
        }

        private void move(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int colToInsert = int.Parse(button.Text) - 1;
            Debug.Print(colToInsert.ToString());
            m_GameManager.move(colToInsert, m_GameManager.CurrentPlayer);
        }

        private void Board_OnWonGame(Board.ePlayer i_Player)
        {
            string theWinner = (i_Player == Board.ePlayer.PlayerOne ? 1 : 2).ToString();
            if (m_GameManager.GameMode == eGameMode.SinglePlayer && theWinner.Equals("2"))
            {
                theWinner = "Computer";
            }

            DialogResult dialogResult = MessageBox.Show(string.Format("Player {0} won!{1}Another round?", theWinner, Environment.NewLine), "A Win!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                handleWin(i_Player);
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
        }

        private void handleWin(Board.ePlayer i_PlayerWhoWon)
        {
            if (i_PlayerWhoWon == Board.ePlayer.PlayerOne)
            {
                m_FirstPlayerScore.Text = (int.Parse(m_FirstPlayerScore.Text) + 1).ToString();
            }
            else
            {
                m_SecondPlayerScore.Text = (int.Parse(m_SecondPlayerScore.Text) + 1).ToString();
            }

            newGame();
        }

        private void newGame()
        {
            m_GameManager.Board.InitializeBoard();
            foreach (Button button in m_ButtonsForPlay)
            {
                button.Enabled = true;
            }

            foreach (Button button in m_ButtonsArray)
            {
                button.Text = string.Empty;
            }
        }

        private void Board_OnMoveDone(int i_Row, int i_Col, Board.ePlayer i_Player)
        {
            int rowSize = m_ButtonsArray.GetLength(0);
            m_ButtonsArray[rowSize - i_Row - 1, i_Col].Text = (i_Player == Board.ePlayer.PlayerOne) ? "X" : "O";
        }
    }
}

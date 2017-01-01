using System.Windows.Forms;
using System;

namespace UI
{
    public partial class GameUI
    {
        private const int k_SizeOfButtonsArrayX = 30;
        private const int k_SizeOfButtonsArrayY = 30;
        private const int k_SizeOfButtonsForPlayX = 30;
        private const int k_SizeOfButtonsForPlayY = 20;
        private const int k_MarginBetweenButtonsX = 10;
        private const int k_MarginBetweenButtonsY = 10;
        private Button[,] m_ButtonsArray;
        private Button[] m_ButtonsForPlay;
        private Label m_FirstPlayerScore;
        private Label m_SecondPlayerScore;

        private void InitializeComponent(int i_NumOfRows, int i_NumOfCols)
        {
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Text = "4 in a Row!";
            m_ButtonsForPlay = new Button[i_NumOfCols];
            m_ButtonsArray = new Button[i_NumOfRows, i_NumOfCols];

            initializeButtonsForPlay(i_NumOfCols);
            initializeButtonsArray(i_NumOfRows, i_NumOfCols);
            initializeLabels(i_NumOfRows, i_NumOfCols);
        }

        private void initializeLabels(int i_NumOfRows, int i_NumOfCols)
        {
            Label firstPlayerLbael;
            Label secondPlayerLabel;

            // Label - player1
            firstPlayerLbael = new Label();
            firstPlayerLbael.AutoSize = true;
            firstPlayerLbael.Size = new System.Drawing.Size(48, 13);
            firstPlayerLbael.TabIndex = 1;
            firstPlayerLbael.Text = Program.UI.FirstPlayerName;
            this.Controls.Add(firstPlayerLbael);

            // Label - player2 (or computer)
            secondPlayerLabel = new Label();
            secondPlayerLabel.AutoSize = true;
            secondPlayerLabel.Size = new System.Drawing.Size(48, 13);
            secondPlayerLabel.TabIndex = 1;
            secondPlayerLabel.Text = Program.UI.SecondPlayerName;
            this.Controls.Add(secondPlayerLabel);

            // Label - player1 score
            m_FirstPlayerScore = new Label();
            m_FirstPlayerScore.AutoSize = true;
            m_FirstPlayerScore.Size = new System.Drawing.Size(30, 30);
            m_FirstPlayerScore.TabIndex = 1;
            m_FirstPlayerScore.Text = "0";
            this.Controls.Add(m_FirstPlayerScore);

            // Label - second player score
            m_SecondPlayerScore = new Label();
            m_SecondPlayerScore.AutoSize = true;
            m_SecondPlayerScore.Size = new System.Drawing.Size(30, 30);
            m_SecondPlayerScore.TabIndex = 1;
            m_SecondPlayerScore.Text = "0";
            this.Controls.Add(m_SecondPlayerScore);

            // Set the screens size according to the users choice for num of rows&cols
            Width = i_NumOfCols * k_SizeOfButtonsArrayX + (i_NumOfCols + 1) * k_MarginBetweenButtonsX + 15;
            Height = k_SizeOfButtonsForPlayY + (i_NumOfRows + 1) * k_SizeOfButtonsArrayY + i_NumOfRows * k_MarginBetweenButtonsY + firstPlayerLbael.Height + 15;
            
            // Set the labels of the names in the middle of the screen
            firstPlayerLbael.Location = new System.Drawing.Point(Width / 2 - firstPlayerLbael.Width - m_FirstPlayerScore.Width - k_MarginBetweenButtonsX, m_ButtonsArray[i_NumOfRows - 1, 0].Location.Y + k_MarginBetweenButtonsY + k_SizeOfButtonsArrayY);
            secondPlayerLabel.Location = new System.Drawing.Point(Width / 2, m_ButtonsArray[i_NumOfRows - 1, 0].Location.Y + k_MarginBetweenButtonsY + k_SizeOfButtonsArrayY);
            m_FirstPlayerScore.Location = new System.Drawing.Point(firstPlayerLbael.Location.X + firstPlayerLbael.Size.Width, firstPlayerLbael.Location.Y);
            m_SecondPlayerScore.Location = new System.Drawing.Point(secondPlayerLabel.Location.X + secondPlayerLabel.Size.Width, secondPlayerLabel.Location.Y);
        }

        private void initializeButtonsForPlay(int i_NumOfCols)
        {
            for (int i = 0; i < i_NumOfCols; i++)
            {
                m_ButtonsForPlay[i] = new Button();
                m_ButtonsForPlay[i].Location = new System.Drawing.Point(k_MarginBetweenButtonsX + (k_SizeOfButtonsForPlayX + k_MarginBetweenButtonsX) * i, 2);              
                m_ButtonsForPlay[i].Size = new System.Drawing.Size(k_SizeOfButtonsForPlayX, k_SizeOfButtonsForPlayY);              
                m_ButtonsForPlay[i].Text = (i + 1).ToString();        
                this.Controls.Add(m_ButtonsForPlay[i]);
                m_ButtonsForPlay[i].Click += new EventHandler(this.move);
            }
        }

        private void initializeButtonsArray(int i_NumOfRows, int i_NumOfCols)
        {
            for (int i = 0; i < i_NumOfRows; i++)
            {
                for (int j = 0; j < i_NumOfCols; j++)
                {
                    m_ButtonsArray[i, j] = new Button();
                    m_ButtonsArray[i, j].Location = new System.Drawing.Point(k_MarginBetweenButtonsX + (k_MarginBetweenButtonsX + k_SizeOfButtonsArrayX) * j, 30 + (k_SizeOfButtonsArrayY + k_MarginBetweenButtonsY) * i);
                    m_ButtonsArray[i, j].Size = new System.Drawing.Size(k_SizeOfButtonsArrayX, k_SizeOfButtonsArrayY);
                    m_ButtonsArray[i, j].Text = string.Empty;
                    this.Controls.Add(m_ButtonsArray[i, j]);
                }
            }
        }
    }
}
using static GameLogic.Board;

namespace GameLogic
{
    // Delegates
    public delegate void MoveDone(int i_Row, int i_Col, ePlayer i_Player);

    public delegate void WonGame(ePlayer i_Player);

    public delegate void ColDisabled(int i_Col);

    public delegate void Tie();

    public class Board
    {
        // Events       
        public event MoveDone OnMoveDone;

        public event WonGame OnWonGame;

        public event ColDisabled OnColDisabled;

        public event Tie OnTie;

        // Params
        private readonly int m_BoardRow;
        private readonly int m_BoardColumn;
        private int m_BoardFreeSpace;
        private eBoardMarks[,] m_Board;

        // Constructor
        public Board(int i_BoardRow, int i_BoardColumn)
        {
            this.m_BoardFreeSpace = i_BoardRow * i_BoardColumn;
            this.m_BoardRow = i_BoardRow;
            this.m_BoardColumn = i_BoardColumn;
            this.m_Board = new eBoardMarks[m_BoardRow, m_BoardColumn];
        }

        // Getter for BoardColumn
        public int BoardColumn
        {
            get { return m_BoardColumn; }
        }

        // Cleaning the board for new game
        public void InitializeBoard()
        {
            m_BoardFreeSpace = m_BoardRow * m_BoardColumn;
            m_Board = new eBoardMarks[m_BoardRow, m_BoardColumn];
        }

        // Player choose column to insert mark
        public bool EnterMove(int i_ColumnToMark, ePlayer i_Player)
        {
            bool validMoveFlag = m_Board[m_BoardRow - 1, i_ColumnToMark] == eBoardMarks.Empty; 
                                                                                                
            if (validMoveFlag)
            {
                int freeRowIndex = getFreeCellInColumn(i_ColumnToMark);
                m_Board[freeRowIndex, i_ColumnToMark] = i_Player == ePlayer.PlayerOne ? eBoardMarks.PlayerOne : eBoardMarks.PlayerTwo;
                m_BoardFreeSpace--;
                invokeUIFunctions(freeRowIndex, i_ColumnToMark, i_Player);
            }

            return validMoveFlag;
        }

        // Invoking the logical on the UI
        private void invokeUIFunctions(int i_FreeRowIndex, int i_ColumnToMark, ePlayer i_Player)
        {
            OnMoveDone.Invoke(i_FreeRowIndex, i_ColumnToMark, i_Player);

            if (i_FreeRowIndex == m_BoardRow - 1)
            {
                OnColDisabled.Invoke(i_ColumnToMark);
            }

            if (GameIsWon(i_Player, i_FreeRowIndex, i_ColumnToMark))
            {
                OnWonGame.Invoke(i_Player);
            }
            else if(m_BoardFreeSpace == 0)
            {
                OnTie.Invoke();
            }
        }

        // Getting the board spot in the column which is empty
        private int getFreeCellInColumn(int i_ColumnToMark)
        {
            for (int i = 0; i < m_BoardRow; i++)
            {
                if (m_Board[i, i_ColumnToMark] == eBoardMarks.Empty)
                {
                    return i;
                }
            }

            return -1;
        }

        // Check if bingo
        public bool GameIsWon(ePlayer i_Player, int i_Row, int i_Col)
        {
            return isWinRow(i_Player, i_Row, i_Col) ||
                isWinCol(i_Player, i_Row, i_Col) ||
                isWinMainDiagonal(i_Player, i_Row, i_Col) ||
                isThereWinningSecondaryDiagonal(i_Player, i_Row, i_Col);
        }

        // Check if bingo in row
        private bool isWinRow(ePlayer i_Player, int i_Row, int i_Col)
        {
            eBoardMarks valueToCheck = i_Player == ePlayer.PlayerOne ? eBoardMarks.PlayerOne : eBoardMarks.PlayerTwo;
            int counterOfSequence = 0, currentCol = i_Col;

            while (currentCol < m_BoardColumn && m_Board[i_Row, currentCol] == valueToCheck)
            {
                counterOfSequence++;
                currentCol++;
            }

            currentCol = i_Col - 1; 
                                  
            while (currentCol >= 0 && m_Board[i_Row, currentCol] == valueToCheck)
            {
                counterOfSequence++;
                currentCol--;
            }

            return counterOfSequence >= 4;
        }
     
        // Check if bingo in Column
        private bool isWinCol(ePlayer i_Player, int i_Row, int i_Col)
        {
            eBoardMarks valueToCheck = i_Player == ePlayer.PlayerOne ? eBoardMarks.PlayerOne : eBoardMarks.PlayerTwo;
            int counterOfSequence = 0, currentRow = i_Row;
         
            while (currentRow < m_BoardRow && m_Board[currentRow, i_Col] == valueToCheck)
            {
                counterOfSequence++;
                currentRow++;
            }

            currentRow = i_Row - 1; 

            while (currentRow >= 0 && m_Board[currentRow, i_Col] == valueToCheck)
            {
                counterOfSequence++;
                currentRow--;
            }

            return counterOfSequence >= 4;
        }

        // Check if bingo in diagonal /
        private bool isWinMainDiagonal(ePlayer i_Player, int i_Row, int i_Col)
        {
            eBoardMarks valueToCheck = i_Player == ePlayer.PlayerOne ? eBoardMarks.PlayerOne : eBoardMarks.PlayerTwo;
            int counterOfSequence = 0, currentRow = i_Row, currentCol = i_Col;
            
            while (currentRow < m_BoardRow && currentCol < m_BoardColumn && m_Board[currentRow, currentCol] == valueToCheck)
            {
                counterOfSequence++;
                currentRow++;
                currentCol++;
            }

            currentRow = i_Row - 1; 
            currentCol = i_Col - 1;
            
            while (currentRow >= 0 && currentCol >= 0 && m_Board[currentRow, currentCol] == valueToCheck)
            {
                counterOfSequence++;
                currentRow--;
                currentCol--;
            }

            return counterOfSequence >= 4;
        }

        // Check if bingo in diagonal \
        private bool isThereWinningSecondaryDiagonal(ePlayer i_Player, int i_Row, int i_Col)
        {
            eBoardMarks valueToCheck = i_Player == ePlayer.PlayerOne ? eBoardMarks.PlayerOne : eBoardMarks.PlayerTwo;
            int counterOfSequence = 0, currentRow = i_Row, currentCol = i_Col;
            
            while (currentRow < m_BoardRow && currentCol >= 0 && m_Board[currentRow, currentCol] == valueToCheck)
            {
                counterOfSequence++;
                currentRow++;
                currentCol--;
            }

            currentRow = i_Row - 1; 
            currentCol = i_Col + 1;

            while (currentRow >= 0 && currentCol < m_BoardColumn && m_Board[currentRow, currentCol] == valueToCheck)
            {
                counterOfSequence++;
                currentRow--;
                currentCol++;
            }

            return counterOfSequence >= 4;
        }

        // Check if the column is full
        public bool IsColumnFull(int i_Column)
        {
            bool isFull = true;
            if(m_Board[m_BoardRow - 1, i_Column + 1] == eBoardMarks.Empty)
            {
                isFull = false;
            }

            return isFull;
        }

        // Check if board is full
        public bool BoardIsFull()
        {
            return m_BoardFreeSpace == 0;
        }      

        public enum ePlayer
        {
            PlayerOne = 1,
            PlayerTwo = 2,
        }

        public enum eBoardMarks
        {
            Empty,
            PlayerOne,
            PlayerTwo,
        }
    }
}

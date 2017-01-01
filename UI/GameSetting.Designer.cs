namespace UI
{
    public partial class GameSetting
    {
        private static string m_FirstPlyerName;
        private static string m_SecondPlyerName;
       
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LablePlayers = new System.Windows.Forms.Label();
            this.LablePlayerOne = new System.Windows.Forms.Label();
            this.LablePlayerTwo = new System.Windows.Forms.Label();
            this.LableRows = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.LableCols = new System.Windows.Forms.Label();
            this.PlayerTwoExistsCheckBox = new System.Windows.Forms.CheckBox();
            this.PlayerOneName = new System.Windows.Forms.TextBox();
            this.PlayerTwoName = new System.Windows.Forms.TextBox();
            this.NumOfColsChoice = new System.Windows.Forms.NumericUpDown();
            this.NumOfRowsChoice = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfColsChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfRowsChoice)).BeginInit();
            this.SuspendLayout();
            // 
            // LablePlayers
            // 
            this.LablePlayers.AutoSize = true;
            this.LablePlayers.Location = new System.Drawing.Point(24, 18);
            this.LablePlayers.Name = "LablePlayers";
            this.LablePlayers.Size = new System.Drawing.Size(41, 13);
            this.LablePlayers.TabIndex = 0;
            this.LablePlayers.Text = "Players";
            // 
            // LablePlayerOne
            // 
            this.LablePlayerOne.AutoSize = true;
            this.LablePlayerOne.Location = new System.Drawing.Point(34, 55);
            this.LablePlayerOne.Name = "LablePlayerOne";
            this.LablePlayerOne.Size = new System.Drawing.Size(48, 13);
            this.LablePlayerOne.TabIndex = 1;
            this.LablePlayerOne.Text = "Player 1:";         
            // 
            // LablePlayerTwo
            // 
            this.LablePlayerTwo.AutoSize = true;
            this.LablePlayerTwo.Location = new System.Drawing.Point(24, 150);
            this.LablePlayerTwo.Name = "LablePlayerTwo";
            this.LablePlayerTwo.Size = new System.Drawing.Size(61, 13);
            this.LablePlayerTwo.TabIndex = 3;
            this.LablePlayerTwo.Text = "Board Size:";
            // 
            // LableRows
            // 
            this.LableRows.AutoSize = true;
            this.LableRows.Location = new System.Drawing.Point(34, 181);
            this.LableRows.Name = "LableRows";
            this.LableRows.Size = new System.Drawing.Size(34, 13);
            this.LableRows.TabIndex = 4;
            this.LableRows.Text = "Rows";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(27, 220);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(224, 29);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Start!";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // LableCols
            // 
            this.LableCols.AutoSize = true;
            this.LableCols.Location = new System.Drawing.Point(163, 181);
            this.LableCols.Name = "LableCols";
            this.LableCols.Size = new System.Drawing.Size(30, 13);
            this.LableCols.TabIndex = 6;
            this.LableCols.Text = "Cols:";
            // 
            // PlayerTwoExistsCheckBox
            // 
            this.PlayerTwoExistsCheckBox.AutoSize = true;
            this.PlayerTwoExistsCheckBox.Location = new System.Drawing.Point(37, 81);
            this.PlayerTwoExistsCheckBox.Name = "PlayerTwoExistsCheckBox";
            this.PlayerTwoExistsCheckBox.Size = new System.Drawing.Size(67, 17);
            this.PlayerTwoExistsCheckBox.TabIndex = 7;
            this.PlayerTwoExistsCheckBox.Text = "Player 2:";
            this.PlayerTwoExistsCheckBox.UseVisualStyleBackColor = true;
            this.PlayerTwoExistsCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // PlayerOneName
            // 
            this.PlayerOneName.Location = new System.Drawing.Point(129, 52);
            this.PlayerOneName.Name = "PlayerOneName";
            this.PlayerOneName.Size = new System.Drawing.Size(100, 20);
            this.PlayerOneName.TabIndex = 8;
            // 
            // PlayerTwoName
            // 
            this.PlayerTwoName.Enabled = false;
            this.PlayerTwoName.Location = new System.Drawing.Point(129, 79);
            this.PlayerTwoName.Name = "PlayerTwoName";
            this.PlayerTwoName.Size = new System.Drawing.Size(100, 20);
            this.PlayerTwoName.TabIndex = 9;
            // 
            // NumOfColsChoice
            // 
            this.NumOfColsChoice.Location = new System.Drawing.Point(196, 179);
            this.NumOfColsChoice.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumOfColsChoice.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumOfColsChoice.Name = "NumOfColsChoice";
            this.NumOfColsChoice.Size = new System.Drawing.Size(33, 20);
            this.NumOfColsChoice.TabIndex = 11;
            this.NumOfColsChoice.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // NumOfRowsChoice
            // 
            this.NumOfRowsChoice.Location = new System.Drawing.Point(74, 179);
            this.NumOfRowsChoice.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumOfRowsChoice.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumOfRowsChoice.Name = "NumOfRowsChoice";
            this.NumOfRowsChoice.Size = new System.Drawing.Size(33, 20);
            this.NumOfRowsChoice.TabIndex = 12;
            this.NumOfRowsChoice.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // GameSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 261);
            this.Controls.Add(this.NumOfRowsChoice);
            this.Controls.Add(this.NumOfColsChoice);
            this.Controls.Add(this.PlayerTwoName);
            this.Controls.Add(this.PlayerOneName);
            this.Controls.Add(this.PlayerTwoExistsCheckBox);
            this.Controls.Add(this.LableCols);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.LableRows);
            this.Controls.Add(this.LablePlayerTwo);
            this.Controls.Add(this.LablePlayerOne);
            this.Controls.Add(this.LablePlayers);
            this.Name = "GameSetting";
            this.Text = "OpeningUI";
            ((System.ComponentModel.ISupportInitialize)(this.NumOfColsChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfRowsChoice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion      
        private System.Windows.Forms.Label LablePlayers;
        private System.Windows.Forms.Label LablePlayerOne;
        private System.Windows.Forms.Label LablePlayerTwo;
        private System.Windows.Forms.Label LableRows;
        private System.Windows.Forms.Label LableCols;
        private System.Windows.Forms.Button StartButton;       
        private System.Windows.Forms.CheckBox PlayerTwoExistsCheckBox;
        private System.Windows.Forms.TextBox PlayerOneName;
        private System.Windows.Forms.TextBox PlayerTwoName;
        private System.Windows.Forms.NumericUpDown NumOfColsChoice;
        private System.Windows.Forms.NumericUpDown NumOfRowsChoice;      
    }
}
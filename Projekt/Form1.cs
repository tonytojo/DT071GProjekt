using Projekt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;

namespace Projekt
{
/// <summary>
/// This class take care of running a successful Knighttour
/// Node we add a dummy item to array because I want to start with index 1
/// </summary>
    public partial class Form1 : Form
    {
        string[] aToh = {"dummy", "a", "b", "c", "d", "e", "f", "g", "h" };
        string[] eightToone = {"dummy", "1", "2", "3", "4", "5", "6", "7", "8" };
        const int tileSize = 80;
        const int SQUARES_ON_CHESSBOARD = 64;
        const int MAX = 8;
        const int MIN = 1;
        Panel[,] chessBoardPanels;
        int sekvensCounter;
        int minimumValue = 99;
        int[] cell = new int[2];
        const int gridSize = 9;
        List<ChessMove> chessMoves = new List<ChessMove>();
     

        /// <summary>
        /// C-tor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            cboRad.Text = "1";
            cboCol.Text = "a";
            cboRad.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCol.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPersons.DropDownStyle = ComboBoxStyle.DropDownList;

            cboPersons.Items.Clear();
            GetKnightTourPerson();
            lstMoves.Items.Clear();
        }

        /// <summary>
        /// Is called when the form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateChessBoard();
        }

        /// <summary>
        /// Create the chessboard GUI
        /// </summary>
        private void CreateChessBoard()
        {
            //Some local variables
            var clr1 = System.Drawing.ColorTranslator.FromHtml("#63b8ff");
            var clr2 = System.Drawing.ColorTranslator.FromHtml("#c6e2ff");

            //The size of the form
            this.Size = new Size(1000, 1000);

            // Initialize the "chess board"
            chessBoardPanels = new Panel[gridSize, gridSize];

            // Double for loop to handle all rows and columns
            for (var n = 1; n < gridSize; n++) //Columns
            {
                for (var m = 1; m < gridSize; m++) //Rows
                {
                    // Create new Panel control which will be one cell in the chessboard
                    var newPanel = new Panel
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(tileSize * n + 200, tileSize * m + 100)
                    };

                    //Add the column that say 1 to 8
                    AddCol1To8(m);

                    // Add newPanel to Form's Controls so that they show up
                    Controls.Add(newPanel);

                    //Add the final row that say a to h
                    AddRowAToH(n);

                    // add to our 2d array of panels for future use
                    chessBoardPanels[n, m] = newPanel;

                    //Add border for each cell
                    chessBoardPanels[n, m].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

                    // Change color to alternate color for the backgrounds
                    if (n % 2 == 0)
                        newPanel.BackColor = m % 2 != 0 ? clr1 : clr2;
                    else
                        newPanel.BackColor = m % 2 != 0 ? clr2 : clr1;
                }
            }
        }

        /// <summary>
        /// Add the bottom row a to h. Used for positioning
        /// </summary>
        /// <param name="n">The column index to use for adding a character</param>
        private void AddRowAToH(int n)
        {
            Label lbl2 = new Label();
            lbl2.AutoSize = false;
            lbl2.TextAlign = ContentAlignment.MiddleCenter;
            lbl2.Text = aToh[n];
            lbl2.Location = new Point(80 * n + 200, 640 + 180);
            lbl2.Font = new Font("Arial", 14, FontStyle.Regular);
            lbl2.Size = new Size(tileSize, tileSize);
            lbl2.BackColor = System.Drawing.ColorTranslator.FromHtml("#cfcfcf");
            lbl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Controls.Add(lbl2);
        }

        /// <summary>
        ///  Add the side column 1 to 8. Used for positioning
        /// </summary>
        /// <param name="m">The row index to use for adding a character</param>
        private void AddCol1To8(int m)
        {
            Label lbl3 = new Label();
            lbl3.AutoSize = false;
            lbl3.TextAlign = ContentAlignment.MiddleCenter;
            lbl3.Text = eightToone[m];
            lbl3.Location = new Point(200, 80 * m + 100);
            lbl3.Font = new Font("Arial", 14, FontStyle.Regular);
            lbl3.Size = new Size(tileSize, tileSize);
            lbl3.BackColor = System.Drawing.ColorTranslator.FromHtml("#cfcfcf");
            lbl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Controls.Add(lbl3);
        }

        /// <summary>
        /// This is the main engine for runing the KnightTour
        /// </summary>
        private void ProcessKnightTour()
        {
            //Get the row and column data from the input field which was input by the user
            int rad = int.Parse(cboRad.Text); //1-8
            int col = cboCol.Text[0] - 96; //a-h[1-8]

            //Username must be entered
            if (String.IsNullOrEmpty(txtNamn.Text))
            {
                MessageBox.Show("Då måste ange ditt namn i detta fält");
                return;
            }

            // Start with placeing the horse where the user choose
            PositionHorseOnBoard(rad, col);
            chessMoves.Add(new ChessMove() { Rad = rad, Col = aToh[col] });

            // Keep looping and position the horse on all 64 cells without going to same cell twice
            // Now the algoritm is the following to start with. Go to all the places where the
            // horse can go to and from each place count how many free places the horse can go to
            // from there.
            // If we go down and to the right we have + and if we go up och to the left we have -
            // A horse can go to eight places but sometimes some of these will be outside the 
            // chessboard

            for (int i = 1; i < SQUARES_ON_CHESSBOARD; i++)
            {
                // We go clockwise starting at top
                CheckCountMin(GoToAllEightPositions(rad - 2, col - 1), rad - 2, col - 1);  //Up 2, Left 1
                CheckCountMin(GoToAllEightPositions(rad - 2, col + 1), rad - 2, col + 1);  //Up 2, Right 1
                CheckCountMin(GoToAllEightPositions(rad - 1, col + 2), rad - 1, col + 2);  //Up 1, Right 2
                CheckCountMin(GoToAllEightPositions(rad + 1, col + 2), rad + 1, col + 2);  //Down 1, Right 2
                CheckCountMin(GoToAllEightPositions(rad + 2, col + 1), rad + 2, col + 1);  //Down 2, Right 1 
                CheckCountMin(GoToAllEightPositions(rad + 2, col - 1), rad + 2, col - 1);  //Down 2, Left 1
                CheckCountMin(GoToAllEightPositions(rad + 1, col - 2), rad + 1, col - 2);  //Down 1, Left 1
                CheckCountMin(GoToAllEightPositions(rad - 1, col - 2), rad - 1, col - 2);  //Up 1, Left 1
                minimumValue = 99;


                //The new calculated position to place the horse on
                rad = cell[0];
                col = cell[1];
                PositionHorseOnBoard(rad, col);
                chessMoves.Add(new ChessMove() { Rad = rad, Col = aToh[col] });
            }

            //Save the knighttour in the db
            SaveKnightTour();

            //Get the persons that has run the knighttour and display on the form
            GetKnightTourPerson();
        }

        /// <summary>
        /// Ask the db for the persons that has run the Knighttour and present the 
        /// result in the form
        /// </summary>
        private void GetKnightTourPerson()
        {
            DatabaseAPI dbapi = new DatabaseAPI();
            DataTable dt = dbapi.GetKnightTourPerson();
            cboPersons.Items.Clear();

            if (dt.Rows.Count > 0)
            {
               cboPersons.Items.Add("Select ...");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cboPersons.Items.Add(new ComboBoxItem(dt.Rows[i]["id"].ToString(), dt.Rows[i]["Name"].ToString(), dt.Rows[i]["Created"].ToString()));
                }
                cboPersons.SelectedIndex = 0;
            }
        }
        

        /// <summary>
        /// Save all 64 moves into the database
        /// </summary>
        private void SaveKnightTour()
        {
            DatabaseAPI dbapi = new DatabaseAPI();
            dbapi.InsertIntoDb(txtNamn.Text, chessMoves);
        }

        /// <summary>
        /// Count how many free places the horse can go to if it is positioned on passed rad, col 
        /// if rad or col is <= 0 or > 8 then return
        /// A horse can go to eight places some are out of the chessboard
        /// </summary>
        /// <param name="rad">The rad the horse is positioned at.</param>
        /// <param name="col">The column the horse is positioned at</param>
        private int GoToAllEightPositions(int rad, int col)
        {
            //Precondition if rad or col is <= 0 eller > 8 return
            if (rad > 0 && col > 0 && rad < 9 && col < 9)
            {
                int CountValidPositions = 0;


                //Special handling when find the index for the last mode the 64
                if (sekvensCounter == 63 && chessBoardPanels[col, rad].Controls.Count == 0)
                {
                    CountValidPositions++;
                }


                // We go clockwise starting at top
                if (ValidateRC(rad - 2, col - 1)) // Up 2,Left 1
                {
                    if (chessBoardPanels[col - 1, rad - 2].Controls.Count == 0) 
                        CountValidPositions++;
                }

                if (ValidateRC(rad - 2, col + 1)) // Up 2, Right 1
                {
                    if (chessBoardPanels[col + 1, rad - 2].Controls.Count == 0)
                        CountValidPositions++;
                }

                if (ValidateRC(rad - 1, col + 2)) // Up 1, Right 2
                {
                    if (chessBoardPanels[col + 2, rad - 1].Controls.Count == 0)
                        CountValidPositions++;
                }

                if (ValidateRC(rad + 1, col + 2)) // Down 1, Right 2
                {
                    if (chessBoardPanels[col + 2, rad + 1].Controls.Count == 0)
                        CountValidPositions++;
                }

                if (ValidateRC(rad + 2, col + 1)) // Down 2, Right 1
                {
                    if (chessBoardPanels[col + 1, rad + 2].Controls.Count == 0)
                        CountValidPositions++;
                }

                if (ValidateRC(rad + 2, col - 1)) // Down 2, left 1
                {
                    if (chessBoardPanels[col - 1, rad + 2].Controls.Count == 0)
                        CountValidPositions++;
                }

                if (ValidateRC(rad + 1, col - 2)) // Down 1, left 2
                {
                    if (chessBoardPanels[col - 2, rad + 1].Controls.Count == 0)
                        CountValidPositions++;
                }

                if (ValidateRC(rad - 1, col - 2)) // Up 1, left 2
                {
                    if (chessBoardPanels[col - 2, rad - 1].Controls.Count == 0)
                        CountValidPositions++;
                }

                return CountValidPositions;
            }
            else
                return 0;
        }

        /// <summary>
        /// This method will set a new minimumValue if validPositions is less then minimumValue
        /// We just return if validPositions is zero
        /// </summary>
        /// <param name="ValidPositions">The number if valid positions to go to for these rad and col</param>
        /// <param name="rad">The rad position for the horse</param>
        /// <param name="col">The column position for the horse</param>
        private void CheckCountMin(int validPositions, int rad, int col)
        {
            if (validPositions == 0)
                return;

            if (chessBoardPanels[col,rad].Controls.Count == 0)
            {
                if (validPositions < minimumValue)
                {
                    minimumValue = validPositions;
                    cell[0] = rad;
                    cell[1] = col;
                }
            }
        }

        /// <summary>
        /// Validate rad and column againt MIN and MAX
        /// </summary>
        /// <param name="col"></param>
        /// <param name="rad"></param>
        /// <returns></returns>
        private bool ValidateRC(int rad, int col)
        {
            return rad >= MIN && rad <= MAX && col >= MIN && col <= MAX; 
        }

       /// <summary>
       /// Position the horse on the chessboard at the passed position col, row
       /// </summary>
       /// <param name="rad">The row the horse should be at</param>
       /// <param name="column">The column the horse should be at</param>
        private void PositionHorseOnBoard(int row, int col)
        {
            Label lbl = new Label();
            lbl.Font = new Font("Verdana", 16, FontStyle.Regular);
            lbl.Text = (++sekvensCounter).ToString();
            chessBoardPanels[col, row].Controls.Add(lbl);
        }

      

        /// <summary>
        /// Clear the chessboard
        /// </summary>
        private void ClearChessBard()
        {
            for (var n = 1; n < gridSize; n++) //Columns
            {
                for (var m = 1; m < gridSize; m++) //Rows
                {
                    chessBoardPanels[n, m].Controls.Clear();
                }
            }
        }

        /// <summary>
        /// Show all the moves that the horse has made for this simulation of KnightTour
        /// </summary>
        /// <param name="id">The persons id who run the simulation</param>
        private void GetKnightToursMoves(int id)
        {
            DatabaseAPI dbapi = new DatabaseAPI();
            DataTable dt = dbapi.GetKnightToursMoves(id);
            lstMoves.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lstMoves.Items.Add(i+1 + "  " + dt.Rows[i]["Row"].ToString() + ", "+ dt.Rows[i]["Col"].ToString());
            }
        }


        /// <summary>
        /// Eventhandler to start the computer to complete a successful knighttour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpela_Click(object sender, EventArgs e)
        {
            sekvensCounter = 0;
            ProcessKnightTour();
        }

        /// <summary>
        /// Event handler for handling to clear the chessboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearChessBard();
            txtNamn.Text = "";
            cboRad.SelectedIndex = 0;
            cboCol.SelectedIndex = 0;

            lstMoves.Items.Clear();
            cboPersons.SelectedIndex = 0;
        }

        /// <summary>
        /// Eventhandler that is called as soon as you select another index in the comboxox for personsn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPersons_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Clear the array that keep all the moves
            chessMoves.Clear();
            if (!cboPersons.SelectedItem.ToString().StartsWith("Select"))
            {
                //Get the id for selected person you want to see all athe moves
                int idValue = int.Parse(((ComboBoxItem)cboPersons.SelectedItem).HiddenValue);
                GetKnightToursMoves(idValue);
            }
        }
    }
}

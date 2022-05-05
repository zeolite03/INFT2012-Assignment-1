﻿namespace BlakeEastwoodAssgt
{
    //see if this edit is here
    public partial class Game : Form
    {
        Random Rnd = new Random();
        MainMenu main = new MainMenu();
        PlayerInfo[] TurnOrder;
        int TurnCounter = 0;
        Boolean BidRound = false; //when its false its roll round and when its true its bidding
        int NoOfDieBid = 0;
        int dieBid = 0;
        Graphics graDieCurr;

        GameInfo game1;
        
        public Game(GameInfo gamein)
        {
            InitializeComponent();
            game1 = gamein;
            TurnOrder = new PlayerInfo[game1.TotalPlayers];
            graDieCurr = DieFaceCurr.CreateGraphics();


        }

        //
        // all the internal function for the game class. including the turn system
        //
        #region game funtions

        private int GetCurPlayer()
        {
            int TempNumIndex = 0;
            while (TurnOrder[TempNumIndex].GetCurrentPlayer() != true)
            {
                TempNumIndex++;
            }
            return TempNumIndex;
        }

        //starts the game and generates the players
        private void Startgame(int PlayersIn, int AI_In)
        {
            
           
            //creates the first player which will be the user.
            TurnOrder[0] = new PlayerInfo(1, true);
            

            //generates the human players into an array that handles the turn order 
            for (int i = 1; i <= PlayersIn-1; i++)
            {
                TurnOrder[i] = new PlayerInfo(1, false);
                
            }
            //generates the Ai players into an array that handles the turn order 
            int PAfterHumans = AI_In + PlayersIn -1;
            for (int i = PlayersIn ; i <= PAfterHumans ; i++)
            {
                TurnOrder[i] = new PlayerInfo(2, false);     
            }
            PlayerInfo[] TempArray = new PlayerInfo[game1.TotalPlayers];
            for (int i = 0; i < game1.TotalPlayers; i++)
            {
                
                int RandInt = Rnd.Next(0, game1.TotalPlayers);
                while (TempArray[RandInt] != null)
                {
                    RandInt = Rnd.Next(0, game1.TotalPlayers);
                }
                TempArray[RandInt] = TurnOrder[i];
            }
            
            Array.Copy(TempArray, TurnOrder, game1.TotalPlayers);




                //needs a function here to randomize the order of the array so that the order of the players and AI is randomized
                StartTurn();
        }

        //starts the turn process 
        private void StartTurn()
        {
            // loads the current player into current dice pictures
            //currently only does player 1
            
            for (int i = 0; i < TurnOrder[TurnCounter].GetPlayerDiceLeft(); i++)
            {
                LoadCurrentPlayer(i, TurnOrder[TurnCounter].GetRolls(i)) ;
            }
            //displays the number of each pip amount of dice
            SortDiceVal(TurnOrder[1]);
            
        }

        private void EndTurn()
        {
            if (TurnCounter != game1.TotalPlayers -1)
            {
                TurnCounter++;
                TurnOrder[TurnCounter].SetCurrentPlayer();
            }    
            else
            {
                TurnCounter = 0;
                TurnOrder[TurnCounter].SetCurrentPlayer();
                /*if (BidRound == false)
                {
                    //Start bid function
                }
                else
                {
                   */ 
               // }
            }
            DieNumTxt.Text = "";
            graDieCurr.Clear(Color.White);
            StartTurn();

        }
        


        private void SortDiceVal(PlayerInfo PlayerIn)
        {
            int[] Dicecount = new int[6];
            for (int i = 0; i < PlayerIn.GetPlayerDiceLeft(); i++)
            {
                    switch (PlayerIn.GetRolls(i))
                    {
                        case 1: Dicecount[1]++; break;
                        case 2: Dicecount[2]++; break;
                        case 3: Dicecount[3]++; break;
                        case 4: Dicecount[4]++; break;
                        case 5: Dicecount[5]++; break;
                        case 6: Dicecount[6]++; break;
                    }
            }

            CurrDieStats.Text ="number of: "+"\r\n"
            + "1's:       " + Dicecount[1] + "\r\n"
            + "2's:       " + Dicecount[2] + "\r\n"
            + "3's:       " + Dicecount[3] + "\r\n"
            + "4's:       " + Dicecount[4] + "\r\n"
            + "5's:       " + Dicecount[5] + "\r\n"
            + "6's:       " + Dicecount[6] + "\r\n";
        }

        #endregion
        //
        // Loading Dice values into picture box functions
        //
        #region load dice display


        void LoadCurrentPlayer(int dice, int roll)
        {

            switch (dice)
            {
                case 0:
                    Graphics Cd1 = CD1.CreateGraphics();
                    Cd1.Clear(Color.White);
                    CreateDice(Cd1, roll);
                    break;
                case 1:
                    Graphics Cd2 = CD2.CreateGraphics();
                    Cd2.Clear(Color.White);
                    CreateDice(Cd2, roll);
                    break;
                case 2:
                    Graphics Cd3 = CD3.CreateGraphics();
                    CreateDice(Cd3, roll);
                    break;
                case 3:
                    Graphics Cd4 = CD4.CreateGraphics();
                    CreateDice(Cd4, roll);
                    break;
                case 4:
                    Graphics Cd5 = CD5.CreateGraphics();
                    CreateDice(Cd5, roll);
                    break;
            }

        }



        void LoadPlayer(int PlayerNum ,int dice, int roll)
        {
            switch (PlayerNum)
            {
                case 0:
                    P1(dice, roll);
                    break;
                case 1:
                    P2(dice, roll);
                    break;
                case 2:
                    P3(dice, roll);
                    break;
                case 3:
                    P4(dice, roll);
                    break;
                case 4:
                    P5(dice, roll);
                    break;
                case 5:
                    P6(dice, roll);
                    break;
            }

        }

        private void P1(int dice, int roll)
        {
            switch (dice)
            {
                case 0:
                    Graphics p1d1 = P1D1.CreateGraphics();
                    CreateDice(p1d1, roll);
                    break;
                case 1:
                    Graphics p1d2 = P1D2.CreateGraphics();
                    CreateDice(p1d2 , roll);
                    break;
                case 2:
                    Graphics p1d3 = P1D3.CreateGraphics();
                    CreateDice (p1d3 , roll);
                    break;
                case 3:
                    Graphics p1d4 = P1D4.CreateGraphics();
                    CreateDice (p1d4 , roll);
                    break;
                case 4:
                    Graphics p1d5 = P1D5.CreateGraphics();
                    CreateDice (p1d5 , roll);
                    break;
            }
        }
        private void P2(int dice, int roll)
        {
            switch (dice)
            {
                case 0:
                    Graphics p2d1 = P2D1.CreateGraphics();
                    CreateDice(p2d1, roll);
                    break;
                case 1:
                    Graphics p2d2 = P2D2.CreateGraphics();
                    CreateDice(p2d2, roll);
                    break;
                case 2:
                    Graphics p2d3 = P2D3.CreateGraphics();
                    CreateDice(p2d3, roll);
                    break;
                case 3:
                    Graphics p2d4 = P2D4.CreateGraphics();
                    CreateDice(p2d4, roll);
                    break;
                case 4:
                    Graphics p2d5 = P2D5.CreateGraphics();
                    CreateDice(p2d5, roll);
                    break;
            }
        }

        private void P3(int dice, int roll)
        {
            switch (dice)
            {
                case 0:
                    Graphics p3d1 = P3D1.CreateGraphics();
                    CreateDice(p3d1, roll);
                    break;
                case 1:
                    Graphics p3d2 = P3D2.CreateGraphics();
                    CreateDice(p3d2, roll);
                    break;
                case 2:
                    Graphics p3d3 = P3D3.CreateGraphics();
                    CreateDice(p3d3, roll);
                    break;
                case 3:
                    Graphics p3d4 = P3D4.CreateGraphics();
                    CreateDice(p3d4, roll);
                    break;
                case 4:
                    Graphics p3d5 = P3D5.CreateGraphics();
                    CreateDice(p3d5, roll);
                    break;
            }
        }

        private void P4(int dice, int roll)
        {
            switch (dice)
            {
                case 0:
                    Graphics p4d1 = P4D1.CreateGraphics();
                    CreateDice(p4d1, roll);
                    break;
                case 1:
                    Graphics p4d2 = P4D2.CreateGraphics();
                    CreateDice(p4d2, roll);
                    break;
                case 2:
                    Graphics p4d3 = P4D3.CreateGraphics();
                    CreateDice(p4d3, roll);
                    break;
                case 3:
                    Graphics p4d4 = P4D4.CreateGraphics();
                    CreateDice(p4d4, roll);
                    break;
                case 4:
                    Graphics p4d5 = P4D5.CreateGraphics();
                    CreateDice(p4d5, roll);
                    break;
            }
        }

        private void P5(int dice, int roll)
        {
            switch (dice)
            {
                case 0:
                    Graphics p5d1 = P5D1.CreateGraphics();
                    CreateDice(p5d1, roll);
                    break;
                case 1:
                    Graphics p5d2 = P5D2.CreateGraphics();
                    CreateDice(p5d2, roll);
                    break;
                case 2:
                    Graphics p5d3 = P5D3.CreateGraphics();
                    CreateDice(p5d3, roll);
                    break;
                case 3:
                    Graphics p5d4 = P5D4.CreateGraphics();
                    CreateDice(p5d4, roll);
                    break;
                case 4:
                    Graphics p5d5 = P5D5.CreateGraphics();
                    CreateDice(p5d5, roll);
                    break;
            }
        }

        private void P6(int dice, int roll)
        {
            switch (dice)
            {
                case 0:
                    Graphics p6d1 = P6D1.CreateGraphics();
                    CreateDice(p6d1, roll);
                    break;
                case 1:
                    Graphics p6d2 = P6D2.CreateGraphics();
                    CreateDice(p6d2, roll);
                    break;
                case 2:
                    Graphics p6d3 = P6D3.CreateGraphics();
                    CreateDice(p6d3, roll);
                    break;
                case 3:
                    Graphics p6d4 = P6D4.CreateGraphics();
                    CreateDice(p6d4, roll);
                    break;
                case 4:
                    Graphics p6d5 = P6D5.CreateGraphics();
                    CreateDice(p6d5, roll);
                    break;
            }
        }









      
        // this function is going to take the number of dice the player has left and roll the by calling create dice
        private void DisplayDie( int iCount, int roll)
        {
            
           
            
            
            switch (iCount)
            {
                case 0:
                    //dice 1
                        Graphics graDie1 = CD1.CreateGraphics();
                        //creates the graphic for the picture box then passes into the create dice function
                        CreateDice(graDie1, roll);
                        
                        break;
                case 1:

                    //Dice 2
                        
                        Graphics graDie2 = CD2.CreateGraphics();
                        CreateDice(graDie2, roll);
                        
                        break;
                case 2:
                    //Dice 3
                        
                        Graphics graDie3 = CD3.CreateGraphics();
                        CreateDice(graDie3, roll);
                        
                        break;
                case 3: 
                    //Dice 4
                       
                        Graphics graDie4 = CD4.CreateGraphics();
                        CreateDice(graDie4, roll);
                       
                        break;

                //Dice 5
                case 4:
                        Graphics graDie5 = CD5.CreateGraphics();
                        CreateDice(graDie5, roll);
                        break;
                        
                }
            }
        


        //creates trhe picture of the dice based on the amount rolled
        private void CreateDice(Graphics graDie, int roll)
        {
            
            graDie.Clear(Color.White);
           
            switch (roll)
            {
                

                case 1:
                    graDie.DrawRectangle(Pens.Black, 0, 0, 50, 50);
                    graDie.FillEllipse(Brushes.Black, 24, 24, 5, 5);
                    break;

                case 2:
                    graDie.DrawRectangle(Pens.Black, 0, 0, 50, 50);
                    graDie.FillEllipse(Brushes.Black, 12, 24, 5, 5);
                    graDie.FillEllipse(Brushes.Black, 36, 24, 5, 5);
                    break;

                case 3:
                    graDie.DrawRectangle(Pens.Black, 0, 0, 50, 50);
                    graDie.FillEllipse(Brushes.Black, 24, 24, 5, 5);
                    graDie.FillEllipse(Brushes.Black, 12, 12, 5, 5);
                    graDie.FillEllipse(Brushes.Black, 36, 36, 5, 5);
                    break;

                case 4:
                    graDie.DrawRectangle(Pens.Black, 0, 0, 50, 50);
                    graDie.FillEllipse(Brushes.Black, 12, 12, 5, 5);
                    graDie.FillEllipse(Brushes.Black, 36, 36, 5, 5);
                    graDie.FillEllipse(Brushes.Black, 12, 36, 5, 5);
                    graDie.FillEllipse(Brushes.Black, 36, 12, 5, 5);
                    break;

                case 5:

                    graDie.DrawRectangle(Pens.Black, 0, 0, 50, 50);
                    graDie.FillEllipse(Brushes.Black, 12, 12, 5, 5);
                    graDie.FillEllipse(Brushes.Black, 36, 36, 5, 5);
                    graDie.FillEllipse(Brushes.Black, 12, 36, 5, 5);
                    graDie.FillEllipse(Brushes.Black, 36, 12, 5, 5);
                    graDie.FillEllipse(Brushes.Black, 25, 25, 5, 5);
                    break;

                case 6:

                    graDie.DrawRectangle(Pens.Black, 0, 0, 50, 50);
                    graDie.FillEllipse(Brushes.Black, 12, 12, 5, 5);
                    graDie.FillEllipse(Brushes.Black, 36, 36, 5, 5);
                    graDie.FillEllipse(Brushes.Black, 12, 36, 5, 5);
                    graDie.FillEllipse(Brushes.Black, 36, 12, 5, 5);
                    graDie.FillEllipse(Brushes.Black, 12, 25, 5, 5);
                    graDie.FillEllipse(Brushes.Black, 36, 25, 5, 5);
                    break;
            }             
          }
        #endregion


        //
        // Button functions. methods that control what happens when you press a button
        //
        #region buttons

        private void StartBtn_click(object sender, EventArgs e)
        {
            Startgame(game1.playerCount, game1.AiCount);
        }

        private void DieNumPlus_Click(object sender, EventArgs e)
        {
            try
            {
                if (NoOfDieBid < 30)
                {
                    NoOfDieBid++;
                }
                TurnOrder[GetCurPlayer()].SetNoOfDice(NoOfDieBid);
                DieNumTxt.Text = Convert.ToString(NoOfDieBid);
            }
            catch (Exception)
            {
                MessageBox.Show("You must start the game first");
            }
        }

        private void DieNumMinus_Click(object sender, EventArgs e)
        {
            try
            {
                if (NoOfDieBid >= 2)
                {
                    NoOfDieBid--;
                }
                TurnOrder[GetCurPlayer()].SetNoOfDice(NoOfDieBid);
                DieNumTxt.Text = Convert.ToString(NoOfDieBid);
            }
            catch (Exception)
            {
                MessageBox.Show("you must start the game first");
            }
        }

        private void DieFacePlus_Click(object sender, EventArgs e)
        {
            if (dieBid <= 5)
            {
                dieBid++;
                CreateDice(graDieCurr, dieBid);
            }
            TurnOrder[GetCurPlayer()].SetDieFaceBet(dieBid);

        }

        private void DieFaceMinus_Click(object sender, EventArgs e)
        {
            if (dieBid >= 2)
            {
                dieBid--;
                CreateDice(graDieCurr, dieBid);
            }
            TurnOrder[GetCurPlayer()].SetDieFaceBet(dieBid);


        }


        
        private void BidBtn_Click(object sender, EventArgs e)
        {
            EndTurn();
        }
        #endregion

    }


}
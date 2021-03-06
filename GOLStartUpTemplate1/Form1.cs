﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOLStartUpTemplate1
{
    public partial class Form1 : Form
    {
        //seed the random generator
        Random rand = new Random(2); 
        

        // The universe array
        bool[,] universe = new bool[100, 100];
         

        // Drawing colors
        Color gridColor = Color.Black; //lines
        Color cellColor = Color.Red; //fill

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;

        // living cells count
        int alive = 0; 

        public Form1()
        {
            InitializeComponent();

            // Setup the timer
            timer.Interval = 100; // milliseconds
            timer.Tick += Timer_Tick;
                        
            timer.Enabled = false; // start timer running
            //timer.Start() or timer.Stop(); 
           
            //Main title of window. 
            this.Text = Properties.Resources.AppTitle; 

        }

        private int CountNeighbors(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);

            for (int yOffset = -1; yOffset <= 1; yOffset++) //each 3 grid column
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++) //each 3 grid row
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;

                    // if xOffset and yOffset are both equal to 0 then continue //this represents the test grid
                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }

                    // if xCheck is less than 0 then set to xLen - 1  //represents testgrid on left column, and makes the neighbor other side of universe
                    if (xCheck < 0)
                        xCheck = xLen - 1;

                    // if xCheck is greater than or equal too xLen then set to 0 //represents testgrid on right column, and makes the neighbor other side of universe
                    if (xCheck >= xLen)
                        xCheck = 0;

                    //if yCheck is less than 0 then set to yLen - 1 //represents the testgrid on the top row and ,makes it the opposite side of universe. 
                    if (yCheck < 0)
                        yCheck = yLen - 1; 

                    // if yCheck is greater than or equal too yLen then set to 0  //represents testgrid on bottom row, and makes the neighbor other side of universe
                    if (yCheck >= yLen)
                        yCheck = 0;

                    if (universe[xCheck, yCheck] == true) count++;
                }
            }
            return count;
        }
      


        private void NextGeneration()
        {
            alive = 0; 
            bool[,] scratchpad = new bool[universe.GetLength(0), universe.GetLength(1)]; //this will hold the values of the universe temporarily.
            int neighbors = 0;         
            
            // Iterate through the universe 
            for (int y = 0; y < universe.GetLength(1); y++)
            {                
                for (int x = 0; x < universe.GetLength(0); x++)
                {                    
                    neighbors = CountNeighbors(x, y);

                    //Any living cell in the current universe with less than 2 living neighbors dies in the next generation.                    
                    //Any living cell with more than 3 living neighbors will die in the next generation. 
                    //Any living cell with 2 or 3 living neighbors will live on into the next generation. 
                    //Any dead cell with exactly 3 living neighbors will be born into the next generation as if by reproduction. 

                    if (universe[x, y] == false)
                    {
                        if (neighbors == 3)
                        {
                            scratchpad[x, y] = true;
                            alive++; 
                        }                           
                    }
                     else
                    {
                        if (neighbors > 3)
                        {
                            scratchpad[x, y] = false;                                                  
                        }
                        else if (neighbors == 2 || neighbors == 3)
                        {
                            scratchpad[x, y] = true;
                            alive++; 
                        }
                        else if (neighbors < 2)
                        {
                            scratchpad[x, y] = false;                            
                        }
                     }  
                }
            }

            //bool[,] temp = universe; 
            universe = scratchpad;
            scratchpad = null;

            //update the status strip alive count 
           toolStripStatusLabel1Alive.Text = "Alive = " + alive.ToString();

            // Increment generation count
            generations++;

            // Update status strip generations
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();

            //redraw the universe 
            graphicsPanel1.Invalidate();
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration(); //iterate through universe, count neighbors, apply rules, turn cells on and off in second array, swap the arrays. 
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            //converted to floats to help with boarder gap. 
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            float cellWidth = (float)graphicsPanel1.ClientSize.Width / (float)universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            float cellHeight = (float)graphicsPanel1.ClientSize.Height / (float)universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {

                    // A rectangle to represent each cell in pixels
                    //converted to floats to help with boarder gap. 
                    RectangleF cellRect = Rectangle.Empty;
                    cellRect.X = x * (float)cellWidth;
                    cellRect.Y = y * (float)cellHeight;
                    cellRect.Width = (float)cellWidth;
                    cellRect.Height = (float)cellHeight;

                    // Fill the cell with a brush if alive
                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                    }

                    // Outline the cell with a pen
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                    //e.Graphics.DrawEllipse(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                }
            }

            //create using new, doint have to destroy usiung delete, bc of garbage collector. 
            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the width and height of each cell in pixels
                float cellWidth = (float)graphicsPanel1.ClientSize.Width / (float)universe.GetLength(0);
                float cellHeight = (float)graphicsPanel1.ClientSize.Height / (float)universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                float x = e.X / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                float y = e.Y / cellHeight;

                // Toggle the cell's state
                universe[(int)x, (int)y] = !universe[(int)x, (int)y];

                //update alive integer
                if (universe[(int)x, (int)y] == true)
                {
                    alive++;
                }
                else
                    alive--;

                //update the status strip alive count 
                toolStripStatusLabel1Alive.Text = "Alive = " + alive.ToString();

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate(); //never put this in the function paint, it will cause a paint loop. 
            }
        }

  

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //NEW BUTTON
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                //Iterate through the universe 
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    Console.WriteLine("New Button Clicked!!");
                    universe[x,y] = false;
                    generations = 0;
                    alive = 0; 
                    timer.Enabled = false;
                    //TODO: Consider a function for update status for generations and alive count
                    //// Update status strip generations and revert colors 
                    toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
                    //update the status strip alive count 
                    toolStripStatusLabel1Alive.Text = "Alive = " + alive.ToString();
                    gridColor = Color.Black;
                    cellColor = Color.Red;
                    graphicsPanel1.BackColor = Color.White;                     
                }
            }
            graphicsPanel1.Invalidate();
        }


        private void toolStripButton1Start_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            graphicsPanel1.Invalidate();
            Console.WriteLine("Start Button Clicked!!");
        }      


        private void toolStripButton2Pause_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            Console.WriteLine("Pause Button Clicked!!");
            graphicsPanel1.Invalidate();            
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create text for the version of the game and the author info.  

            ModalDialog dlg = new ModalDialog(); 
            if (DialogResult.OK == dlg.ShowDialog())
            {
                
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3Next_Click_1(object sender, EventArgs e)
        {
            NextGeneration();           
        }

        private void toolStripButton1Random_Click(object sender, EventArgs e)
        {
            alive = 0;
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    int randomNumber = rand.Next(3);
                    if (randomNumber == 0)
                    {
                        universe[x, y] = true;
                        alive++;
                    }
                    else 
                        universe[x, y] = false;
                }
            }
            graphicsPanel1.Invalidate();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void backColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = gridColor;
            
            if(DialogResult.OK == dlg.ShowDialog()) //returns true if okay/accept is selected
            {
                gridColor = dlg.Color;
                graphicsPanel1.Invalidate(); 
            }
        }

        private void cellColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = cellColor; 

            if(DialogResult.OK == dlg.ShowDialog())
            {
                cellColor = dlg.Color;
                graphicsPanel1.Invalidate(); 
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = graphicsPanel1.BackColor; 

            if (DialogResult.OK == dlg.ShowDialog())
            {
                graphicsPanel1.BackColor = dlg.Color;
                graphicsPanel1.Invalidate(); 
            }
        }



        private void fromSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModalDialog dlg = new ModalDialog();

            dlg.Seed = numericUpDown1.Value; 

            if (DialogResult.OK == dlg.ShowDialog())
            {
                numericUpDown1.Value = dlg.Seed; 
            }
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings dlg = new Settings();
            dlg.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
        }
    }
}

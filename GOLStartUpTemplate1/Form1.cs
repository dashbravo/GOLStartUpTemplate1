using System;
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
        bool[,] universe = new bool[200, 200];
         

        // Drawing colors
        Color gridColor = Color.Black; //lines
        Color cellColor = Color.Red; //fill

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;

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
        //private int CountNeighbors(int x, int y)
        //{
        //    //first define neighbors. 
        //    //enum Location {topLeft= 1, top, bottomRight, bottom  }
        //    int alive = 0;
        //    bool mate1 = false;
        //    bool mate2 = false;
        //    bool mate3 = false;
        //    bool mate4 = false;
        //    bool mate5 = false;
        //    bool mate6 = false;
        //    bool mate7 = false;
        //    bool mate8 = false;

        //    //store the values into neighbor variables.
        //    //if no neighbors, get value from other end of universe

        //    if (x == 0 & y == 0)
        //    {//top left edge modifies mate 1, 2, 3, 4, 6
        //        mate1 = universe[99, 99];
        //        mate2 = universe[98, 99];
        //        mate3 = universe[97, 99];
        //        mate4 = universe[99, 98];
        //        mate5 = universe[x + 1, y];
        //        mate6 = universe[99, 97];
        //        mate7 = universe[x, y + 1];
        //        mate8 = universe[x + 1, y + 1];
        //    }
        //    else if (x == 0 && y == 99)
        //    {//bottem left edge modifies mate 1,4,6,7,8
        //        mate1 = universe[1, 99];
        //        mate2 = universe[x, y - 1];
        //        mate3 = universe[x + 1, y - 1];
        //        mate4 = universe[2, 99];
        //        mate5 = universe[1, 0];
        //        mate6 = universe[99, 0];
        //        mate7 = universe[98, 0];
        //        mate8 = universe[97, 0];
        //    }
        //    else if (x == 99 && y == 99)
        //    {//bottom right edge modifies mate 3,5,6,7,8
        //        mate1 = universe[x - 1, y - 1];
        //        mate2 = universe[x, y - 1];
        //        mate3 = universe[2, 0];
        //        mate4 = universe[x - 1, y];
        //        mate5 = universe[1, 0];
        //        mate6 = universe[0, 2];
        //        mate7 = universe[0, 1];
        //        mate8 = universe[0, 0];
        //    }
        //    else if (x == 99 && y == 0)
        //    {//top right 
        //        mate1 = universe[97, 0];
        //        mate2 = universe[98, 0];
        //        mate3 = universe[99, 0];
        //        mate4 = universe[x - 1, y];
        //        mate5 = universe[98, 0];
        //        mate6 = universe[x - 1, y + 1];
        //        mate7 = universe[x, y + 1];
        //        mate8 = universe[97, 0];
        //    }
        //    else if (x == 0)
        //    {//left edge modifies mate 1, 4, 6
        //        mate1 = universe[99, y - 1];
        //        mate2 = universe[x, y - 1];
        //        mate3 = universe[x + 1, y - 1];
        //        mate4 = universe[99, y];
        //        mate5 = universe[x + 1, y];
        //        mate6 = universe[99, y + 1];
        //        mate7 = universe[x, y + 1];
        //        mate8 = universe[x + 1, y + 1];
        //    }
        //    else if (x == 99)
        //    {//right edge modifies mate 3, 5, 8
        //        mate1 = universe[x - 1, y - 1];
        //        mate2 = universe[x, y - 1];
        //        mate3 = universe[2, 0];
        //        mate4 = universe[x - 1, y];
        //        mate5 = universe[1, 0];
        //        mate6 = universe[x - 1, y + 1];
        //        mate7 = universe[x, y + 1];
        //        mate8 = universe[0, 0];
        //    }

        //    else if (y == 0)
        //    {//top
        //        mate1 = universe[x - 1, 99];
        //        mate2 = universe[x, 99];
        //        mate3 = universe[x + 1, 99];
        //        mate4 = universe[x - 1, y];
        //        mate5 = universe[x + 1, y];
        //        mate6 = universe[x - 1, y + 1];
        //        mate7 = universe[x, y + 1];
        //        mate8 = universe[x + 1, y + 1];
        //    }
        //    else if (y == 99)
        //    {   //bottom
        //        mate1 = universe[x - 1, y - 1];
        //        mate2 = universe[x, y - 1];
        //        mate3 = universe[x + 1, y - 1];
        //        mate4 = universe[x - 1, y];
        //        mate5 = universe[x + 1, y];
        //        mate6 = universe[x - 1, 0];
        //        mate7 = universe[x, 0];
        //        mate8 = universe[x + 1, 0];
        //    }
        //    else
        //    {
        //        //default               
        //        mate1 = universe[x - 1, y - 1];
        //        mate2 = universe[x, y - 1];
        //        mate3 = universe[x + 1, y - 1];
        //        mate4 = universe[x - 1, y];
        //        mate5 = universe[x + 1, y];
        //        mate6 = universe[x - 1, y + 1];
        //        mate7 = universe[x, y + 1];
        //        mate8 = universe[x + 1, y + 1];
        //    }

        //    //check each neighbors for alive, return total
        //    if (mate1 == true)
        //        alive++;
        //    if (mate2 == true)
        //        alive++;
        //    if (mate3 == true)
        //        alive++;
        //    if (mate4 == true)
        //        alive++;
        //    if (mate5 == true)
        //        alive++;
        //    if (mate6 == true)
        //        alive++;
        //    if (mate7 == true)
        //        alive++;
        //    if (mate8 == true)
        //        alive++;

        //    return alive;
        //}


        private void NextGeneration()
        {
            bool[,] scratchpad = new bool[universe.GetLength(0), universe.GetLength(1)]; //this will hold the values of the universe temporarily.
            int living = 0;
            // Iterate through the universe 
            for (int y = 0; y < universe.GetLength(1); y++)
            {                
                for (int x = 0; x < universe.GetLength(0); x++)
                {                    
                    living = CountNeighbors(x, y);

                    //Any living cell in the current universe with less than 2 living neighbors dies in the next generation.                    
                    //Any living cell with more than 3 living neighbors will die in the next generation. 
                    //Any living cell with 2 or 3 living neighbors will live on into the next generation. 
                    //Any dead cell with exactly 3 living neighbors will be born into the next generation as if by reproduction. 

                    if (universe[x, y] == false)
                    {
                        if (living == 3)
                            scratchpad[x, y] = true; 
                    }
                     else
                    {
                        if (living > 3)
                        {
                            scratchpad[x, y] = false;
                        }
                        else if (living == 2 || living == 3)
                        {
                            scratchpad[x, y] = true;
                        }
                        else if (living < 2)
                        {
                            scratchpad[x, y] = false;
                        }
                     }           
                }
            }

            //bool[,] temp = universe; 
            universe = scratchpad;
            scratchpad = null;


           
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
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = false;
                    generations = 0;
                    timer.Enabled = false;
                    // Update status strip generations
                    toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
                    graphicsPanel1.Invalidate();
                }
            }
        }



        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Console.WriteLine("BOOM!!");
        //    graphicsPanel1.Invalidate();
        //}

        private void toolStripButton1Start_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            graphicsPanel1.Invalidate();
            Console.WriteLine("Start Button Clicked!!");
        }

        //private int exitToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    return 0;
        //}


        private void toolStripButton3Next_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            Console.WriteLine("Next Button Clicked!!");
            graphicsPanel1.Invalidate();
        }

        private void toolStripButton2Pause_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            Console.WriteLine("Pause Button Clicked!!");
            graphicsPanel1.Invalidate();
            //Console.WriteLine("Pause Button CLicked");
            //if (timer.Enabled == true)
            //{
            //    timer.Enabled = false;
            //    graphicsPanel1.Invalidate();
            //}
            //else
            //{
            //    timer.Enabled = true;
            //    graphicsPanel1.Invalidate();
            //}
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create text for the version of the game and the author info.            
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
            
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    int randomNumber = rand.Next(3);
                    if (randomNumber == 0)
                    {
                        universe[x, y] = true;
                    }
                    else 
                        universe[x, y] = false;
                }
            }
            graphicsPanel1.Invalidate();
        }
    }
}

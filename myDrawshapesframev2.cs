using System;
using System.Drawing;
using System.Windows.Forms;

public class myDrawshapesframe : Form
{  private const int formwidth = 1600; // we will attempt to create a graphical window os size 1600x 900
   private const int formheight = 900; // valid x- coordinates: 0 - 1599 valid Y- coordinates: 0 -899.
   //for our class CPSc 223n we should use the alrgest area possible that is supported graphically on our monitors
   

   private const int upperLeftCornerXCoordinate = 100;
   private const int upperLeftCornerYCoordinate = 80;
   private const int rectangle_width = 1400;  // i assume this is for the drawn rectangle dimensions
   private const int rectangle_height = 450;
   private const int lowerRightCornerXCoordinate = upperLeftCornerXCoordinate + rectangle_width;
   private const int lowerRightCornerYCoordinate = upperLeftCornerYCoordinate + rectangle_height;

   private const int penwidth = 5;
   private Label title = new Label();                        //label for the entire program
   private Button draw_button = new Button();                // all buttons that will be used to assign shape should be created here     
   private Button erase_button = new Button();
   private Button quit_button = new Button();
   
   private Button red_button = new Button();                 //buttons to change form the three color options
   private Button blue_button = new Button();         
   private Button green_button = new Button(); 
   
   private Button circle_button = new Button();              // buttons for the three different shapes for the assighnment
   private Button triangle_button = new Button();
   private Button rectangle_button = new Button();

   private Pen ballpointpen1 = new Pen(Color.Blue,penwidth);            // create 3 pen variables so that we may draw in other colors
   private Pen ballpointpen2 = new Pen(Color.Red,penwidth);
   private Pen ballpointpen3 = new Pen(Color.Green,penwidth);

   private bool showRectangleblue = false;    //by default no rectangle or shape in general should be drawn
   private bool showCircleblue = false;    //define all possible cscenarios
   private bool showTriangleblue = false;

   private bool showRectanglered = false;    
   private bool showCirclered = false;    
   private bool showTrianglered = false;
   
   private bool showTrianglegreen = false;
   private bool showRectanglegreen = false;
   private bool showCirclegreen = false; 
 
 //  private bool showRectangle = false;    //by default no rectangle or shape in general should be drawn
 //  private bool showCircle = false;    //assume somewhere around here there needs to be other shapes that should be off by default
 //  private bool showTriangle = false;
   
   private Point location_title = new Point (700,20);                    // create a point object for our title location
   private Point location_draw_button = new Point(1200,640);            //create locations for all our buttosn so that they fit nicely
   private Point location_erase_button = new Point(1300,640);            // include all buttons for colors and shapes and options
   private Point location_quit_button = new Point(1400,640);
   private Point location_circle_button = new Point(200,640);
   private Point location_rectangle_button = new Point(300,640);
   private Point location_triangle_button = new Point(400,640);
   private Point location_red_button = new Point(650,640);
   private Point location_green_button = new Point (750,640);
   private Point location_blue_button = new Point(850, 640);
   
   
      public myDrawshapesframe()        // we are creating a class to house everythign we need for our own objects
   {  // set the title of this parivular form
      Text = "see you spacecowboy...";
      					//set the initial size for this form which we want to use the values we created above
      Size = new Size(formwidth,formheight);
      				        // set the backgorund color of this form/window
      BackColor = Color.Black;          //Backcolor allows us to be able to set background color for the form, search online for c# colors
      title.Text = "Shapes by Juan Linares";             //create title in regards to the prompt i was given
      title.Size = new Size(170,18);
      title.Location = location_title;                   //note most point of location were created beforehand so we just use them here
      title.BackColor = Color.Red;                      //select color for title back ground
      
      draw_button.Text = "Draw";                        
      draw_button.Size = new Size (85,25);              //test out button sizes so that they fit nicely amongst three groups
      draw_button.Location = location_draw_button;      //repeat previous  step for title in a similar manner for the rest of the buttons
      draw_button.BackColor = Color.Coral;
      
      erase_button.Text ="Clear";			//my erase / clear button
      erase_button.Size = new Size(85,25);
      erase_button.Location = location_erase_button;
      erase_button.BackColor = Color.YellowGreen;
      
      quit_button.Text ="Exit"; 			//exit button
      quit_button.Size = new Size(85,25);
      quit_button.Location = location_quit_button;
      quit_button.BackColor = Color.Firebrick;
      
      circle_button.Text = "Circle"; 			// here begins the buttons for the shapes cirlce,triangle, and rectangle
      circle_button.Location = location_circle_button;
      circle_button.Size = new Size (85,25);
      circle_button.BackColor = Color.White;
      
      rectangle_button.Text = "Rectangle";
      rectangle_button.Location = location_rectangle_button;
      rectangle_button.Size = new Size(85,25);
      rectangle_button.BackColor = Color.White;
      
      triangle_button.Text = "Triangle";
      triangle_button.Location = location_triangle_button; 
      triangle_button.Size = new Size(85,25);
      triangle_button.BackColor = Color.White;     

      red_button.Text = "Red";				//here we list the buttons for the pen colors we will want to use
      red_button.Location = location_red_button;
      red_button.Size = new Size(85,25);
      red_button.BackColor = Color.Red;

      blue_button.Text = "Blue";
      blue_button.Location = location_blue_button;
      blue_button.Size = new Size(85,25);
      blue_button.BackColor = Color.Aqua;
      
      green_button.Text = "Green";
      green_button.Location = location_green_button;
      green_button.Size = new Size(85,25);
      green_button.BackColor = Color.Green;

      Controls.Add(title);			// here we create a system of controls with the buttons that we had created
      Controls.Add(draw_button);		// with these buttons the user should be able to interact with the program
      Controls.Add(erase_button);		// there will be an event for every single one of these buttons
      Controls.Add(quit_button);		
      Controls.Add(circle_button);
      Controls.Add(triangle_button);
      Controls.Add(rectangle_button);
      Controls.Add(red_button);
      Controls.Add(blue_button);
      Controls.Add(green_button);
       
      blue_button.Click += new EventHandler(seerectangleblue);
      red_button.Click += new EventHandler(seerectanglered);
      green_button.Click += new EventHandler(seerectanglegreen);

      blue_button.Click += new EventHandler(seetriangleblue);
      red_button.Click += new EventHandler(seetrianglered);
      green_button.Click += new EventHandler(seetrianglegreen);

      blue_button.Click += new EventHandler(seecircleblue);
      red_button.Click += new EventHandler(seecirclered);
      green_button.Click += new EventHandler(seecirclegreen);
                                                                 //insert an id statement here for when buttons are clicked together
      rectangle_button.Click += new EventHandler(seerectangleblue);
      triangle_button.Click += new EventHandler(seetriangleblue);    // create events for when we click on the buttons seeCircle,seeTriangle
      circle_button.Click += new EventHandler(seecircleblue); 

      rectangle_button.Click += new EventHandler(seerectanglered);
      triangle_button.Click += new EventHandler(seetrianglered);    // create events for when we click on the buttons seeCircle,seeTriangle
      circle_button.Click += new EventHandler(seecirclered);

      rectangle_button.Click += new EventHandler(seerectanglegreen);
      triangle_button.Click += new EventHandler(seetrianglegreen);    // create events for when we click on the buttons seeCircle,seeTriangle
      circle_button.Click += new EventHandler(seecirclegreen);

      draw_button.Click += new EventHandler(seeshapes);
      erase_button.Click += new EventHandler(hideShapes);
      quit_button.Click += new EventHandler(closeprogram);
   
}// end of constructor and all avaibale class variables

   protected override void OnPaint(PaintEventArgs ee)
   { Graphics graph = ee.Graphics;
   
   if(showCircleblue){
   graph.DrawEllipse(ballpointpen1,600,100,400,400);
   } 

   if(showTriangleblue){
   graph.DrawLine(ballpointpen1,400,450,1200,450);
   graph.DrawLine(ballpointpen1,800,100,400,450);
   graph.DrawLine(ballpointpen1,800,100,1200,450);
   }
   
   if(showRectangleblue){ 
   graph.DrawRectangle(ballpointpen1,upperLeftCornerXCoordinate,upperLeftCornerYCoordinate,rectangle_width,rectangle_height);
   }
    

   if(showCirclered){ graph.DrawEllipse(ballpointpen2,600,100,400,400);
     }

   if(showTrianglered){
     graph.DrawLine(ballpointpen2,400,450,1200,450);
     graph.DrawLine(ballpointpen2,800,100,400,450);
     graph.DrawLine(ballpointpen2,800,100,1200,450);
    }
   if(showRectanglered){
     graph.DrawRectangle(ballpointpen2,upperLeftCornerXCoordinate,upperLeftCornerYCoordinate,rectangle_width,rectangle_height);

    }
     
   
   if(showCirclegreen){ graph.DrawEllipse(ballpointpen3,600,100,400,400);
    }

   if(showTrianglegreen){
     graph.DrawLine(ballpointpen3,400,450,1200,450);
     graph.DrawLine(ballpointpen3,800,100,400,450);
     graph.DrawLine(ballpointpen3,800,100,1200,450);
    }
   
   if(showRectanglegreen){
     graph.DrawRectangle(ballpointpen3,upperLeftCornerXCoordinate,upperLeftCornerYCoordinate,rectangle_width,rectangle_height);

    }


     graph.FillRectangle(Brushes.Green,0,620,formwidth,73); // create orange horizontal band near buttons at the bottom

     base.OnPaint(ee);
   }

   protected void seerectanglered(Object sender,EventArgs events)
   { showRectanglered = true;

     System.Console.WriteLine("User has clicked red Rectangle");
   }
   
   protected void seetrianglered(Object sender,EventArgs events)
   { showRectanglered = true;

     System.Console.WriteLine("User has clicked red Rectangle");
   }
   
   protected void seecirclered(Object sender,EventArgs events)
   { showRectanglered = true;

     System.Console.WriteLine("User has clicked red Rectangle");
   }
   
   protected void seetriangleblue(Object sender,EventArgs events)
   { showTriangleblue =true;

     System.Console.WriteLine("User has Selected blue Triangle");
   }

   protected void seecircleblue(Object sender, EventArgs events)
   { showCircleblue = true;

     System.Console.WriteLine("User has Selected red Circle");
   }
   
   protected void seerectangleblue(Object sender,EventArgs events)
   { showRectangleblue = true;

     System.Console.WriteLine("User has clicked red Rectangle");
   }
   
   protected void seetrianglegreen(Object sender,EventArgs events)
   { showTrianglegreen =true;

     System.Console.WriteLine("User has Selected green Triangle");
   }

   protected void seecirclegreen(Object sender, EventArgs events)
   { showCirclegreen = true;

     System.Console.WriteLine("User has Selected green Circle");
   }
   
   protected void seerectanglegreen(Object sender,EventArgs events)
   { showRectanglegreen = true;

     System.Console.WriteLine("User has clicked green Rectangle");
   }
   protected void hideShapes(Object sender, EventArgs events)
   { showRectangleblue = false;
     showCircleblue = false;
     showTriangleblue = false;
     showRectanglered = false;
     showCirclered = false;
     showTrianglered = false;
     showRectanglegreen = false;
     showCirclegreen = false;
     showTrianglegreen = false;
   
     Invalidate();
     System.Console.WriteLine("User has clicked on Clear button, all shapes have been cleared");
   }
   
  protected void seeshapes(Object sender, EventArgs events)
  {
	  Invalidate();
  }
   protected void closeprogram(Object sender, EventArgs events)
   { System.Console.WriteLine("The Prgram will now terminate. ");
	   Close();
   }
} 

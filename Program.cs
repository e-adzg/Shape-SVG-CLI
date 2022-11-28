/*
Student Name: Erikas Adzgauskas
Student Number: 20415984

This is my SVG Maker. I am using NET 6.0. 
Tested on Windows 11 in VSCode 1.72.2

HOW TO USE:
to run programme, type 'dotnet run' in console. 
a list of instructions are printed to the console.
for example, if you want to make a rectangle, you would type 'rectangle'
then, input all of the co-ordinates and CSS styles you wish to add.
all inputs take in string, so to add colour, you can type 'lime'
inputs accepts decimals where appropriate.

TO EXPORT:
after adding shapes, you can type 'export' to make a SVG file
and the programme will terminate and a new SVG file will
be made in the same folder here.

CODE CONTEXT:
a list holds all shapes. the interface shape extends to all
other shapes. after creating a new shape, it will be added 
to the shapes list. at the end, when the user wants to export,
it will loop through the list and add each SVG method to the
SVG file.

*/


using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Assignment3
{
    //have 2 stacks, undo and redo, when redo-ing, take states from the redo stack and bring it back

    class Program
    {
        static void Main(string[] args)
        {
            bool programRun = true; //checks if the programme is still running
            bool userInput = true;  //used to keep the while loop looping so that the user can keep entering shapes

            Canvas canvas = new Canvas();
            Console.WriteLine(canvas);
            User user = new User();





            var shapes = new List<Shape>(); //this is the list that holds all shapes

            string? svgHeight = "400"; //default values for canvas
            string? svgWidth = "400";

            string svgOpening = String.Format(@"<svg height=""{0}"" width=""{1}"" xmlns=""http://www.w3.org/2000/svg"">", svgHeight, svgWidth); //this is the first line for the SVG file which lets the user change the canvas

            string svgOpen = svgOpening + Environment.NewLine;
            string svgClose = Environment.NewLine + @"</svg>"; //last line for the SVG file

            while (programRun == true)
            {
                Console.Clear(); //this is all console printing. I added colour because i thought it looked cool

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Assignment 3");
                Console.WriteLine("By Erikas Adzgauskas 20415984");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("====================================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nCanvas Created - use commands to add shapes to the canvas!\n");
                Console.ResetColor();

                // Console.ForegroundColor = ConsoleColor.Green;
                // Console.WriteLine("SVG MAKER V1.0.0");
                // Console.WriteLine("By Erikas Adzgauskas 20415984");
                // Console.ResetColor();
                // Console.ForegroundColor = ConsoleColor.Blue;
                // Console.WriteLine("====================================");
                // Console.ResetColor();
                // Console.WriteLine("Type Shape To Add: rectangle, circle, ellipse, line, polyline, polygon, path");
                // Console.WriteLine("To Change Canvas Size, Type: canvas");
                // Console.WriteLine("To Export, Type: export");
                // Console.WriteLine("To Exit, Type: exit");
                // Console.ForegroundColor = ConsoleColor.Blue;
                // Console.WriteLine("====================================");
                // Console.ResetColor();
                // Console.WriteLine();

                while (userInput == true) //this will let the user keep entering as many inputs while this is true
                {
                    string? userRead = Console.ReadLine();

                    switch (userRead) //this is a long switch case for every input possible that the user can enter
                    {
                        case "A rectangle":
                            shapes = AddRectangle(shapes);
                            break;

                        case "A circle":
                            AddCircle(user, canvas);
                            break;

                        case "A ellipse":
                            shapes = AddEllipse(shapes);
                            break;

                        case "A line":
                            shapes = AddLine(shapes);
                            break;

                        case "A polyline":
                            shapes = AddPolyline(shapes);
                            break;

                        case "A polygon":
                            shapes = AddPolygon(shapes);
                            break;

                        case "A path":
                            shapes = AddPath(shapes);
                            break;

                        case "V":
                            svgHeight = ChangeCanvasHeight(svgHeight);
                            svgWidth = ChangeCanvasWidth(svgWidth);
                            svgOpening = String.Format(@"<svg height=""{0}"" width=""{1}"" xmlns=""http://www.w3.org/2000/svg"">", svgHeight, svgWidth);
                            svgOpen = svgOpening + Environment.NewLine;
                            Console.WriteLine("\nCanvas Updated!\n");
                            break;

                        case "export":
                            userInput = false; //ends the user input

                            string allshapes = "";
                            int length = shapes.Count; //gets the length of the list of shapes

                            for (int i = 0; i < length; i++) //while it goes through the list of shapes, it will add each ToString from every shape
                            {
                                allshapes = allshapes + Convert.ToString(shapes[i]);
                            }

                            File.WriteAllText(@"./An_SVG.svg", svgOpen + "".PadLeft(3, ' ') + allshapes + Environment.NewLine + svgClose); //file creation here

                            Console.WriteLine("\nSVG Exported!\n");

                            break;

                        case "E":
                            userInput = false; //ends the user input

                            //! added canvas.ToString()
                            File.WriteAllText(@"./An_SVG.svg", svgOpen + "".PadLeft(3, ' ') + canvas.ToString() + Environment.NewLine + svgClose); //file creation here

                            Console.WriteLine("\nSVG Exported!\n");

                            break;

                        case "exit":
                            userInput = false; //ends the user input so that the programme can close
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nGoodbye!\n");
                            Console.ResetColor();
                            break;

                        case "Q":
                            userInput = false; //ends the user input so that the programme can close
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nGoodbye!\n");
                            Console.ResetColor();
                            break;

                        case "H":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nCommands:");
                            Console.ResetColor();
                            Console.WriteLine("H               Help - displays this message\nA <shape>       Add <shape> to canvas\nT               Delete Last Shape\nU               Undo last operation\nR               Redo last operation\nC               Clear canvas\nV               Change Canvas Size\nD               Display canvas to console\nE               Export canvas\nQ               Quit application\n");
                            break;

                        case "D":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nDisplaying SVG To Console:\n");
                            Console.ResetColor();
                            Console.WriteLine(svgOpen);
                            Console.WriteLine(canvas);
                            Console.WriteLine(svgClose + "\n");
                            break;

                        case "T":
                            try
                            {
                                user.Action(new DeleteShapeCommand(canvas));
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nShape Deleted!\n");
                                Console.ResetColor();
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nERROR: Shape could not be deleted!\n");
                                Console.ResetColor();
                            }
                            break;

                        case "U":
                            user.Undo();
                            break;

                        case "R":
                            user.Redo();
                            break;

                        case "hello":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nHello!\n"); //hello :)
                            Console.ResetColor();
                            break;
                    }
                }
                programRun = false;
            }
        }

        public static string? ChangeCanvasHeight(string? svgHeight)
        {
            Console.WriteLine("\nEnter Canvas Height:");
            string? userSvgHeight = Console.ReadLine();
            return userSvgHeight;
        }
        public static string? ChangeCanvasWidth(string? svgWidth)
        {
            Console.WriteLine("Enter Canvas Width:");
            string? userSvgWidth = Console.ReadLine();
            return userSvgWidth;
        }
        public static List<Shape> AddRectangle(List<Shape> shapes)
        {
            Console.WriteLine("Set the height:");
            string? userHeight = Console.ReadLine();
            Console.WriteLine("Set the width:");
            string? userWitdh = Console.ReadLine();
            Console.WriteLine("Set the X:");
            string? userRecX = Console.ReadLine();
            Console.WriteLine("Set the Y:");
            string? userRecY = Console.ReadLine();
            Console.WriteLine("Enter Fill Colour:");
            string? userFill = Console.ReadLine();
            Console.WriteLine("Enter Stroke Colour:");
            string? userRecStrokeColour = Console.ReadLine();
            Console.WriteLine("Enter Stroke Width:");
            string? valRecStrokeWidth = Console.ReadLine();
            Console.WriteLine("Enter Fill Opacity:");
            string? userRecFillOpacity = Console.ReadLine();
            Console.WriteLine("Enter Stroke Opacity:");
            string? userRecStrokeOpacity = Console.ReadLine();
            shapes.Add(new Rectangle(userRecX, userRecY, userHeight, userWitdh, userFill, userRecStrokeColour, valRecStrokeWidth, userRecFillOpacity, userRecStrokeOpacity));
            Console.WriteLine("\nRectangle Added!\n");
            return shapes;
        }

        public static void AddCircle(User user, Canvas canvas)
        {
            Console.WriteLine("Set the radius:");
            string? userCr = Console.ReadLine();
            Console.WriteLine("Set the circle X:");
            string? userCx = Console.ReadLine();
            Console.WriteLine("Set the circle Y:");
            string? userCy = Console.ReadLine();
            Console.WriteLine("Enter Stroke Colour:");
            string? userCircleStroke = Console.ReadLine();
            Console.WriteLine("Enter Stroke Witdh:");
            string? userCircleStrokeWidth = Console.ReadLine();
            Console.WriteLine("Enter Fill Colour:");
            string? userCircleFill = Console.ReadLine();

            //! THIS IS CIRCLE NEW
            user.Action(new AddShapeCommand(new Circle(userCr, userCx, userCy, userCircleStroke, userCircleStrokeWidth, userCircleFill), canvas));

            //shapes.Add(new Circle(userCr, userCx, userCy, userCircleStroke, userCircleStrokeWidth, userCircleFill));



            Console.WriteLine("\nCircle Added!\n");
            //return shapes;
        }
        public static List<Shape> AddEllipse(List<Shape> shapes)
        {
            Console.WriteLine("Set the position X:");
            string? userEx = Console.ReadLine();
            Console.WriteLine("Set the position Y:");
            string? userEy = Console.ReadLine();
            Console.WriteLine("Set the radius X:");
            string? userEr1 = Console.ReadLine();
            Console.WriteLine("Set the radius Y:");
            string? userEr2 = Console.ReadLine();
            Console.WriteLine("Enter Fill Colour:");
            string? userEllipseFill = Console.ReadLine();
            Console.WriteLine("Enter Stroke Colour:");
            string? userEllipseStroke = Console.ReadLine();
            Console.WriteLine("Enter Stroke Width:");
            string? userEllipseStrokeWidth = Console.ReadLine();
            shapes.Add(new Ellipse(userEx, userEy, userEr1, userEr2, userEllipseFill, userEllipseStroke, userEllipseStrokeWidth));
            Console.WriteLine("\nEllipse Added!\n");
            return shapes;
        }
        public static List<Shape> AddLine(List<Shape> shapes)
        {
            Console.WriteLine("Set the X1:");
            string? userLineX1 = Console.ReadLine();
            Console.WriteLine("Set the Y1:");
            string? userLineY1 = Console.ReadLine();
            Console.WriteLine("Set the X2:");
            string? userLineX2 = Console.ReadLine();
            Console.WriteLine("Set the Y2:");
            string? userLineY2 = Console.ReadLine();
            Console.WriteLine("Enter Stroke Colour: (string)");
            string? userLineStroke = Console.ReadLine();
            Console.WriteLine("Enter Stroke Width: (string)");
            string? userLineStrokeWidth = Console.ReadLine();
            shapes.Add(new Line(userLineX1, userLineY1, userLineX2, userLineY2, userLineStroke, userLineStrokeWidth));
            Console.WriteLine("\nLine Added!\n");
            return shapes;
        }
        public static List<Shape> AddPath(List<Shape> shapes)
        {
            Console.WriteLine("Enter the path points: (E.g. M 175 200 l 150 0)");
            string? userPath = Console.ReadLine();
            Console.WriteLine("Enter Stroke Colour: (string)");
            string? userPathStroke = Console.ReadLine();
            Console.WriteLine("Enter Stroke Width: (string)");
            string? userPathStrokeWidth = Console.ReadLine();
            Console.WriteLine("Enter Fill Colour: (string)");
            string? userPathFill = Console.ReadLine();
            shapes.Add(new Path(userPath, userPathStroke, userPathStrokeWidth, userPathFill));
            Console.WriteLine("\nPath Added!\n");
            return shapes;
        }
        public static List<Shape> AddPolygon(List<Shape> shapes)
        {
            Console.WriteLine("Enter the polygon points: (E.g. 200,10 250,190 160,210)");
            string? userPointGon = Console.ReadLine();
            Console.WriteLine("Enter Fill Colour: (string)");
            string? userPolygonFill = Console.ReadLine();
            Console.WriteLine("Enter Stroke Colour: (string)");
            string? userPolygonStroke = Console.ReadLine();
            Console.WriteLine("Enter Stroke Width: (string)");
            string? userPolygonStrokeWidth = Console.ReadLine();
            shapes.Add(new Polygon(userPointGon, userPolygonFill, userPolygonStroke, userPolygonStrokeWidth));
            Console.WriteLine("\nPolygon Added!\n");
            return shapes;
        }
        public static List<Shape> AddPolyline(List<Shape> shapes)
        {
            Console.WriteLine("Enter the polyline points: (E.g. 20,20 40,25 60,40 80,120 120,140 200,180)");
            string? userPoint = Console.ReadLine();
            Console.WriteLine("Enter Fill Colour: (string) (can enter: none)");
            string? userPolylineFill = Console.ReadLine();
            Console.WriteLine("Enter Stroke Colour: (string)");
            string? userPolylineStroke = Console.ReadLine();
            Console.WriteLine("Enter Stroke Width: (string)");
            string? userPolylineStrokeWidth = Console.ReadLine();
            shapes.Add(new Polyline(userPoint, userPolylineFill, userPolylineStroke, userPolylineStrokeWidth));
            Console.WriteLine("\nPolyline Added!\n");
            return shapes;
        }
    }
}
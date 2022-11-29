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

//using stat9c System.Console;
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
            Console.Clear();

            bool programRun = true; //used to end the program
            bool userInput = true;  //used to stop user input

            string? svgHeight = "400";
            string? svgWidth = "400";

            string svgOpening = String.Format(@"<svg height=""{0}"" width=""{1}"" xmlns=""http://www.w3.org/2000/svg"">", svgHeight, svgWidth);

            string svgOpen = svgOpening + Environment.NewLine;
            string svgClose = @"</svg>";

            while (programRun == true)
            {

                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Assignment 4"); Console.WriteLine("By Erikas Adzgauskas 20415984"); Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("===================================="); Console.ResetColor();

                //!NEW STUFF
                Canvas canvas = new Canvas();
                User user = new User();
                //!END OF NEW STUFF

                while (userInput == true) //this will let the user keep entering as many inputs while this is true
                {
                    string? userRead = Console.ReadLine();

                    switch (userRead) //this is a long switch case for every input possible that the user can enter
                    {
                        case "A rectangle":
                            AddRectangle(user, canvas);
                            break;

                        case "A circle":
                            AddCircle(user, canvas);
                            break;

                        case "A ellipse":
                            AddEllipse(user, canvas);
                            break;

                        case "A line":
                            AddLine(user, canvas);
                            break;

                        case "A polyline":
                            AddPolyline(user, canvas);
                            break;

                        case "A polygon":
                            AddPolygon(user, canvas);
                            break;

                        case "A path":
                            AddPath(user, canvas);
                            break;

                        case "V":
                            svgHeight = ChangeCanvasHeight(svgHeight);
                            svgWidth = ChangeCanvasWidth(svgWidth);
                            svgOpening = String.Format(@"<svg height=""{0}"" width=""{1}"" xmlns=""http://www.w3.org/2000/svg"">", svgHeight, svgWidth);
                            svgOpen = svgOpening + Environment.NewLine;
                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nCanvas Updated!\n"); Console.ResetColor();
                            break;

                        case "E":
                            userInput = false;
                            Export(svgOpen, svgClose, canvas);
                            break;

                        case "exit":
                            userInput = false;
                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nGoodbye!\n"); Console.ResetColor();
                            break;

                        case "Q":
                            userInput = false;
                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nGoodbye!\n"); Console.ResetColor();
                            break;

                        case "H":
                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nCommands:"); Console.ResetColor();
                            Console.WriteLine("H               Help - displays this message\nA <shape>       Add <shape> to canvas\nS               See list of shapes\nT               Delete Last Shape\nU               Undo last operation\nR               Redo last operation\nV               Change Canvas Size\nD               Display canvas to console\nE               Export canvas\nO               Clear Console\nQ               Quit application\n");
                            break;

                        case "S":
                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nList of Shapes:"); Console.ResetColor();
                            Console.WriteLine("A rectangle\nA circle\nA ellipse\nA line\nA path\nA polygon\nA polyline\n");
                            break;

                        case "D":
                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nDisplaying SVG To Console:\n"); Console.ResetColor();
                            Console.WriteLine(svgOpen);
                            Console.WriteLine(canvas);
                            Console.WriteLine(svgClose + "\n");
                            break;

                        case "T":
                            try
                            {
                                user.Action(new DeleteShapeCommand(canvas));
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nERROR: Shape could not be deleted!\n"); Console.ResetColor();
                            }
                            break;

                        case "U":
                            try
                            {
                                user.Undo();
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nERROR: Cannot Undo!\n"); Console.ResetColor();
                            }
                            break;

                        case "R":
                            try
                            {
                                user.Redo();
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nERROR: Cannot Redo!\n"); Console.ResetColor();
                            }
                            break;

                        case "O":
                            Console.Clear();
                            break;

                        case "hello":
                            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("\nHello!\n"); Console.ResetColor();
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nInvalid Input! - Type 'Q' for commands!\n"); Console.ResetColor();
                            break;
                    }
                }
                programRun = false;
            }
        }
        public static void Export(string? svgOpen, string? svgClose, Canvas canvas)
        {
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\nEnter File Name:"); Console.ResetColor();
            string? svgName = Console.ReadLine();
            File.WriteAllText(@"./" + svgName + ".svg", svgOpen + Environment.NewLine + canvas.ToString() + Environment.NewLine + svgClose);
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nSVG Exported!\n"); Console.ResetColor();
        }
        public static string? ChangeCanvasHeight(string? svgHeight)
        {
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\nEnter Canvas Height:"); Console.ResetColor();
            string? userSvgHeight = Console.ReadLine();
            return userSvgHeight;
        }
        public static string? ChangeCanvasWidth(string? svgWidth)
        {

            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Canvas Width:"); Console.ResetColor();
            string? userSvgWidth = Console.ReadLine();
            return userSvgWidth;
        }
        public static void AddRectangle(User user, Canvas canvas)
        {
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\nSet the height:"); Console.ResetColor();
            string? userHeight = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Set the width:"); Console.ResetColor();
            string? userWitdh = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Set the X:"); Console.ResetColor();
            string? userRecX = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Set the Y:"); Console.ResetColor();
            string? userRecY = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Fill Colour:"); Console.ResetColor();
            string? userFill = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Stroke Colour:"); Console.ResetColor();
            string? userRecStrokeColour = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Stroke Width:"); Console.ResetColor();
            string? valRecStrokeWidth = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Fill Opacity:"); Console.ResetColor();
            string? userRecFillOpacity = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Stroke Opacity:"); Console.ResetColor();
            string? userRecStrokeOpacity = Console.ReadLine();

            user.Action(new AddShapeCommand(new Rectangle(userRecX, userRecY, userHeight, userWitdh, userFill, userRecStrokeColour, valRecStrokeWidth, userRecFillOpacity, userRecStrokeOpacity), canvas));
        }
        public static void AddCircle(User user, Canvas canvas)
        {
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\nSet the radius:"); Console.ResetColor();
            string? userCr = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Set the circle X:"); Console.ResetColor();
            string? userCx = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Set the circle Y:"); Console.ResetColor();
            string? userCy = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Stroke Colour:"); Console.ResetColor();
            string? userCircleStroke = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Stroke Witdh:"); Console.ResetColor();
            string? userCircleStrokeWidth = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Fill Colour:"); Console.ResetColor();
            string? userCircleFill = Console.ReadLine();

            user.Action(new AddShapeCommand(new Circle(userCr, userCx, userCy, userCircleStroke, userCircleStrokeWidth, userCircleFill), canvas));
        }
        public static void AddEllipse(User user, Canvas canvas)
        {
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\nSet the position X:"); Console.ResetColor();
            string? userEx = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Set the position Y:"); Console.ResetColor();
            string? userEy = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Set the radius X:"); Console.ResetColor();
            string? userEr1 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Set the radius Y:"); Console.ResetColor();
            string? userEr2 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Fill Colour:"); Console.ResetColor();
            string? userEllipseFill = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Stroke Colour:"); Console.ResetColor();
            string? userEllipseStroke = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Stroke Width:"); Console.ResetColor();
            string? userEllipseStrokeWidth = Console.ReadLine();

            user.Action(new AddShapeCommand(new Ellipse(userEx, userEy, userEr1, userEr2, userEllipseFill, userEllipseStroke, userEllipseStrokeWidth), canvas));
        }
        public static void AddLine(User user, Canvas canvas)
        {
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\nSet the X1:"); Console.ResetColor();
            string? userLineX1 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Set the Y1:"); Console.ResetColor();
            string? userLineY1 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Set the X2:"); Console.ResetColor();
            string? userLineX2 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Set the Y2:"); Console.ResetColor();
            string? userLineY2 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Stroke Colour:"); Console.ResetColor();
            string? userLineStroke = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Stroke Width:"); Console.ResetColor();
            string? userLineStrokeWidth = Console.ReadLine();

            user.Action(new AddShapeCommand(new Line(userLineX1, userLineY1, userLineX2, userLineY2, userLineStroke, userLineStrokeWidth), canvas));
        }
        public static void AddPath(User user, Canvas canvas)
        {
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\nEnter the path points: (E.g. M 175 200 l 150 0)"); Console.ResetColor();
            string? userPath = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Stroke Colour:"); Console.ResetColor();
            string? userPathStroke = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Stroke Width:"); Console.ResetColor();
            string? userPathStrokeWidth = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Fill Colour:"); Console.ResetColor();
            string? userPathFill = Console.ReadLine();

            user.Action(new AddShapeCommand(new Path(userPath, userPathStroke, userPathStrokeWidth, userPathFill), canvas));
        }
        public static void AddPolygon(User user, Canvas canvas)
        {
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\nEnter the polygon points: (E.g. 200,10 250,190 160,210)"); Console.ResetColor();
            string? userPointGon = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Fill Colour:"); Console.ResetColor();
            string? userPolygonFill = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Stroke Colour:"); Console.ResetColor();
            string? userPolygonStroke = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Stroke Width:"); Console.ResetColor();
            string? userPolygonStrokeWidth = Console.ReadLine();

            user.Action(new AddShapeCommand(new Polygon(userPointGon, userPolygonFill, userPolygonStroke, userPolygonStrokeWidth), canvas));
        }
        public static void AddPolyline(User user, Canvas canvas)
        {
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("\nEnter the polyline points: (E.g. 20,20 40,25 60,40 80,120 120,140 200,180)"); Console.ResetColor();
            string? userPoint = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Fill Colour:"); Console.ResetColor();
            string? userPolylineFill = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Stroke Colour:"); Console.ResetColor();
            string? userPolylineStroke = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Enter Stroke Width:"); Console.ResetColor();
            string? userPolylineStrokeWidth = Console.ReadLine();

            user.Action(new AddShapeCommand(new Polyline(userPoint, userPolylineFill, userPolylineStroke, userPolylineStrokeWidth), canvas));
        }
    }
}
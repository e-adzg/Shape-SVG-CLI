/*
https://github.com/e-adzg/Shape-SVG-CLI

This is my SVG Maker. I am using NET 6.0. 
Tested on Windows 11 Pro in VSCode 1.73.0

HOW TO USE:
to run programme, type 'dotnet run' in  for example, if you want to make a rectangle, you would type 'A rectangle' then, input all of the co-ordinates and CSS styles you wish to add. all inputs take in string, so to add colour, you can type 'lime'. inputs accepts decimals where appropriate.

TO EXPORT:
after adding shapes, you can type 'E' to make a SVG file. Enter the name of the SVG file and then the program will terminate and a new SVG file will be made in the same folder here.

CODE CONTEXT:
Command Pattern. Shapes will be pushed into canvas stack. There are undo and redo stacks. They will be pushing and removing shapes when they are called. The user class is the invoker class. The command class is the interface for commands. The deleteshapecommand and addshapecommand classes are classes that injerit from the command class. 
*/

using static System.Console;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args) //main program
        {
            Clear();

            bool programRun = true; //used to end the program
            bool userInput = true;  //used to stop user input

            string? svgHeight = "400"; //default value
            string? svgWidth = "400"; //default value

            string svgOpening = String.Format(@"<svg height=""{0}"" width=""{1}"" xmlns=""http://www.w3.org/2000/svg"">", svgHeight, svgWidth);

            string svgOpen = svgOpening + Environment.NewLine;
            string svgClose = @"</svg>";

            while (programRun == true) //keeps program on
            {
                ForegroundColor = ConsoleColor.Red; WriteLine("Shape SVG CLI"); WriteLine("By e-adzg"); ResetColor();
                ForegroundColor = ConsoleColor.Blue; WriteLine("===================================="); ResetColor();

                Canvas canvas = new Canvas(); //creates canvas
                User user = new User(); //creates user

                while (userInput == true) //this will let the user keep entering as many inputs while this is true
                {
                    string? userRead = ReadLine();

                    switch (userRead) //this is a long switch case for every input possible that the user can enter
                    {   //these shapes are using methods in which the user and canvas are being sent
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

                        case "V": //change canvas size
                            svgHeight = ChangeCanvasHeight(svgHeight);
                            svgWidth = ChangeCanvasWidth(svgWidth);
                            svgOpening = String.Format(@"<svg height=""{0}"" width=""{1}"" xmlns=""http://www.w3.org/2000/svg"">", svgHeight, svgWidth);
                            svgOpen = svgOpening + Environment.NewLine;
                            ForegroundColor = ConsoleColor.Green; WriteLine("\nCanvas Updated!\n"); ResetColor();
                            break;

                        case "E": //export
                            userInput = false;
                            Export(svgOpen, svgClose, canvas);
                            break;

                        case "exit": //exit
                            userInput = false;
                            ForegroundColor = ConsoleColor.Green; WriteLine("\nGoodbye!\n"); ResetColor();
                            break;

                        case "Q": //exit
                            userInput = false;
                            ForegroundColor = ConsoleColor.Green; WriteLine("\nGoodbye!\n"); ResetColor();
                            break;

                        case "H": //display help
                            ForegroundColor = ConsoleColor.Green; WriteLine("\nCommands:"); ResetColor();
                            WriteLine("H               Help - displays this message\nA <shape>       Add <shape> to canvas\nS               See list of shapes\nT               Delete Last Shape\nU               Undo last operation\nR               Redo last operation\nV               Change Canvas Size\nD               Display canvas to console\nE               Export canvas\nO               Clear Console\nQ               Quit application\n");
                            break;

                        case "S": //display list of shapes you can add
                            ForegroundColor = ConsoleColor.Green; WriteLine("\nList of Shapes:"); ResetColor();
                            WriteLine("A rectangle\nA circle\nA ellipse\nA line\nA path\nA polygon\nA polyline\n");
                            break;

                        case "D": //display the svg to console
                            ForegroundColor = ConsoleColor.Green; WriteLine("\nDisplaying SVG To Console:\n"); ResetColor();
                            WriteLine(svgOpen);
                            WriteLine(canvas);
                            WriteLine(svgClose + "\n");
                            break;

                        case "T": //delete command
                            try
                            {
                                user.Action(new DeleteShapeCommand(canvas));
                            }
                            catch
                            {
                                ForegroundColor = ConsoleColor.Red; WriteLine("\nERROR: Shape could not be deleted!\n"); ResetColor();
                            }
                            break;

                        case "U": //undo command
                            user.Undo();
                            break;

                        case "R": //redo command
                            user.Redo();
                            break;

                        case "O": //clear console command
                            Clear();
                            break;

                        case "hello": //hello
                            ForegroundColor = ConsoleColor.DarkMagenta; WriteLine("\nHello!\n"); ResetColor();
                            break;

                        default: //default case if user does not enter any other case
                            ForegroundColor = ConsoleColor.Red; WriteLine("\nInvalid Input! - Type 'H' for commands!\n"); ResetColor();
                            break;
                    }
                }
                programRun = false;
            }
        } // the rest are methods to handle everything. they are pretty straight forward.
        public static void Export(string? svgOpen, string? svgClose, Canvas canvas)
        {
            ForegroundColor = ConsoleColor.Blue; WriteLine("\nEnter File Name:"); ResetColor();
            string? svgName = ReadLine();
            File.WriteAllText(@"./" + svgName + ".svg", svgOpen + Environment.NewLine + canvas.ToString() + Environment.NewLine + svgClose);
            ForegroundColor = ConsoleColor.Green; WriteLine("\nSVG Exported!\n"); ResetColor();
        }
        public static string? ChangeCanvasHeight(string? svgHeight)
        {
            ForegroundColor = ConsoleColor.Blue; WriteLine("\nEnter Canvas Height:"); ResetColor();
            string? userSvgHeight = ReadLine();
            return userSvgHeight;
        }
        public static string? ChangeCanvasWidth(string? svgWidth)
        {
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Canvas Width:"); ResetColor();
            string? userSvgWidth = ReadLine();
            return userSvgWidth;
        }
        public static void AddRectangle(User user, Canvas canvas)
        {
            ForegroundColor = ConsoleColor.Blue; WriteLine("\nSet the height:"); ResetColor();
            string? userHeight = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Set the width:"); ResetColor();
            string? userWitdh = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Set the X:"); ResetColor();
            string? userRecX = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Set the Y:"); ResetColor();
            string? userRecY = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Fill Colour:"); ResetColor();
            string? userFill = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Stroke Colour:"); ResetColor();
            string? userRecStrokeColour = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Stroke Width:"); ResetColor();
            string? valRecStrokeWidth = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Fill Opacity:"); ResetColor();
            string? userRecFillOpacity = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Stroke Opacity:"); ResetColor();
            string? userRecStrokeOpacity = ReadLine();

            user.Action(new AddShapeCommand(new Rectangle(userRecX, userRecY, userHeight, userWitdh, userFill, userRecStrokeColour, valRecStrokeWidth, userRecFillOpacity, userRecStrokeOpacity), canvas));
        }
        public static void AddCircle(User user, Canvas canvas)
        {
            ForegroundColor = ConsoleColor.Blue; WriteLine("\nSet the radius:"); ResetColor();
            string? userCr = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Set the circle X:"); ResetColor();
            string? userCx = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Set the circle Y:"); ResetColor();
            string? userCy = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Stroke Colour:"); ResetColor();
            string? userCircleStroke = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Stroke Witdh:"); ResetColor();
            string? userCircleStrokeWidth = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Fill Colour:"); ResetColor();
            string? userCircleFill = ReadLine();

            user.Action(new AddShapeCommand(new Circle(userCr, userCx, userCy, userCircleStroke, userCircleStrokeWidth, userCircleFill), canvas));
        }
        public static void AddEllipse(User user, Canvas canvas)
        {
            ForegroundColor = ConsoleColor.Blue; WriteLine("\nSet the position X:"); ResetColor();
            string? userEx = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Set the position Y:"); ResetColor();
            string? userEy = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Set the radius X:"); ResetColor();
            string? userEr1 = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Set the radius Y:"); ResetColor();
            string? userEr2 = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Fill Colour:"); ResetColor();
            string? userEllipseFill = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Stroke Colour:"); ResetColor();
            string? userEllipseStroke = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Stroke Width:"); ResetColor();
            string? userEllipseStrokeWidth = ReadLine();

            user.Action(new AddShapeCommand(new Ellipse(userEx, userEy, userEr1, userEr2, userEllipseFill, userEllipseStroke, userEllipseStrokeWidth), canvas));
        }
        public static void AddLine(User user, Canvas canvas)
        {
            ForegroundColor = ConsoleColor.Blue; WriteLine("\nSet the X1:"); ResetColor();
            string? userLineX1 = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Set the Y1:"); ResetColor();
            string? userLineY1 = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Set the X2:"); ResetColor();
            string? userLineX2 = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Set the Y2:"); ResetColor();
            string? userLineY2 = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Stroke Colour:"); ResetColor();
            string? userLineStroke = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Stroke Width:"); ResetColor();
            string? userLineStrokeWidth = ReadLine();

            user.Action(new AddShapeCommand(new Line(userLineX1, userLineY1, userLineX2, userLineY2, userLineStroke, userLineStrokeWidth), canvas));
        }
        public static void AddPath(User user, Canvas canvas)
        {
            ForegroundColor = ConsoleColor.Blue; WriteLine("\nEnter the path points: (E.g. M 175 200 l 150 0)"); ResetColor();
            string? userPath = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Stroke Colour:"); ResetColor();
            string? userPathStroke = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Stroke Width:"); ResetColor();
            string? userPathStrokeWidth = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Fill Colour:"); ResetColor();
            string? userPathFill = ReadLine();

            user.Action(new AddShapeCommand(new Path(userPath, userPathStroke, userPathStrokeWidth, userPathFill), canvas));
        }
        public static void AddPolygon(User user, Canvas canvas)
        {
            ForegroundColor = ConsoleColor.Blue; WriteLine("\nEnter the polygon points: (E.g. 200,10 250,190 160,210)"); ResetColor();
            string? userPointGon = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Fill Colour:"); ResetColor();
            string? userPolygonFill = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Stroke Colour:"); ResetColor();
            string? userPolygonStroke = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Stroke Width:"); ResetColor();
            string? userPolygonStrokeWidth = ReadLine();

            user.Action(new AddShapeCommand(new Polygon(userPointGon, userPolygonFill, userPolygonStroke, userPolygonStrokeWidth), canvas));
        }
        public static void AddPolyline(User user, Canvas canvas)
        {
            ForegroundColor = ConsoleColor.Blue; WriteLine("\nEnter the polyline points: (E.g. 20,20 40,25 60,40 80,120 120,140 200,180)"); ResetColor();
            string? userPoint = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Fill Colour:"); ResetColor();
            string? userPolylineFill = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Stroke Colour:"); ResetColor();
            string? userPolylineStroke = ReadLine();
            ForegroundColor = ConsoleColor.Blue; WriteLine("Enter Stroke Width:"); ResetColor();
            string? userPolylineStrokeWidth = ReadLine();

            user.Action(new AddShapeCommand(new Polyline(userPoint, userPolylineFill, userPolylineStroke, userPolylineStrokeWidth), canvas));
        }
    }
}
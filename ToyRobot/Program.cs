// See https://aka.ms/new-console-template for more information
using ToyRobot;
using ToyRobot.ActionExecutors;
using ToyRobot.Actions;
using ToyRobot.Factories;
using ToyRobot.TablePositionValidator;


// Ideally these should be provided by Dependency injector
var tableTopFactory = new ConsoleTableTopFactory();
var tablePositionValidator = new TablePositionValidator();
var actionExecutorProvider = new ActionExecutorProvider();
var userActionController = new ConsoleActionController(tablePositionValidator, new ConsoleActionParser() ,actionExecutorProvider);

var toyRobotGame = new ToyRobotOnTableTopGame(tableTopFactory, userActionController);

toyRobotGame.Start();
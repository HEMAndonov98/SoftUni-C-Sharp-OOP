using Logger.Appenders;
using Logger.Appenders.Interfaces;
using Logger.IO;
using Logger.IO.Interfaces;
using Logger.Layouts;
using Logger.Layouts.Interfaces;
using Logger.Loggers;

ILayout simpleLayout = new SimpleLayout();

IFileWriter writer = new FileWriter(Directory.GetCurrentDirectory() + "../../../../../");

ILogFile file = new LogFile(writer);

IAppender consoleAppender = new ConsoleAppender(simpleLayout);
IAppender fileAppender = new FileAppender(simpleLayout, file);

ReportLogger log = new ReportLogger(consoleAppender, fileAppender);

//3 / 26 / 2015 2:08:11 PM  Everything seems fine
log.Info("3 / 26 / 2015 2:08:11 PM", "Everything seems fine");
file.SaveAs("Fine");
Console.WriteLine();
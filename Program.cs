using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
string ticketFilePath = Directory.GetCurrentDirectory() + "\\Tickets.csv";
string enhanceFilePath = Directory.GetCurrentDirectory() + "\\Enhancements.csv";
string taskFilePath = Directory.GetCurrentDirectory() + "\\Task.csv";

logger.Info("Program started");

TicketFile ticketFile = new TicketFile(ticketFilePath);
EnhanceFile enhanceFile = new EnhanceFile(enhanceFilePath);
TaskFile taskFile = new TaskFile(taskFilePath);


string choice = "";
do
{
  // display choices to user
  Console.WriteLine("1) Add Ticket");
  Console.WriteLine("2) Display All Tickets");
  Console.WriteLine("3) Add Enchancement");
  Console.WriteLine("4) Display All Enhancements");
  Console.WriteLine("5) Add Task");
  Console.WriteLine("6) Display All Task");
  Console.WriteLine("Enter to quit");
  // input selection
  choice = Console.ReadLine();
  logger.Info("User choice: {Choice}", choice);
  if (choice == "1")
  {
    Ticket ticket = new Ticket();
    // ask user to input ticket summary
    Console.WriteLine("Enter ticket summary");
    // input summary
    ticket.Summary = Console.ReadLine();
    // ask user to input ticket status
    Console.WriteLine("Enter ticket status");
    // input status
    ticket.Status = Console.ReadLine();
    // ask user to input ticket priority
    Console.WriteLine("Enter ticket priotity");
    // input priority
    ticket.Priority = Console.ReadLine();
    // ask user to input ticket Submitter
    Console.WriteLine("Enter ticket submitter");
    // input submitter
    ticket.Submitter = Console.ReadLine();
    // ask user to input ticket assigned
    Console.WriteLine("Enter ticket assigned");
    // input assigned
    ticket.Assigned = Console.ReadLine();
    string input;
      do
      {
        // ask user to enter watching
        Console.WriteLine("Enter watching (or done to quit)");
        // input watching
        input = Console.ReadLine();
        // if user enters "done"
        // or does not enter a genre do not add it to list
        if (input != "done" && input.Length > 0)
        {
          ticket.Watching.Add(input);
        }
      } while (input != "done");
      // specify if no watching are entered
      if (ticket.Watching.Count == 0)
      {
        ticket.Watching.Add("(no genres listed)");
      }
      // ask user to input ticket severity
      Console.WriteLine("Enter ticket Severity");
      // input severity
      ticket.Severity = Console.ReadLine();
      // add movie
      ticketFile.AddTicket(ticket);
  } else if (choice == "2")
  {
    // Display All Tickets
    foreach(Ticket m in ticketFile.Tickets)
    {
      Console.WriteLine(m.Display());
    }
  }
  else if (choice == "3")
  {
    Enhancements eTicket = new Enhancements();
    // ask user to input ticket summary
    Console.WriteLine("Enter ticket summary");
    // input summary
    eTicket.Summary = Console.ReadLine();
    // ask user to input ticket status
    Console.WriteLine("Enter ticket status");
    // input status
    eTicket.Status = Console.ReadLine();
    // ask user to input ticket priority
    Console.WriteLine("Enter ticket priotity");
    // input priority
    eTicket.Priority = Console.ReadLine();
    // ask user to input ticket Submitter
    Console.WriteLine("Enter ticket submitter");
    // input submitter
    eTicket.Submitter = Console.ReadLine();
    // ask user to input ticket assigned
    Console.WriteLine("Enter ticket assigned");
    // input assigned
    eTicket.Assigned = Console.ReadLine();
    string input;
      do
      {
        // ask user to enter watching
        Console.WriteLine("Enter watching (or done to quit)");
        // input watching
        input = Console.ReadLine();
        // if user enters "done"
        // or does not enter a genre do not add it to list
        if (input != "done" && input.Length > 0)
        {
          eTicket.Watching.Add(input);
        }
      } while (input != "done");
      // specify if no watching are entered
      if (eTicket.Watching.Count == 0)
      {
        eTicket.Watching.Add("(no genres listed)");
      }
      // ask user to input ticket software
      Console.WriteLine("Enter ticket software");
      // input severity
      eTicket.Software = Console.ReadLine();
      // ask user to input ticket cost
      Console.WriteLine("Enter ticket cost");
      // input cost
      eTicket.Cost = Console.ReadLine();
      // ask user to input ticket reason
      Console.WriteLine("Enter ticket reason");
      // input reason
      eTicket.Reason = Console.ReadLine();
      // ask user to input ticket estimate
      Console.WriteLine("Enter ticket etimate");
      // input estimate
      eTicket.Estimate = Console.ReadLine();
      // add movie
      enhanceFile.AddEnhancement(eTicket);
  } else if (choice == "4")
  {
    // Display All Enhancements
    foreach(Enhancements e in enhanceFile.Enhancements)
    {
      Console.WriteLine(e.Display());
    }
  }
  else if (choice == "5")
  {
    Task task = new Task();
    // ask user to input ticket summary
    Console.WriteLine("Enter task summary");
    // input summary
    task.Summary = Console.ReadLine();
    // ask user to input ticket status
    Console.WriteLine("Enter task status");
    // input status
    task.Status = Console.ReadLine();
    // ask user to input ticket priority
    Console.WriteLine("Enter task priotity");
    // input priority
    task.Priority = Console.ReadLine();
    // ask user to input ticket Submitter
    Console.WriteLine("Enter task submitter");
    // input submitter
    task.Submitter = Console.ReadLine();
    // ask user to input ticket assigned
    Console.WriteLine("Enter task assigned");
    // input assigned
    task.Assigned = Console.ReadLine();
    string input;
      do
      {
        // ask user to enter watching
        Console.WriteLine("Enter watching (or done to quit)");
        // input watching
        input = Console.ReadLine();
        // if user enters "done"
        // or does not enter a genre do not add it to list
        if (input != "done" && input.Length > 0)
        {
          task.Watching.Add(input);
        }
      } while (input != "done");
      // specify if no watching are entered
      if (task.Watching.Count == 0)
      {
        task.Watching.Add("(no genres listed)");
      }
      // ask user to input ticket project name
      Console.WriteLine("Enter task Project Name");
      // input project name
      task.ProjectName = Console.ReadLine();
      // ask user to input ticket due date
      Console.WriteLine("Enter task Due Date");
      // input due date
      task.DueDate = Console.ReadLine();
      // add movie
      taskFile.AddTask(task);
  } else if (choice == "6")
  {
    // Display All tasks
    foreach(Task e in taskFile.Tasks)
    {
      Console.WriteLine(e.Display());
    }
  }
} while (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5" || choice == "6");

logger.Info("Program ended");
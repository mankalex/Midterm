using NLog;
public class TaskFile
{
  // public property
  public string filePath { get; set; }
  public List<Task> Tasks { get; set; }
  private static NLog.Logger logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();


  // constructor is a special method that is invoked
  // when an instance of a class is created
  public TaskFile(string taskFilePath)
  {
    filePath = taskFilePath;
    // create instance of Logger
    

    Tasks = new List<Task>();

    // to populate the list with data, read from the data file
    try
    {
      StreamReader sr = new StreamReader(filePath);
      // first line contains column headers
      sr.ReadLine();
      while (!sr.EndOfStream)
      {
        // create instance of Movie class
        Task task = new Task();
        string line = sr.ReadLine();
        // first look for quote(") in string
        // this indicates a comma(,) in ticket title
        int idx = line.IndexOf('"');
        if (idx == -1)
        {
          // no quote = no comma in ticket title
          // title details are separated with comma(,)
          string[] taskDetails = line.Split(',');
          task.TicketID = UInt64.Parse(taskDetails[0]);
          task.Summary = taskDetails[1];
          task.Status = taskDetails[2];
          task.Priority = taskDetails[3];
          task.Submitter = taskDetails[4];
          task.Assigned = taskDetails[5];
          task.Watching = taskDetails[6].Split('|').ToList();
          task.ProjectName = taskDetails[7];
          task.DueDate = taskDetails[8];
        }
        else
        {
          // quote = comma in ticket title
          // extract the ticketId
          task.TicketID = UInt64.Parse(line.Substring(0, idx - 1));
          // remove movieId and first quote from string
          line = line.Substring(idx + 1);
          // find the next quote
          idx = line.IndexOf('"');
          // extract the summary
          task.Summary = line.Substring(0, idx);
          // remove summary and last comma from the string
          line = line.Substring(idx + 2);

          idx = line.IndexOf('"');
          // extract the status
          task.Status = line.Substring(0, idx);
          // remove status and last comma from the string
          line = line.Substring(idx + 3);

          idx = line.IndexOf('"');
          // extract the priority
          task.Priority = line.Substring(0, idx);
          // remove priority and last comma from the string
          line = line.Substring(idx + 4);

          idx = line.IndexOf('"');
          // extract the submitter
          task.Submitter = line.Substring(0, idx);
          // remove submitter and last comma from the string
          line = line.Substring(idx + 5);

          idx = line.IndexOf('"');
          // extract the assigned
          task.Assigned = line.Substring(0, idx);
          // remove assigned and last comma from the string
          line = line.Substring(idx + 6);
          task.Watching = line.Split('|').ToList();

          idx = line.IndexOf('"');
          // extract the projectname
          task.ProjectName = line.Substring(0, idx);
          // remove projectname and last comma from the string
          line = line.Substring(idx + 7);

          idx = line.IndexOf('"');
          // extract the duedate
          task.DueDate = line.Substring(0, idx);
          // remove duedate and last comma from the string
          line = line.Substring(idx + 8);
        }
        Tasks.Add(task);
      }
      // close file when done
      sr.Close();
      logger.Info("Task in file {Count}", Tasks.Count);
    }
    catch (Exception ex)
    {
      logger.Error(ex.Message);
    }
  }
  public void AddTask(Task task)
  {
    try
    {
      // first generate movie id
      task.TicketID = Tasks.Max(m => m.TicketID) + 1;
      StreamWriter sw = new StreamWriter(filePath, true);
      sw.WriteLine($"{task.TicketID},{task.Summary},{task.Status},{task.Priority},{task.Submitter},{task.Assigned},{string.Join("|", task.Watching)},{task.ProjectName},{task.DueDate}");
      sw.Close();
      // add movie details to Lists
      Tasks.Add(task);
      // log transaction
      logger.Info("Ticket id {Id} added", task.TicketID);
    } 
    catch(Exception ex)
    {
      logger.Error(ex.Message);
    }
  }
}
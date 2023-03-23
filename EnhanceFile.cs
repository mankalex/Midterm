using NLog;
public class EnhanceFile
{
  // public property
  public string filePath { get; set; }
  public List<Enhancements> Enhancements { get; set; }
  private static NLog.Logger logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();


  // constructor is a special method that is invoked
  // when an instance of a class is created
  public EnhanceFile(string enhanceFilePath)
  {
    filePath = enhanceFilePath;
    // create instance of Logger
    

    Enhancements = new List<Enhancements>();

    // to populate the list with data, read from the data file
    try
    {
      StreamReader sr = new StreamReader(filePath);
      // first line contains column headers
      sr.ReadLine();
      while (!sr.EndOfStream)
      {
        // create instance of Movie class
        Enhancements enhance = new Enhancements();
        string line = sr.ReadLine();
        // first look for quote(") in string
        // this indicates a comma(,) in ticket title
        int idx = line.IndexOf('"');
        if (idx == -1)
        {
          // no quote = no comma in ticket title
          // title details are separated with comma(,)
          string[] eDetails = line.Split(',');
          enhance.TicketID = UInt64.Parse(eDetails[0]);
          enhance.Summary = eDetails[1];
          enhance.Status = eDetails[2];
          enhance.Priority = eDetails[3];
          enhance.Submitter = eDetails[4];
          enhance.Assigned = eDetails[5];
          enhance.Watching = eDetails[6].Split('|').ToList();
          enhance.Software = eDetails[7];
          enhance.Cost = eDetails[8];
          enhance.Reason = eDetails[9];
          enhance.Estimate = eDetails[10];
        }
        else
        {
          // quote = comma in ticket title
          // extract the ticketId
          enhance.TicketID = UInt64.Parse(line.Substring(0, idx - 1));
          // remove movieId and first quote from string
          line = line.Substring(idx + 1);
          // find the next quote
          idx = line.IndexOf('"');
          // extract the summary
          enhance.Summary = line.Substring(0, idx);
          // remove summary and last comma from the string
          line = line.Substring(idx + 2);

          idx = line.IndexOf('"');
          // extract the status
          enhance.Status = line.Substring(0, idx);
          // remove status and last comma from the string
          line = line.Substring(idx + 3);

          idx = line.IndexOf('"');
          // extract the priority
          enhance.Priority = line.Substring(0, idx);
          // remove priority and last comma from the string
          line = line.Substring(idx + 4);

          idx = line.IndexOf('"');
          // extract the submitter
          enhance.Submitter = line.Substring(0, idx);
          // remove submitter and last comma from the string
          line = line.Substring(idx + 5);

          idx = line.IndexOf('"');
          // extract the assigned
          enhance.Assigned = line.Substring(0, idx);
          // remove assigned and last comma from the string
          line = line.Substring(idx + 6);
          enhance.Watching = line.Split('|').ToList();

          idx = line.IndexOf('"');
          // extract the software
          enhance.Software = line.Substring(0, idx);
          // remove software and last comma from the string
          line = line.Substring(idx + 7);

          idx = line.IndexOf('"');
          // extract the cost
          enhance.Cost = line.Substring(0, idx);
          // remove cost and last comma from the string
          line = line.Substring(idx + 8);

          idx = line.IndexOf('"');
          // extract the reason
          enhance.Reason = line.Substring(0, idx);
          // remove reason and last comma from the string
          line = line.Substring(idx + 9);

          idx = line.IndexOf('"');
          // extract the estimate
          enhance.Estimate = line.Substring(0, idx);
          // remove estimate and last comma from the string
          line = line.Substring(idx + 10);
        }
        Enhancements.Add(enhance);
      }
      // close file when done
      sr.Close();
      logger.Info("Enhancements in file {Count}", Enhancements.Count);
    }
    catch (Exception ex)
    {
      logger.Error(ex.Message);
    }
  }
  public void AddEnhancement(Enhancements enhance)
  {
    try
    {
      // first generate movie id
      enhance.TicketID = Enhancements.Max(m => m.TicketID) + 1;
      StreamWriter sw = new StreamWriter(filePath, true);
      sw.WriteLine($"{enhance.TicketID},{enhance.Summary},{enhance.Status},{enhance.Priority},{enhance.Submitter},{enhance.Assigned},{string.Join("|", enhance.Watching)},{enhance.Software},{enhance.Cost},{enhance.Reason},{enhance.Estimate}");
      sw.Close();
      // add movie details to Lists
      Enhancements.Add(enhance);
      // log transaction
      logger.Info("Ticket id {Id} added", enhance.TicketID);
    } 
    catch(Exception ex)
    {
      logger.Error(ex.Message);
    }
  }
}
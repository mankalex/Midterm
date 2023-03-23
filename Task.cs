public class Task
{
  public UInt64 TicketID { get; set; }
  public string Summary { get; set; }
  public string Status { get; set; }
  public string Priority { get; set; }
  public string Submitter { get; set; }
  public string Assigned { get; set; }
  public List<string> Watching { get; set; }
  public string ProjectName { get; set; }
  public string DueDate { get; set; }
  

 public Task()
  {
    Watching = new List<string>();
  }
  public string Display()
    {
      return $"Id: {TicketID}\nSummary: {Summary}\nStatus: {Status}\nPriority: {Priority}\nSubmitter: {Submitter}\nAssigned: {Assigned}\nWatching: {string.Join(", ", Watching)}\nProject Name: {ProjectName}\nDue Date: {DueDate}\n";
    }
}
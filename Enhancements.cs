public class Enhancements
{
  public UInt64 TicketID { get; set; }
  public string Summary { get; set; }
  public string Status { get; set; }
  public string Priority { get; set; }
  public string Submitter { get; set; }
  public string Assigned { get; set; }
  public List<string> Watching { get; set; }
  public string Software { get; set; }
  public string Cost { get; set; }
  public string Reason { get; set; }
  public string Estimate { get; set; }
  

 public Enhancements()
  {
    Watching = new List<string>();
  }
  public string Display()
    {
      return $"Id: {TicketID}\nSummary: {Summary}\nStatus: {Status}\nPriority: {Priority}\nSubmitter: {Submitter}\nAssigned: {Assigned}\nWatching: {string.Join(", ", Watching)}\nSoftware: {Software}\nCost: {Cost}\nReason: {Reason}\nEstimate: {Estimate}\n";
    }
}
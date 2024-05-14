namespace EditableCV.Services.WorkPlaceDto
{
    public class WorkPlaceReadDto
  {
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string Position { get; set; }
    public string Experience { get; set; }
    public DateTime StartWorkingDate { get; set; }
    public bool IsCurrentlyWorking {
      get
      {
        return !EndWorkingDate.HasValue;
      }
    }
    public DateTime? EndWorkingDate { get; set; }
  }
}

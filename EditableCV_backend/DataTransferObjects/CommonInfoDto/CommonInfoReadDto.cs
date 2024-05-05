using EditableCV_backend.Models;
using System;

namespace EditableCV_backend.DataTransferObjects.CommonInfoDto
{
    public class CommonInfoReadDto
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PatronymicName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ImageModel Photo { get; set; }
  }
}

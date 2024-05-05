using EditableCV_backend.Models;

namespace EditableCV_backend.Data.ContactInfoData
{
    public interface IContactInfoRepository: IRepository
  {
    ContactInfo GetContactInfo();
    void UpdateContactInfo(ContactInfo info);
    void AddContactInfo(ContactInfo info);
  }
}

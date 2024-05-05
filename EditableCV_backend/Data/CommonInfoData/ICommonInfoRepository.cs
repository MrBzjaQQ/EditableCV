using EditableCV_backend.Models;

namespace EditableCV_backend.Data.CommonInfoData
{
    public interface ICommonInfoRepository : IRepository
  {
    CommonInfo GetCommonInfo();
    void UpdateCommonInfo(CommonInfo info);
    void AddCommonInfo(CommonInfo info);
  }
}

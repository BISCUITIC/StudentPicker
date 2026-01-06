using Application.UseCases.DTO;

namespace Application.Services.Interfaces;

public interface IStudentApplicationService
{
    IReadOnlyCollection<StudentDTO> Load(int groupId);
    StudentDTO Add(AddStudentRequest request);
    void Delete(DeleteStudentRequest request);
    void Update(UpdateStudentRequest request);
    int? Pick(PickStudentRequest request);
}

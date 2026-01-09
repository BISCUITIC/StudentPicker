using Application.Services.Interfaces;
using Application.UseCases.Students.DTO;
using Application.UseCases.Students.Interfaces;

namespace Application.Services;

public class StudentApplicationService : IStudentApplicationService
{
    private readonly ILoadStudentsUseCase _loadStudentsUseCase;
    private readonly IUpdateStudentUseCase _updateStudentUseCase;
    private readonly IDeleteStudentUseCase _deleteStudentUseCase;
    private readonly IAddStudentUseCase _addStudentUseCase;
    private readonly IPickStudentUseCase _pickStudentUseCase;

    public StudentApplicationService(ILoadStudentsUseCase loadStudentsUseCase,
                                     IUpdateStudentUseCase updateStudentUseCase,
                                     IDeleteStudentUseCase deleteStudentUseCase,
                                     IAddStudentUseCase addStudentUseCase,
                                     IPickStudentUseCase pickStudentUseCase,
                                     IStudentPickerService studentPickerService)
    {

        _loadStudentsUseCase = loadStudentsUseCase;
        _updateStudentUseCase = updateStudentUseCase;
        _deleteStudentUseCase = deleteStudentUseCase;
        _addStudentUseCase = addStudentUseCase;
        _pickStudentUseCase = pickStudentUseCase;
    }

    public IReadOnlyCollection<StudentDTO> Load(int groupId)
    => _loadStudentsUseCase.Execute(groupId);

    public StudentDTO Add(AddStudentRequest request)
    => _addStudentUseCase.Execute(request);

    public void Delete(DeleteStudentRequest request)
    => _deleteStudentUseCase.Execute(request);

    public void Update(UpdateStudentRequest request)
    => _updateStudentUseCase.Execute(request);

    public int? Pick(PickStudentRequest request)
    => _pickStudentUseCase.Execute(request);
}

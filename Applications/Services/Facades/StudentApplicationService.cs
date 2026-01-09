using Application.Services.Interfaces;
using Application.Services.Interfaces.Facades;
using Application.UseCases.Students.DTO;
using Application.UseCases.Students.Interfaces;

namespace Application.Services.Facades;

public class StudentApplicationService : IStudentApplicationService
{
    private readonly ILoadStudentsUseCase _loadStudentsUseCase;
    private readonly IAddStudentUseCase _addStudentUseCase;
    private readonly IDeleteStudentUseCase _deleteStudentUseCase;
    private readonly IUpdateStudentUseCase _updateStudentUseCase;
    private readonly IPickStudentUseCase _pickStudentUseCase;

    public StudentApplicationService(ILoadStudentsUseCase loadStudentsUseCase,
                                     IAddStudentUseCase addStudentUseCase,
                                     IDeleteStudentUseCase deleteStudentUseCase,
                                     IUpdateStudentUseCase updateStudentUseCase,
                                     IPickStudentUseCase pickStudentUseCase,
                                     IStudentPickerService studentPickerService)
    {

        _loadStudentsUseCase = loadStudentsUseCase;
        _addStudentUseCase = addStudentUseCase;
        _deleteStudentUseCase = deleteStudentUseCase;
        _updateStudentUseCase = updateStudentUseCase;
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

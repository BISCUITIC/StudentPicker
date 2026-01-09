using Application.Services.Interfaces;
using Application.UseCases.Student.DTO;
using Application.UseCases.Student.Interfaces;
using Domain.Entities;

namespace Application.UseCases.Student;

public class PickStudentUseCase : IPickStudentUseCase
{
    private readonly IStudentPickerService _studentPickerService;

    public PickStudentUseCase(IStudentPickerService studentPickerService)
    {
        _studentPickerService = studentPickerService;
    }

    public int? Execute(PickStudentRequest pickRequest)
    {
        List<int> availableIdes = pickRequest.Items
                                             .Where(data => !data.IsExcluded)
                                             .Select(data => data.Id)
                                             .ToList();

        return _studentPickerService.PickRandom(availableIdes);
    }
}

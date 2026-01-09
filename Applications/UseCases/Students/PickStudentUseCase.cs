using Application.Services.Interfaces;
using Application.UseCases.Students.DTO;
using Application.UseCases.Students.Interfaces;

namespace Application.UseCases.Students;

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

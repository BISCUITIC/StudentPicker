using Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces;

public interface IStudentApplicationService
{
    IReadOnlyCollection<StudentDTO> Load(int groupId);
    StudentDTO Add(AddStudentRequest request);
    void Delete(DeleteStudentRequest request);
    void Update(UpdateStudentRequest request);
    int? Pick(PickStudentRequest request);
}

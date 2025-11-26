using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

internal class StudentProvider
{
    private readonly IStudentRepository _studentRepository;

    public StudentProvider(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public IReadOnlyCollection<Student> GetStudents(Group group)
    {
        return _studentRepository.GetAllByGroup(group);
    }
}

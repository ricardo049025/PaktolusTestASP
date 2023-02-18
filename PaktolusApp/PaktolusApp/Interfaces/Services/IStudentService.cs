using System;
using PaktolusApp.Models;
using PaktolusApp.ModelView;

namespace PaktolusApp.Interfaces.Services
{
	public interface IStudentService : IBaseService<Student>
	{
        Task<StudentVM> GetStudentWithHobbies(int id);
        Task<IEnumerable<StudentVM>> GetStudentWithHobbiesNames();
        Task SaveStudentWithHobbies(StudentVM studentVM);
        Task UpdateStudent(StudentVM student);
        bool validateEmailPhone(string email, string phone);
    }
}


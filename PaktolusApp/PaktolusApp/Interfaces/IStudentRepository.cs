using System;
using PaktolusApp.Models;
using PaktolusApp.ModelView;

namespace PaktolusApp.Interfaces
{
	public interface IStudentRepository : IBaseRepository<Student>
	{
        Task<IEnumerable<StudentVM>> GetStudentWithHobbiesNames();
        Task<StudentVM> GetStudentWithHobbies(int id);
        void RemoveHobbiesStudentById(int id);
        void AddHobbiesToStudent(Student student, List<int> hobbiesId);
    }
}


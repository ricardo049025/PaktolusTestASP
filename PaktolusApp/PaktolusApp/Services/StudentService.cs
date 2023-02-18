using System;
using PaktolusApp.Interfaces;
using PaktolusApp.Interfaces.Services;
using PaktolusApp.Models;
using Microsoft.EntityFrameworkCore;
using PaktolusApp.ModelView;

namespace PaktolusApp.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        protected IStudentRepository studentRepository;
        protected IHobbyRepository hobbyRepository;


        public StudentService(IStudentRepository studentRepository, IHobbyRepository hobbyRepository) : base(studentRepository)
        {
            this.studentRepository = studentRepository;
            this.hobbyRepository = hobbyRepository;
        }

        public Task<StudentVM> GetStudentWithHobbies(int id)
        {
            return this.studentRepository.GetStudentWithHobbies(id);

        }

        public Task<IEnumerable<StudentVM>> GetStudentWithHobbiesNames()
        {
            
            return this.studentRepository.GetStudentWithHobbiesNames();
        }

        public Task SaveStudentWithHobbies(StudentVM studentVM)
        {
            Student st = new Student();
          
            List<Hobby> hobbies = studentVM.HobbiesId != null ? this.hobbyRepository.getHobbiesByIds(studentVM.HobbiesId).ToList() : null;

            st.Name = studentVM.Name;
            st.Email = studentVM.Email;
            st.Phone = studentVM.Phone;
            st.ZipCode = studentVM.ZipCode;
            st.Hobbies = hobbies;

            return this.studentRepository.Add(st);
        }

        public Task UpdateStudent(StudentVM student)
        {
            List<Hobby> hobbies = new List<Hobby>();
            Student st = this.studentRepository.GetById(student.Id).Result;
            st.Name = student.Name;
            st.Email = student.Email;
            st.Phone = student.Phone;
            st.ZipCode = student.ZipCode;

            //removing all hobbies
            this.studentRepository.RemoveHobbiesStudentById(st.Id);

            //adding selected hobbies
            this.studentRepository.AddHobbiesToStudent(st, student.HobbiesId);

            return this.studentRepository.Update(st);

            
        }

        public bool validateEmailPhone(string email, string phone)
        {
            return this.studentRepository.GetAll().Result.Any(x => x.Email == email || x.Phone == phone);
        }
    }
}


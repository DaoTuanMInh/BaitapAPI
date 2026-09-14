using WebApplication1.IUser;
using WebApplication1.Model;

namespace WebApplication1.Student
{
    public class StudentService : IStudentservice
    {
        public Studentcs informasion(Studentcs studentcs)
        {
            var stu = new Studentcs()
            {
                name = studentcs.name,
                clas = studentcs.clas,
                soce = studentcs.soce,
                address = studentcs.address,
                gmail = studentcs.gmail,
            };
            return stu;
        }
    }
}

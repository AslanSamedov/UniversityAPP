using Ejournall.Commands.Main;
using Ejournall.DataAccessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ejournall.ViewModels
{
    public class MainWindowViewModel : BaseWindowViewModel
    {
        public MainWindowViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Grid CenterGrid { get; set; }

        public OpenStudentCommand StudentCommand => new OpenStudentCommand(this);
        public OpenTeacherCommand TeacherCommand => new OpenTeacherCommand(this);
        public OpenGroupCommand GroupCommand => new OpenGroupCommand(this);
        public OpenSpecialityCommand SpecialityCommand => new OpenSpecialityCommand(this);
        public OpenSubjectCommand SubjectCommand => new OpenSubjectCommand(this);
        public OpenExamCommand ExamCommand => new OpenExamCommand(this);
        public OpenLessonCommand LessonCommand => new OpenLessonCommand(this);
        public OpenExamScoreCommand ExamScore => new OpenExamScoreCommand(this);    
        public OpenLessonTimeCommand LessonTimesCommand => new OpenLessonTimeCommand(this);

    }
}

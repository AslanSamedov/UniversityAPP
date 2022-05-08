using Ejournall.Commands;
using Ejournall.Commands.ExamCommands;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.ViewModels.Controls
{
    public class ExamControlViewModel : BaseControlViewModel<ExamModel>
    {
        public ExamControlViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region Properties
        public List<LessonModel> Lessons { get; set; }
        private LessonModel selectedLesson;
        public LessonModel SelectedLesson
        {
            get => selectedLesson;

            set
            {
                selectedLesson = value;
                OnPropertyChanged(nameof(SelectedLesson));
            }
        }

        #endregion

        #region Commands
        public ExcelExportCommand<ExamModel, LessonModel> ExcelCommand =>new ExcelExportCommand<ExamModel, LessonModel>(this);
        public SaveExamCommand Save => new SaveExamCommand(this);
        public DeleteExamCommand Delete => new DeleteExamCommand(this);
        public RejectCommand<ExamModel> Reject => new RejectCommand<ExamModel>(this);

        #endregion

        public override void OnSearch()
        {
            var models = AllValues.Where(x => IsCompatibleWithValue(x.Lesson.Subject.Subject.Name) ||
                                             IsCompatibleWithValue(x.Lesson.Semester.Name) ||
                                             IsCompatibleWithValue(x.Lesson.Classroom.ClassNo.ToString()) ||
                                             IsCompatibleWithValue(x.Lesson.Group.Name) ||
                                             IsCompatibleWithValue(x.Lesson.Subject.Teacher.Name));

            Values = new ObservableCollection<ExamModel>(models);
        }
    }
}

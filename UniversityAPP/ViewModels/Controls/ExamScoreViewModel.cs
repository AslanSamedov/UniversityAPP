using Ejournall.Commands;
using Ejournall.Commands.ExamScoreCommands;
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
    public class ExamScoreViewModel : BaseControlViewModel<ExamScoreModel>
    {
        public ExamScoreViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        #region Properties 
        public List<StudentModel> Students { get; set; } = new List<StudentModel>();


        private StudentModel selectedStudent;
        public StudentModel SelectedStudent
        {
            get
            {
                return selectedStudent;
            }
            set
            {
                selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        public List<ExamModel> Exams { get; set; } = new List<ExamModel>();


        private ExamModel selectedExam;
        public ExamModel SelectedExam
        {
            get
            {
                return selectedExam;
            }
            set
            {
                selectedExam = value;
                OnPropertyChanged(nameof(SelectedExam));
            }
        }
        #endregion
        //
        #region Methods
        public override void OnSearch()
        {
            var models = AllValues.Where(x => IsCompatibleWithValue(x.Student.Name) ||
                                              IsCompatibleWithValue(x.Student.Surname) ||
                                              IsCompatibleWithValue(x.Score.ToString()) ||
                                              IsCompatibleWithValue(x.Exam.Lesson.Group.Name) ||
                                              IsCompatibleWithValue(x.No.ToString()) ||
                                              IsCompatibleWithValue(x.Exam.Lesson.Semester.Name) ||
                                              IsCompatibleWithValue(x.Exam.Lesson.Subject.Teacher.Name) ||
                                              IsCompatibleWithValue(x.Exam.Lesson.Subject.Subject.Name));

            Values = new ObservableCollection<ExamScoreModel>(models);

        }
        #endregion
        //
        #region Commands 
        public SaveExmScoreCommand Save => new SaveExmScoreCommand(this);
        public DeleteExamScoreCommand Delete => new DeleteExamScoreCommand(this);
        public RejectCommand<ExamScoreModel> Reject => new RejectCommand<ExamScoreModel>(this);
        public ExcelExportCommand<ExamScoreModel, ExamModel> ExcelCommand => new ExcelExportCommand<ExamScoreModel, ExamModel>(this);
        #endregion
    }
}

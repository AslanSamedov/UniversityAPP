using Ejournall.Commands;
using Ejournall.Commands.LessonCommands;
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
    public class LessonControlViewModel : BaseControlViewModel<LessonModel>
    {
        public LessonControlViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region Properties
        public List<GroupModel> Groups { get; set; }
        private GroupModel selectedGroup;
        public GroupModel SelectedGroup
        {
            get => selectedGroup;
            set
            {
                selectedGroup = value;
                OnPropertyChanged(nameof(SelectedGroup));
            }
        }

        public List<ClassRoomModel> ClassRooms{ get; set; }
        private ClassRoomModel selectedClassrooms;
        public ClassRoomModel SelectedClassRooms
        {
            get => selectedClassrooms;
            set
            {
                selectedClassrooms = value;
                OnPropertyChanged(nameof (SelectedClassRooms)); 
            }
        }

        public List<SemesterModel> Semesters { get; set; }
        private SemesterModel selectedSemester;
        public SemesterModel SelectedSemesters
        {
            get => selectedSemester;
            set
            {
                selectedSemester = value;
                OnPropertyChanged(nameof(SelectedSemesters));
            }

        }

        public List<TeacherSubjectModel> Subjects { get; set; }    
        private TeacherSubjectModel selectedSubject;
        public TeacherSubjectModel SelectedSubject
        {
            get => selectedSubject;
            set
            {
                selectedSubject = value;
                OnPropertyChanged(nameof(SelectedSubject));
            }
        }

        #endregion
        //
        #region Commands
        public SaveLessonCommand Save => new SaveLessonCommand(this);
        public DeleteLessonCommand Delete => new DeleteLessonCommand(this); 
        public RejectCommand<LessonModel> Reject => new RejectCommand<LessonModel> (this);
        public ExcelExportCommand<LessonModel, TeacherSubjectModel> ExcelCommand => new ExcelExportCommand<LessonModel, TeacherSubjectModel>(this); 

        #endregion
        //
        #region Methods
        public override void OnSearch()
        {
            var models = AllValues.Where(x => IsCompatibleWithValue(x.Subject.Subject.Name) ||
                                               IsCompatibleWithValue(x.Semester.Name) ||
                                               IsCompatibleWithValue(x.Classroom.ClassNo.ToString()) ||
                                               IsCompatibleWithValue(x.Group.Name) ||
                                               IsCompatibleWithValue(x.Subject.Teacher.Name));

            Values = new ObservableCollection<LessonModel>(models);
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Utils
{
    public class Constants
    {
        public const string DateFormat = "dd.MM.yyyy";

        public const string OperationSuccessMessage = "Operation completed successfully";
        public const string OperationFaultMessage = "Operation completed unsuccessfully";
        public const string ErrorMessage = "Unknown error occured.";
        public const string SureDeleteMessage = "Are you sure you want to delete?";

        public static string LogFileFolder = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Ejournall\";
        public static string LogFilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Ejournall\log.txt";
    }
}

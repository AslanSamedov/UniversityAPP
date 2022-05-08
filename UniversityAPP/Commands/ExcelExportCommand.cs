using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Ejournall.Attributes;
using Ejournall.Commands.Auth;
using Ejournall.Enums;
using Ejournall.Mapper;
using Ejournall.Models;
using Ejournall.Utils;
using Ejournall.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ejournall.Commands
{
    public class ExcelExportCommand<T,A> : BaseCommand  where T : BaseModel<T>, new() where A : BaseModel<A>, new()
    {
        private readonly BaseControlViewModel<T> viewModel;
        public ExcelExportCommand(BaseControlViewModel<T> viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                DefaultExt = "xlsx",
            };

            var result = saveFileDialog.ShowDialog();

            if (result == false)
                return;

            using (XLWorkbook workBook = new XLWorkbook())
            {
                DataTable dataTable = new DataTable();

               var propInfos = typeof(T).GetProperties();
                var necessaryPropInfos = new List<PropertyInfo>();

                foreach (var propInfo in propInfos)
                {
                    var attributesArr = propInfo.GetCustomAttribute(typeof(ExcelIgnoreAttribute), false);
                    if (attributesArr != null)
                        continue;

                    var displayAttributesArr = propInfo.GetCustomAttributes(typeof(ExcelDisplayDetailsAttribute), false);
                    var displayAttribute = displayAttributesArr.FirstOrDefault() as ExcelDisplayDetailsAttribute;
                    if(displayAttribute != null)
                    {
                        necessaryPropInfos.Insert(displayAttribute.ColumnNo,propInfo);
                    }
                    else
                    {
                        necessaryPropInfos.Add(propInfo);
                    }
                }
                foreach(var propInfo in necessaryPropInfos)
                {
                    dataTable.Columns.Add(propInfo.Name);
                }

                foreach(var value in viewModel.AllValues)
                {
                    object[] propValues = new object[necessaryPropInfos.Count];
                    for(int i = 0; i < propValues.Length; i++)
                    {
                        var propValue = necessaryPropInfos[i].GetValue(value);

                        if(propValue is BaseModel<A> model)
                        {
                            propValues[i] = model.ExcelToString();
                        }
                        else
                        {
                            propValues[i] = propValue;
                        }
                    }
                    dataTable.Rows.Add(propValues);
                }

                var workSheet = workBook.AddWorksheet();
                workSheet.Cell(1, 1).InsertTable(dataTable);
                workSheet.Columns().AdjustToContents();

                workBook.SaveAs(saveFileDialog.FileName);

                viewModel.Message = Constants.OperationSuccessMessage;
                DoAnimation(viewModel.ErrorDialog);
            }
        }
    }
}

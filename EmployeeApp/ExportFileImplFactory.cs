using System;

namespace EmployeeApp
{
    public class ExportFileImplFactory : ExportFileFactory
    {
        public override ExportEmployees GetExportFile(FileTypeEnum fileType)
        {
            switch (fileType)
            {
                case FileTypeEnum.CSV:
                    return new ExportCSVEmployees();                   
                case FileTypeEnum.JSON:
                    return new ExportJsonEmployees();                 
                case FileTypeEnum.DELIMITED:
                    return new ExportPipeDelimetedEmployees();                   
                default:
                    throw new ApplicationException(string.Format("File type '{0}' cannot be created", fileType));
            }
        }       
    }
}

namespace EmployeeApp
{
    public abstract class ExportFileFactory
    {
        public abstract ExportEmployees GetExportFile(FileTypeEnum fileType);
    }

}

using System;
using System.IO;
using System.Linq;

public class CompressedFile
{
    public CompressedFileTypes CompressedFileType { get; private set; }
    public string CompressedFileName { get; private set; }
    public string CompressedDirectory { get; private set; }

    public string CompressedDirectoryFullPath { get; private set; }

    public CompressedFile(string fullPath)
    {
        CompressedDirectoryFullPath = fullPath;
        _setParams(fullPath);
    }

    private void _setParams(string fullPath)
    {
        string fullName = Path.GetFileName(fullPath);
        _setFileNameParts(fullName);
        _setCompressedDirectory(fullPath);
    }

    private void _setFileNameParts(string fileName)
    {
        _setExtension(fileName);
        _setFileName(fileName);
    }

    private void _setExtension(string fileName)
    {
        var fileType = fileName.Split(".").Last();
        _convertExtentionToEnum(fileType);
    }

    private void _setFileName(string fileName)
    {
        string extention = "." + CompressedFileType.ToString();
        CompressedFileName = fileName.Substring(0, fileName.Length - extention.Length);
    }

    private void _setCompressedDirectory(string fullPath)
    {
        string fullFileName = CompressedFileName + "." + CompressedFileType.ToString();
        CompressedDirectory = fullPath.Substring(0, fullPath.Length - fullFileName.Length);

    }

    private void _convertExtentionToEnum(string extention)
    {
        Enum.TryParse(extention, out CompressedFileTypes CompressedFileType);
    }
}
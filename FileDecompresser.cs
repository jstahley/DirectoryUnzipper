using System.Linq;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;

public class FileDecompresser
{
    private CompressedFile _compressedFile;
    public FileDecompresser(CompressedFile fileToDecompress)
    {
        _compressedFile = fileToDecompress;
    }

    public void Decompress()
    {
        using (var archive = RarArchive.Open(_compressedFile.CompressedDirectoryFullPath))
        {
            foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
            {
                entry.WriteToDirectory(_compressedFile.CompressedDirectory, new ExtractionOptions()
                {
                    ExtractFullPath = true,
                    Overwrite = true
                });
            }
        }
    }
}
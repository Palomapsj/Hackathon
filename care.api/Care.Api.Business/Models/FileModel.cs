namespace Care.Api.Business.Models
{
    public class FileModel
    {
        public byte[] FileRaw { get; }
        public string MimeType { get; }
        public long FileSize { get; }
        public string Extension { get; }

        public FileModel(byte[] fileRaw, string mimeType, long fileSize, string extension)
        {
            FileRaw = fileRaw;
            MimeType = mimeType;
            FileSize = fileSize;
            Extension = extension;
        }
    }
}

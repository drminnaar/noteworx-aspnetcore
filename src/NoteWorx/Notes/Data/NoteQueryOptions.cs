namespace NoteWorx.Notes.Data
{
    public sealed class NoteQueryOptions
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Term { get; set; } = string.Empty;
        public string Tag { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Order { get; set; } = string.Empty;
    }
}

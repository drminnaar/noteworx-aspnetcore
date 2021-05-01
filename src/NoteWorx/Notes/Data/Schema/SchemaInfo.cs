namespace NoteWorx.Notes.Data.Schema
{
    internal static partial class SchemaInfo
    {
        private static readonly string _shortSchemaName = SchemaName.Replace("_", "").ToLower();

        internal const string SchemaName = "note_data";
    }
}

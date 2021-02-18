using System;

namespace BlazorApp1.Shared.Components.Models.NoteList
{
    public class NoteListData
    {
        public int Icon { get; set; }

        public int Id { get; set; }

        public int Status { get; set; }

        public DateTime Created { get; set; }

        public int Length { get; set; }

        public string Author { get; set; }
    }
}

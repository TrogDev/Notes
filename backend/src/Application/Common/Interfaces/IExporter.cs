namespace Notes.Application.Common.Interfaces;

using Notes.Application.DTO;

public interface IExporter
{
    byte[] Export(List<NoteDTO> notes);
}

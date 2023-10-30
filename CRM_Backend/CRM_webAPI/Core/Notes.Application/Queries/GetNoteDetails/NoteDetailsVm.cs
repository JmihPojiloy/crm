using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Queries.GetNoteDetails
{
    public class NoteDetailsVm : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteDetailsVm>()
                .ForMember(noteVm => noteVm.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteVm => noteVm.Name,
                    opt => opt.MapFrom(note => note.Name))
                .ForMember(noteVm => noteVm.Description,
                    opt => opt.MapFrom(note => note.Description))
                .ForMember(noteVm => noteVm.Contact,
                    opt => opt.MapFrom(note => note.Contact))
                .ForMember(noteVm => noteVm.Status,
                    opt => opt.MapFrom(note => note.Status))
                .ForMember(noteVm => noteVm.CreationDate,
                    opt => opt.MapFrom(note => note.CreationDate));
        }
    }
}

using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Queries.GetNoteList
{
    public class NoteLookUpDto : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookUpDto>()
                .ForMember(noteDto => noteDto.Id, 
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.Name,
                    opt => opt.MapFrom(note => note.Name));
        }
    }
}

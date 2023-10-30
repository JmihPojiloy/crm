using Notes.Application.Commands.CreateNote;
using AutoMapper;
using Notes.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace Notes.WebApi.Models
{
    public class CreateNoteDto : IMapWith<CreateNoteCommand>
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }

        public void Mapping (Profile profile)
        {
            profile.CreateMap<CreateNoteDto, CreateNoteCommand>()
                .ForMember(noteCommand => noteCommand.Name,
                    opt => opt.MapFrom(noteDto => noteDto.Name))
                .ForMember(noteCommand => noteCommand.Description,
                    opt => opt.MapFrom(noteDto => noteDto.Description))
                .ForMember(noteCommand => noteCommand.Contact,
                    opt => opt.MapFrom(noteDto => noteDto.Contact));
        }
    }
}

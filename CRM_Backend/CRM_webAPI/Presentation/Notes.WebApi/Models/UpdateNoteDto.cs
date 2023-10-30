using AutoMapper;
using Notes.Application.Commands.UpdateNote;
using Notes.Application.Common.Mappings;

namespace Notes.WebApi.Models
{
    public class UpdateNoteDto : IMapWith<UpdateNoteCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }

        public string Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>()
                .ForMember(noteCommand => noteCommand.Id,
                    opt => opt.MapFrom(noteDto => noteDto.Id))
                .ForMember(noteCommand => noteCommand.Name,
                    opt => opt.MapFrom(noteDto => noteDto.Name))
                .ForMember(noteCommand => noteCommand.Description,
                    opt => opt.MapFrom(noteDto => noteDto.Description))
                .ForMember(noteCommand => noteCommand.Contact,
                    opt => opt.MapFrom(noteDto => noteDto.Contact))
                .ForMember(noteCommand => noteCommand.Status,
                    opt => opt.MapFrom(noteDto => noteDto.Status));
        }
    }
}

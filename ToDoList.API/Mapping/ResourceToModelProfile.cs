using AutoMapper;
using ToDoList.Domain.Models;
using ToDoList.DTO;

namespace ToDoList.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<ToDoListItemResource, ToDoListItem>();
        }
    }
}
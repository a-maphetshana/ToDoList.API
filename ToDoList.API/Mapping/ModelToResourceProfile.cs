using AutoMapper;
using ToDoList.Domain.Models;
using ToDoList.DTO;

namespace ToDoList.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<ToDoListItem, ToDoListItemResource>();
        }
    }
}

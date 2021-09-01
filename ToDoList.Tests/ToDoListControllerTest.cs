using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using ToDoList.API.Controllers;
using ToDoList.API.Mapping;
using ToDoList.Domain.IServices;
using ToDoList.Domain.IServices.Communication;
using ToDoList.Domain.Models;
using ToDoList.DTO;
using Xunit;

namespace ToDoList.Tests
{
    public class ToDoListControllerTest
    {
        #region Property  
        public Mock<IToDoListItemService> mock = new Mock<IToDoListItemService>();
        private readonly Mock<ILogger<ToDoListController>> _logger = new Mock<ILogger<ToDoListController>>();
        //private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        private static IMapper _mapper;
        #endregion

        public ToDoListControllerTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new ModelToResourceProfile());
                    mc.AddProfile(new ResourceToModelProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
        [Fact]
        //Expected to throw NullReferenceException 
        public async void InsertToDoListItem()
        {
            ToDoListItemResource toDoListItemPostResource = new ToDoListItemResource()
            {
                ToDoListItemID = 1,
                Name = "Test task 1"
            };

            var toDoListItem = _mapper.Map<ToDoListItemResource, ToDoListItem>(toDoListItemPostResource);

            ToDoListItemResponse toDoListItemResponse = new ToDoListItemResponse(toDoListItem);
            mock.Setup(p => p.SaveAsync(toDoListItem)).ReturnsAsync(toDoListItemResponse);

            ToDoListController toDoListController = new ToDoListController(_logger.Object, mock.Object, _mapper);
                       
            var result = await toDoListController.PostAsync(toDoListItemPostResource);
            Assert.True(toDoListItemPostResource.Equals(result));
        }
        [Fact]
        //Expected to pass
        public async void GetToDoListItemById()
        {
            int toDoListItemID = 1;
            ToDoListItem toDoListItem = new ToDoListItem()
            {
                ToDoListItemID = toDoListItemID,
                Name = "Test task 1"
            };
            mock.Setup(p => p.FindByIdAsync(1)).ReturnsAsync(toDoListItem);
            ToDoListController toDoListController = new ToDoListController(_logger.Object, mock.Object, _mapper);
            ToDoListItem result = await toDoListController.GetAsync(toDoListItemID);
            Assert.Equal(toDoListItem, result);
        }
    }
}

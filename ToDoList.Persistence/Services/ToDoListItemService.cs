using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.IRepositories;
using ToDoList.Domain.IServices;
using ToDoList.Domain.IServices.Communication;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Repositories;

namespace FruitSA.Persistence.Services
{
    public class ToDoListItemService : IToDoListItemService
    {
        private readonly IToDoListItemRepository _toDoListItemRepository;
        private readonly IUnitOfWork _unitOfWork;


        public ToDoListItemService(IToDoListItemRepository toDoListItemRepository, IUnitOfWork unitOfWork)
        {
            _toDoListItemRepository = toDoListItemRepository;
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<ToDoListItem>> ListAsync()
        {
            return _toDoListItemRepository.ListAsync();
        }

        public Task<ToDoListItem> FindByIdAsync(long id)
        {
            return _toDoListItemRepository.FindByIdAsync(id);
        }

        public async Task<ToDoListItemResponse> SaveAsync(ToDoListItem toDoListItem)
        {
            try
            {
                await _toDoListItemRepository.AddAsync(toDoListItem);
                await _unitOfWork.CompleteAsync();

                return new ToDoListItemResponse(toDoListItem);
            }
            catch (Exception ex)
            {
                return new ToDoListItemResponse($"An error occured while saving the toDoListItem: {ex.Message}");
            }
        }

        public async Task<ToDoListItemResponse> UpdateAsync(long id, ToDoListItem toDoListItem)
        {
            var existingToDoListItem = await _toDoListItemRepository.FindByIdAsync(id);

            if (existingToDoListItem == null)
                return new ToDoListItemResponse("ToDoListItem not found");

            existingToDoListItem.Name = toDoListItem.Name;

            try
            {
                await _unitOfWork.CompleteAsync();
                return new ToDoListItemResponse(existingToDoListItem);
            }
            catch (Exception ex)
            {
                return new ToDoListItemResponse($"An error occured while updating the toDoListItem: {ex.Message}");
            }

        }

        public async Task<ToDoListItemResponse> DeleteAsync(long id)
        {
            var existingToDoListItem = await _toDoListItemRepository.FindByIdAsync(id);

            if (existingToDoListItem == null)
                return new ToDoListItemResponse("ToDoListItem not found");

            try
            {
                _toDoListItemRepository.Delete(existingToDoListItem);
                await _unitOfWork.CompleteAsync();
                return new ToDoListItemResponse(existingToDoListItem);
            }
            catch (Exception ex)
            {
                return new ToDoListItemResponse($"An error occured while deleting the toDoListItem: {ex.Message}");
            }
        }
    }
}

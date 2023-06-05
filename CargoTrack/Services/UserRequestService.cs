using server.CargoTrack.App.Domain.Repository;
using server.CargoTrack.Domain.Core;
using server.CargoTrack.Domain.Core.Communication;
using server.CargoTrack.Domain.Models;
using Shared.Domain.Repositories;

namespace server.CargoTrack.Services;

public class UserRequestService:IUserRequestService
{
    private readonly IUserRequestRepository _userRequestRepository;

    private readonly IUnitOfWork _unitOfWork;
    public UserRequestService(IUserRequestRepository userRequestRepository, IUnitOfWork unitOfWork)
    {
        _userRequestRepository = userRequestRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<UserRequest>> ListAsync()
    {
        return await _userRequestRepository.ListAsync();
    }

    public async Task<UserRequestResponse> SaveAsync(UserRequest userRequest)
    {
        try
        {
            await _userRequestRepository.AddAsync(userRequest);
            await _unitOfWork.CompleteAsync();

            return new UserRequestResponse(userRequest);
        }
        catch (Exception e)
        {
            return new UserRequestResponse($"An error occurred while saving the UserRequest: {e.Message}");
        }
    }

    public async Task<UserRequestResponse> UpdateAsync(int id, UserRequest userRequest)
    {
        var existingUserRequest = await _userRequestRepository.FindByIdAsync(id);

        if (existingUserRequest == null)
            return new UserRequestResponse("UserRequest not found.");

        existingUserRequest.AddressStart = userRequest.AddressStart;
        existingUserRequest.AddressEnd = userRequest.AddressEnd;
        existingUserRequest.ReferenceAddress = userRequest.ReferenceAddress;
        existingUserRequest.Photo = userRequest.Photo;
        existingUserRequest.Description = userRequest.Description;
        existingUserRequest.Date = userRequest.Date;
        existingUserRequest.Hour = userRequest.Hour;
        

        try
        {
            _userRequestRepository.Update(existingUserRequest);
            await _unitOfWork.CompleteAsync();
            
            return new UserRequestResponse(existingUserRequest);
        }
        catch (Exception e)
        {
            return new UserRequestResponse($"An error occurred while updating the UserRequest: {e.Message}");
        }
    }

    public async Task<UserRequestResponse> DeleteAsync(int id)
    {
        var existingUserRequest = await _userRequestRepository.FindByIdAsync(id);

        if (existingUserRequest == null)
            return new UserRequestResponse("UserRequest not found.");

        try
        {
            _userRequestRepository.Remove(existingUserRequest);
            await _unitOfWork.CompleteAsync();

            return new UserRequestResponse(existingUserRequest);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new UserRequestResponse($"An error occurred while deleting the UserRequest: {e.Message}");
        }
    }
}
using server.CargoTrack.App.Domain.Repository;
using server.CargoTrack.Domain.Core;
using server.CargoTrack.Domain.Core.Communication;
using server.CargoTrack.Domain.Models;
using Shared.Domain.Repositories;

namespace server.CargoTrack.Services;

public class CourierService:ICourierService
{
    private readonly ICourierRepository _courierRepository;

    private readonly IUnitOfWork _unitOfWork;
    public CourierService(ICourierRepository courierRepository, IUnitOfWork unitOfWork)
    {
        _courierRepository = courierRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Courier>> ListAsync()
    {
        return await _courierRepository.ListAsync();
    }

    public async Task<CourierResponse> SaveAsync(Courier courier)
    {
        try
        {
            await _courierRepository.AddAsync(courier);
            await _unitOfWork.CompleteAsync();

            return new CourierResponse(courier);
        }
        catch (Exception e)
        {
            return new CourierResponse($"An error occurred while saving the Courier: {e.Message}");
        }
    }

    public async Task<CourierResponse> UpdateAsync(int id, Courier courier)
    {
        var existingCourier = await _courierRepository.FindByIdAsync(id);

        if (existingCourier == null)
            return new CourierResponse("Courier not found.");

        existingCourier.DNI = courier.DNI;
        existingCourier.Name = courier.Name;
        existingCourier.LastName = courier.LastName;
        existingCourier.BirthDay = courier.BirthDay;
        existingCourier.Email = courier.Email;
        existingCourier.LicenseNumber = courier.LicenseNumber;

        try
        {
            _courierRepository.Update(existingCourier);
            await _unitOfWork.CompleteAsync();
            
            return new CourierResponse(existingCourier);
        }
        catch (Exception e)
        {
            return new CourierResponse($"An error occurred while updating the Courier: {e.Message}");
        }
    }

    public async Task<CourierResponse> DeleteAsync(int id)
    {
        var existingCourier = await _courierRepository.FindByIdAsync(id);

        if (existingCourier == null)
            return new CourierResponse("Courier not found.");

        try
        {
            _courierRepository.Remove(existingCourier);
            await _unitOfWork.CompleteAsync();

            return new CourierResponse(existingCourier);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new CourierResponse($"An error occurred while deleting the Courier: {e.Message}");
        }
    }
}
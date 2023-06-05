using server.CargoTrack.App.Domain.Repository;
using server.CargoTrack.Domain.Core;
using server.CargoTrack.Domain.Core.Communication;
using server.CargoTrack.Domain.Models;
using Shared.Domain.Repositories;

namespace server.CargoTrack.Services;

public class VehicleService:IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;

    private readonly IUnitOfWork _unitOfWork;
    public VehicleService(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    {
        _vehicleRepository = vehicleRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Vehicle>> ListAsync()
    {
        return await _vehicleRepository.ListAsync();
    }
    
    public async Task<VehicleResponse> SaveAsync(Vehicle vehicle)
    {
        try
        {
            await _vehicleRepository.AddAsync(vehicle);
            await _unitOfWork.CompleteAsync();

            return new VehicleResponse(vehicle);
        }
        catch (Exception e)
        {
            return new VehicleResponse($"An error occurred while saving the Vehicle: {e.Message}");
        }
    }

    public async Task<VehicleResponse> UpdateAsync(int id, Vehicle vehicle)
    {
        var existingVehicle = await _vehicleRepository.FindByIdAsync(id);

        if (existingVehicle == null)
            return new VehicleResponse("Vehicle not found.");

        existingVehicle.Plate = vehicle.Plate;
        existingVehicle.Photo = vehicle.Photo;
        existingVehicle.CirculationCard = vehicle.CirculationCard;

        try
        {
            _vehicleRepository.Update(existingVehicle);
            await _unitOfWork.CompleteAsync();
            
            return new VehicleResponse(existingVehicle);
        }
        catch (Exception e)
        {
            return new VehicleResponse($"An error occurred while updating the Vehicle: {e.Message}");
        }
    }

    public async Task<VehicleResponse> DeleteAsync(int id)
    {
        var existingVehicle = await _vehicleRepository.FindByIdAsync(id);

        if (existingVehicle == null)
            return new VehicleResponse("Vehicle not found.");

        try
        {
            _vehicleRepository.Remove(existingVehicle);
            await _unitOfWork.CompleteAsync();

            return new VehicleResponse(existingVehicle);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new VehicleResponse($"An error occurred while deleting the Vehicle: {e.Message}");
        }
    }
}
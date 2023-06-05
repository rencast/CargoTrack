using server.CargoTrack.App.Domain.Repository;
using server.CargoTrack.Domain.Core;
using server.CargoTrack.Domain.Core.Communication;
using server.CargoTrack.Domain.Models;
using Shared.Domain.Repositories;


namespace server.CargoTrack.Services;

public class BrandVehicleService:IBrandVehicleService
{
    private readonly IBrandVehicleRepository _brandVehicleRepository;

    private readonly IUnitOfWork _unitOfWork;
    public BrandVehicleService(IBrandVehicleRepository brandVehicleRepository, IUnitOfWork unitOfWork)
    {
        _brandVehicleRepository = brandVehicleRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<BrandVehicle>> ListAsync()
    {
        return await _brandVehicleRepository.ListAsync();
    }
    
    public async Task<BrandVehicleResponse> SaveAsync(BrandVehicle brandVehicle)
    {
        try
        {
            await _brandVehicleRepository.AddAsync(brandVehicle);
            await _unitOfWork.CompleteAsync();

            return new BrandVehicleResponse(brandVehicle);
        }
        catch (Exception e)
        {
            return new BrandVehicleResponse($"An error occurred while saving the BrandVehicle: {e.Message}");
        }
    }

    public async Task<BrandVehicleResponse> UpdateAsync(int id, BrandVehicle brandVehicle)
    {
        var existingBrandVehicle = await _brandVehicleRepository.FindByIdAsync(id);

        if (existingBrandVehicle == null)
            return new BrandVehicleResponse("BrandVehicle not found.");

        existingBrandVehicle.Brand = brandVehicle.Brand;

        try
        {
            _brandVehicleRepository.Update(existingBrandVehicle);
            await _unitOfWork.CompleteAsync();
            
            return new BrandVehicleResponse(existingBrandVehicle);
        }
        catch (Exception e)
        {
            return new BrandVehicleResponse($"An error occurred while updating the BrandVehicle: {e.Message}");
        }
    }

    public async Task<BrandVehicleResponse> DeleteAsync(int id)
    {
        var existingBrandVehicle = await _brandVehicleRepository.FindByIdAsync(id);

        if (existingBrandVehicle == null)
            return new BrandVehicleResponse("BrandVehicle not found.");

        try
        {
            _brandVehicleRepository.Remove(existingBrandVehicle);
            await _unitOfWork.CompleteAsync();

            return new BrandVehicleResponse(existingBrandVehicle);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new BrandVehicleResponse($"An error occurred while deleting the BrandVehicle: {e.Message}");
        }
    }
}
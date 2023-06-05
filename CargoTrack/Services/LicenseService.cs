
using server.CargoTrack.App.Domain.Repository;
using server.CargoTrack.Domain.Core;
using server.CargoTrack.Domain.Core.Communication;
using server.CargoTrack.Domain.Models;
using Shared.Domain.Repositories;

namespace server.CargoTrack.Services;

public class LicenseService:ILicenseService
{
    private readonly ILicenseRepository _licenseRepository;
    private readonly IUnitOfWork _unitOfWork;
    public LicenseService(ILicenseRepository licenseRepository, IUnitOfWork unitOfWork)
    {
        _licenseRepository = licenseRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<License>> ListAsync()
    {
        return await _licenseRepository.ListAsync();
    }

    public async Task<LicenseResponse> SaveAsync(License license)
    {
        try
        {
            await _licenseRepository.AddAsync(license);
            await _unitOfWork.CompleteAsync();

            return new LicenseResponse(license);
        }
        catch (Exception e)
        {
            return new LicenseResponse($"An error occurred while saving the License: {e.Message}");
        }
    }

    public async Task<LicenseResponse> UpdateAsync(int id, License license)
    {
        var existingLicense = await _licenseRepository.FindByIdAsync(id);
        if (existingLicense == null)
            return new LicenseResponse("License not found");

        existingLicense.Class = license.Class;
        existingLicense.Category = license.Category;
        existingLicense.Courier_PersonId = license.Courier_PersonId;

        try
        {
            _licenseRepository.Update(existingLicense);
            await _unitOfWork.CompleteAsync();

            return new LicenseResponse(existingLicense);
        }
        catch (Exception e)
        {
            return new LicenseResponse($"An error occurred while updating the Courier: {e.Message}");
        }
    }

    public async Task<LicenseResponse> DeleteAsync(int id)
    {
        var existingLicense = await _licenseRepository.FindByIdAsync(id);

        if (existingLicense == null)
            return new LicenseResponse("License not found.");

        try
        {
            _licenseRepository.Remove(existingLicense);
            await _unitOfWork.CompleteAsync();

            return new LicenseResponse(existingLicense);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new LicenseResponse($"An error occurred while deleting the License: {e.Message}");
        }
    }
}
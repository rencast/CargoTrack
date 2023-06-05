using server.CargoTrack.App.Domain.Repository;
using server.CargoTrack.Domain.Core;
using server.CargoTrack.Domain.Core.Communication;
using server.CargoTrack.Domain.Models;
using Shared.Domain.Repositories;

namespace server.CargoTrack.Services;

public class PaymentMethodService:IPaymentMethodService
{
    private readonly IPaymentMethodRepository _paymentMethodRepository;

    private readonly IUnitOfWork _unitOfWork;
    public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository, IUnitOfWork unitOfWork)
    {
        _paymentMethodRepository = paymentMethodRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<PaymentMethod>> ListAsync()
    {
        return await _paymentMethodRepository.ListAsync();
    }

    public async Task<PaymentMethodResponse> SaveAsync(PaymentMethod paymentMethod)
    {
        try
        {
            await _paymentMethodRepository.AddAsync(paymentMethod);
            await _unitOfWork.CompleteAsync();

            return new PaymentMethodResponse(paymentMethod);
        }
        catch (Exception e)
        {
            return new PaymentMethodResponse($"An error occurred while saving the PaymentMethod: {e.Message}");
        }
    }

    public async Task<PaymentMethodResponse> UpdateAsync(int id, PaymentMethod paymentMethod)
    {
        var existingPaymentMethod = await _paymentMethodRepository.FindByIdAsync(id);

        if (existingPaymentMethod == null)
            return new PaymentMethodResponse("PaymentMethod not found.");

        existingPaymentMethod.Type = paymentMethod.Type;

        try
        {
            _paymentMethodRepository.Update(existingPaymentMethod);
            await _unitOfWork.CompleteAsync();
            
            return new PaymentMethodResponse(existingPaymentMethod);
        }
        catch (Exception e)
        {
            return new PaymentMethodResponse($"An error occurred while updating the PaymentMethod: {e.Message}");
        }
    }

    public async Task<PaymentMethodResponse> DeleteAsync(int id)
    {
        var existingPaymentMethod = await _paymentMethodRepository.FindByIdAsync(id);

        if (existingPaymentMethod == null)
            return new PaymentMethodResponse("PaymentMethod not found.");

        try
        {
            _paymentMethodRepository.Remove(existingPaymentMethod);
            await _unitOfWork.CompleteAsync();

            return new PaymentMethodResponse(existingPaymentMethod);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new PaymentMethodResponse($"An error occurred while deleting the PaymentMethod: {e.Message}");
        }
    }
}
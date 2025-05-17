using NajotTalim.HR.API.Models;
using NajotTalim.HR.DataAcces;
using NajotTalim.HR.DataAcces.Entities;

namespace NajotTalim.HR.API.Services
{
    public class AdressCRUDService : IGenericCRUDService<AdressModel>
    {
        private readonly IAdressRepository _adressRepository;

        public AdressCRUDService(IAdressRepository adressRepository)
        {
            _adressRepository = adressRepository;
        }

        public async Task<AdressModel> Create(AdressModel model)
        {
            var adress = new Adress
            {
                AdressLine1 = model.AdressLine1,
                AdressLine2 = model.AdressLine2,
                PostalCode = model.PostalCode,
                City = model.City,
                Country = model.Country,
            };

            var createdAdress = await _adressRepository.Create(adress);
            var result = new AdressModel
            {
                Id = createdAdress.Id,
                AdressLine1 = createdAdress.AdressLine1,
                AdressLine2 = createdAdress.AdressLine2,
                PostalCode = createdAdress.PostalCode,
                City = createdAdress.City,
                Country = createdAdress.Country,
            };

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _adressRepository.Delete(id);
        }

        public async Task<AdressModel> Get(int id)
        {
            var adress = await _adressRepository.Get(id);
            var model = new AdressModel
            {
                Id = adress.Id,
                AdressLine1 = adress.AdressLine1,
                AdressLine2 = adress.AdressLine2,
                PostalCode = adress.PostalCode,
                City = adress.City,
                Country = adress.Country,
            };

            return model;
        }

        public async Task<IEnumerable<AdressModel>> GetAll()
        {
            var result = new List<AdressModel>();
            var adresses = await _adressRepository.GetAll();
            foreach (var adress in adresses)
            {
                var model = new AdressModel
                {
                    Id = adress.Id,
                    AdressLine1 = adress.AdressLine1,
                    AdressLine2 = adress.AdressLine2,
                    PostalCode = adress.PostalCode,
                    City = adress.City,
                    Country = adress.Country,
                };
                result.Add(model);
            }

            return result;
        }

        public async Task<AdressModel> Update(int id, AdressModel model)
        {
            var adress = new Adress
            {
                Id = model.Id,
                AdressLine1 = model.AdressLine1,
                AdressLine2 = model.AdressLine2,
                PostalCode = model.PostalCode,
                City = model.City,
                Country = model.Country,
            };

            var updatedEmployee = await _adressRepository.Update(id, adress);
            var result = new AdressModel
            {
                Id = adress.Id,
                AdressLine1 = adress.AdressLine1,
                AdressLine2 = adress.AdressLine2,
                PostalCode = adress.PostalCode,
                City = adress.City,
                Country = adress.Country,
            };

            return result;
        }
    }
}

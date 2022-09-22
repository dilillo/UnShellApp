namespace UnShellApp
{
    public interface IConnectedProductsApiClient
    {
        Task<SerialNumberInfoModel> GetSerialNumberInfo(string serialNumberId);

        Task CreatePartnerLocationProduct(PartnerLocationProductModel partnerLocationProductModel);

        Task<List<PartnerLocationProductModel>> GetPartnerLocationProducts(string partnerLocationProductId);

        Task<List<PartnerLocationModel>> GetPartnerLocations(string partnerId);

        Task<List<PartnerModel>> GetPartners();
    }

    public class ConnectedProductsApiClient : IConnectedProductsApiClient
    {
        List<PartnerModel> _partners = new()
        {
            new PartnerModel
            {
                Id = "1",
                Name = "Customer 1"
            },
            new PartnerModel
            {
                Id = "2",
                Name = "Customer 2"
            },
            new PartnerModel
            {
                Id = "3",
                Name = "Customer 3"
            }
        };

        List<PartnerLocationModel> _partnerLocations = new()
        {
            new PartnerLocationModel
            {
                Id = "1",
                PartnerId = "1",
                Name = "Location 1"
            },
            new PartnerLocationModel
            {
                Id = "2",
                PartnerId = "1",
                Name = "Location 2"

            },
            new PartnerLocationModel
            {
                Id = "3",
                PartnerId = "2",
                Name = "Location 3"
            }
        };

        List<PartnerLocationProductModel> _partnerLocationProducts = new()
        {
            new PartnerLocationProductModel
            {
                Id = "1",
                PartnerId = "1",
                PartnerLocationId = "1",
                Name = "Product 1"
            },
            new PartnerLocationProductModel
            {
                Id = "2",
                PartnerId = "1",
                PartnerLocationId = "1",
                Name = "Product 2"

            },
            new PartnerLocationProductModel
            {
                Id = "3",
                PartnerId = "2",
                PartnerLocationId = "3",
                Name = "Product 3"
            }
        };

        List<SerialNumberInfoModel> _serialNumberInfos = new()
        {
            new SerialNumberInfoModel
            {
                Id = "4",
                Name = "Product 4",
                IsPrimary = true
            },
            new SerialNumberInfoModel
            {
                Id = "5",
                Name = "Product 5",
                IsPrimary = true,
                NeedsSecondary = true
            },
            new SerialNumberInfoModel
            {
                Id = "6",
                Name = "Product 6"
            }
        };

        private const int NonStandardDelay = 3000;
        private const int StandardDelay = 1000;

        public async Task<SerialNumberInfoModel> GetSerialNumberInfo(string serialNumberId)
        {
            await Task.Delay(NonStandardDelay);

            return _serialNumberInfos.SingleOrDefault(i => i.Id == serialNumberId);
        }

        public async Task<List<PartnerModel>> GetPartners()
        {
            await Task.Delay(StandardDelay);

            return _partners;
        }

        public async Task<List<PartnerLocationModel>> GetPartnerLocations(string partnerId)
        {
            await Task.Delay(StandardDelay);

            return _partnerLocations.Where(i => i.PartnerId == partnerId).ToList();
        }

        public async Task<List<PartnerLocationProductModel>> GetPartnerLocationProducts(string partnerLocationProductId)
        {
            await Task.Delay(StandardDelay);

            return _partnerLocationProducts.Where(i => i.PartnerId == partnerLocationProductId).ToList();
        }

        public async Task CreatePartnerLocationProduct(PartnerLocationProductModel partnerLocationProductModel)
        {
            await Task.Delay(StandardDelay);

            var existingItem = _partnerLocationProducts.FirstOrDefault(i => i.Id == partnerLocationProductModel.Id);

            if (existingItem != null)
            {
                _partnerLocationProducts.Remove(existingItem);
            }

            _partnerLocationProducts.Add(partnerLocationProductModel);
        }
    }

    public class PartnerModel
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }

    public class PartnerLocationModel
    {
        public string Id { get; set; }

        public string PartnerId { get; set; }

        public string Name { get; set; }
    }

    public class PartnerLocationProductModel
    {
        public string Id { get; set; }

        public string PartnerId { get; set; }

        public string PartnerLocationId { get; set; }

        public string Name { get; set; }
    }

    public class SerialNumberInfoModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsPrimary { get; set; }

        public bool NeedsSecondary { get; set; }
    }
}

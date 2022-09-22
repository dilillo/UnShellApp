namespace UnShellApp
{
    public class AddProductContext
    {
        public PartnerModel Partner { get; set; }

        public PartnerLocationModel PartnerLocation { get; set; }

        public PartnerLocationProductModel PrimaryProduct { get; set; }

        public PartnerLocationProductModel SecondaryProduct { get; set; }
    }
}

namespace Pharmagest.Dto.Company
{
    public class ResponseVatDto
    {

        public CompanyDto Company { get; set; }

        public bool IsValid { get; set; }

        public string ErrorMessage { get; set; }
    }
}

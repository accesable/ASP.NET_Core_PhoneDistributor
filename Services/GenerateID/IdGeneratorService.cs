namespace WebApplication_Slicone_Supplier.Services.GenerateID
{
    public class IdGeneratorService : IIdGeneratorService
    {
        public string GenerateId(string l)
        {
            return Guid.NewGuid().ToString();
        }

        public string GenerateIdForIventories(string IventoryAddress)
        {
            string[] regex = IventoryAddress.Split(' ');
            string reVal ="SOC";
            foreach (string s in regex)
            {
                reVal += s.Substring(0, 1).ToUpper();
            }
            return reVal;
        }
    }
}

namespace MedCenter.Contracts.Patients
{
    public class PatientResponse
    {
        public int Id {  get; set; }
        public string Name { get; set; } = string.Empty;
        public string SeName { get; set; } = string.Empty;
        public DateOnly BirthDay { get; set; }
    }
}

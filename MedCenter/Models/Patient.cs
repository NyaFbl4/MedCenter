namespace MedCenter.Models
{
    public class Patient : People
    {
        public Patient(string name, string seName, DateOnly birthDay) 
        {
            SetName(name);
            SetSeName(seName);
            SetBirthDay(birthDay);
        }
    }
}

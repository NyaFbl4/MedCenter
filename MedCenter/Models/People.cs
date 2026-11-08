using System.Xml.Linq;

namespace MedCenter.Models
{
    public class People
    {
        private int _id;
        private string _name = string.Empty;
        private string _seName = string.Empty;
        private DateOnly _birthDay;

        public int Id => _id;
        public string Name => _name;
        public string SeName => _seName;
        public DateOnly BirthDay => _birthDay;

        public void SetId(int id)
        { 
            _id = id;
        }

        public void SetName(string name)
        {
            if(!string.IsNullOrWhiteSpace(name))
                _name = name;
            else
                throw new ArgumentException("Имя не может быть пустым.", nameof(name));
        }

        public void SetSeName(string seName)
        {
            if (!string.IsNullOrWhiteSpace(seName))
                _seName = seName;
            else
                throw new ArgumentException("Фамилия не может быть пустым.", nameof(seName));
        }

        public void SetBirthDay(DateOnly birthDay)
        {
            _birthDay = birthDay;
        }
    }
}

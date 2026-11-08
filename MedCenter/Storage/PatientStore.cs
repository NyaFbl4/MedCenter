using MedCenter.Models;

namespace MedCenter.Storage
{
    public class PatientStore
    {
        private readonly Lock _sync = new();
        private Dictionary<int, Patient> _patients = new();
        private int _nextId = 1;

        public Patient CreatePatient(Patient patient)
        {
            lock (_sync)
            {
                int id = _nextId++;
                patient.SetId(id);

                _patients.Add(id, patient);
                return patient;
            }
        }

        public Patient GetById(int id)
        {
            lock (_sync)
            {
                if (_patients.TryGetValue(id, out var patient))
                {
                    return patient;
                }

                throw new KeyNotFoundException("Пациент не найден");
            }
        }

        public List<Patient> SearchPatients(string search)
        {
            lock (_sync)
            {
                var matches = _patients.Values
                    .Where(patient =>
                    patient.Name.Contains(search, StringComparison.OrdinalIgnoreCase)
                    ||
                    patient.SeName.Contains(search, StringComparison.OrdinalIgnoreCase))
                .ToList();

                return matches;
            }
        }
    }
}

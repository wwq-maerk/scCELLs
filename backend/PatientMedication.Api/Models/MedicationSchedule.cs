namespace PatientMedication.Api.Models;

public class MedicationSchedule
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public string DrugName { get; set; } = string.Empty;
    public string Dosage { get; set; } = string.Empty;
    public string Schedule { get; set; } = string.Empty;
    public string? Notes { get; set; }
    public DateTime? NextDoseTime { get; set; }

    public Patient? Patient { get; set; }
}

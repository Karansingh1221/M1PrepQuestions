using System;
using System.Collections.Generic;
using System.Linq;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Condition { get; set; }

    public Patient(int id, string name, int age, string condition)
    {
        Id = id;
        Name = name;
        Age = age;
        Condition = condition;
    }
}

public class HospitalManager
{
    private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
    private Queue<Patient> _appointmentQueue = new Queue<Patient>();

    // Register patient
    public void RegisterPatient(int id, string name, int age, string condition)
    {
        if (!_patients.ContainsKey(id))
        {
            Patient p = new Patient(id, name, age, condition);
            _patients.Add(id, p);
            Console.WriteLine($"Patient {name} registered successfully.");
        }
        else
        {
            Console.WriteLine("Patient already exists!");
        }
    }

    // Schedule appointment
    public void ScheduleAppointment(int patientId)
    {
        if (_patients.ContainsKey(patientId))
        {
            _appointmentQueue.Enqueue(_patients[patientId]);
            Console.WriteLine($"Appointment scheduled for {_patients[patientId].Name}");
        }
        else
        {
            Console.WriteLine("Patient not found!");
        }
    }

    // Process next appointment
    public Patient ProcessNextAppointment()
    {
        if (_appointmentQueue.Count > 0)
        {
            Patient nextPatient = _appointmentQueue.Dequeue();
            Console.WriteLine($"Processing appointment for {nextPatient.Name}");
            return nextPatient;
        }

        Console.WriteLine("No appointments in queue.");
        return null;
    }

    // Find patients by condition
    public List<Patient> FindPatientsByCondition(string condition)
    {
        return _patients.Values
                        .Where(p => p.Condition.Equals(condition, StringComparison.OrdinalIgnoreCase))
                        .ToList();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        HospitalManager hospital = new HospitalManager();

        // Register patients
        hospital.RegisterPatient(1, "Amit", 30, "Fever");
        hospital.RegisterPatient(2, "Priya", 25, "Cold");
        hospital.RegisterPatient(3, "Rahul", 40, "Fever");

        Console.WriteLine();

        // Schedule appointments
        hospital.ScheduleAppointment(1);
        hospital.ScheduleAppointment(3);

        Console.WriteLine();

        // Process appointments
        hospital.ProcessNextAppointment();
        hospital.ProcessNextAppointment();
        hospital.ProcessNextAppointment(); // No appointment case

        Console.WriteLine();

        // Find patients by condition
        var feverPatients = hospital.FindPatientsByCondition("Fever");

        Console.WriteLine("Patients with Fever:");
        foreach (var patient in feverPatients)
        {
            Console.WriteLine($"{patient.Name} - Age {patient.Age}");
        }
    }
}

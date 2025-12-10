using System.Collections.Generic;
using Eksamensplaner.Models;

namespace Eksamensplaner.Data;

public static class EksamenRepository
{
    private static List<Eksamen> _eksamener = new List<Eksamen>();

    public static void Add(Eksamen eksamen)
    {
        _eksamener.Add(eksamen);
    }

    public static List<Eksamen> GetForLaerer(string holdId)
    {
        List<Eksamen> result = new List<Eksamen>();
        int i;

        for (i = 0; i < _eksamener.Count; i++)
        {
            Eksamen eksamen = _eksamener[i];

            if (eksamen.MaalGruppe == "Underviser" &&
                (string.IsNullOrEmpty(holdId) || eksamen.HoldId == holdId))
            {
                result.Add(eksamen);
            }
        }
        return result;
    }

    public static List<Eksamen> GetForStuderende(string holdId)
    {
        List<Eksamen> result = new List<Eksamen>();
        int i;

        for (i = 0; i < _eksamener.Count; i++)
        {
            Eksamen eksamen = _eksamener[i];

            if (eksamen.MaalGruppe == "Studerende" && 
                (string.IsNullOrEmpty(holdId) || eksamen.HoldId == holdId))
            {
                result.Add(eksamen);
            }
        }

        return result;
    }
}


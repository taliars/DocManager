using System;

namespace DocManager.Services.Contract.Interfaces
{
    interface IUserClaimService
    {
        bool CheckUser(int practiceId, int patientId);

        bool CheckPracticeId(int practiceId);

        PracticePatientPair[] GetPracticePatientClaims();

        Guid? GetUserId();
    }
}

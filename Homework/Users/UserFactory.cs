
namespace Users
{
    public static class UserFactory
    {   
        public static Candidate GiveCandidateObject()
        {
            // Returns the first generated object.
            var result = RandomInstancesGenerator.RandomInstanceGenerator().Item1[0];
            return result;
        }
        
        public static Employee GiveEmployeeObject()
        {
            // Returns the first generated object.
            var result = RandomInstancesGenerator.RandomInstanceGenerator().Item2[0];
            return result;
        }
    }
}

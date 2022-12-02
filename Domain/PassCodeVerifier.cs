namespace ClimateControlSystem.Domain
{
    public class PassCodeVerifier
    {
        public void Verify(byte[] hashBytes, string _passCode)
        {
            PasswordHash hash = new PasswordHash(hashBytes);
            if (!hash.Verify(_passCode))
                throw new System.UnauthorizedAccessException("Wrong passcode!");
        }
    }
}
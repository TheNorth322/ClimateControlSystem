using System;

namespace ClimateControlSystem.Domain
{
    public class PassCodeVerifier
    {
        public void Verify(byte[] hashBytes, string _passCode)
        {
            var hash = new PasswordHash(hashBytes);
            if (!hash.Verify(_passCode))
                throw new UnauthorizedAccessException("Wrong passcode!");
        }
    }
}
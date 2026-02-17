using System;
using Exceptions;

namespace Domain
{
    public class Medicine : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int ExpiryYear { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Id))
                throw new ScenarioException("Invalid Id");

            if (Price <= 0)
                throw new ScenarioException("Invalid Price");

            if (ExpiryYear < DateTime.Now.Year)
                throw new ScenarioException("Invalid Expiry Year");
        }
    }
}

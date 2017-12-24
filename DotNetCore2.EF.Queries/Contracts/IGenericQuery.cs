using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.EF.Queries.Contracts
{
    public interface IGenericQuery<TMdl>
    {
        IEnumerator<TMdl> GetEnumerator();
    }
}

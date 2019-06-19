using Service.Bo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ISecurityService
    {

        Task<AuthResponseBo> authentication(LoginBo loginBo);



    }
}

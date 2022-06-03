using andresflorez.hotel.service.Wrapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace andresflorez.hotel.api.Controllers
{
    public abstract class BaseControllerApi : ControllerBase
    {
        protected IWrapperRepository repositorio;
        public BaseControllerApi(IWrapperRepository wrapperRepository) 
            => repositorio = wrapperRepository;
    }
}

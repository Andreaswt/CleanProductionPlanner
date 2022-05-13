using AutoMapper;
using Clean.ProductionPlanner.MVC.Contracts;
using Clean.ProductionPlanner.MVC.Models;
using Clean.ProductionPlanner.MVC.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.ProductionPlanner.MVC.Contracts;
using Clean.ProductionPlanner.MVC.Services.Base;

namespace Clean.ProductionPlanner.MVC.Services
{
    public class DayService : BaseHttpService, IDayService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;

        public DayService(IMapper mapper, IClient httpclient, ILocalStorageService localStorageService) : base(httpclient, localStorageService)
        {
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            this._httpclient = httpclient;
        }
        
        public async Task<DayVM> GetDay(int id)
        {
            AddBearerToken();
            var project = await _client.DaysAsync(id);
            return _mapper.Map<DayVM>(project);
        }

        public async Task<List<DayVM>> GetDays()
        {
            AddBearerToken();
            var days = await _client.DaysAllAsync();
            return _mapper.Map<List<DayVM>>(days);
        }
    }
}

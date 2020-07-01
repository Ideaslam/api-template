using Data;
using Data.UnitOfWork;
using Domain.Entity.Common;
using Model.DTOs;
using Model.SearchCriteria;
using Model.SearchResult;
using Model.Support;
using Orchestrator.Common.Contract;
using Repository.Common.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orchestrator.Common
{
     
    public  class CityOrchestrator: ICityOrchestrator
    {

        private readonly IUnitOfWork<ApplicationDbContext> unitOfWork;
        private readonly ICityRepository   cityRepository;
        public CityOrchestrator(
            IUnitOfWork<ApplicationDbContext> _unitOfWork,
            ICityRepository  _cityRepository)
        {
            unitOfWork = _unitOfWork;
            cityRepository = _cityRepository;
        }


        public CitySearchResult Get (CitySearchCriteria  citySearchCriteria)
        {
            var res = new CitySearchResult();
            try
            { 
                res.cityDTOs = cityRepository.GetAsQueryable(citySearchCriteria)
                    .Select(city => new CityDTO
                    {
                        Id = city.Id,
                        Name = city.Name
                    }).ToList();

                res.TotalCount = res.cityDTOs.Count;
                

               
            }
            catch (Exception ex )
            {
                res.Exception = ex;
                res.Message = "Error";
            }
            return res;

        }


        public ExecutionResponse<CityDTO> Create(City city)
        {
            var res = new ExecutionResponse<CityDTO>();
            try
            {
                unitOfWork.CreateTransaction();
                var cityRes = cityRepository.Insert(city);
                var cityDto = new CityDTO()
                {
                    Id = cityRes.Id,
                    Name = cityRes.Name
                }; 
                unitOfWork.Save();
                unitOfWork.Commit();


                res.Result = cityDto;
                return res;
            }
            catch (Exception ex)
            {

                res.Exception = ex; 
                unitOfWork.Rollback();
                return res;
            }

        }



        public ExecutionResponse<CityDTO> Update(City city)
        {
            var res = new ExecutionResponse<CityDTO>();
            try
            {
                unitOfWork.CreateTransaction();
                var cityRes = cityRepository.Update(city);
                var cityDto = new CityDTO()
                {
                    Id = cityRes.Id,
                    Name = cityRes.Name
                };
                unitOfWork.Save();
                unitOfWork.Commit();


                res.Result = cityDto;
                return res;
            }
            catch (Exception ex)
            {

                res.Exception = ex;
                unitOfWork.Rollback();
                return res;
            }

        }




        public ExecutionResponse<bool> Delete(int id)
        {
            var res = new ExecutionResponse<bool>();
            try
            {
                unitOfWork.CreateTransaction();
                var city = cityRepository.GetByID(id);
                cityRepository.Delete(city);
                unitOfWork.Save();
                unitOfWork.Commit();


                res.Result = true;
                return res;
            }
            catch(Exception ex )
            {
              
                unitOfWork.Rollback();
                res.Exception = ex;
                res.Result = false;
                return res;
            }
            
        }



    }
}

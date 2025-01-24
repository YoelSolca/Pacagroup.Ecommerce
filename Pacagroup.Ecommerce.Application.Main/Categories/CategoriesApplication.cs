using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.UseCases.Categories
{
    public class CategoriesApplication : ICategoriesApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;


        public CategoriesApplication(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache distributedCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }


        public async Task<Response<IEnumerable<CategoryDto>>> GetAll()
        {
            var response = new Response<IEnumerable<CategoryDto>>();
            var cacheKey = "categoriesList";

            try
            {
                var redisCategories = await _distributedCache.GetAsync(cacheKey);

                if (redisCategories != null)
                {
                    response.Data = JsonSerializer.Deserialize<IEnumerable<CategoryDto>>(redisCategories);
                }
                else
                {
                    var categories = await _unitOfWork.Categories.GetAll();
                    response.Data = _mapper.Map<IEnumerable<CategoryDto>>(categories);

                    if (response.Data != null)
                    {
                        var serializedCategories = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response.Data));
                        var options = new DistributedCacheEntryOptions()
                                     .SetAbsoluteExpiration(DateTime.Now.AddHours(8))
                                     .SetSlidingExpiration(TimeSpan.FromMinutes(60));


                        await _distributedCache.SetAsync(cacheKey, serializedCategories, options);
                    }
                }


                if (response != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}

﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Otiva.AppServeces.IRepository;
using Otiva.Contracts.AdDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.AppServeces.Service.Ad
{
    public class AdService : IAdService
    {
        public readonly IAdRepository _adRepository;
        public readonly IMapper _mapper;
        public AdService(IAdRepository adRepository, IMapper mapper)
        {
            _adRepository = adRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAdAsync(CreateOrUpdateAdRequest createAd)
        {
            try
            {
                var newUser = _mapper.Map<Domain.Ad>(createAd);
                newUser.CreateTime = DateTime.UtcNow;
                await _adRepository.Add(newUser);

                return newUser.Id;
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingUser = await _adRepository.FindByIdAsync(id);
            if (existingUser == null)
                throw new Exception("Объявления с таким идентификатором не сущесвует");

            await _adRepository.DeleteAsync(existingUser);
        }

        public async Task<InfoAdResponse> EditAdAsync(Guid Id, CreateOrUpdateAdRequest editAd)
        {
            var existingAd = await _adRepository.FindByIdAsync(Id);
            if (existingAd == null)
                throw new Exception("Объявления с таким идентификатором не сущесвует");

            await _adRepository.EditAdAsync(_mapper.Map(editAd, existingAd));

            return _mapper.Map<InfoAdResponse>(editAd);

        }

        public async Task<IReadOnlyCollection<InfoAdResponse>> GetAllAsync(int take, int skip)
        {
            return await _adRepository.GetAll()
                 .Select(a => new InfoAdResponse
                 {
                     Id = a.Id,
                     Name = a.Name,
                     Description = a.Description,
                     SubcategoryId = a.SubcategoryId,
                     CreateTime = a.CreateTime,
                 }).OrderBy(d=>d.CreateTime).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<IReadOnlyCollection<InfoAdResponse>> GetByFilterAsync(SearchFilterAd search)
        {
            var query = _adRepository.GetAll();

            if (search == null)
                throw new Exception("Не задан фильтр");

            if (!string.IsNullOrEmpty(search.Name))
                query = query.Where(p => p.Name.ToLower().Contains(search.Name.ToLower()));

            if (search.SubcategoryId.HasValue)
                query = query.Where(c => c.SubcategoryId == search.SubcategoryId);

            if(search.UserId.HasValue)
                query = query.Where(c => c.UserId == search.UserId);

            if (search.PriceFrom != null)
                query = query.Where(c => c.Price >= search.PriceFrom);

            if (search.PriceTo != null)
                query = query.Where(c => c.Price <= search.PriceTo);

            return await query.Select(p => new InfoAdResponse
            {
                Id = p.Id,
                Name = p.Name,
                UserId = p.UserId,
                SubcategoryId = p.SubcategoryId,
                Description = p.Description,
                Region = p.Region,
                Price = p.Price,
                CreateTime = p.CreateTime
            }).OrderBy(x => x.CreateTime).Skip(search.skip).Take(search.take).ToListAsync();
        }


        public async  Task<InfoAdResponse> GetByIdAsync(Guid id)
        {
            var exitAd = await _adRepository.FindByIdAsync(id);
            if (exitAd == null)
                throw new Exception("Объявления с таким идентификатором не сущесвует");
            return _mapper.Map<InfoAdResponse>(exitAd);
        }
    }
}

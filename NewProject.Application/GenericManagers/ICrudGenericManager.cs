﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VendorView.Shared;

namespace VendorView.Application;

public interface ICrudGenericManager <TKey, Entity, ReadDto, WriteDto> 
    where ReadDto : class
    where WriteDto : class 
    where Entity : class
{
    public Task<IEnumerable<ReadDto>> GetAll(Expression<Func<Entity, bool>> expression, int? take, int? skip,
        Expression<Func<Entity, object>> orderBy,
        string orderDirection = Constanties.ORDERASC , params string[] includes);
    public Task<IEnumerable<ReadDto>> GetAll(Expression<Func<Entity, bool>> expression, params string[]? includes);
    public ReadDto GetBy(Expression<Func<Entity, bool>> expression);
    public ReadDto GetBy(Expression<Func<Entity, bool>> expression, params string[]? includes);
    public Task<ReadDto> GetById(TKey Id);
    public Task<WriteDto> GetWrite(Expression<Func<Entity, bool>> expression, params string[]? includes);
    public Task<Entity> GetModelById(TKey Id);
    public Task<ReadDto> AddAsync(WriteDto dto);
    public ReadDto Add(WriteDto dto);
    public Task<ReadDto> Update(WriteDto dto);
    public Task<ReadDto> UpdateById(TKey Id,WriteDto dto);
    
    public Task<bool> Remove(TKey id);
    Task<bool> IsExistedAsync(Expression<Func<Entity, bool>> expression);
    bool IsExisted(Expression<Func<Entity, bool>> expression);
    int Count(Expression<Func<Entity, bool>> expression);

}

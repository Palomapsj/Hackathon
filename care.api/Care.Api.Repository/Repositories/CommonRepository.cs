using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Models.Interfaces;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ValidationResult = Care.Api.Repository.Validation.ValidationResult;

namespace Care.Api.Repository.Repositories;

public class CommonRepository<T> : ICommonRepository<T> where T : class, new()
{
    protected CareDbContext _careDbContext;

    private readonly ValidationResult _validationResult;

    private const string AdminId = "6B93EA3E-0AC5-4B4D-8E88-06A77736C785";

    public CommonRepository(CareDbContext careDbContext)
    {
        _careDbContext = careDbContext;
        _validationResult = new ValidationResult();
    }

    public void Delete(T data)
    {
        try
        {
            _careDbContext.Set<T>().Remove(data);
            _careDbContext.SaveChanges();
        }
        catch (Exception ex)
        {

        }
    }

    public List<T>? GetAll()
    {
        try
        {
            return _careDbContext.Set<T>().ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}. Trace: {ex.StackTrace}");
            return null;
        }
    }

    public List<T>? Find(Expression<Func<T, bool>> predicate)
    {
        try
        {
            return _careDbContext.Set<T>().Where(predicate).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}. Trace: {ex.StackTrace}");
            return null;
        }
    }

    public T GetValue(Expression<Func<T, bool>> predicate) //where T : class
    {
        try
        {
            return _careDbContext.Set<T>().FirstOrDefault(predicate);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}. Trace: {ex.StackTrace}");
        }
        return new T();
    }

    public List<T> GetValues(Expression<Func<T, bool>> predicate) //where T : class
    {
        try
        {
            var teste = _careDbContext.Set<T>().Where(predicate).ToList();
            return teste;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}. Trace: {ex.StackTrace}");
        }
        return new List<T>();
    }

    public List<T> GetValuesByPagination(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> predicateOrderBy, int currentPage, int pageSize, bool orderAsc = true)
    {
        try
        {
            List<T> result = new List<T>();

            if (currentPage == 1)
            {
                if (orderAsc)
                    result = _careDbContext.Set<T>().Where(predicate).OrderBy(predicateOrderBy).Take(pageSize).ToList();
                else
                    result = _careDbContext.Set<T>().Where(predicate).OrderByDescending(predicateOrderBy).Take(pageSize).ToList();
            }

            if (currentPage > 1)
            {
                currentPage = (pageSize * (currentPage - 1));

                if (orderAsc)
                    result = _careDbContext.Set<T>().Where(predicate).OrderBy(predicateOrderBy).Skip(currentPage).Take(pageSize).ToList();
                else
                    result = _careDbContext.Set<T>().Where(predicate).OrderByDescending(predicateOrderBy).Skip(currentPage).Take(pageSize).ToList();
            }

            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}. Trace: {ex.StackTrace}");
        }
        return new List<T>();
    }

    public T GetById(Guid Id)
    {
        return _careDbContext.Set<T>().Find(Id);
    }

    private async Task<T?> GetByIdAsync(Guid id)
    {
        return await _careDbContext.Set<T>().FindAsync(id);
    }

    public ValidationResult Insert(T data)
    {
        try
        {
            if (data is BaseEntity && data is not null)
            {

                _validationResult.Id = (data as BaseEntity).Id;

                if ((data as BaseEntity).CreatedBy is null)
                {
                    (data as BaseEntity).CreatedBy = Guid.Parse("6B93EA3E-0AC5-4B4D-8E88-06A77736C785");
                    (data as BaseEntity).CreatedByName = "Admin";
                }
                if ((data as BaseEntity).ModifiedBy is null)
                {
                    (data as BaseEntity).ModifiedBy = Guid.Parse("6B93EA3E-0AC5-4B4D-8E88-06A77736C785");
                    (data as BaseEntity).ModifiedByName = "Admin";
                }
                if ((data as BaseEntity).OwnerId is null)
                {
                    (data as BaseEntity).OwnerId = Guid.Parse("6B93EA3E-0AC5-4B4D-8E88-06A77736C785");
                    (data as BaseEntity).OwnerIdName = "Admin";
                }


                (data as BaseEntity).CreatedOn = DateTime.Now;
                (data as BaseEntity).ModifiedOn = (data as BaseEntity).CreatedOn;
                (data as BaseEntity).StateCode = true;
                (data as BaseEntity).IsDeleted = false;

                if (!(data as BaseEntity).StatusCodeStringMapId.HasValue)
                    (data as BaseEntity).StatusCodeStringMapId = GetStatusCode(data.GetType().Name, "#ACTV");

                //SetUser(ref data, EntityState.Added);
            }

            AuditRepository auditRepository = new AuditRepository(_careDbContext._configuration);
            auditRepository.SaveAudit(data, Microsoft.EntityFrameworkCore.EntityState.Added);
            if (data is User)
                _careDbContext.Entry<AccessProfile>((data as User).AccessProfiles.FirstOrDefault()).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;

            if (data is Doctor)
            {
                var medicalSpecialties = (data as Doctor).MedicalSpecialties;

                foreach (var medicalSpecialty in medicalSpecialties)
                {
                    _careDbContext.Attach(medicalSpecialty).State = EntityState.Unchanged;
                }
            }

            _careDbContext.Set<T>().Add(data);
            _careDbContext.SaveChanges();

            return _validationResult;
        }
        catch (Exception ex)
        {
            _validationResult.Add(ex.Message);
            return _validationResult;
        }
    }

    public virtual T Update(T data)
    {
        try
        {
            var id = _careDbContext.ContextId;
            if (data is BaseEntity && data is not null)
            {
                (data as BaseEntity).ModifiedOn = DateTime.Now;

                var entityId = (data as BaseEntity).Id;
                var entityInDatabase = GetById(entityId);

                // Check if the entity is already being tracked
                var entry = _careDbContext.ChangeTracker.Entries().FirstOrDefault(e => e.Entity == entityInDatabase);

                if (entry != null)
                {
                    // If the entity is being tracked, detach it
                    entry.State = EntityState.Detached;
                }
                else
                {
                    foreach (var e in _careDbContext.ChangeTracker.Entries())
                    {
                        e.State = EntityState.Detached;
                    }
                }

                SetOriginalValues(ref data, entityInDatabase);

                // SetUser(ref data, EntityState.Modified);
            }

            AuditRepository auditRepository = new AuditRepository(_careDbContext._configuration);
            auditRepository.SaveAudit(data, EntityState.Modified);

            _careDbContext.Entry(data).State = EntityState.Modified;
            _careDbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return data;
    }

    private Guid GetStatusCode(string entityName, string flag)
    {
        var stringMap = _careDbContext.StringMaps.Where(_ => _.Flag == flag
                                                            && _.AttributeMetadataIdName == "STATUSCODESTRINGMAP"
                                                            && _.EntityMetadataIdName == entityName).FirstOrDefault();
        return stringMap.StringMapId;
    }

    public void SetOriginalValues(ref T entity, object obj)
    {
        var dataBaseEntity = (entity as BaseEntity);

        dataBaseEntity.EntityOriginalValues = Helpers.Helpers.AuditJsonSerializer(obj);
    }

    public void SetUser(ref T entity, EntityState entityState)
    {
        var currentUser = _careDbContext.Users.FirstOrDefault();
        if (entity is BaseEntity)
        {
            var currentUserId = (entity as BaseEntity).CurrentUserId;
            if (currentUserId != null)
            {
                currentUser = _careDbContext.Set<User>().Find(currentUserId.Value);
                // currentUser.AccessProfiles = coreDapper.GetAccessProfileForUser<AccessProfile>(currentUser.Id);
            }
        }

        string name = currentUser.Name;
        if (name.Length > 49)
            name = name.Substring(0, 49);

        if (entity is IBaseEntity && currentUser is not null)
        {
            var dataBaseEntity = (entity as IBaseEntity);
            if (entityState == EntityState.Added)
            {
                dataBaseEntity.OwnerId = currentUser.Id;
                dataBaseEntity.CreatedBy = currentUser.Id;
                dataBaseEntity.ModifiedBy = currentUser.Id;

                dataBaseEntity.OwnerIdName = name;
                dataBaseEntity.CreatedByName = name;
                dataBaseEntity.ModifiedByName = name;

            }

            if (entityState == EntityState.Modified && dataBaseEntity.IsDeleted == false)
            {
                dataBaseEntity.ModifiedBy = currentUser.Id;
                dataBaseEntity.ModifiedByName = name;
            }
        }

    }

    public async Task<T?> GetValueAsync(Expression<Func<T, bool>> predicate)
    {
        return await _careDbContext.Set<T>().FirstOrDefaultAsync(predicate);
    }

    public async Task<ValidationResult> InsertAsync(T data)
    {
        try
        {
            if (data is not BaseEntity || data is null)
            {
                throw new Exception("Entidade não é válida...");
            }

            var dataBaseEntity = data as BaseEntity;

            _validationResult.Id = dataBaseEntity.Id;

            if (dataBaseEntity.CreatedBy is null)
            {
                dataBaseEntity.CreatedBy = Guid.Parse("6B93EA3E-0AC5-4B4D-8E88-06A77736C785");
                dataBaseEntity.CreatedByName = "Admin";
            }
            if (dataBaseEntity.ModifiedBy is null)
            {
                dataBaseEntity.ModifiedBy = Guid.Parse("6B93EA3E-0AC5-4B4D-8E88-06A77736C785");
                dataBaseEntity.ModifiedByName = "Admin";
            }
            if (dataBaseEntity.OwnerId is null)
            {
                dataBaseEntity.OwnerId = Guid.Parse("6B93EA3E-0AC5-4B4D-8E88-06A77736C785");
                dataBaseEntity.OwnerIdName = "Admin";
            }

            dataBaseEntity.CreatedOn = DateTime.Now;
            dataBaseEntity.ModifiedOn = dataBaseEntity.CreatedOn;
            dataBaseEntity.StateCode = true;
            dataBaseEntity.IsDeleted = false;

            if (!dataBaseEntity.StatusCodeStringMapId.HasValue)
                dataBaseEntity.StatusCodeStringMapId = GetStatusCode(data.GetType().Name, "#ACTV");


            var auditRepository = new AuditRepository(_careDbContext._configuration);
            auditRepository.SaveAudit(data, EntityState.Added);

            if (data is User)
                _careDbContext.Entry<AccessProfile>((data as User).AccessProfiles.FirstOrDefault()).State = EntityState.Unchanged;

            _careDbContext.Set<T>().Add(data);
            await _careDbContext.SaveChangesAsync();

            return _validationResult;
        }
        catch (Exception ex)
        {
            _validationResult.Message = ex.Message;

            return _validationResult;
        }
    }

    public async Task<ValidationResult> UpdateAsync(T data)
    {
        var validationResult = new ValidationResult();

        try
        {
            if (data is not BaseEntity || data is null)
            {
                throw new Exception("A entidade não é válida...");
            }

            var entity = (data as BaseEntity) ?? throw new Exception("A entidade está vazia...");

            if (entity.ModifiedBy is null)
            {
                entity.ModifiedBy = Guid.Parse(AdminId);
                entity.ModifiedByName = "Admin";
            }

            var originalEntity = await GetValueAsync(x => (x as BaseEntity).Id == entity.Id);

            entity.ModifiedOn = DateTime.Now;
            entity.EntityOriginalValues = Helpers.Helpers.AuditJsonSerializer(originalEntity);

            var auditRepository = new AuditRepository(_careDbContext._configuration);
            auditRepository.SaveAudit(entity, EntityState.Modified);

            _careDbContext.Entry(data).State = EntityState.Modified;
            await _careDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            validationResult.Message = ex.Message;
        }

        return validationResult;
    }
}

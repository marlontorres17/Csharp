
using Entity.Model.Contexts;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DTO;
using Data.Implements;
using Data.Dto;

namespace Data.Implementations
{
    public class PersonData : IPersonData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public PersonData(ApplicationDbContexts context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.Deleted_at = DateTime.Now; 
            context.person.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
               Id,
                CONCAT(Primer_nombre, ' - ', Segundo_nombre) AS TextoMostrar
            FROM 
                [person]
            WHERE deleted_at IS NULL AND estado = 1
            ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<PersonDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                Primer_nombre,
                Segundo_nombre,
                Primer_aPellido,
                Segundo_apellido,
                Email,
                Fecha_nacimiento,
                Genero,
                Direccion,
                Tipo_documento,
                Documento,
                State
            FROM [person]
            WHERE Deleted_at IS NULL
            ORDER BY Id ASC";

            return await context.QueryAsync<PersonDto>(sql);
        }

        public async Task<Person> GetById(int id)
        {
            var sql = @"SELECT * FROM [person] WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Person>(sql, new { Id = id });
        }


        public async Task<Person> Save(Person entity)
        {
            if (entity.Created_at == default)
            {
                entity.Created_at = DateTime.Now;
            }

            entity.Deleted_at = null;
            entity.Updated_at = null; 

            context.person.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Person entity)
        {
            entity.Updated_at = DateTime.Now;

            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

     

        public Task<Person> GetByFirst_name(string first_name)
        {
            throw new NotImplementedException();
        }

        public Task<PagedListDto<PersonDto>> GetDataTable(QueryFilterDto filter)
        {
            throw new NotImplementedException();
        }
    }
}

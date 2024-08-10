﻿using Bunnisses.Security.Interface;
using Data.DTO;
using Data.Implementations;
using Data.Interfaces;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Implements
{
    public class Role_ViewBusiness : IRole_ViewBusiness
    {
        private readonly IRole_ViewData data;

        public Role_ViewBusiness(IRole_ViewData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<IEnumerable<Rol_ViewDto>> GetAll()
        {
            return await this.data.GetAll();
        }


        public async Task<Rol_ViewDto> GetById(int id)
        {
            Role_View rolView = await this.data.GetById(id);
            Rol_ViewDto rolViewDto = new Rol_ViewDto();

            {
                rolViewDto.Id = rolView.Id;
                rolViewDto.RoleId = rolView.RoleId;
                rolViewDto.ViewId = rolView.ViewId;
                rolViewDto.role = rolView.role;
                rolViewDto.view = rolView.view;
                rolViewDto.State = rolView.State;

                return rolViewDto;
            }

        }

        public async Task<Role_View> Save(Rol_ViewDto entity)
        {
            Role_View rolView = new Role_View();
            rolView = this.mapearDatos(rolView, entity);

            return await data.Save(rolView);
        }

        

        public async Task Update(int Id, Rol_ViewDto entity)
        {
            Role_View rolVista = await this.data.GetById(Id);
            if (rolVista == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            rolVista = this.mapearDatos(rolVista, entity);

            await this.data.Update(rolVista);
        }


        private Role_View mapearDatos(Role_View rolView, Rol_ViewDto entity)
        {
            rolView.Id = entity.Id;
            rolView.RoleId = entity.RoleId;
            rolView.ViewId = entity.ViewId;
            rolView.role = entity.role;
            rolView.view = entity.view;
            rolView.State = entity.State;

            return rolView;
        }

     
    }
}

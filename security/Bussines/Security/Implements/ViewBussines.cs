﻿using Bunnisses.Security.Interface;
using Data.Dto;
using Data.DTO;
using Data.Implementations;
using Data.Interfaces;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Bunnisses.Security.Implements
{
    public class ViewBusiness : IViewBusiness
    {
        private readonly IViewData data;

        public ViewBusiness(IViewData data)
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

        public async Task<IEnumerable<ViewDto>> GetAll()
        {
            return await this.data.GetAll();
        }

        public async Task<ViewDto> GetById(int id)
        {
            View view = await this.data.GetById(id);
            ViewDto ViewDto = new ViewDto();

            {
                ViewDto.Id = view.Id;
                ViewDto.Nombre = view.Nombre;
                ViewDto.descripcion = view.descripcion;
                ViewDto.ruta = view.ruta;
                ViewDto.ModuleId = view.ModuleId;
                ViewDto.module = view.module;
                ViewDto.State = view.State;

                return ViewDto;
            };


        }

        public async Task<View> Save(ViewDto entity)
        {
            View view = new View();
            view = this.mapearDatos(view, entity);

            return await data.Save(view);
        }

        public async Task Update(int Id, ViewDto entity)
        {
            View view = await this.data.GetById(Id);
            if (view == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            view = this.mapearDatos(view, entity);

            await this.data.Update(view);
        }

        private View mapearDatos(View view, ViewDto entity)
        {
            view.Id = view.Id;
            view.Nombre = view.Nombre;
            view.descripcion = view.descripcion;
            view.ruta = view.ruta;
            view.ModuleId = view.ModuleId;
            view.module = view.module;
            view.State = view.State;

            return view;
        }
        public async Task<ViewDto> GetByNombre(string nombre)
        {
            var view = await this.data.GetByName(nombre);
            if (view == null)
            {
                return null;
            }

            var viewDto = new ViewDto
            {
                Id = view.Id,
                Nombre = view.Nombre,
                descripcion = view.descripcion,
                ruta = view.ruta,
                ModuleId = view.ModuleId,
                module = view.module,
                State = view.State
            };

            return viewDto;

        }
    }
}

using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.Fornecedor;
using Domain.Entities;
using Domain.Entities.FornecedorEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureMapping : Profile
    {
        public static MapperConfiguration Configure()
        {
            return new MapperConfiguration(cfg => {
                ProdutoResponseDtoMap(cfg);
                FornecedorDtoMap(cfg);                
            });
        }

        private static void FornecedorDtoMap(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Fornecedor, FornecedorDto>()
                .ForMember(dto => dto.Id, m => m.MapFrom(entity => entity.Id))
                .ForMember(dto => dto.Descricao, m => m.MapFrom(entity => entity.Descricao))
                .ForMember(dto => dto.CNPJ, m => m.MapFrom(entity => entity.CNPJ));
        }                

        private static void ProdutoResponseDtoMap(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Produto, ProdutoResponseDto>()
                .ForMember(dto => dto.Id, m => m.MapFrom(entity => entity.Id))
                .ForMember(dto => dto.Descricao, m => m.MapFrom(entity => entity.Descricao))
                .ForMember(dto => dto.Situacao, m => m.MapFrom(entity => entity.Situacao))
                .ForMember(dto => dto.DataFabricacao, m => m.MapFrom(entity => entity.DataFabricacao))
                .ForMember(dto => dto.DataValidade, m => m.MapFrom(entity => entity.DataValidade))
                .ForMember(dto => dto.Fornecedor, m => m.MapFrom(entity => entity.Fornecedor));
        }
    }
}

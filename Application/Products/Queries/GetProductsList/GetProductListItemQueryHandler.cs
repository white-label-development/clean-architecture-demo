﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Core.Queries;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Products.Queries.GetProductsList
{
    public class GetProductListItemQueryHandler 
        : IQueryHandler<GetProductsListQuery, List<ProductListItemDto>>
    {
        private readonly IDatabaseContext _database;

        public GetProductListItemQueryHandler(IDatabaseContext database)
        {
            _database = database;
        }

        public List<ProductListItemDto> Execute(GetProductsListQuery query)
        {
            var products = _database.Products
                .Select(p => new ProductListItemDto
                {
                    Id = p.Id, 
                    Name = p.Name
                });

            return products.ToList();
        }
    }
}